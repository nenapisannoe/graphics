using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

namespace LAB4
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics g;

        Point prim_point;
        const int point_radius = 7;

        Line prim_edge;
        int edge_c = 0;

        Polygon prim_polygon;
        bool first_point = true;
        const int locate_radius = 20;

        Point center;

        double angle;

        double dx_shift;
        double dy_shift;

        double mx_scale;
        double my_scale;

        Color my_color = Color.Turquoise;

        public Form1()
        {
            InitializeComponent();

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);

            pictureBox1.Image = bitmap;
            prim_edge = new Line();

            prim_polygon = new Polygon();
            center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            g.FillEllipse(new SolidBrush(Color.DarkOrange), center.X, center.Y, 13, 13);
        }

        public class Line
        {
            public Point _p1;
            public Point _p2;
            public Line()
            {
                _p1 = new Point(-1, -1);
                _p2 = new Point(-1, -1);
            }
            public Line(Point p1, Point p2)
            {
                _p1 = p1;
                _p2 = p2;
            }
        }

        public class PolygonPoint
        {
            public float _x;
            public float _y;
            public PolygonPoint _prev;
            public PolygonPoint _next;

            public PolygonPoint()
            {
                _x = -1;
                _y = -1;
                _prev = null;
                _next = null;
            }
            public PolygonPoint(PointF p, PolygonPoint prev, PolygonPoint next)
            {
                _x = p.X;
                _y = p.Y;
                _prev = prev;
                _next = next;
            }
            public PolygonPoint(PointF p)
            {
                _x = p.X;
                _y = p.Y;
                _prev = null;
                _next = null;
            }
            public PolygonPoint(float x, float y, PolygonPoint prev, PolygonPoint next)
            {
                _x = x;
                _y = y;
                _prev = prev;
                _next = next;
            }
            public Point ToPoint()
            {
                return new Point((int)_x, (int)_y);
            }
        }

        public class Polygon
        {
            public PolygonPoint _start;
            public int _size;
            public bool _done;

            public Polygon()
            {
                _start = null;
                _size = 0;
                _done = false;
            }
            public Polygon(PointF p)
            {
                _start = new PolygonPoint(p);
                _size = 1;
                _done = false;
            }
            public PolygonPoint getlast()
            {
                if (_done)
                    return _start;
                PolygonPoint polygon1 = _start;
                while (polygon1._next != null)
                    polygon1 = polygon1._next;
                return polygon1;
            }
            public void addPoint(PointF p)
            {
                if (_done) return;
                PolygonPoint polygon1 = _start;
                if (polygon1 == null)
                {
                    _start = new PolygonPoint(p);
                    _size = 1;
                    return;
                }

                Point pPoint = polygon1.ToPoint();
                if (pPoint == p)
                {
                    PolygonPoint last = getlast();
                    last._next = _start;
                    _start._prev = last;
                    _done = true;
                    return;
                }

                while (polygon1._next != null)
                    polygon1 = polygon1._next;

                polygon1._next = new PolygonPoint(p);
                PolygonPoint polygon2 = polygon1._next;
                polygon2._prev = polygon1;
                _size++;
            }
        }

        private void dx_textBox_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(dx_textBox.Text, out dx_shift);
        }

        private void dy_textBox_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(dy_textBox.Text, out dy_shift);
        }

        private void angle_textBox_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(angle_textBox.Text, out angle);
        }

        private void mx_textBox_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(mx_textBox.Text, out mx_scale);
        }

        private void my_textBox_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(my_textBox.Text, out my_scale);
        }

        private void RedrawScene()
        {
            g.Clear(Color.White);

            DrawPoint(prim_point.X, prim_point.Y, point_radius);

            if (prim_edge != null && prim_edge._p1.X != -1)
            {
                DrawPrimEdge();
            }

            if (!first_point || prim_polygon._done)
            {
                DrawPolygon();
            }

            g.FillEllipse(new SolidBrush(Color.DarkOrange), center.X, center.Y, 13, 13);
            pictureBox1.Refresh();
        }

        private void DrawPoint(int x, int y, int r)
        {
            g.FillEllipse(new SolidBrush(my_color), x - r, y - r, 2 * r, 2 * r);
            pictureBox1.Refresh();
        }

        private void DrawPrimEdge()
        {
            DrawPoint(prim_edge._p1.X, prim_edge._p1.Y, point_radius);
            DrawPoint(prim_edge._p2.X, prim_edge._p2.Y, point_radius);
            g.DrawLine(new Pen(my_color, 5), prim_edge._p1, prim_edge._p2);
            pictureBox1.Refresh();
        }

        private void DrawPolygon()
        {
            PolygonPoint p = prim_polygon._start;
            if (prim_polygon._size == 1)
            {
                DrawPoint((int)p._x, (int)p._y, point_radius);
                return;
            }

            PolygonPoint p1 = new PolygonPoint();
            for (int i = 0; i < prim_polygon._size - 1; i++)
            {
                DrawPoint((int)p._x, (int)p._y, point_radius);
                p1 = p._next;
                g.DrawLine(new Pen(my_color, 5), p.ToPoint(), p1.ToPoint());
                DrawPoint((int)p1._x, (int)p1._y, point_radius);
                p = p1;
            }

            if (prim_polygon._done)
                g.DrawLine(new Pen(my_color, 5), p.ToPoint(), prim_polygon._start.ToPoint());
            else g.DrawLine(new Pen(my_color, 5), p.ToPoint(), p1.ToPoint());
            pictureBox1.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var mouse_ev = (MouseEventArgs)e;
            if (!point_button.Enabled)
            {
                prim_point = mouse_ev.Location;
                RedrawScene();
            }
            else if (!line_button.Enabled)
            {    
                if (edge_c == 0)
                {
                    prim_edge._p1 = mouse_ev.Location;
                    edge_c++;
                    prim_edge._p2 = mouse_ev.Location;
                }
                else
                {
                    prim_edge._p2 = mouse_ev.Location;
                    edge_c--;
                }
                RedrawScene();
            }
            else if (!polygon_button.Enabled)
            {
                if (prim_polygon._done)
                    prim_polygon = new Polygon();
                if (first_point)
                {
                    first_point = false;
                    prim_polygon.addPoint(mouse_ev.Location);
                }
                else if (LocatePoint(mouse_ev.Location))
                {
                    prim_polygon.addPoint(prim_polygon._start.ToPoint());
                    first_point = true;
                    RedrawScene();
                }
                else prim_polygon.addPoint(mouse_ev.Location);
                RedrawScene();
            }
            else if (!center_button.Enabled)
            {
                center = mouse_ev.Location;
                RedrawScene();
            }
            pictureBox1.Image = bitmap;
        }

        private bool LocatePoint(Point p)
        {
            return Math.Abs(p.X - prim_polygon._start._x) < locate_radius && Math.Abs(p.Y - prim_polygon._start._y) < locate_radius;
        }

        private void point_button_Click(object sender, EventArgs e)
        {
            point_button.Enabled = false;
            line_button.Enabled = true;
            polygon_button.Enabled = true;
            center_button.Enabled = true;
        }

        private void line_button_Click(object sender, EventArgs e)
        {
            point_button.Enabled = true;
            line_button.Enabled = false;
            polygon_button.Enabled = true;
            center_button.Enabled = true;
        }

        private void polygon_button_Click(object sender, EventArgs e)
        {
            point_button.Enabled = true;
            line_button.Enabled = true;
            polygon_button.Enabled = false;
            center_button.Enabled = true;
        }

        private void center_button_Click(object sender, EventArgs e)
        {
            point_button.Enabled = true;
            line_button.Enabled = true;
            polygon_button.Enabled = true;
            center_button.Enabled = false;
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);

            prim_point = new Point();
            prim_edge = new Line();
            prim_polygon = new Polygon();
            edge_c = 0;

            g.FillEllipse(new SolidBrush(Color.DarkOrange), center.X, center.Y, 13, 13);

            center.X = pictureBox1.Width / 2;
            center.Y = pictureBox1.Height / 2;

            point_button.Enabled = true;
            line_button.Enabled = true;
            polygon_button.Enabled = true;
            center_button.Enabled = true;

            RedrawScene();
            pictureBox1.Refresh();
        }

        private void afinne(string name)
        {
            Matrix m = new Matrix(3);

            if (name == "rotate")
            {
                var rad_angle = angle * Math.PI / 180;
                m[0, 0] = Math.Cos(rad_angle);
                m[0, 1] = Math.Sin(rad_angle);
                m[0, 2] = 0;
                m[1, 0] = -Math.Sin(rad_angle);
                m[1, 1] = Math.Cos(rad_angle);
                m[1, 2] = 0;
                m[2, 0] = 0;
                m[2, 1] = 0;
                m[2, 2] = 1;
            }
            else if (name == "shift")
            {
                m[0, 0] = 1;
                m[0, 1] = 0;
                m[0, 2] = 0;
                m[1, 0] = 0;
                m[1, 1] = 1;
                m[1, 2] = 0;
                m[2, 0] = -dx_shift;
                m[2, 1] = -dy_shift;
                m[2, 2] = 1;
            }
            else if (name == "scale")
            {
                m[0, 0] = 1 / mx_scale;
                m[0, 1] = 0;
                m[0, 2] = 0;
                m[1, 0] = 0;
                m[1, 1] = 1 / my_scale;
                m[1, 2] = 0;
                m[2, 0] = 0;
                m[2, 1] = 0;
                m[2, 2] = 1;
            }

            if (prim_polygon._done)
            {
                var sh = new Matrix(3, 3);
                sh[0, 0] = 1;
                sh[0, 1] = 0;
                sh[0, 2] = 0;
                sh[1, 0] = 0;
                sh[1, 1] = 1;
                sh[1, 2] = 0;
                sh[2, 0] = -center.X;
                sh[2, 1] = -center.Y;
                sh[2, 2] = 1;

                var unsh = new Matrix(3, 3);
                unsh[0, 0] = 1;
                unsh[0, 1] = 0;
                unsh[0, 2] = 0;
                unsh[1, 0] = 0;
                unsh[1, 1] = 1;
                unsh[1, 2] = 0;
                unsh[2, 0] = center.X;
                unsh[2, 1] = center.Y;
                unsh[2, 2] = 1;
                var prim = prim_polygon._start;
                var new_prim_polygon = new Polygon();

                for (int i = 0; i < prim_polygon._size; i++)
                {
                    Matrix p = new Matrix(1, 3);
                    p[0, 0] = prim._x;
                    p[0, 1] = prim._y;
                    p[0, 2] = 1;

                    Matrix res = p * sh * m * unsh;
                    new_prim_polygon.addPoint(new PointF((int)res[0, 0], (int)res[0, 1]));

                    prim = prim._next;
                }
                new_prim_polygon._done = true;

                prim_polygon = new_prim_polygon;
                RedrawScene();
            }
        }

        private void rotate_button_Click(object sender, EventArgs e)
        {
            afinne("rotate");
        }

        private void shift_button_Click(object sender, EventArgs e)
        {
            afinne("shift");
        }

        private void scale_button_Click(object sender, EventArgs e)
        {
            afinne("scale");
        }
    }
}
