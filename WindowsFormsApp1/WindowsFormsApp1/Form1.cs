using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<int> pixels, pixels2;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(openDialog.FileName);

                pictureBox1.Image = bmp;
                Bitmap bmp1 = (Bitmap)bmp.Clone();
                Bitmap bmp2 = (Bitmap)bmp.Clone();

                pixels = new List<int>();
                pixels2 = new List<int>();

                for (int i = 0; i < 256; ++i)
                {
                    pixels.Add(0);
                    pixels2.Add(0);
                }

                equalGrey(bmp1);
                differentGrey(bmp2);
                imageDifference((Bitmap)bmp1.Clone(), (Bitmap)bmp2.Clone());
                Histogram();
            }
        }

        private void equalGrey(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; ++i)
                for (int j = 0; j < bmp.Height; ++j)
                {
                    Color pixelColor = bmp.GetPixel(i, j);

                    int colorGray = (pixelColor.R + pixelColor.B + pixelColor.G) / 3;
                    pixels[colorGray]++;

                    Color newColor = Color.FromArgb(colorGray, colorGray, colorGray);
                    bmp.SetPixel(i, j, newColor);
                }

            pictureBox2.Image = bmp;
        }

        private void differentGrey(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; ++i)
                for (int j = 0; j < bmp.Height; ++j)
                {
                    Color pixelColor = bmp.GetPixel(i, j);

                    int colorGray = (int)(0.2126 * pixelColor.R + 0.7152 * pixelColor.G + 0.0722 * pixelColor.B);
                    pixels2[colorGray]++;

                    Color newColor = Color.FromArgb(colorGray, colorGray, colorGray);
                    bmp.SetPixel(i, j, newColor);
                }

            pictureBox3.Image = bmp;
        }

        private void imageDifference(Bitmap bmp1, Bitmap bmp2)
        {
            Bitmap bmp3 = (Bitmap)bmp2.Clone();

            for (int i = 0; i < bmp3.Width; ++i)
                for (int j = 0; j < bmp3.Height; ++j)
                {
                    Color pixelColor = bmp1.GetPixel(i, j);
                    Color pixelColor2 = bmp2.GetPixel(i, j);
                    byte colorGray = (byte)Math.Abs(pixelColor.R - pixelColor2.R + pixelColor.G - pixelColor2.G + pixelColor.B - pixelColor2.B);

                    Color newColor = Color.FromArgb(colorGray, colorGray, colorGray);
                    bmp3.SetPixel(i, j, newColor);
                }

            pictureBox4.Image = bmp3;
        }

        private void Histogram()
        {
            chart1.Series["equalG"].Points.Clear();
            chart1.Series["differentG"].Points.Clear();

            for (int i = 0; i < 256; ++i)
            {
                chart1.Series["equalG"].Points.AddY(pixels[i]);
                chart1.Series["differentG"].Points.AddY(pixels2[i]);
            }
            chart1.Update();
        }
    }
}
