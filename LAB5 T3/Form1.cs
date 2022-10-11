using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB5_T3
{
    public partial class Form1 : Form
    {
        Graphics g;

        double search_rad = 10.0;
        int p_rad = 5;

        int p_move = -1;
        List<Point> points = new List<Point>();
        List<Point> curve_points = new List<Point>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            RedrawScene();
        }

        private void RedrawScene()
        {
            g.Clear(Color.White);
            draw_points();
            draw_curves();
            pictureBox1.Refresh();
        }

        private void draw_points()
        {
            if (points.Count == 0)
                return;
            foreach (var p in points)
                g.DrawEllipse(new Pen(Color.DarkOrange), p.X - p_rad, p.Y - p_rad, p_rad * 2, p_rad * 2);
            if (points.Count() > 1)
                g.DrawLines(new Pen(Color.DarkOrange), points.ToArray());
        }

        private void draw_curves()
        {
            if (curve_points.Count > 1)
                g.DrawLines(new Pen(Color.Black), curve_points.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points.Clear();
            curve_points.Clear();
            p_move = -1;
            RedrawScene();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var m = (MouseEventArgs)e;
            var p_near = ind_point_in_rad(m.Location);
            if (p_near == -1)
            {
                add_point(m.Location);
                return;
            }
        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            var m = (MouseEventArgs)e;
            var p_near = ind_point_in_rad(m.Location);
            if (p_near != -1)
                delete_point(p_near);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            var p_near = ind_point_in_rad(e.Location);
            if (p_near == -1)
                return;
            p_move = p_near;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            p_move = -1;
            make_curves();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (p_move == -1)
                return;
            points[p_move] = e.Location;
            make_curves();
            RedrawScene();
        }

        private void add_point(Point p)
        {
            points.Add(p);
            make_curves();
            RedrawScene();
        }

        private void delete_point(int index)
        {
            points.RemoveAt(index);
            make_curves();
            RedrawScene();
        }

        private int ind_point_in_rad(Point p)
        {
            int result = -1;
            double min = int.MaxValue;

            for (int i = 0; i < points.Count(); i++)
            {
                var tmp_rad = Math.Sqrt((points[i].X - p.X) * (points[i].X - p.X) + (points[i].Y - p.Y) * (points[i].Y - p.Y));
                if (tmp_rad < search_rad && tmp_rad < min)
                {
                    result = i;
                    min = tmp_rad;
                }
            }

            return result;
        }

        private void make_curves()
        {
            curve_points.Clear();
            if (points.Count() < 3)
                return;
            if (points.Count() == 3)
            {
                curve(points[0], points[1], points[1], points[2]);
                return; 
            }
            curve(points[0], points[1], points[2], points[3]);
            for (int i = 3; i < points.Count(); i += 3)
            {
                if (i + 3 == points.Count())
                    curve(points[i], points[i + 1], points[i + 1], points[i + 2]);
                if (i + 3 < points.Count())
                    curve(points[i], points[i + 1], points[i + 2], points[i + 3]);
            }
        }

        private void curve(Point p0, Point p1, Point p2, Point p3)
        {
            for (double t = 0.0; t <= 1; t += 0.01)
            {
                double t_cubic = Math.Pow(t, 3);
                double t_double = Math.Pow(t, 2);
                double xb = t_cubic * (3 * p1.X - p0.X - 3 * p2.X + p3.X) + t_double * (3 * p0.X - 6 * p1.X + 3 * p2.X) + t * (3 * p1.X - 3 * p0.X) + p0.X;
                double yb = t_cubic * (3 * p1.Y - p0.Y - 3 * p2.Y + p3.Y) + t_double * (3 * p0.Y - 6 * p1.Y + 3 * p2.Y) + t * (3 * p1.Y - 3 * p0.Y) + p0.Y;
                curve_points.Add(new Point((int)xb, (int)yb));
            }
        }
    }
}
