namespace individualgraphics
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
            this.pointButton = new System.Windows.Forms.Button();
            this.doTheThing = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(872, 609);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pointButton
            // 
            this.pointButton.Location = new System.Drawing.Point(893, 221);
            this.pointButton.Name = "pointButton";
            this.pointButton.Size = new System.Drawing.Size(227, 46);
            this.pointButton.TabIndex = 1;
            this.pointButton.Text = "Рисовать точки";
            this.pointButton.UseVisualStyleBackColor = true;
            this.pointButton.Click += new System.EventHandler(this.pointButton_Click);
            // 
            // doTheThing
            // 
            this.doTheThing.Location = new System.Drawing.Point(893, 285);
            this.doTheThing.Name = "doTheThing";
            this.doTheThing.Size = new System.Drawing.Size(227, 46);
            this.doTheThing.TabIndex = 2;
            this.doTheThing.Text = "Получить оболочку";
            this.doTheThing.UseVisualStyleBackColor = true;
            this.doTheThing.Click += new System.EventHandler(this.doTheThing_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 633);
            this.Controls.Add(this.doTheThing);
            this.Controls.Add(this.pointButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button pointButton;
        private System.Windows.Forms.Button doTheThing;
    }
}
