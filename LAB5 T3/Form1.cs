using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB5_T3
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private List<Point> points;
        private Point p;
        int p_rad = 5;
        private bool isCurveDrawn = false;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            points = new List<Point>();
            comboBox1.SelectedIndex = 0;
        }

        private void redraw_points()
        {
            g.Clear(Color.White);
            for (int i = 0; i < points.Count; ++i)
                g.FillEllipse(Brushes.Black, points[i].X - p_rad, points[i].Y - p_rad, p_rad * 2, p_rad * 2);
            pictureBox1.Invalidate();
        }

        private void add_point(Point p, int ind)
        {
            if (ind == -1)
                points.Add(p);
            else points.Insert(ind, p);

            g.FillEllipse(Brushes.Black, p.X - p_rad, p.Y - p_rad, p_rad * 2, p_rad * 2);
            pictureBox1.Invalidate();
        }

        private int remove_point(Point p)
        {
            int ind = 0;
            while (ind < points.Count && !(Math.Abs(points[ind].X - p.X) < 5 && Math.Abs(points[ind].Y - p.Y) < 5))
                ++ind;

            if (ind < points.Count)
            {
                points.RemoveAt(ind);
                redraw_points();
            }
            else return -1;

            return ind;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                add_point(e.Location, -1);
                if (isCurveDrawn)
                {
                    redraw_points();
                    draw_composite_Bezier_curve();
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                remove_point(e.Location);
                if (isCurveDrawn)
                {
                    redraw_points();
                    draw_composite_Bezier_curve();
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
                p = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 2 && e.Location != p)
            {
                int ind = remove_point(p);
                if (ind == -1)
                    return;
                add_point(e.Location, ind);
                if (isCurveDrawn)
                {
                    redraw_points();
                    draw_composite_Bezier_curve();
                }
            }
        }

        private void DrawCurveBtn_Click(object sender, EventArgs e)
        {
            draw_composite_Bezier_curve();
            isCurveDrawn = true;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            isCurveDrawn = false;
            points.Clear();
            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }

        private void draw_Bezier_curve(Point p0, Point p1, Point p2)
        {
            Point p1_1 = new Point(p0.X + 2 * (p1.X - p0.X) / 3, p0.Y + 2 * (p1.Y - p0.Y) / 3);
            Point p1_2 = new Point(p1.X + (p2.X - p1.X) / 3, p1.Y + (p2.Y - p1.Y) / 3);

            draw_Bezier_curve(p0, p1_1, p1_2, p2);
        }

        private void draw_Bezier_curve(Point p0, Point p1, Point p2, Point p3)
        {
            Point[] V = new Point[4] { p0, p1, p2, p3 };
            int[,] M = new int[4, 4] { { 1, -3, 3, -1 },
                                       { 0, 3, -6, 3 },
                                       { 0, 0, 3, -3 },
                                       { 0, 0, 0, 1 } };
            float[] T = new float[4];

            Point[] VM = new Point[4] { new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0) };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    VM[i].X += V[j].X * M[j, i];
                    VM[i].Y += V[j].Y * M[j, i];
                }

            for (float t = 0; t <= 1; t += (float)0.001)
            {
                T[0] = 1;
                T[1] = t;
                T[2] = t * t;
                T[3] = t * t * t;
                PointF VMT = new PointF(0, 0);
                for (int i = 0; i < 4; i++)
                {
                    VMT.X += VM[i].X * T[i];
                    VMT.Y += VM[i].Y * T[i];
                }
                (pictureBox1.Image as Bitmap).SetPixel((int)VMT.X, (int)VMT.Y, Color.DarkOrange);
            }

            g.DrawLine(Pens.Black, p0, p1);
            g.DrawLine(Pens.Black, p1, p2);
            g.DrawLine(Pens.Black, p2, p3);

            pictureBox1.Invalidate();
        }

        private void draw_composite_Bezier_curve()
        {
            if (points.Count < 2)
                return;

            if (points.Count == 2)
            {
                g.DrawLine(Pens.DarkOrange, points[0], points[1]);
                pictureBox1.Invalidate();
                return;
            }

            Point prev, next;
            prev = points[0];

            for (int i = 0; i < points.Count - 4; i += 2)
            {
                next = new Point((points[i + 2].X + points[i + 3].X) / 2, (points[i + 2].Y + points[i + 3].Y) / 2);
                draw_Bezier_curve(prev, points[i + 1], points[i + 2], next);
                prev = next;
            }

            if (points.Count % 2 == 0)
                draw_Bezier_curve(prev, points[points.Count - 3], points[points.Count - 2], points[points.Count - 1]);
            else draw_Bezier_curve(prev, points[points.Count - 2], points[points.Count - 1]);
        }
    }
}