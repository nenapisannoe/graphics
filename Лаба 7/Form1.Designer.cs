namespace Lab06
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
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.projBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rotateBtn = new System.Windows.Forms.Button();
            this.point1Z = new System.Windows.Forms.TextBox();
            this.point1Y = new System.Windows.Forms.TextBox();
            this.point1X = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.point2Z = new System.Windows.Forms.TextBox();
            this.point2Y = new System.Windows.Forms.TextBox();
            this.point2X = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.figuraCount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.figureX = new System.Windows.Forms.TextBox();
            this.figureY = new System.Windows.Forms.TextBox();
            this.figuraZ = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.addPointButton = new System.Windows.Forms.Button();
            this.drawFigureRotationButton = new System.Windows.Forms.Button();
            this.graphY2 = new System.Windows.Forms.TextBox();
            this.graphY1 = new System.Windows.Forms.TextBox();
            this.graphX2 = new System.Windows.Forms.TextBox();
            this.graphX1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.graphicsList = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.countSplit = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.radioTetra = new System.Windows.Forms.RadioButton();
            this.radioGecsa = new System.Windows.Forms.RadioButton();
            this.radioOkta = new System.Windows.Forms.RadioButton();
            this.label26 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rotateAngle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(467, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(967, 567);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(128, 90);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 32);
            this.button3.TabIndex = 3;
            this.button3.Text = "Очистить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(72, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(124, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Z";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 314);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(45, 22);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(59, 314);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(45, 22);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(111, 314);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(45, 22);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "0";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(4, 384);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(196, 34);
            this.button5.TabIndex = 12;
            this.button5.Text = "Использовать";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Смещение по оси",
            "Масштабирование",
            "Поворот",
            "Отражение по Z",
            "Отражение по Y",
            "Отражение по X"});
            this.comboBox1.Location = new System.Drawing.Point(5, 347);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 24);
            this.comboBox1.TabIndex = 17;
            // 
            // projBox
            // 
            this.projBox.FormattingEnabled = true;
            this.projBox.Items.AddRange(new object[] {
            "Перспективная",
            "Изометрическая"});
            this.projBox.Location = new System.Drawing.Point(244, 367);
            this.projBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.projBox.Name = "projBox";
            this.projBox.Size = new System.Drawing.Size(195, 24);
            this.projBox.TabIndex = 21;
            this.projBox.SelectedIndexChanged += new System.EventHandler(this.projBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 347);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Проекция";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 239);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Градус";
            // 
            // rotateBtn
            // 
            this.rotateBtn.Location = new System.Drawing.Point(67, 257);
            this.rotateBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rotateBtn.Name = "rotateBtn";
            this.rotateBtn.Size = new System.Drawing.Size(172, 28);
            this.rotateBtn.TabIndex = 30;
            this.rotateBtn.Text = "Поворот";
            this.rotateBtn.UseVisualStyleBackColor = true;
            this.rotateBtn.Click += new System.EventHandler(this.rotateBtn_Click);
            // 
            // point1Z
            // 
            this.point1Z.Location = new System.Drawing.Point(48, 209);
            this.point1Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.point1Z.Name = "point1Z";
            this.point1Z.Size = new System.Drawing.Size(45, 22);
            this.point1Z.TabIndex = 36;
            this.point1Z.Text = "0";
            // 
            // point1Y
            // 
            this.point1Y.Location = new System.Drawing.Point(47, 181);
            this.point1Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.point1Y.Name = "point1Y";
            this.point1Y.Size = new System.Drawing.Size(45, 22);
            this.point1Y.TabIndex = 35;
            this.point1Y.Text = "0";
            // 
            // point1X
            // 
            this.point1X.Location = new System.Drawing.Point(128, 153);
            this.point1X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.point1X.Name = "point1X";
            this.point1X.Size = new System.Drawing.Size(45, 22);
            this.point1X.TabIndex = 34;
            this.point1X.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(99, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "Z";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(99, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(99, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 20);
            this.label10.TabIndex = 31;
            this.label10.Text = "X";
            // 
            // point2Z
            // 
            this.point2Z.Location = new System.Drawing.Point(127, 209);
            this.point2Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.point2Z.Name = "point2Z";
            this.point2Z.Size = new System.Drawing.Size(45, 22);
            this.point2Z.TabIndex = 42;
            this.point2Z.Text = "0";
            // 
            // point2Y
            // 
            this.point2Y.Location = new System.Drawing.Point(127, 181);
            this.point2Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.point2Y.Name = "point2Y";
            this.point2Y.Size = new System.Drawing.Size(45, 22);
            this.point2Y.TabIndex = 41;
            this.point2Y.Text = "0";
            // 
            // point2X
            // 
            this.point2X.Location = new System.Drawing.Point(46, 153);
            this.point2X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.point2X.Name = "point2X";
            this.point2X.Size = new System.Drawing.Size(45, 22);
            this.point2X.TabIndex = 40;
            this.point2X.Text = "0";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(128, 53);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(111, 32);
            this.saveButton.TabIndex = 46;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadButton.Location = new System.Drawing.Point(128, 16);
            this.loadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(111, 32);
            this.loadButton.TabIndex = 47;
            this.loadButton.Text = "Загрузить";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label14.Location = new System.Drawing.Point(248, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 17);
            this.label14.TabIndex = 48;
            this.label14.Text = "Ось вращения:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.comboBox2.Location = new System.Drawing.Point(363, 16);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(49, 24);
            this.comboBox2.TabIndex = 49;
            // 
            // figuraCount
            // 
            this.figuraCount.Location = new System.Drawing.Point(295, 127);
            this.figuraCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.figuraCount.Name = "figuraCount";
            this.figuraCount.Size = new System.Drawing.Size(44, 22);
            this.figuraCount.TabIndex = 51;
            this.figuraCount.Text = "10";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(248, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 20);
            this.label16.TabIndex = 52;
            this.label16.Text = "X";
            // 
            // figureX
            // 
            this.figureX.Location = new System.Drawing.Point(295, 39);
            this.figureX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.figureX.Name = "figureX";
            this.figureX.Size = new System.Drawing.Size(44, 22);
            this.figureX.TabIndex = 53;
            this.figureX.Text = "0";
            // 
            // figureY
            // 
            this.figureY.Location = new System.Drawing.Point(295, 70);
            this.figureY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.figureY.Name = "figureY";
            this.figureY.Size = new System.Drawing.Size(44, 22);
            this.figureY.TabIndex = 54;
            this.figureY.Text = "0";
            // 
            // figuraZ
            // 
            this.figuraZ.Location = new System.Drawing.Point(295, 100);
            this.figuraZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.figuraZ.Name = "figuraZ";
            this.figuraZ.Size = new System.Drawing.Size(44, 22);
            this.figuraZ.TabIndex = 55;
            this.figuraZ.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(248, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 20);
            this.label17.TabIndex = 56;
            this.label17.Text = "Y";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(248, 100);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 20);
            this.label18.TabIndex = 57;
            this.label18.Text = "Z";
            // 
            // addPointButton
            // 
            this.addPointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addPointButton.Location = new System.Drawing.Point(345, 90);
            this.addPointButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addPointButton.Name = "addPointButton";
            this.addPointButton.Size = new System.Drawing.Size(116, 31);
            this.addPointButton.TabIndex = 58;
            this.addPointButton.Text = "Добавить";
            this.addPointButton.UseVisualStyleBackColor = true;
            this.addPointButton.Click += new System.EventHandler(this.addPointButton_Click);
            // 
            // drawFigureRotationButton
            // 
            this.drawFigureRotationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.drawFigureRotationButton.Location = new System.Drawing.Point(345, 124);
            this.drawFigureRotationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drawFigureRotationButton.Name = "drawFigureRotationButton";
            this.drawFigureRotationButton.Size = new System.Drawing.Size(116, 27);
            this.drawFigureRotationButton.TabIndex = 59;
            this.drawFigureRotationButton.Text = "Нарисовать";
            this.drawFigureRotationButton.UseVisualStyleBackColor = true;
            this.drawFigureRotationButton.Click += new System.EventHandler(this.drawFigureRotationButton_Click);
            // 
            // graphY2
            // 
            this.graphY2.Location = new System.Drawing.Point(292, 268);
            this.graphY2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graphY2.Name = "graphY2";
            this.graphY2.Size = new System.Drawing.Size(44, 22);
            this.graphY2.TabIndex = 67;
            this.graphY2.Text = "4";
            // 
            // graphY1
            // 
            this.graphY1.Location = new System.Drawing.Point(292, 239);
            this.graphY1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graphY1.Name = "graphY1";
            this.graphY1.Size = new System.Drawing.Size(44, 22);
            this.graphY1.TabIndex = 66;
            this.graphY1.Text = "-4";
            // 
            // graphX2
            // 
            this.graphX2.Location = new System.Drawing.Point(244, 268);
            this.graphX2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graphX2.Name = "graphX2";
            this.graphX2.Size = new System.Drawing.Size(44, 22);
            this.graphX2.TabIndex = 63;
            this.graphX2.Text = "4";
            // 
            // graphX1
            // 
            this.graphX1.Location = new System.Drawing.Point(244, 239);
            this.graphX1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graphX1.Name = "graphX1";
            this.graphX1.Size = new System.Drawing.Size(44, 22);
            this.graphX1.TabIndex = 62;
            this.graphX1.Text = "-4";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(303, 215);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(19, 20);
            this.label21.TabIndex = 61;
            this.label21.Text = "Y";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(255, 214);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(20, 20);
            this.label22.TabIndex = 60;
            this.label22.Text = "X";
            // 
            // graphicsList
            // 
            this.graphicsList.FormattingEnabled = true;
            this.graphicsList.Items.AddRange(new object[] {
            "z = Sin(x+y)",
            "z = Cos(x+y)",
            "z = Sin(x)*Cos(y)*Sin(y)",
            "z = Sin(x*x+y*y)/(x*x+y*y)",
            "z = Sin(x+y)/(x+y)"});
            this.graphicsList.Location = new System.Drawing.Point(243, 185);
            this.graphicsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graphicsList.Name = "graphicsList";
            this.graphicsList.Size = new System.Drawing.Size(163, 24);
            this.graphicsList.TabIndex = 69;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label23.Location = new System.Drawing.Point(240, 161);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(126, 17);
            this.label23.TabIndex = 68;
            this.label23.Text = "Функция графика";
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button8.Location = new System.Drawing.Point(243, 298);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(183, 30);
            this.button8.TabIndex = 70;
            this.button8.Text = "Построить график";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.DrawGraphic_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label24.Location = new System.Drawing.Point(340, 250);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 17);
            this.label24.TabIndex = 71;
            this.label24.Text = "Кол-во";
            // 
            // countSplit
            // 
            this.countSplit.Location = new System.Drawing.Point(345, 268);
            this.countSplit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.countSplit.Name = "countSplit";
            this.countSplit.Size = new System.Drawing.Size(60, 22);
            this.countSplit.TabIndex = 72;
            this.countSplit.Text = "30";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "json";
            this.openFileDialog1.FileName = "figure";
            this.openFileDialog1.Filter = "JSON files|*.json|All files|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "json";
            this.saveFileDialog1.FileName = "figure";
            this.saveFileDialog1.Filter = "JSON files|*.json|All files|*.*";
            // 
            // radioTetra
            // 
            this.radioTetra.AutoSize = true;
            this.radioTetra.Location = new System.Drawing.Point(13, 25);
            this.radioTetra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioTetra.Name = "radioTetra";
            this.radioTetra.Size = new System.Drawing.Size(92, 20);
            this.radioTetra.TabIndex = 74;
            this.radioTetra.TabStop = true;
            this.radioTetra.Text = "Тетраэдр";
            this.radioTetra.UseVisualStyleBackColor = true;
            this.radioTetra.Click += new System.EventHandler(this.tetra_Click);
            // 
            // radioGecsa
            // 
            this.radioGecsa.AutoSize = true;
            this.radioGecsa.Location = new System.Drawing.Point(13, 53);
            this.radioGecsa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioGecsa.Name = "radioGecsa";
            this.radioGecsa.Size = new System.Drawing.Size(89, 20);
            this.radioGecsa.TabIndex = 75;
            this.radioGecsa.TabStop = true;
            this.radioGecsa.Text = "Гексаэдр";
            this.radioGecsa.UseVisualStyleBackColor = true;
            this.radioGecsa.Click += new System.EventHandler(this.gecsa_Click);
            // 
            // radioOkta
            // 
            this.radioOkta.AutoSize = true;
            this.radioOkta.Location = new System.Drawing.Point(13, 81);
            this.radioOkta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioOkta.Name = "radioOkta";
            this.radioOkta.Size = new System.Drawing.Size(84, 20);
            this.radioOkta.TabIndex = 76;
            this.radioOkta.TabStop = true;
            this.radioOkta.Text = "Октаэдр";
            this.radioOkta.UseVisualStyleBackColor = true;
            this.radioOkta.Click += new System.EventHandler(this.okta_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(1, 130);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(97, 16);
            this.label26.TabIndex = 80;
            this.label26.Text = "Первая точка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 81;
            this.label1.Text = "Вторая точка";
            // 
            // rotateAngle
            // 
            this.rotateAngle.Location = new System.Drawing.Point(5, 260);
            this.rotateAngle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rotateAngle.Name = "rotateAngle";
            this.rotateAngle.Size = new System.Drawing.Size(45, 22);
            this.rotateAngle.TabIndex = 82;
            this.rotateAngle.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(240, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 83;
            this.label6.Text = "Кол-во";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 577);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rotateAngle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.radioOkta);
            this.Controls.Add(this.radioGecsa);
            this.Controls.Add(this.radioTetra);
            this.Controls.Add(this.countSplit);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.graphicsList);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.graphY2);
            this.Controls.Add(this.graphY1);
            this.Controls.Add(this.graphX2);
            this.Controls.Add(this.graphX1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.drawFigureRotationButton);
            this.Controls.Add(this.addPointButton);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.figuraZ);
            this.Controls.Add(this.figureY);
            this.Controls.Add(this.figureX);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.figuraCount);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.point2Z);
            this.Controls.Add(this.point2Y);
            this.Controls.Add(this.point2X);
            this.Controls.Add(this.point1Z);
            this.Controls.Add(this.point1Y);
            this.Controls.Add(this.point1X);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rotateBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.projBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox projBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button rotateBtn;
        private System.Windows.Forms.TextBox point1Z;
        private System.Windows.Forms.TextBox point1Y;
        private System.Windows.Forms.TextBox point1X;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox point2Z;
        private System.Windows.Forms.TextBox point2Y;
        private System.Windows.Forms.TextBox point2X;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox figuraCount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox figureX;
        private System.Windows.Forms.TextBox figureY;
        private System.Windows.Forms.TextBox figuraZ;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button addPointButton;
        private System.Windows.Forms.Button drawFigureRotationButton;
        private System.Windows.Forms.TextBox graphY2;
        private System.Windows.Forms.TextBox graphY1;
        private System.Windows.Forms.TextBox graphX2;
        private System.Windows.Forms.TextBox graphX1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox graphicsList;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox countSplit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton radioTetra;
        private System.Windows.Forms.RadioButton radioGecsa;
        private System.Windows.Forms.RadioButton radioOkta;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rotateAngle;
        private System.Windows.Forms.Label label6;
    }
}

