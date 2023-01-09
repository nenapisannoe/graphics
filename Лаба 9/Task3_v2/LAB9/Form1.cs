using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB9
{ 
    public partial class Form1 : Form
    {
        // вспомогательные переменные для изменения обзора
        double fi1 = 80 * 0.0174532925;  
        double fi2 = 340 * 0.0174532925;
        int last = 0;
        int upDown = 80;
        int leftRight = 340;

        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(700, 500);
        }

        // нижняя и верхняя граница горизонта
        List<double> maxB;
        List<double> minB;

        // плавающий горизонт
        void draw_graphic(int num)
        {
            bmp = new Bitmap(700, 500);
            maxB = new List<double>(710);
            minB = new List<double>(710);
            List<PointF> predLine = new List<PointF>(40);
            List<PointF> currentLine = new List<PointF>(40);

            // заполняем границы горизонта
            for (int i = 0; i < 710; i++)
            {
                maxB.Add(0);
                minB.Add(500);
            }

            for (double y = -6; y < 6; y += 0.15)
            {
                currentLine = new List<PointF>(40);
                for (double x = -6; x < 6; x += 0.15)
                {
                    double func;
                    switch (num)
                    {
                        case 1:
                            func = Math.Cos(Math.Sqrt(x * x + y * y));
                            break;
                        case 2:
                            func = (0.5) * Math.Cos(Math.Sqrt(x * x + y * y));
                            break;
                        case 3:
                            func = 5 * (Math.Cos(x * x + y * y + 1) / (x * x + y * y + 1) + 0.1);
                            break;
                        default:
                            func = 0;
                            break;
                    }

                    //отображение координат
                    double fx = x * Math.Cos(fi2) - (-Math.Sin(fi1) * y + Math.Cos(fi1) * func) * Math.Sin(fi2);
                    double fy = y * Math.Cos(fi1) + func * Math.Sin(fi1);
                    double fz = (-Math.Sin(fi1) * y + Math.Cos(fi1) * func);

                    //отображение графика на pictureBox1
                    int x2 = (int)Math.Round(fx * 50 + (bmp.Width / 2));
                    int y2 = (int)Math.Round(fy * 50 + (bmp.Height / 2));

                    currentLine.Add(new Point(x2, y2));

                    //рисует линии по горизонтали
                    if (currentLine.Count > 1)
                        DrawLine(currentLine[currentLine.Count - 1], currentLine[currentLine.Count - 2]);

                    //рисует соединяющие линии для создания сетки
                    if (predLine.Count > 0)
                    {
                        DrawLine(currentLine[currentLine.Count - 1], predLine[currentLine.Count - 1]);
                        if (predLine.Count > 1 && currentLine.Count > 1)
                            DrawLine(currentLine[currentLine.Count - 2], predLine[currentLine.Count - 2]);
                    }

                }
                predLine = currentLine;
            }
            pictureBox1.Image = bmp;
        }

        // алгоритм Брезенхэма
        void DrawLine(PointF LineP1, PointF LineP2)
        {
            var step = Math.Abs(LineP2.Y - LineP1.Y) > Math.Abs(LineP2.X - LineP1.X);
            if (step)
            {
                int k = (int)LineP1.X;
                LineP1.X = LineP1.Y;
                LineP1.Y = (float)k;

                k = (int)LineP2.X;
                LineP2.X = LineP2.Y;
                LineP2.Y = (float)k;
            }

            if (LineP1.X > LineP2.X)
            {
                int k = (int)LineP1.X;
                LineP1.X = LineP2.X;
                LineP2.X = (float)k;

                k = (int)LineP1.Y;
                LineP1.Y = LineP2.Y;
                LineP2.Y = (float)k;
            }

            // переносим в начало коор-нат
            float dx = LineP2.X - LineP1.X;
            float dy = LineP2.Y - LineP1.Y;

            float gradient = dy / dx;
            float y = LineP1.Y + gradient;

            for (int x = (int)LineP1.X + 1; x < LineP2.X; x++)
            {
                // если угол наклона слишком большой
                int x1 = step ? (int)Math.Round(y) : x;
                int x2 = step ? (int)Math.Round(y) : x;
                int y1 = step ? x : (int)Math.Round(y);
                int y2 = step ? x : (int)Math.Round(y + 1);

                // считаем ошибку
                x1 = Math.Max(Math.Min(x1, bmp.Width - 1), 0);
                x2 = Math.Max(Math.Min(x2, bmp.Width - 1), 0);
                y1 = Math.Max(Math.Min(y1, bmp.Height - 1), 0);
                y2 = Math.Max(Math.Min(y2, bmp.Height - 1), 0);

                //maxB minB - ячейки сетки
                if ((y1 >= maxB[x1] && y2 >= maxB[x2]))
                {
                    bmp.SetPixel(x2, y2, Color.DarkOrange);
                    maxB[x1] = y1;
                    maxB[x2] = y2;
                }
                if (y1 <= minB[x1] && y2 <= minB[x2])
                {
                    bmp.SetPixel(x1, y1, Color.DarkTurquoise);
                    bmp.SetPixel(x2, y2, Color.DarkTurquoise);
                    minB[x1] = y1;
                    minB[x2] = y2;
                }

                // возвращаем на место оси
                maxB[x1] = Math.Max(y1, maxB[x1]);
                minB[x1] = Math.Min(y1, minB[x1]);
                maxB[x2] = Math.Max(y2, maxB[x2]);
                minB[x2] = Math.Min(y2, minB[x2]);

                y = y + gradient;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                last = 2;
                draw_graphic(2);
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                last = 1;
                draw_graphic(1);
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                last = 3;
                draw_graphic(3);
                checkBox2.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                leftRight += 10;
                fi2 = leftRight * 0.0174532925;
                draw_graphic(last);
            }
            else if (e.KeyCode == Keys.D)
            {
                leftRight -= 10;
                fi2 = leftRight * 0.0174532925;
                draw_graphic(last);
            }
            else if (e.KeyCode == Keys.W)
            {
                upDown += 10;
                fi1 = upDown * 0.0174532925;
                draw_graphic(last);
            }
            else if (e.KeyCode == Keys.S)
            {
                upDown -= 10;
                fi1 = upDown * 0.0174532925;
                draw_graphic(last);
            }
        }
    }
}
