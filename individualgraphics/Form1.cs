using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace individualgraphics
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();
        Point currentPoint;
        int point_radius = 5;
        Graphics g;
        Bitmap bitmap;
        Point p0;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);

            pictureBox1.Image = bitmap;
        }

        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        private void DrawPoint(int x, int y, int r)
        {
            g.FillEllipse(new SolidBrush(Color.Aquamarine), x - r, y - r, 2 * r, 2 * r);
            pictureBox1.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(!pointButton.Enabled)
            {
                var mouse_ev = (MouseEventArgs)e;
                if (!pointButton.Enabled)
                {
                    currentPoint = mouse_ev.Location;
                    DrawPoint(currentPoint.X, currentPoint.Y, point_radius);
                    points.Add(currentPoint);
                    System.Diagnostics.Debug.Write(currentPoint.X);
                    System.Diagnostics.Debug.Write(", ");
                    System.Diagnostics.Debug.WriteLine(currentPoint.Y);
                }
            }
        }

        private void pointButton_Click(object sender, EventArgs e)
        {
            pointButton.Enabled = !pointButton.Enabled;
        }

        private int Rotate(Point A, Point B, Point C)
        {
            return (B.X - A.X) * (C.Y - B.Y) - (B.Y - A.Y) * (C.X - B.X);
        }
        double alpha(Point t)   
        {
            t.X -= p0.X;
            t.Y = p0.Y - t.Y;
            double alph;
            if (t.X == 0) alph = Math.PI / 2;
            else
            {

                if (t.Y == 0) alph = 0;
                else alph = Math.Atan(Convert.ToDouble(t.Y) / Convert.ToDouble(t.X));
                if (t.X < 0) alph += Math.PI;

            }
            return alph;
        }

        double GetPolarAngle(Point p)
        {
            return Math.Atan2(p.Y - p0.Y, p.X - p0.X);
        }
        private List<Point> Graham()
        {
            p0 = points[0];
            int n = points.Count;
            List<int> pointInd = new List<int>();
            for (int i = 0; i < n; i++)
            {
                pointInd.Add(i);
            }
            for (int i = 0; i < n; i++)
            {
                if (points[i].Y > points[0].Y)
                {
                    p0 = points[i];
                    Swap(points, i, 0);
                }
            }
            System.Diagnostics.Debug.Write("/");
            System.Diagnostics.Debug.Write(p0.X);
            System.Diagnostics.Debug.Write(", ");
            System.Diagnostics.Debug.WriteLine(p0.Y);
            for (int i = 1; i < n; i++)
            {
                int j = i;
                while (j > 1 && GetPolarAngle(points[j - 1]) < GetPolarAngle(points[j]))
                {
                    Swap(points, j - 1, j);
                    j--;
                }
            }
            List<Point> s = new List<Point>() { points[0], points[1] };
            for (int i = 0; i < n; i++)
            {
                while (Rotate(s[s.Count - 2], s[s.Count - 1], points[i]) > 0)
                {
                    s.RemoveAt(s.Count - 1);
                }
                s.Add(points[i]);
            }
            return s;
        }
        void DrawBlueThiccLine(int x1,int y1,int x2,int y2)
        {
            Pen pen = new Pen(Color.Aquamarine,3);
            g.DrawLine(pen, x1,y1,x2,y2);

        }
        private void DrawBlackPoint(int x, int y, int r)
        {
            g.FillEllipse(new SolidBrush(Color.Black), x - r, y - r, 2 * r, 2 * r);
            pictureBox1.Refresh();
        }
        private void DrawRedkPoint(int x, int y, int r)
        {
            g.FillEllipse(new SolidBrush(Color.Red), x - r, y - r, 2 * r, 2 * r);
            pictureBox1.Refresh();
        }

        private void doTheThing_Click(object sender, EventArgs e)
        {
            var s = Graham();
            DrawBlackPoint(p0.X, p0.Y, point_radius);
            DrawRedkPoint(points[1].X,points[1].Y, point_radius);
            
            for (int i = 0; i < s.Count-1; i++)
            {
                DrawBlueThiccLine(s[i].X, s[i].Y, s[i+1].X, s[i+1].Y);
            }

            DrawBlueThiccLine(s[s.Count-1].X, s[s.Count - 1].Y, s[0].X, s[0].Y);
        }
    }
}
