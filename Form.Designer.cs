namespace ScriptSolidEdge
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.button_flatten = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxFacesFlat = new System.Windows.Forms.ListBox();
            this.listBoxEdges = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxFeatureName = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxAngle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxFixFaces = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNewAngle = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.connectActiveDoc = new System.Windows.Forms.Button();
            this.ActiveDocName = new System.Windows.Forms.Label();
            this.trackBarAngle = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.listBoxAngleChanged = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxChangeAngle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngle)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_flatten
            // 
            this.button_flatten.BackColor = System.Drawing.Color.Azure;
            this.button_flatten.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_flatten.Enabled = false;
            this.button_flatten.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_flatten.Location = new System.Drawing.Point(6, 372);
            this.button_flatten.Name = "button_flatten";
            this.button_flatten.Size = new System.Drawing.Size(209, 53);
            this.button_flatten.TabIndex = 1;
            this.button_flatten.Text = "Сделать развёртку";
            this.button_flatten.UseVisualStyleBackColor = false;
            this.button_flatten.Click += new System.EventHandler(this.button_flatten_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Список граней";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Список рёбер";
            // 
            // listBoxFacesFlat
            // 
            this.listBoxFacesFlat.BackColor = System.Drawing.Color.AliceBlue;
            this.listBoxFacesFlat.FormattingEnabled = true;
            this.listBoxFacesFlat.ItemHeight = 16;
            this.listBoxFacesFlat.Location = new System.Drawing.Point(6, 50);
            this.listBoxFacesFlat.Name = "listBoxFacesFlat";
            this.listBoxFacesFlat.Size = new System.Drawing.Size(102, 308);
            this.listBoxFacesFlat.TabIndex = 6;
            this.listBoxFacesFlat.SelectedIndexChanged += new System.EventHandler(this.listBoxFaces_SelectedIndexChanged);
            // 
            // listBoxEdges
            // 
            this.listBoxEdges.BackColor = System.Drawing.Color.AliceBlue;
            this.listBoxEdges.FormattingEnabled = true;
            this.listBoxEdges.ItemHeight = 16;
            this.listBoxEdges.Location = new System.Drawing.Point(114, 50);
            this.listBoxEdges.Name = "listBoxEdges";
            this.listBoxEdges.Size = new System.Drawing.Size(101, 308);
            this.listBoxEdges.TabIndex = 7;
            this.listBoxEdges.SelectedIndexChanged += new System.EventHandler(this.listBoxEdges_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Операция для изменения";
            // 
            // listBoxFeatureName
            // 
            this.listBoxFeatureName.BackColor = System.Drawing.Color.Ivory;
            this.listBoxFeatureName.FormattingEnabled = true;
            this.listBoxFeatureName.ItemHeight = 16;
            this.listBoxFeatureName.Location = new System.Drawing.Point(6, 50);
            this.listBoxFeatureName.Name = "listBoxFeatureName";
            this.listBoxFeatureName.Size = new System.Drawing.Size(173, 308);
            this.listBoxFeatureName.TabIndex = 13;
            this.listBoxFeatureName.SelectedIndexChanged += new System.EventHandler(this.listBoxFeatureName_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.listBoxEdges);
            this.groupBox1.Controls.Add(this.listBoxFacesFlat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_flatten);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 435);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Создание развёртки.";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox2.Controls.Add(this.textBoxAngle);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.listBoxFixFaces);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxNewAngle);
            this.groupBox2.Controls.Add(this.listBoxFeatureName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(236, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 435);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Изменение угла сгиба.";
            // 
            // textBoxAngle
            // 
            this.textBoxAngle.Enabled = false;
            this.textBoxAngle.Location = new System.Drawing.Point(197, 372);
            this.textBoxAngle.Name = "textBoxAngle";
            this.textBoxAngle.Size = new System.Drawing.Size(47, 22);
            this.textBoxAngle.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 403);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Значение нового угла";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Текущее значение угла";
            // 
            // listBoxFixFaces
            // 
            this.listBoxFixFaces.BackColor = System.Drawing.Color.Ivory;
            this.listBoxFixFaces.FormattingEnabled = true;
            this.listBoxFixFaces.ItemHeight = 16;
            this.listBoxFixFaces.Location = new System.Drawing.Point(185, 50);
            this.listBoxFixFaces.Name = "listBoxFixFaces";
            this.listBoxFixFaces.Size = new System.Drawing.Size(102, 308);
            this.listBoxFixFaces.TabIndex = 26;
            this.listBoxFixFaces.SelectedIndexChanged += new System.EventHandler(this.listBoxFixFaces_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Выбрать грань";
            // 
            // textBoxNewAngle
            // 
            this.textBoxNewAngle.Enabled = false;
            this.textBoxNewAngle.Location = new System.Drawing.Point(197, 400);
            this.textBoxNewAngle.Name = "textBoxNewAngle";
            this.textBoxNewAngle.Size = new System.Drawing.Size(47, 22);
            this.textBoxNewAngle.TabIndex = 23;
            this.textBoxNewAngle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNewAngle_KeyDown);
            // 
            // connectActiveDoc
            // 
            this.connectActiveDoc.BackColor = System.Drawing.Color.Azure;
            this.connectActiveDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connectActiveDoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.connectActiveDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectActiveDoc.Location = new System.Drawing.Point(12, 12);
            this.connectActiveDoc.Name = "connectActiveDoc";
            this.connectActiveDoc.Size = new System.Drawing.Size(816, 46);
            this.connectActiveDoc.TabIndex = 22;
            this.connectActiveDoc.Text = "Подключиться к активному документу";
            this.connectActiveDoc.UseVisualStyleBackColor = false;
            this.connectActiveDoc.Click += new System.EventHandler(this.connectActiveDoc_Click);
            // 
            // ActiveDocName
            // 
            this.ActiveDocName.AutoSize = true;
            this.ActiveDocName.BackColor = System.Drawing.Color.LightCoral;
            this.ActiveDocName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ActiveDocName.Location = new System.Drawing.Point(426, 61);
            this.ActiveDocName.Name = "ActiveDocName";
            this.ActiveDocName.Size = new System.Drawing.Size(121, 24);
            this.ActiveDocName.TabIndex = 24;
            this.ActiveDocName.Text = "отсутствует";
            // 
            // trackBarAngle
            // 
            this.trackBarAngle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarAngle.Enabled = false;
            this.trackBarAngle.LargeChange = 50;
            this.trackBarAngle.Location = new System.Drawing.Point(0, 380);
            this.trackBarAngle.Maximum = 1800;
            this.trackBarAngle.Name = "trackBarAngle";
            this.trackBarAngle.Size = new System.Drawing.Size(245, 45);
            this.trackBarAngle.TabIndex = 22;
            this.trackBarAngle.Scroll += new System.EventHandler(this.trackBarAngle_Scroll);
            this.trackBarAngle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarAngle_MouseUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Сгиб для изменения";
            // 
            // listBoxAngleChanged
            // 
            this.listBoxAngleChanged.BackColor = System.Drawing.Color.Snow;
            this.listBoxAngleChanged.FormattingEnabled = true;
            this.listBoxAngleChanged.ItemHeight = 16;
            this.listBoxAngleChanged.Location = new System.Drawing.Point(6, 50);
            this.listBoxAngleChanged.Name = "listBoxAngleChanged";
            this.listBoxAngleChanged.Size = new System.Drawing.Size(280, 308);
            this.listBoxAngleChanged.TabIndex = 24;
            this.listBoxAngleChanged.SelectedIndexChanged += new System.EventHandler(this.listBoxAngleChanged_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.MistyRose;
            this.groupBox3.Controls.Add(this.textBoxChangeAngle);
            this.groupBox3.Controls.Add(this.listBoxAngleChanged);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.trackBarAngle);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(536, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(292, 435);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поменять значение существующего изменения угла.";
            // 
            // textBoxChangeAngle
            // 
            this.textBoxChangeAngle.Enabled = false;
            this.textBoxChangeAngle.Location = new System.Drawing.Point(239, 387);
            this.textBoxChangeAngle.Name = "textBoxChangeAngle";
            this.textBoxChangeAngle.Size = new System.Drawing.Size(47, 22);
            this.textBoxChangeAngle.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(166, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 24);
            this.label4.TabIndex = 23;
            this.label4.Text = "Подключенный документ: ";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(839, 543);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ActiveDocName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.connectActiveDoc);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Развёртка и Изменение угла сгиба";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngle)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_flatten;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxFacesFlat;
        private System.Windows.Forms.ListBox listBoxEdges;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxFeatureName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox textBoxNewAngle;
        private System.Windows.Forms.Button connectActiveDoc;
        private System.Windows.Forms.Label ActiveDocName;
        private System.Windows.Forms.ListBox listBoxFixFaces;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAngle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBarAngle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBoxAngleChanged;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxChangeAngle;
    }
}

