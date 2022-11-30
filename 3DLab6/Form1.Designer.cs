namespace _3DLab6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.primitivesBox = new System.Windows.Forms.ComboBox();
            this.primitiveButton = new System.Windows.Forms.Button();
            this.PerspectiveBox = new System.Windows.Forms.ComboBox();
            this.xShift = new System.Windows.Forms.NumericUpDown();
            this.yShift = new System.Windows.Forms.NumericUpDown();
            this.zShift = new System.Windows.Forms.NumericUpDown();
            this.displacementApply = new System.Windows.Forms.Button();
            this.xRotate = new System.Windows.Forms.NumericUpDown();
            this.yRotate = new System.Windows.Forms.NumericUpDown();
            this.zRotate = new System.Windows.Forms.NumericUpDown();
            this.rotateApply = new System.Windows.Forms.Button();
            this.xScale = new System.Windows.Forms.NumericUpDown();
            this.yScale = new System.Windows.Forms.NumericUpDown();
            this.zScale = new System.Windows.Forms.NumericUpDown();
            this.scaleApply = new System.Windows.Forms.Button();
            this.reflectionBox = new System.Windows.Forms.ComboBox();
            this.reflectionApply = new System.Windows.Forms.Button();
            this.rotateX1 = new System.Windows.Forms.NumericUpDown();
            this.rotateY1 = new System.Windows.Forms.NumericUpDown();
            this.rotateZ1 = new System.Windows.Forms.NumericUpDown();
            this.rotateAngle = new System.Windows.Forms.NumericUpDown();
            this.rotateX2 = new System.Windows.Forms.NumericUpDown();
            this.rotateY2 = new System.Windows.Forms.NumericUpDown();
            this.rotateZ2 = new System.Windows.Forms.NumericUpDown();
            this.rotateLine = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.Scale_center = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xRotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zRotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateZ1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateZ2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Scale_center)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(953, 842);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // primitivesBox
            // 
            this.primitivesBox.FormattingEnabled = true;
            this.primitivesBox.Items.AddRange(new object[] {
            "Тетраэдр",
            "Гексаэдр",
            "Октаэдр",
            "Икосаэдр"});
            this.primitivesBox.Location = new System.Drawing.Point(1353, 42);
            this.primitivesBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.primitivesBox.Name = "primitivesBox";
            this.primitivesBox.Size = new System.Drawing.Size(277, 28);
            this.primitivesBox.TabIndex = 1;
            // 
            // primitiveButton
            // 
            this.primitiveButton.Location = new System.Drawing.Point(1402, 78);
            this.primitiveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.primitiveButton.Name = "primitiveButton";
            this.primitiveButton.Size = new System.Drawing.Size(188, 34);
            this.primitiveButton.TabIndex = 2;
            this.primitiveButton.Text = "Выбрать";
            this.primitiveButton.UseVisualStyleBackColor = true;
            this.primitiveButton.Click += new System.EventHandler(this.primitiveButton_Click);
            // 
            // PerspectiveBox
            // 
            this.PerspectiveBox.FormattingEnabled = true;
            this.PerspectiveBox.Items.AddRange(new object[] {
            "Перспективная",
            "Аксонометрическая"});
            this.PerspectiveBox.Location = new System.Drawing.Point(986, 42);
            this.PerspectiveBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PerspectiveBox.Name = "PerspectiveBox";
            this.PerspectiveBox.Size = new System.Drawing.Size(281, 28);
            this.PerspectiveBox.TabIndex = 3;
            // 
            // xShift
            // 
            this.xShift.Location = new System.Drawing.Point(974, 201);
            this.xShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xShift.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.xShift.Name = "xShift";
            this.xShift.Size = new System.Drawing.Size(70, 27);
            this.xShift.TabIndex = 4;
            // 
            // yShift
            // 
            this.yShift.Location = new System.Drawing.Point(1081, 201);
            this.yShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.yShift.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.yShift.Name = "yShift";
            this.yShift.Size = new System.Drawing.Size(70, 27);
            this.yShift.TabIndex = 5;
            // 
            // zShift
            // 
            this.zShift.Location = new System.Drawing.Point(1185, 201);
            this.zShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zShift.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.zShift.Name = "zShift";
            this.zShift.Size = new System.Drawing.Size(70, 27);
            this.zShift.TabIndex = 6;
            // 
            // displacementApply
            // 
            this.displacementApply.Location = new System.Drawing.Point(1011, 236);
            this.displacementApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.displacementApply.Name = "displacementApply";
            this.displacementApply.Size = new System.Drawing.Size(191, 34);
            this.displacementApply.TabIndex = 7;
            this.displacementApply.Text = "Применить";
            this.displacementApply.UseVisualStyleBackColor = true;
            this.displacementApply.Click += new System.EventHandler(this.displacementApply_Click);
            // 
            // xRotate
            // 
            this.xRotate.Location = new System.Drawing.Point(1364, 201);
            this.xRotate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xRotate.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.xRotate.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.xRotate.Name = "xRotate";
            this.xRotate.Size = new System.Drawing.Size(70, 27);
            this.xRotate.TabIndex = 8;
            // 
            // yRotate
            // 
            this.yRotate.Location = new System.Drawing.Point(1466, 201);
            this.yRotate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.yRotate.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.yRotate.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.yRotate.Name = "yRotate";
            this.yRotate.Size = new System.Drawing.Size(70, 27);
            this.yRotate.TabIndex = 9;
            // 
            // zRotate
            // 
            this.zRotate.Location = new System.Drawing.Point(1560, 201);
            this.zRotate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zRotate.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.zRotate.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.zRotate.Name = "zRotate";
            this.zRotate.Size = new System.Drawing.Size(70, 27);
            this.zRotate.TabIndex = 10;
            // 
            // rotateApply
            // 
            this.rotateApply.Location = new System.Drawing.Point(1402, 238);
            this.rotateApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotateApply.Name = "rotateApply";
            this.rotateApply.Size = new System.Drawing.Size(188, 32);
            this.rotateApply.TabIndex = 11;
            this.rotateApply.Text = "Применить";
            this.rotateApply.UseVisualStyleBackColor = true;
            this.rotateApply.Click += new System.EventHandler(this.rotateApply_Click);
            // 
            // xScale
            // 
            this.xScale.DecimalPlaces = 1;
            this.xScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.xScale.Location = new System.Drawing.Point(974, 344);
            this.xScale.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xScale.Name = "xScale";
            this.xScale.Size = new System.Drawing.Size(70, 27);
            this.xScale.TabIndex = 12;
            this.xScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yScale
            // 
            this.yScale.DecimalPlaces = 1;
            this.yScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.yScale.Location = new System.Drawing.Point(1081, 344);
            this.yScale.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.yScale.Name = "yScale";
            this.yScale.Size = new System.Drawing.Size(70, 27);
            this.yScale.TabIndex = 13;
            this.yScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // zScale
            // 
            this.zScale.DecimalPlaces = 1;
            this.zScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.zScale.Location = new System.Drawing.Point(1185, 344);
            this.zScale.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zScale.Name = "zScale";
            this.zScale.Size = new System.Drawing.Size(70, 27);
            this.zScale.TabIndex = 14;
            this.zScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // scaleApply
            // 
            this.scaleApply.Location = new System.Drawing.Point(1011, 379);
            this.scaleApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scaleApply.Name = "scaleApply";
            this.scaleApply.Size = new System.Drawing.Size(191, 32);
            this.scaleApply.TabIndex = 15;
            this.scaleApply.Text = "Применить";
            this.scaleApply.UseVisualStyleBackColor = true;
            this.scaleApply.Click += new System.EventHandler(this.scaleApply_Click);
            // 
            // reflectionBox
            // 
            this.reflectionBox.FormattingEnabled = true;
            this.reflectionBox.Items.AddRange(new object[] {
            "Плоскость X",
            "Плоскость Y",
            "Плоскость Z"});
            this.reflectionBox.Location = new System.Drawing.Point(1364, 343);
            this.reflectionBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reflectionBox.Name = "reflectionBox";
            this.reflectionBox.Size = new System.Drawing.Size(277, 28);
            this.reflectionBox.TabIndex = 16;
            // 
            // reflectionApply
            // 
            this.reflectionApply.Location = new System.Drawing.Point(1413, 379);
            this.reflectionApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reflectionApply.Name = "reflectionApply";
            this.reflectionApply.Size = new System.Drawing.Size(191, 32);
            this.reflectionApply.TabIndex = 17;
            this.reflectionApply.Text = "Применить";
            this.reflectionApply.UseVisualStyleBackColor = true;
            this.reflectionApply.Click += new System.EventHandler(this.reflectionApply_Click);
            // 
            // rotateX1
            // 
            this.rotateX1.Location = new System.Drawing.Point(975, 468);
            this.rotateX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotateX1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rotateX1.Name = "rotateX1";
            this.rotateX1.Size = new System.Drawing.Size(70, 27);
            this.rotateX1.TabIndex = 18;
            // 
            // rotateY1
            // 
            this.rotateY1.Location = new System.Drawing.Point(1081, 468);
            this.rotateY1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotateY1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rotateY1.Name = "rotateY1";
            this.rotateY1.Size = new System.Drawing.Size(70, 27);
            this.rotateY1.TabIndex = 19;
            // 
            // rotateZ1
            // 
            this.rotateZ1.Location = new System.Drawing.Point(1185, 468);
            this.rotateZ1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotateZ1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rotateZ1.Name = "rotateZ1";
            this.rotateZ1.Size = new System.Drawing.Size(70, 27);
            this.rotateZ1.TabIndex = 20;
            // 
            // rotateAngle
            // 
            this.rotateAngle.Location = new System.Drawing.Point(975, 591);
            this.rotateAngle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotateAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rotateAngle.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.rotateAngle.Name = "rotateAngle";
            this.rotateAngle.Size = new System.Drawing.Size(281, 27);
            this.rotateAngle.TabIndex = 21;
            // 
            // rotateX2
            // 
            this.rotateX2.Location = new System.Drawing.Point(975, 528);
            this.rotateX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotateX2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rotateX2.Name = "rotateX2";
            this.rotateX2.Size = new System.Drawing.Size(70, 27);
            this.rotateX2.TabIndex = 22;
            // 
            // rotateY2
            // 
            this.rotateY2.Location = new System.Drawing.Point(1081, 528);
            this.rotateY2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotateY2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rotateY2.Name = "rotateY2";
            this.rotateY2.Size = new System.Drawing.Size(70, 27);
            this.rotateY2.TabIndex = 23;
            // 
            // rotateZ2
            // 
            this.rotateZ2.Location = new System.Drawing.Point(1185, 528);
            this.rotateZ2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotateZ2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rotateZ2.Name = "rotateZ2";
            this.rotateZ2.Size = new System.Drawing.Size(70, 27);
            this.rotateZ2.TabIndex = 24;
            // 
            // rotateLine
            // 
            this.rotateLine.Location = new System.Drawing.Point(1011, 626);
            this.rotateLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotateLine.Name = "rotateLine";
            this.rotateLine.Size = new System.Drawing.Size(191, 32);
            this.rotateLine.TabIndex = 25;
            this.rotateLine.Text = "Применить";
            this.rotateLine.UseVisualStyleBackColor = true;
            this.rotateLine.Click += new System.EventHandler(this.rotateLine_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1084, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Проекция";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1455, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Примитив";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1072, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Смещение";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1455, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Поворот";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(995, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1101, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1206, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "Z";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1585, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.TabIndex = 35;
            this.label8.Text = "Z";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1490, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 20);
            this.label9.TabIndex = 34;
            this.label9.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1384, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "X";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1209, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "Z";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1101, 320);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 20);
            this.label12.TabIndex = 37;
            this.label12.Text = "Y";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(995, 320);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 20);
            this.label13.TabIndex = 36;
            this.label13.Text = "X";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1072, 300);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 20);
            this.label14.TabIndex = 39;
            this.label14.Text = "Масштаб";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1455, 319);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 20);
            this.label15.TabIndex = 40;
            this.label15.Text = "Отражение";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1209, 444);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 20);
            this.label16.TabIndex = 43;
            this.label16.Text = "Z1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1101, 444);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 20);
            this.label17.TabIndex = 42;
            this.label17.Text = "Y1";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(995, 444);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 20);
            this.label18.TabIndex = 41;
            this.label18.Text = "X1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1209, 504);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(26, 20);
            this.label19.TabIndex = 46;
            this.label19.Text = "Z2";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(1101, 504);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(25, 20);
            this.label20.TabIndex = 45;
            this.label20.Text = "Y2";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(995, 504);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 20);
            this.label21.TabIndex = 44;
            this.label21.Text = "X2";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1085, 567);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 20);
            this.label22.TabIndex = 47;
            this.label22.Text = "Угол";
            // 
            // Scale_center
            // 
            this.Scale_center.DecimalPlaces = 1;
            this.Scale_center.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Scale_center.Location = new System.Drawing.Point(1370, 469);
            this.Scale_center.Name = "Scale_center";
            this.Scale_center.Size = new System.Drawing.Size(271, 27);
            this.Scale_center.TabIndex = 48;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1413, 504);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 29);
            this.button1.TabIndex = 49;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(1437, 444);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(125, 20);
            this.label23.TabIndex = 50;
            this.label23.Text = "Масштаб центра";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1704, 866);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Scale_center);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rotateLine);
            this.Controls.Add(this.rotateZ2);
            this.Controls.Add(this.rotateY2);
            this.Controls.Add(this.rotateX2);
            this.Controls.Add(this.rotateAngle);
            this.Controls.Add(this.rotateZ1);
            this.Controls.Add(this.rotateY1);
            this.Controls.Add(this.rotateX1);
            this.Controls.Add(this.reflectionApply);
            this.Controls.Add(this.reflectionBox);
            this.Controls.Add(this.scaleApply);
            this.Controls.Add(this.zScale);
            this.Controls.Add(this.yScale);
            this.Controls.Add(this.xScale);
            this.Controls.Add(this.rotateApply);
            this.Controls.Add(this.zRotate);
            this.Controls.Add(this.yRotate);
            this.Controls.Add(this.xRotate);
            this.Controls.Add(this.displacementApply);
            this.Controls.Add(this.zShift);
            this.Controls.Add(this.yShift);
            this.Controls.Add(this.xShift);
            this.Controls.Add(this.PerspectiveBox);
            this.Controls.Add(this.primitiveButton);
            this.Controls.Add(this.primitivesBox);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xRotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zRotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateZ1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateZ2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Scale_center)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox primitivesBox;
        private System.Windows.Forms.Button primitiveButton;
        private System.Windows.Forms.ComboBox PerspectiveBox;
        private System.Windows.Forms.NumericUpDown xShift;
        private System.Windows.Forms.NumericUpDown yShift;
        private System.Windows.Forms.NumericUpDown zShift;
        private System.Windows.Forms.Button displacementApply;
        private System.Windows.Forms.NumericUpDown xRotate;
        private System.Windows.Forms.NumericUpDown yRotate;
        private System.Windows.Forms.NumericUpDown zRotate;
        private System.Windows.Forms.Button rotateApply;
        private System.Windows.Forms.NumericUpDown xScale;
        private System.Windows.Forms.NumericUpDown yScale;
        private System.Windows.Forms.NumericUpDown zScale;
        private System.Windows.Forms.Button scaleApply;
        private System.Windows.Forms.ComboBox reflectionBox;
        private System.Windows.Forms.Button reflectionApply;
        private System.Windows.Forms.NumericUpDown rotateX1;
        private System.Windows.Forms.NumericUpDown rotateY1;
        private System.Windows.Forms.NumericUpDown rotateZ1;
        private System.Windows.Forms.NumericUpDown rotateAngle;
        private System.Windows.Forms.NumericUpDown rotateX2;
        private System.Windows.Forms.NumericUpDown rotateY2;
        private System.Windows.Forms.NumericUpDown rotateZ2;
        private System.Windows.Forms.Button rotateLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown Scale_center;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label23;
    }
}
