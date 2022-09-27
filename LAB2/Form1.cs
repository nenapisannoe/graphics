using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Form1 : Form
    {

        private static Bitmap img1, img2, img3;
        List<int> list_of_red, list_of_green, list_of_blue;

        public Form1()
        {
            InitializeComponent();
        }

        // разделяем по цветам и строим гистограммы
        private void diff_rgb_and_charts()
        {
            // задаём автоподстраивание под размер pictureBox
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;

            // картинка в pictureBox
            pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
            img1 = new Bitmap(openFileDialog1.FileName, true);
            img2 = new Bitmap(openFileDialog1.FileName, true);
            img3 = new Bitmap(openFileDialog1.FileName, true);
            pictureBox2.Image = img1;
            pictureBox3.Image = img2;
            pictureBox4.Image = img3;

            // списки для значений цветов
            list_of_red = new List<int>();
            list_of_green = new List<int>();
            list_of_blue = new List<int>();
            for (int i = 0; i < 256; i++)
            {
                list_of_red.Add(0);
                list_of_green.Add(0);
                list_of_blue.Add(0);
            }

            // заполняем списки значений цветов
            for (int x = 0; x < img1.Width; x++)
                for (int y = 0; y < img1.Height; y++) 
                {
                    var pixel_clr = img1.GetPixel(x, y);

                    // красный имеет значение, зеленый и синий по нулям
                    var set_clr = Color.FromArgb(pixel_clr.R, 0, 0); 
                    img1.SetPixel(x, y, set_clr);

                    // красный имеет значение, зеленый и синий по нулям
                    set_clr = Color.FromArgb(0, pixel_clr.G, 0);
                    img2.SetPixel(x, y, set_clr);

                    // красный имеет значение, зеленый и синий по нулям
                    set_clr = Color.FromArgb(0, 0, pixel_clr.B);
                    img3.SetPixel(x, y, set_clr);

                    list_of_red[pixel_clr.R]++;
                    list_of_green[pixel_clr.G]++;
                    list_of_blue[pixel_clr.B]++;
                }

            chart1.Series["Series1"].Points.Clear();
            chart2.Series["Series1"].Points.Clear();
            chart3.Series["Series1"].Points.Clear();

            for (int i = 0; i < 256; i++)
            {
                chart1.Series["Series1"].Points.Add(list_of_red[i]);
                chart2.Series["Series1"].Points.Add(list_of_green[i]);
                chart3.Series["Series1"].Points.Add(list_of_blue[i]);
            }

            chart1.Update();
            chart2.Update();
            chart3.Update();
        }

        // выбираем картинку
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            diff_rgb_and_charts();
        }
    }
}
