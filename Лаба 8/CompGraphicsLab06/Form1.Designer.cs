namespace Lab08
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.projBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.camPosZ = new System.Windows.Forms.TextBox();
            this.camPosY = new System.Windows.Forms.TextBox();
            this.camPosX = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.FreeCam = new System.Windows.Forms.CheckBox();
            this.UpBtn = new System.Windows.Forms.Button();
            this.LBtn = new System.Windows.Forms.Button();
            this.RBtn = new System.Windows.Forms.Button();
            this.DBtn = new System.Windows.Forms.Button();
            this.EBtn = new System.Windows.Forms.Button();
            this.QBtn = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.addPointButton = new System.Windows.Forms.Button();
            this.drawFigureRotationButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1110, 948);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1170, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Куб (гексаэдр)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1169, 64);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 39);
            this.button2.TabIndex = 2;
            this.button2.Text = "Тетраэдр";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1341, 229);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 37);
            this.button3.TabIndex = 3;
            this.button3.Text = "Очистить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Clear_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1170, 107);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(208, 39);
            this.button4.TabIndex = 4;
            this.button4.Text = "Октаэдр";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1317, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1316, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1317, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Z";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1187, 387);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(213, 50);
            this.button5.TabIndex = 12;
            this.button5.Text = "Применить преобразования";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(1169, 290);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(118, 24);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Смещение";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton1_MouseClick);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(1169, 320);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(107, 24);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Масштаб";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton2_MouseClick);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton3.Location = new System.Drawing.Point(1169, 350);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(103, 24);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Поворот";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton3_MouseClick);
            // 
            // projBox
            // 
            this.projBox.FormattingEnabled = true;
            this.projBox.Items.AddRange(new object[] {
            "Перспективная",
            "Изометрическая"});
            this.projBox.Location = new System.Drawing.Point(1169, 181);
            this.projBox.Margin = new System.Windows.Forms.Padding(4);
            this.projBox.Name = "projBox";
            this.projBox.Size = new System.Drawing.Size(209, 24);
            this.projBox.TabIndex = 21;
            this.projBox.SelectedIndexChanged += new System.EventHandler(this.projBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1237, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Проекция";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(1139, 229);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(96, 37);
            this.saveButton.TabIndex = 46;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadButton.Location = new System.Drawing.Point(1239, 229);
            this.loadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(96, 37);
            this.loadButton.TabIndex = 47;
            this.loadButton.Text = "Загрузить";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "json";
            this.openFileDialog1.FileName = "Figure";
            this.openFileDialog1.Filter = "JSON files|*.json|All files|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "json";
            this.saveFileDialog1.FileName = "Figure";
            this.saveFileDialog1.Filter = "JSON files|*.json|All files|*.*";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(1140, 773);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(245, 20);
            this.checkBox1.TabIndex = 74;
            this.checkBox1.Text = "Не показывать нелицевые грани";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.Location = new System.Drawing.Point(1328, 721);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(18, 20);
            this.label25.TabIndex = 80;
            this.label25.Text = "Z";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(1258, 721);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(19, 20);
            this.label26.TabIndex = 79;
            this.label26.Text = "Y";
            // 
            // camPosZ
            // 
            this.camPosZ.Location = new System.Drawing.Point(1306, 743);
            this.camPosZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.camPosZ.Name = "camPosZ";
            this.camPosZ.Size = new System.Drawing.Size(61, 22);
            this.camPosZ.TabIndex = 78;
            this.camPosZ.Text = "15";
            // 
            // camPosY
            // 
            this.camPosY.Location = new System.Drawing.Point(1240, 743);
            this.camPosY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.camPosY.Name = "camPosY";
            this.camPosY.Size = new System.Drawing.Size(61, 22);
            this.camPosY.TabIndex = 77;
            this.camPosY.Text = "0";
            // 
            // camPosX
            // 
            this.camPosX.Location = new System.Drawing.Point(1170, 743);
            this.camPosX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.camPosX.Name = "camPosX";
            this.camPosX.Size = new System.Drawing.Size(61, 22);
            this.camPosX.TabIndex = 76;
            this.camPosX.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(1188, 721);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(20, 20);
            this.label27.TabIndex = 75;
            this.label27.Text = "X";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label28.Location = new System.Drawing.Point(1166, 701);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(209, 20);
            this.label28.TabIndex = 81;
            this.label28.Text = "Выберите точку обзора";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(1140, 803);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 20);
            this.checkBox2.TabIndex = 83;
            this.checkBox2.Text = "Z-буфер";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // FreeCam
            // 
            this.FreeCam.AutoSize = true;
            this.FreeCam.Location = new System.Drawing.Point(1140, 831);
            this.FreeCam.Margin = new System.Windows.Forms.Padding(4);
            this.FreeCam.Name = "FreeCam";
            this.FreeCam.Size = new System.Drawing.Size(152, 20);
            this.FreeCam.TabIndex = 84;
            this.FreeCam.Text = "Свободная камера";
            this.FreeCam.UseVisualStyleBackColor = true;
            this.FreeCam.Click += new System.EventHandler(this.FreeCam_Click);
            // 
            // UpBtn
            // 
            this.UpBtn.Location = new System.Drawing.Point(1241, 860);
            this.UpBtn.Margin = new System.Windows.Forms.Padding(4);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(100, 28);
            this.UpBtn.TabIndex = 85;
            this.UpBtn.Text = "↑";
            this.UpBtn.UseVisualStyleBackColor = true;
            this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
            // 
            // LBtn
            // 
            this.LBtn.Location = new System.Drawing.Point(1160, 895);
            this.LBtn.Margin = new System.Windows.Forms.Padding(4);
            this.LBtn.Name = "LBtn";
            this.LBtn.Size = new System.Drawing.Size(100, 28);
            this.LBtn.TabIndex = 86;
            this.LBtn.Text = "←";
            this.LBtn.UseVisualStyleBackColor = true;
            this.LBtn.Click += new System.EventHandler(this.LBtn_Click);
            // 
            // RBtn
            // 
            this.RBtn.Location = new System.Drawing.Point(1320, 895);
            this.RBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RBtn.Name = "RBtn";
            this.RBtn.Size = new System.Drawing.Size(100, 28);
            this.RBtn.TabIndex = 87;
            this.RBtn.Text = "→";
            this.RBtn.UseVisualStyleBackColor = true;
            this.RBtn.Click += new System.EventHandler(this.RBtn_Click);
            // 
            // DBtn
            // 
            this.DBtn.Location = new System.Drawing.Point(1241, 930);
            this.DBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DBtn.Name = "DBtn";
            this.DBtn.Size = new System.Drawing.Size(100, 28);
            this.DBtn.TabIndex = 88;
            this.DBtn.Text = "↓";
            this.DBtn.UseVisualStyleBackColor = true;
            this.DBtn.Click += new System.EventHandler(this.DBtn_Click);
            // 
            // EBtn
            // 
            this.EBtn.Location = new System.Drawing.Point(1349, 860);
            this.EBtn.Margin = new System.Windows.Forms.Padding(4);
            this.EBtn.Name = "EBtn";
            this.EBtn.Size = new System.Drawing.Size(71, 28);
            this.EBtn.TabIndex = 89;
            this.EBtn.Text = "↻";
            this.EBtn.UseVisualStyleBackColor = true;
            this.EBtn.Click += new System.EventHandler(this.EBtn_Click);
            // 
            // QBtn
            // 
            this.QBtn.Location = new System.Drawing.Point(1158, 860);
            this.QBtn.Margin = new System.Windows.Forms.Padding(4);
            this.QBtn.Name = "QBtn";
            this.QBtn.Size = new System.Drawing.Size(71, 28);
            this.QBtn.TabIndex = 90;
            this.QBtn.Text = "↺";
            this.QBtn.UseVisualStyleBackColor = true;
            this.QBtn.Click += new System.EventHandler(this.QBtn_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(1186, 449);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(216, 20);
            this.label14.TabIndex = 48;
            this.label14.Text = "Выберите ось вращения";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Ось Ox",
            "Ось Oy",
            "Ось Oz"});
            this.comboBox2.Location = new System.Drawing.Point(1156, 473);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(264, 24);
            this.comboBox2.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(1186, 505);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(203, 20);
            this.label15.TabIndex = 50;
            this.label15.Text = "Количество разбиений";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1258, 527);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(60, 22);
            this.textBox5.TabIndex = 51;
            this.textBox5.Text = "6";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(1206, 559);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 20);
            this.label16.TabIndex = 52;
            this.label16.Text = "X";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(1188, 581);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(61, 22);
            this.textBox6.TabIndex = 53;
            this.textBox6.Text = "0";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(1258, 581);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(61, 22);
            this.textBox7.TabIndex = 54;
            this.textBox7.Text = "0";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(1324, 581);
            this.textBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(61, 22);
            this.textBox8.TabIndex = 55;
            this.textBox8.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(1276, 559);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 20);
            this.label17.TabIndex = 56;
            this.label17.Text = "Y";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(1346, 559);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 20);
            this.label18.TabIndex = 57;
            this.label18.Text = "Z";
            // 
            // addPointButton
            // 
            this.addPointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addPointButton.Location = new System.Drawing.Point(1156, 608);
            this.addPointButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addPointButton.Name = "addPointButton";
            this.addPointButton.Size = new System.Drawing.Size(131, 48);
            this.addPointButton.TabIndex = 58;
            this.addPointButton.Text = "Добавить точку";
            this.addPointButton.UseVisualStyleBackColor = true;
            this.addPointButton.Click += new System.EventHandler(this.addPointButton_Click);
            // 
            // drawFigureRotationButton
            // 
            this.drawFigureRotationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drawFigureRotationButton.Location = new System.Drawing.Point(1292, 608);
            this.drawFigureRotationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drawFigureRotationButton.Name = "drawFigureRotationButton";
            this.drawFigureRotationButton.Size = new System.Drawing.Size(131, 48);
            this.drawFigureRotationButton.TabIndex = 59;
            this.drawFigureRotationButton.Text = "Нарисовать";
            this.drawFigureRotationButton.UseVisualStyleBackColor = true;
            this.drawFigureRotationButton.Click += new System.EventHandler(this.drawFigureRotationButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(1346, 296);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(61, 22);
            this.numericUpDown1.TabIndex = 91;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 1;
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown2.Location = new System.Drawing.Point(1346, 324);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(61, 22);
            this.numericUpDown2.TabIndex = 92;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 1;
            this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown3.Location = new System.Drawing.Point(1346, 353);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(61, 22);
            this.numericUpDown3.TabIndex = 93;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 970);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.QBtn);
            this.Controls.Add(this.EBtn);
            this.Controls.Add(this.DBtn);
            this.Controls.Add(this.RBtn);
            this.Controls.Add(this.LBtn);
            this.Controls.Add(this.UpBtn);
            this.Controls.Add(this.FreeCam);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.camPosZ);
            this.Controls.Add(this.camPosY);
            this.Controls.Add(this.camPosX);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.drawFigureRotationButton);
            this.Controls.Add(this.addPointButton);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.projBox);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ComboBox projBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox camPosZ;
        private System.Windows.Forms.TextBox camPosY;
        private System.Windows.Forms.TextBox camPosX;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox FreeCam;
        private System.Windows.Forms.Button UpBtn;
        private System.Windows.Forms.Button LBtn;
        private System.Windows.Forms.Button RBtn;
        private System.Windows.Forms.Button DBtn;
        private System.Windows.Forms.Button EBtn;
        private System.Windows.Forms.Button QBtn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button addPointButton;
        private System.Windows.Forms.Button drawFigureRotationButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
    }
}

