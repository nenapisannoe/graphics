namespace LAB2_T2
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
            this.text_box_HR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_R = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.text_box_HL = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1078, 737);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // text_box_HR
            // 
            this.text_box_HR.Location = new System.Drawing.Point(134, 145);
            this.text_box_HR.Name = "text_box_HR";
            this.text_box_HR.Size = new System.Drawing.Size(72, 22);
            this.text_box_HR.TabIndex = 2;
            this.text_box_HR.Text = "10";
            this.text_box_HR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Левая точка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Правая точка";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Шероховатость";
            // 
            // textBox_R
            // 
            this.textBox_R.Location = new System.Drawing.Point(134, 194);
            this.textBox_R.Name = "textBox_R";
            this.textBox_R.Size = new System.Drawing.Size(72, 22);
            this.textBox_R.TabIndex = 6;
            this.textBox_R.Text = "1";
            this.textBox_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_start.Location = new System.Drawing.Point(67, 325);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(103, 38);
            this.button_start.TabIndex = 7;
            this.button_start.Text = "Построить";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(67, 381);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(103, 38);
            this.clear_button.TabIndex = 8;
            this.clear_button.Text = "Очистить ";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // text_box_HL
            // 
            this.text_box_HL.Location = new System.Drawing.Point(134, 102);
            this.text_box_HL.Name = "text_box_HL";
            this.text_box_HL.Size = new System.Drawing.Size(72, 22);
            this.text_box_HL.TabIndex = 10;
            this.text_box_HL.Text = "10";
            this.text_box_HL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.clear_button);
            this.groupBox1.Controls.Add(this.text_box_HL);
            this.groupBox1.Controls.Add(this.button_start);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_R);
            this.groupBox1.Controls.Add(this.text_box_HR);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(1085, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 470);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 743);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox text_box_HR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_R;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.TextBox text_box_HL;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

