﻿namespace LAB4
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scale_button = new System.Windows.Forms.Button();
            this.rotate_button = new System.Windows.Forms.Button();
            this.shift_button = new System.Windows.Forms.Button();
            this.my_textBox = new System.Windows.Forms.TextBox();
            this.mx_textBox = new System.Windows.Forms.TextBox();
            this.angle_textBox = new System.Windows.Forms.TextBox();
            this.dy_textBox = new System.Windows.Forms.TextBox();
            this.dx_textBox = new System.Windows.Forms.TextBox();
            this.angle_label = new System.Windows.Forms.Label();
            this.my_label = new System.Windows.Forms.Label();
            this.mx_label = new System.Windows.Forms.Label();
            this.dy_label = new System.Windows.Forms.Label();
            this.dx_label = new System.Windows.Forms.Label();
            this.center_button = new System.Windows.Forms.Button();
            this.polygon_button = new System.Windows.Forms.Button();
            this.line_button = new System.Windows.Forms.Button();
            this.point_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.lineRotationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(808, 589);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lineRotationButton);
            this.groupBox1.Controls.Add(this.scale_button);
            this.groupBox1.Controls.Add(this.rotate_button);
            this.groupBox1.Controls.Add(this.shift_button);
            this.groupBox1.Controls.Add(this.my_textBox);
            this.groupBox1.Controls.Add(this.mx_textBox);
            this.groupBox1.Controls.Add(this.angle_textBox);
            this.groupBox1.Controls.Add(this.dy_textBox);
            this.groupBox1.Controls.Add(this.dx_textBox);
            this.groupBox1.Controls.Add(this.angle_label);
            this.groupBox1.Controls.Add(this.my_label);
            this.groupBox1.Controls.Add(this.mx_label);
            this.groupBox1.Controls.Add(this.dy_label);
            this.groupBox1.Controls.Add(this.dx_label);
            this.groupBox1.Controls.Add(this.center_button);
            this.groupBox1.Controls.Add(this.polygon_button);
            this.groupBox1.Controls.Add(this.line_button);
            this.groupBox1.Controls.Add(this.point_button);
            this.groupBox1.Controls.Add(this.clear_button);
            this.groupBox1.Location = new System.Drawing.Point(822, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(166, 535);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // scale_button
            // 
            this.scale_button.Location = new System.Drawing.Point(4, 447);
            this.scale_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scale_button.Name = "scale_button";
            this.scale_button.Size = new System.Drawing.Size(158, 19);
            this.scale_button.TabIndex = 17;
            this.scale_button.Text = "SCALE";
            this.scale_button.UseVisualStyleBackColor = true;
            this.scale_button.Click += new System.EventHandler(this.scale_button_Click);
            // 
            // rotate_button
            // 
            this.rotate_button.Location = new System.Drawing.Point(4, 348);
            this.rotate_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rotate_button.Name = "rotate_button";
            this.rotate_button.Size = new System.Drawing.Size(158, 19);
            this.rotate_button.TabIndex = 16;
            this.rotate_button.Text = "ROTATE";
            this.rotate_button.UseVisualStyleBackColor = true;
            this.rotate_button.Click += new System.EventHandler(this.rotate_button_Click);
            // 
            // shift_button
            // 
            this.shift_button.Location = new System.Drawing.Point(4, 277);
            this.shift_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shift_button.Name = "shift_button";
            this.shift_button.Size = new System.Drawing.Size(158, 19);
            this.shift_button.TabIndex = 15;
            this.shift_button.Text = "SHIFT";
            this.shift_button.UseVisualStyleBackColor = true;
            this.shift_button.Click += new System.EventHandler(this.shift_button_Click);
            // 
            // my_textBox
            // 
            this.my_textBox.Location = new System.Drawing.Point(93, 418);
            this.my_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.my_textBox.Name = "my_textBox";
            this.my_textBox.Size = new System.Drawing.Size(54, 20);
            this.my_textBox.TabIndex = 14;
            this.my_textBox.TextChanged += new System.EventHandler(this.my_textBox_TextChanged);
            // 
            // mx_textBox
            // 
            this.mx_textBox.Location = new System.Drawing.Point(93, 393);
            this.mx_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mx_textBox.Name = "mx_textBox";
            this.mx_textBox.Size = new System.Drawing.Size(54, 20);
            this.mx_textBox.TabIndex = 13;
            this.mx_textBox.TextChanged += new System.EventHandler(this.mx_textBox_TextChanged);
            // 
            // angle_textBox
            // 
            this.angle_textBox.Location = new System.Drawing.Point(98, 318);
            this.angle_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.angle_textBox.Name = "angle_textBox";
            this.angle_textBox.Size = new System.Drawing.Size(55, 20);
            this.angle_textBox.TabIndex = 12;
            this.angle_textBox.TextChanged += new System.EventHandler(this.angle_textBox_TextChanged);
            // 
            // dy_textBox
            // 
            this.dy_textBox.Location = new System.Drawing.Point(93, 248);
            this.dy_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dy_textBox.Name = "dy_textBox";
            this.dy_textBox.Size = new System.Drawing.Size(54, 20);
            this.dy_textBox.TabIndex = 11;
            this.dy_textBox.TextChanged += new System.EventHandler(this.dy_textBox_TextChanged);
            // 
            // dx_textBox
            // 
            this.dx_textBox.Location = new System.Drawing.Point(93, 223);
            this.dx_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dx_textBox.Name = "dx_textBox";
            this.dx_textBox.Size = new System.Drawing.Size(54, 20);
            this.dx_textBox.TabIndex = 10;
            this.dx_textBox.TextChanged += new System.EventHandler(this.dx_textBox_TextChanged);
            // 
            // angle_label
            // 
            this.angle_label.AutoSize = true;
            this.angle_label.BackColor = System.Drawing.SystemColors.HighlightText;
            this.angle_label.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.angle_label.Location = new System.Drawing.Point(17, 318);
            this.angle_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.angle_label.Name = "angle_label";
            this.angle_label.Size = new System.Drawing.Size(81, 18);
            this.angle_label.TabIndex = 9;
            this.angle_label.Text = "Write angle:";
            // 
            // my_label
            // 
            this.my_label.AutoSize = true;
            this.my_label.BackColor = System.Drawing.SystemColors.HighlightText;
            this.my_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.my_label.Location = new System.Drawing.Point(17, 420);
            this.my_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.my_label.Name = "my_label";
            this.my_label.Size = new System.Drawing.Size(67, 17);
            this.my_label.TabIndex = 8;
            this.my_label.Text = "Write my:";
            // 
            // mx_label
            // 
            this.mx_label.AutoSize = true;
            this.mx_label.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mx_label.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mx_label.Location = new System.Drawing.Point(17, 393);
            this.mx_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mx_label.Name = "mx_label";
            this.mx_label.Size = new System.Drawing.Size(66, 18);
            this.mx_label.TabIndex = 7;
            this.mx_label.Text = "Write mx:";
            // 
            // dy_label
            // 
            this.dy_label.AutoSize = true;
            this.dy_label.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dy_label.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dy_label.Location = new System.Drawing.Point(17, 249);
            this.dy_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dy_label.Name = "dy_label";
            this.dy_label.Size = new System.Drawing.Size(63, 18);
            this.dy_label.TabIndex = 6;
            this.dy_label.Text = "Write dy:";
            // 
            // dx_label
            // 
            this.dx_label.AutoSize = true;
            this.dx_label.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dx_label.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dx_label.Location = new System.Drawing.Point(17, 223);
            this.dx_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dx_label.Name = "dx_label";
            this.dx_label.Size = new System.Drawing.Size(62, 18);
            this.dx_label.TabIndex = 5;
            this.dx_label.Text = "Write dx:";
            // 
            // center_button
            // 
            this.center_button.Location = new System.Drawing.Point(4, 167);
            this.center_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.center_button.Name = "center_button";
            this.center_button.Size = new System.Drawing.Size(158, 19);
            this.center_button.TabIndex = 4;
            this.center_button.Text = "CENTER";
            this.center_button.UseVisualStyleBackColor = true;
            this.center_button.Click += new System.EventHandler(this.center_button_Click);
            // 
            // polygon_button
            // 
            this.polygon_button.Location = new System.Drawing.Point(4, 131);
            this.polygon_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.polygon_button.Name = "polygon_button";
            this.polygon_button.Size = new System.Drawing.Size(158, 19);
            this.polygon_button.TabIndex = 3;
            this.polygon_button.Text = "POLYGON";
            this.polygon_button.UseVisualStyleBackColor = true;
            this.polygon_button.Click += new System.EventHandler(this.polygon_button_Click);
            // 
            // line_button
            // 
            this.line_button.Location = new System.Drawing.Point(4, 107);
            this.line_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.line_button.Name = "line_button";
            this.line_button.Size = new System.Drawing.Size(158, 19);
            this.line_button.TabIndex = 2;
            this.line_button.Text = "LINE";
            this.line_button.UseVisualStyleBackColor = true;
            this.line_button.Click += new System.EventHandler(this.line_button_Click);
            // 
            // point_button
            // 
            this.point_button.Location = new System.Drawing.Point(4, 84);
            this.point_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.point_button.Name = "point_button";
            this.point_button.Size = new System.Drawing.Size(158, 19);
            this.point_button.TabIndex = 1;
            this.point_button.Text = "POINT";
            this.point_button.UseVisualStyleBackColor = true;
            this.point_button.Click += new System.EventHandler(this.point_button_Click);
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(4, 29);
            this.clear_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(158, 20);
            this.clear_button.TabIndex = 0;
            this.clear_button.Text = "CLEAR";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // lineRotationButton
            // 
            this.lineRotationButton.Location = new System.Drawing.Point(5, 471);
            this.lineRotationButton.Name = "lineRotationButton";
            this.lineRotationButton.Size = new System.Drawing.Size(161, 19);
            this.lineRotationButton.TabIndex = 2;
            this.lineRotationButton.Text = "ROTATE LINE";
            this.lineRotationButton.UseVisualStyleBackColor = true;
            this.lineRotationButton.Click += new System.EventHandler(this.lineRotationButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 609);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button center_button;
        private System.Windows.Forms.Button polygon_button;
        private System.Windows.Forms.Button line_button;
        private System.Windows.Forms.Button point_button;
        private System.Windows.Forms.Label dy_label;
        private System.Windows.Forms.Label dx_label;
        private System.Windows.Forms.Label my_label;
        private System.Windows.Forms.Label mx_label;
        private System.Windows.Forms.Label angle_label;
        private System.Windows.Forms.TextBox dx_textBox;
        private System.Windows.Forms.TextBox dy_textBox;
        private System.Windows.Forms.TextBox angle_textBox;
        private System.Windows.Forms.TextBox my_textBox;
        private System.Windows.Forms.TextBox mx_textBox;
        private System.Windows.Forms.Button shift_button;
        private System.Windows.Forms.Button rotate_button;
        private System.Windows.Forms.Button scale_button;
        private System.Windows.Forms.Button lineRotationButton;
    }
}
