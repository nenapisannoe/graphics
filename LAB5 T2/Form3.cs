using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB5_T2
{
    public partial class Form3 : Form
    {
        Bitmap bitmap;

        Color itemsCol_1;
        Pen LinePen_1;

        Random rand;

        List<PointF> Points;

        double R;
        PointF p1;
        PointF p2;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;

            itemsCol_1 = Color.Blue;
            LinePen_1 = new Pen(itemsCol_1, 4);

            rand = new Random();

            Points = new List<PointF>();

            R = Convert.ToDouble(numericUpDown3.Value.ToString()) / 10;
            p1 = new PointF(0, pictureBox1.Height - Convert.ToInt32(numericUpDown1.Value.ToString()));
            p2 = new PointF(pictureBox1.Width, pictureBox1.Height - Convert.ToInt32(numericUpDown2.Value.ToString()));

        }

        private double Distance(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private void Midpoint_Displacement_Recur(PointF p1, PointF p2, double R)
        {
            if (p2.X - p1.X <= 1)
            {
                return;
            }

            PointF res = new PointF(0, 0);

            double l = Distance(p1, p2);

            res.X = (p1.X + p2.X) / 2;
            res.Y = ((p1.Y + p2.Y) / 2) + rand.Next((int)(-R * l), (int)(R * l));

            if (res.Y < 0)
            {
                res.Y = 0;
            }

            if (res.Y > pictureBox1.Height)
            {
                res.Y = pictureBox1.Height;
            }

            Points.Add(res);

            Midpoint_Displacement_Recur(p1, res, R);
            Midpoint_Displacement_Recur(res, p2, R);
        }

        public static int CompareByX(PointF p1, PointF p2)
        {
            return p1.X.CompareTo(p2.X);
        }

        private void DrawSceneRecur(Bitmap pic)
        {
            Points.Clear();

            Graphics g = Graphics.FromImage(pic);
            g.Clear(Color.Transparent);

            Points.Add(p1);
            Points.Add(p2);

            Midpoint_Displacement_Recur(p1, p2, R);

            Points.Sort(CompareByX);

            for (int i = 0; i < Points.Count() - 1; i++)
            {
                g.DrawLine(LinePen_1, Points[i], Points[i + 1]);
            }

            g.DrawLine(LinePen_1, Points[Points.Count() - 2], p2);

            Points.Clear();

            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawSceneRecur(bitmap);
        }

        private void Midpoint_Displacement_Iter(PointF p1, PointF p2, double R)
        {
            if (p2.X - p1.X <= 1)
            {
                return;
            }

            PointF res = new PointF(0, 0);

            double l = Distance(p1, p2);

            res.X = (p1.X + p2.X) / 2;
            res.Y = ((p1.Y + p2.Y) / 2) + rand.Next((int)(-R * l), (int)(R * l));

            if (res.Y < 0)
            {
                res.Y = 0;
            }

            if (res.Y > pictureBox1.Height)
            {
                res.Y = pictureBox1.Height;
            }

            Points.Add(res);
        }

        private void DrawSceneIter(Bitmap pic)
        {
            Graphics g = Graphics.FromImage(pic);
            g.Clear(Color.Transparent);

            if (Points.Count == 0)
            {
                Points.Add(p1);
                Points.Add(p2);
            }

            int prev_count = Points.Count() - 1;

            for (int i = 0; i < prev_count; i++)
            {
                Midpoint_Displacement_Iter(Points[i], Points[i + 1], R);
            }

            Points.Sort(CompareByX);

            for (int i = 0; i < Points.Count() - 1; i++)
            {
                g.DrawLine(LinePen_1, Points[i], Points[i + 1]);
            }

            g.DrawLine(LinePen_1, Points[Points.Count() - 2], Points[Points.Count() - 1]);

            pictureBox1.Refresh();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            DrawSceneIter(bitmap);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            p1 = new PointF(0, pictureBox1.Height - Convert.ToInt32(numericUpDown1.Value.ToString()));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            p2 = new PointF(pictureBox1.Width, pictureBox1.Height - Convert.ToInt32(numericUpDown2.Value.ToString()));
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            R = Convert.ToDouble(numericUpDown3.Value.ToString()) / 10;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            Points.Clear();
            pictureBox1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int h1 = pictureBox1.Height - rand.Next(0, pictureBox1.Height);
            int h2 = pictureBox1.Height - rand.Next(0, pictureBox1.Height);

            p1 = new PointF(0, h1);
            p2 = new PointF(pictureBox1.Width, h2);

            numericUpDown1.Value = h1;
            numericUpDown2.Value = h2;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
