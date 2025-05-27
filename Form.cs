using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidEdgeCommunity;
using SolidEdgeFramework;
using SolidEdgeGeometry;
using SolidEdgePart;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Cryptography;
using SolidEdgeCommunity.Extensions;


namespace ScriptSolidEdge
{
    public partial class Form : System.Windows.Forms.Form
    {

        // Создаем переменные для работы с Solid Edge
        SolidEdgeFramework.Application seAplication = null; // Приложение Solid Edge
        SolidEdgeFramework.Documents seDocuments = null; // Коллекция документов Solid Edge

        SolidEdgePart.SheetMetalDocument seSheetMetalDoc = null; // Документ детали из листового металла

        SolidEdgePart.FlatPatternModel flatPatternModel = null; // Модель развертк
        SolidEdgePart.FlatPatterns flatPatterns = null; // Коллекция разверток модели
        SolidEdgePart.FlatPattern flatPattern = null; // Коллекция разверток модели

        SolidEdgeGeometry.Body body = null; // Основное тело модели
        SolidEdgePart.Models models = null; // Коллекция моделей
        SolidEdgePart.Model model = null; // Одна модель
        SolidEdgeGeometry.Faces faces = null; // Коллекция граней тела
        SolidEdgeGeometry.Faces facesBend = null; // Коллекция граней тела
        SolidEdgeGeometry.Face faceFlat = null; // Грань для развёртки 
        SolidEdgeGeometry.Face bendFace = null; // Грань для изменения угла сгиба
        SolidEdgeGeometry.Face fixFace = null; // Зафиксированная грань для изменения угла сгиба
        SolidEdgeGeometry.Edges edges = null; // Коллекция ребер грани
        SolidEdgeGeometry.Edge edgeFlat = null; // Отдельное ребро
        SolidEdgeGeometry.Vertex vertex = null; // Вершина ребра

        SolidEdgePart.ChangeBendAngles changeBendAngles = null; // Коллекция операций изменения угла
        SolidEdgePart.ChangeBendAngle changeBendAngle = null; // Операция изменения угла
        List<ChangeBendAngle> changeBAngList = new List<ChangeBendAngle>(); // Список операций изменения угла для выбора 

        SolidEdgePart.BendTable bendTable = null;  // Таблица сгибов для получения информации о сгибах
        List <Faces> facesList = new List <Faces> (); // Список граней для выбора
        object str = "";  // Пустая общая переменная для метода Ststus у операций

        double bendAngle = 0;  // Текущий угол сгиба
        List<double> bendAngleList = new List<double> (); // Список углов для изменения у существующих операций (кроме операции Изменить угол)

       bool is_newDoc = true; // Флаг нового документа

//=============================================================================================================
       // Конструктор формы
        public Form()
        {
            InitializeComponent();
        }
        
        // Подключение к активному документу. 
        private void connectActiveDoc_Click(object sender, EventArgs e)
        {
            try
            {
                form_reset(); 
                OleMessageFilter.Register();
                seAplication = SolidEdgeUtils.Connect(true);
                seDocuments = seAplication.Documents;
                //Является ли полученный документ листовой деталью
                if (seDocuments != null && seAplication.ActiveDocumentType == DocumentTypeConstants.igSheetMetalDocument)
                {
                    seSheetMetalDoc = (SheetMetalDocument)seAplication.ActiveDocument;

                    // Устанавливаем имя документа
                    ActiveDocName.Text = seSheetMetalDoc.Name;
                    ActiveDocName.BackColor = System.Drawing.Color.PaleGreen;

                    // Получаем модель
                    models = seSheetMetalDoc.Models;
                    model = models.Item(1); 

                    // Заполнение/обновление всех списков
                    update_listBoxFixFaces();
                    update_listBoxAngleChanged();
                    update_listBoxFeatureName();
                    is_newDoc = false; // Меняем флаг
                }
                else
                {
                    MessageBox.Show("Ошибка! \n Активынй документ не является листовой деталью!");
                    form_reset();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к документу\nВероятно никакой документ не открыт\n" + ex.Message);
                form_reset();
            }
        }
        
        
        // Сброс формы и очистка всех списков (Приведение к начальному состоянию).
        public void form_reset()
        {
            try
            {
                button_flatten.Enabled = false;
                trackBarAngle.Enabled = false;
                listBoxAngleChanged.Items.Clear();
                listBoxEdges.Items.Clear();
                listBoxFacesFlat.Items.Clear();
                listBoxFeatureName.Items.Clear();
                listBoxFixFaces.Items.Clear();
                ActiveDocName.Text = "отсутствует";
                ActiveDocName.BackColor = System.Drawing.Color.LightCoral;
                is_newDoc = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сбросе формы \n" + ex.Message);
            }
        }


        // Обновление списка операций изменения угла
        private void update_listBoxAngleChanged()
        {
            try
            {
                changeBendAngles = model.ChangeBendAngles;

                listBoxAngleChanged.Items.Clear();
                changeBAngList.Clear();
                for (int i = 1; i <= changeBendAngles.Count; i++)
                {
                    changeBendAngle = changeBendAngles.Item(i);
                    listBoxAngleChanged.Items.Add(changeBendAngle.Name.ToString());
                    changeBAngList.Add(changeBendAngle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении списка операций изменения угла \n" + ex.Message);
            }
        }
        // Обновление списка имён операций сгиба
        private void update_listBoxFeatureName()
        {
            try
            {
                if (seSheetMetalDoc != null)
                {
                    //Получаем таблицу сгибов.
                    bendTable = seSheetMetalDoc.BendTable;
                    // Очищаем списки названия операций, списки углов.
                    listBoxFeatureName.Items.Clear();
                    facesList.Clear();
                    bendAngleList.Clear();
                    double bendRadius = 0;
                    string featureName = null;
                    BendDirectionConstants bendDirection;

                    for (int i = 1; i <= bendTable.BendCount; i++)
                    {
                        bendTable.GetBendData(i, out featureName, out bendRadius, out bendAngle, out bendDirection); // Получаем информацию о сгибе
                        listBoxFeatureName.Items.Add(featureName);                         // Добавлям в список названия операций
                        facesList.Add((Faces)bendTable.BendFaces[i]);
                        bendAngleList.Add(ToDegrees(bendAngle));
                        if (is_newDoc)
                        {
                            seAplication.ActiveSelectSet.Add(facesList[i - 1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получениии сгибов\n" + ex.Message);
            }
        }
        // Обновление списков граней, для выбора фиксированной грани при изменении угла и создании развёртки.
        private void update_listBoxFixFaces()
        {
            try
            {
                body = (SolidEdgeGeometry.Body)model.Body;
                if (body == null)
                {
                    MessageBox.Show("Ошибка! \nТело детали не обнаружено!");
                    return;
                }

                faces = (Faces)body.Faces[SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryPlane]; // Получаем список граней

                listBoxFacesFlat.Items.Clear();
                listBoxFixFaces.Items.Clear();
                for (int i = 1; i <= faces.Count; i++)
                {
                    var f = (Face)faces.Item(i);
                    listBoxFacesFlat.Items.Add($"Грань {i}");
                    listBoxFixFaces.Items.Add($"Грань {i}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения граней\n" + ex.Message);
            }
        }
       
        
        

        // Выбор одной грани из списка.
        private void listBoxFaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                button_flatten.Enabled = false;

                int selectedIndex = listBoxFacesFlat.SelectedIndex;
                if (selectedIndex >= 0 && faces != null)
                {
                    faceFlat = (Face)faces.Item(selectedIndex + 1);
                    edges = (Edges)faceFlat.Edges; // Получаем список ребер грани

                    seAplication.ActiveSelectSet.RemoveAll();
                    seAplication.ActiveSelectSet.Add(faceFlat);   // Подсветка через SelectSet

                    listBoxEdges.Items.Clear();
                    for (int i = 1; i <= edges.Count; i++)
                    {
                        var edge = (Edge)edges.Item(i);
                        listBoxEdges.Items.Add($"Ребро {i}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выборе грани \n" + ex.Message);
            }
        }
        // Выбор одного ребра из списка.
        private void listBoxEdges_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = listBoxEdges.SelectedIndex;
                if (selectedIndex >= 0 && edges != null)
                {
                    edgeFlat = (Edge)edges.Item(selectedIndex + 1);
                    // Подсветка через SelectSet
                    seAplication.ActiveSelectSet.RemoveAll();
                    seAplication.ActiveSelectSet.Add(edgeFlat);

                    button_flatten.Enabled = true;
                    vertex = (Vertex)edgeFlat.EndVertex; // Получаем конечную вершину ребра
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выборе ребра \n" + ex.Message);
            }
        }
        // Создание полной развёртки детали.
        private void button_flatten_Click(object sender, EventArgs e)
        {
            try
            {
                if (edgeFlat == null || faceFlat == null)
                {
                    MessageBox.Show("Сначала выберите грань и ребро");
                    return;
                }

                // Проверяем, есть ли в документе развертка модели
                if (seSheetMetalDoc.FlatPatternModels.Count == 0)
                {
                    // Если нет, создаем развертку модели
                    flatPatternModel = seSheetMetalDoc.FlatPatternModels.Add(seSheetMetalDoc.Models.Item(1));
                    flatPatterns = flatPatternModel.FlatPatterns; // Получаем коллекцию разверток
                }
                else
                {
                    // Если есть, используем существующую
                    flatPatternModel = (FlatPatternModel)seSheetMetalDoc.FlatPatternModels.Item(1);
                    flatPatterns = flatPatternModel.FlatPatterns; // Получаем коллекцию разверток
                }
                // Добавляем новую развертку с указанием базовых элементов
                flatPattern = flatPatterns.Add(
                    ReferenceEdge: edgeFlat, // Опорное ребро
                    ReferenceFace: faceFlat, // Опорная грань
                    ReferenceVertex: vertex, // Опорная вершина
                    ModelType: SolidEdgeConstants.FlattenPatternModelTypeConstants.igFlattenPatternModelTypeFlattenAnything // Тип развертки
                );
                if (flatPattern.Status[out str] == FeatureStatusConstants.igFeatureFailed)
                {
                    flatPattern.Delete();
                    MessageBox.Show("Операция не выполнена! \nВыбирете другое ребро или грань");
                }
                else
                {
                    update_listBoxFixFaces();
                    update_listBoxFeatureName();
                    update_listBoxAngleChanged();
                    seAplication.ActiveSelectSet.RemoveAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при развёртке\n" + ex.Message);
            }
        }
        
        
        
        
        // Выбор нужной операции сгиба для изменения угла сгиба.
        private void listBoxFeatureName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bendFace = null;

                int selectedIndex = listBoxFeatureName.SelectedIndex;
                if (selectedIndex >= 0 && facesList != null)
                {
                    facesBend = (Faces)facesList[selectedIndex];
                    bendFace = (Face)facesBend.Item(1);
                    seAplication.ActiveSelectSet.RemoveAll();
                    seAplication.ActiveSelectSet.Add(bendFace);

                    textBoxNewAngle.Enabled = true;

                    textBoxAngle.Clear();
                    textBoxAngle.Text = (180 - bendAngleList[selectedIndex]).ToString("F1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выборе сгиба\n" + ex.Message);
            }
        }
        // Выбор фиксированной грани для при изменении угла.
        private void listBoxFixFaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = listBoxFixFaces.SelectedIndex;
                if (selectedIndex >= 0 && faces != null)
                {
                    fixFace = (Face)faces.Item(selectedIndex + 1);
                    seAplication.ActiveSelectSet.RemoveAll();
                    seAplication.ActiveSelectSet.Add(fixFace);   // Подсветка через SelectSet
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выборе грани для сгиба \n" + ex.Message);
            }
        }
        // Подтверждение введённого угла нажатием Enter (Применении изменений).
        private void textBoxNewAngle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (double.TryParse(textBoxNewAngle.Text, out double angle))
                    {

                        changeBendAngles = model.ChangeBendAngles;
                        if ((bendFace != null) || (fixFace != null))
                        {
                            changeBendAngle = changeBendAngles.Add(BendFace: bendFace, RefFace: fixFace, dAngle: ToRadians(angle));
                            if (changeBendAngle == null)
                            {
                                MessageBox.Show("Вероятно операция изменения угла для этого сгиба уже существует, используйте её!");
                            }
                            else if (changeBendAngle.Status[out str] == FeatureStatusConstants.igFeatureFailed)
                            {
                                changeBendAngle.Delete();
                                MessageBox.Show("Операция не выполнена! \nВыбирете другую грань или введите другой угол");
                            }
                            update_listBoxFixFaces();
                            update_listBoxFeatureName();
                            update_listBoxAngleChanged();
                            seAplication.ActiveSelectSet.RemoveAll();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Некорректное значение угла!");
                    }

                    e.Handled = true;
                    e.SuppressKeyPress = true; // Чтобы Enter не добавлял символ в TextBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении угла сгиба\n" + ex.Message);
            }
        }


        // Выбора элемента в списке операций изменения углов
        private void listBoxAngleChanged_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = listBoxAngleChanged.SelectedIndex;// Запомнить индекс
                if (selectedIndex >= 0)
                {
                    changeBendAngle = changeBAngList[selectedIndex]; // Найти операцию по индексу
                    seAplication.ActiveSelectSet.RemoveAll();
                    seAplication.ActiveSelectSet.Add(changeBendAngle);   // Подсветка через SelectSet

                    trackBarAngle.Enabled = true;  // Активировать ползунок
                    trackBarAngle.Value = (int)(ToDegrees(changeBendAngle.Angle)*10); // установить значение ползунка
                    textBoxChangeAngle.Text = ((double)trackBarAngle.Value / 10).ToString("F1"); // установить значение подписи
                }
                else
                {
                    trackBarAngle.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выборе операции изменения угла сгиба \n" + ex.Message);
            }
        }
        // Фиксирование значения с ползунка (проверка на сломаннцю геометрию/обновление списков).
        private void trackBarAngle_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                // Проверка на сломанцю геометрию.
                if (changeBendAngle.Status[out str] == FeatureStatusConstants.igFeatureFailed)
                {
                    MessageBox.Show("Операция не выполнена! \n Такой угол ломает геометрию!");
                    return;
                }
                update_listBoxFixFaces();
                update_listBoxFeatureName();
                seAplication.ActiveSelectSet.RemoveAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при отпускании кнопки мыши на ползунке\n" + ex.Message);
            }
        }
        // Изменение угла у операции изменить угол и текста значения угла при передвижении ползунка.
        private void trackBarAngle_Scroll(object sender, EventArgs e)
        {
            try
            {
                changeBendAngle.Angle = ToRadians((double)trackBarAngle.Value / 10);
                textBoxChangeAngle.Text = ((double)trackBarAngle.Value / 10).ToString("F1");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при перемещении ползунка \n" + ex.Message);
            }
        }
       
        
        
        // Преобразование радианов в градусы.
        double ToDegrees(double radians)
        {
            return radians * 180.0 / Math.PI;
        }
        // Преобразование градусов в радианы.
        private double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        } 



        // Закрытие формы.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            OleMessageFilter.Unregister(); // Разрегистрация фильтра сообщений
        }
    }
}


