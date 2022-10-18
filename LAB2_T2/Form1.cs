using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2_T2
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        Pen clear;
        PointF left, right;
        Thread thr;

        public Form1()
        {
            // обычная инициализация всех объектов
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pen = new Pen(Color.ForestGreen, 3);
            clear = new Pen(Color.White, 3);
            g = Graphics.FromImage(pictureBox1.Image);
            left = new PointF(0, pictureBox1.Height - pictureBox1.Height / 4);
            right = new PointF(pictureBox1.Width-1, pictureBox1.Height - pictureBox1.Height/4);
            g.DrawLine(pen, left, right);
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            // очистка экрана
            g.Clear(pictureBox1.BackColor);
            g.DrawLine(pen, left, right);
            pictureBox1.Refresh();
        }

        private void build_mountain()
        {
            // для красивого показа пошагового рисования
            Thread.Sleep(100);
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            // парсим значения из textbox - левая и правая границы и шероховатость
            double hl = double.Parse(text_box_HL.Text);
            double hr = double.Parse(text_box_HR.Text);
            double R = double.Parse(textBox_R.Text);

            // первый шаг - выбрали случайное значение высоты
            g.DrawLine(clear, left, right);
            Random rnd = new Random();

            // создаём очередь из точек - на каждом шаге будем перерасчитывать их значение
            Queue<Tuple<Tuple<PointF, double>, Tuple<PointF, double>>> q = new Queue<Tuple<Tuple<PointF, double>, Tuple<PointF, double>>>();
            // добавляем первую точку - значение по умолчанию и границы для горы
            q.Enqueue(new Tuple<Tuple<PointF, double>, Tuple<PointF, double>>(new Tuple<PointF, double>(left, hl), new Tuple<PointF, double>(right, hr)));

            // цикл пока есть точки в очереди
            while(q.Count > 0)
            {
                // текущий сегмент - достаём точку из очереди
                var cur_segment = q.Dequeue();
                // длина сегмента - разница по координате Х
                double cur_len = (double)(cur_segment.Item2.Item1.X - cur_segment.Item1.Item1.X); 
                if (cur_len <= 3)
                    continue;

                // ищем середину сегмента и нужную высоту по формуле
                PointF middle = new PointF((float)((cur_segment.Item1.Item1.X + cur_segment.Item2.Item1.X) / 2.0), left.Y);
                double h_middle = (cur_segment.Item1.Item2 + cur_segment.Item2.Item2) / 2.0 + (-R * cur_len * 0.2 + rnd.NextDouble() * 2 * cur_len * 0.2 * R);

                // рисуем 3 линии - сначала очищаем, потом рисуем 2 новых, в соответствии с высотой h_middle
                g.DrawLine(clear, new PointF(cur_segment.Item1.Item1.X, cur_segment.Item1.Item1.Y - (float)cur_segment.Item1.Item2),
                    new PointF(cur_segment.Item2.Item1.X, cur_segment.Item2.Item1.Y - (float)cur_segment.Item2.Item2));
                // от левой границы до высоты
                g.DrawLine(pen, new PointF(cur_segment.Item1.Item1.X, cur_segment.Item1.Item1.Y - (float)cur_segment.Item1.Item2),
                    new PointF(middle.X, middle.Y - (float)h_middle));
                // от высоты до правой границы
                g.DrawLine(pen, new PointF(middle.X, middle.Y - (float)h_middle),
                    new PointF(cur_segment.Item2.Item1.X, cur_segment.Item2.Item1.Y - (float)cur_segment.Item2.Item2));

                // показываем по шагам каждое перерисовывание
                pictureBox1.Invalidate();
                thr = new System.Threading.Thread(build_mountain);
                thr.Start();
                thr.Join();
                thr.Abort();

                // добавляем новые точки в очередь
                var mid = new Tuple<PointF, double>(middle, h_middle);
                // сегмент по Х и высота
                q.Enqueue(new Tuple<Tuple<PointF, double>, Tuple<PointF, double>>(cur_segment.Item1, mid));
                // сегмент по Y и высота
                q.Enqueue(new Tuple<Tuple<PointF, double>, Tuple<PointF, double>>(mid, cur_segment.Item2));
            }
        }
    }
}
