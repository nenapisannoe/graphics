using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DLab6
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;

        Point Center;

        List<XYZPoint> points = new List<XYZPoint>();
        Primitive currentPrimitive = new Primitive();

        Pen pen_shape = new Pen(Color.Red);

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);

            primitivesBox.SelectedItem = primitivesBox.Items[0];
            PerspectiveBox.SelectedItem = PerspectiveBox.Items[0];
            
            GetPrimitive();

            Center.X = pictureBox1.Width / 2;
            Center.Y = pictureBox1.Height / 2;
        }

        private void GetPrimitive()
        {
            switch (primitivesBox.SelectedItem.ToString())
            {
                case "Тетраэдр":
                    {
                        currentPrimitive = new Tetrahedron(300);
                        foreach(XYZPoint point in currentPrimitive.Points)
                        {
                            points.Add(point);
                        }
                        break;
                    }
                case "Гексаэдр":
                    {
                        currentPrimitive = new Hexahedron(300);
                        foreach (XYZPoint point in currentPrimitive.Points)
                        {
                            points.Add(point);
                        }
                        break;
                    }
                case "Октаэдр":
                    {
                        currentPrimitive = new Octahedron(300);
                        foreach (XYZPoint point in currentPrimitive.Points)
                        {
                            points.Add(point);
                        }
                        break;
                    }
                case "Икосаэдр":
                    {
                        currentPrimitive = new Icosahedron(300);
                        foreach (XYZPoint point in currentPrimitive.Points)
                        {
                            points.Add(point);
                        }
                        break;
                    }
                default:
                    {
                        currentPrimitive = new Tetrahedron(300);
                        foreach (XYZPoint point in currentPrimitive.Points)
                        {
                            points.Add(point);
                        }
                        break;
                    }
            }
        }

        private void Clear()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        private List<XYZPoint> Copy(List<XYZPoint> l)
        {
            List<XYZPoint> res = new List<XYZPoint>(l.Count);
            for (int i = 0; i < l.Count; ++i)
            {
                res.Add(new XYZPoint(l[i].X, l[i].Y, l[i].Z));
            }
            return res;
        }

        private XYZPoint GetCenter()
        {
            double sumX = 0, sumY = 0, sumZ = 0;
            int count = 0;
            var edges = currentPrimitive.Edges;
            for (int i = 0; i < edges.Count; i++)
            {
                for (int j = 0; j < edges[i].Points.Count; j++)
                {
                    sumX += edges[i].Points[j].X;
                    sumY += edges[i].Points[j].Y;
                    sumZ += edges[i].Points[j].Z;
                    ++count;
                }
            }
            return new XYZPoint(sumX / count, sumY / count, sumZ / count);
        }

        private void DrawEdge(Edge e)
        {
            List<XYZPoint> pointsToDraw = new List<XYZPoint>(e.Points.Count());

            if (PerspectiveBox.SelectedItem.ToString() == "Аксонометрическая")
            {
                pointsToDraw = Matrix.GetTransformesXYZPoints(Matrix.MatrixIsometry(), Copy(e.Points));
            }
            else if (PerspectiveBox.SelectedItem.ToString() == "Перспективная")
            {
                pointsToDraw = Matrix.GetTransformesXYZPoints(Matrix.MatrixPerspective(1000), Copy(e.Points));
            }

            for (int i = 0; i < pointsToDraw.Count(); i++)
            {
                int x1 = (int)Math.Round(pointsToDraw[i].X + Center.X);
                int x2 = (int)Math.Round(pointsToDraw[(i + 1) % pointsToDraw.Count()].X + Center.X);
                int y1 = (int)Math.Round(-pointsToDraw[i].Y + Center.Y);
                int y2 = (int)Math.Round(-pointsToDraw[(i + 1) % pointsToDraw.Count()].Y + Center.Y);
                Pen pen = new Pen(Color.Red, 50);
                g.DrawLine(pen_shape, x1, y1, x2, y2);
            }
        }

        private void redrawImage()
        {
            g.Clear(Color.White);
            foreach (Edge e in currentPrimitive.Edges)
            {
                DrawEdge(e);
            }
            //g.DrawLine(new Pen(Color.Black), new Point(0, 0), new Point(pictureBox1.Width, pictureBox1.Height));
            Pen pen = new Pen(Color.Black, 50);
            pictureBox1.Image = bmp;
            //pictureBox1.Refresh();
        }

        private void primitiveButton_Click(object sender, EventArgs e)
        {
            GetPrimitive();
            redrawImage();
        }

        private void displacementApply_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int kx = (int)xShift.Value, ky = (int)yShift.Value, kz = (int)zShift.Value;
            points = Matrix.GetTransformesXYZPoints(Matrix.MatrixOffset(kx, ky, kz), points);
            redrawImage();
        }

        private void rotateApply_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            double x_angle = ((double)xRotate.Value * Math.PI) / 180;
            double y_angle = ((double)yRotate.Value * Math.PI) / 180;
            double z_angle = ((double)zRotate.Value * Math.PI) / 180;
            Matrix.GetTransformesXYZPoints(Matrix.MatrixRotationXAngular(x_angle), points);
            Matrix.GetTransformesXYZPoints(Matrix.MatrixRotationYAngular(y_angle), points);
            Matrix.GetTransformesXYZPoints(Matrix.MatrixRotationZAngular(z_angle), points);
            redrawImage();
        }

        private void scaleApply_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            XYZPoint center_P = GetCenter();
            Matrix.GetTransformesXYZPoints(Matrix.MatrixOffset(-center_P.X, -center_P.Y, -center_P.Z), points);
            Matrix.GetTransformesXYZPoints(Matrix.MatrixScaele((double)xScale.Value, (double)yScale.Value, (double)zScale.Value), points);
            Matrix.GetTransformesXYZPoints(Matrix.MatrixOffset(center_P.X, center_P.Y, center_P.Z), points);
            redrawImage();
        }

        private void reflectionApply_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int d1 = 1;
            int d2 = 1;
            int d3 = 1;
            switch (reflectionBox.SelectedItem.ToString())
            {
                case "Плоскость X":
                    {
                        d3 = -1;
                        break;
                    }
                case "Плоскость Y":
                    {
                        d2 = -1;
                        break;
                    }
                case "Плоскость Z":
                    {
                        d1= -1;
                        break;
                    }
                default:
                    { 
                        break;
                    }
            }
            Matrix.GetTransformesXYZPoints(Matrix.MatrixRefl(d1, d2, d3), points);
            redrawImage();
        }

        private XYZPoint NormalizeVector(XYZPoint pt1, XYZPoint pt2)
        {
            if (pt2.Z < pt1.Z || (pt2.Z == pt1.Z && pt2.Y < pt1.Y) ||
                (pt2.Z == pt1.Z && pt2.Y == pt1.Y) && pt2.X < pt1.X)
            {
                XYZPoint tmp = pt1;
                pt1 = pt2;
                pt2 = tmp;
            }
            double x = pt2.X - pt1.X;
            double y = pt2.Y - pt1.Y;
            double z = pt2.Z - pt1.Z;
            double d = Math.Sqrt(x * x + y * y + z * z);
            if (d != 0)
            {
                return new XYZPoint(x / d, y / d, z / d);
            }
            return new XYZPoint(0, 0, 0);
        }

        private XYZPoint NormalizeVector2(XYZPoint pt1)
        {
            double x = pt1.X;
            double y = pt1.Y;
            double z = pt1.Z;
            double d = Math.Sqrt(x * x + y * y + z * z);
            if (d != 0)
            {
                return new XYZPoint(x / d, y / d, z / d);
            }
            return new XYZPoint(0, 0, 0);
        }

        private void RotateAxis(XYZPoint pt1, XYZPoint pt2, double angle) 
        {
            XYZPoint dir = new XYZPoint(pt2.X - pt1.X, pt2.Y - pt1.Y, pt2.Z - pt1.Z);
            XYZPoint c_point = new XYZPoint(pt1.X, pt1.Y, pt1.Z);
            XYZPoint c = NormalizeVector2(dir);
            points = Matrix.GetTransformesXYZPoints(Matrix.rotation_matrix(c_point, c, angle), points);
        }

        private void rotateLine_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            RotateAxis(new XYZPoint(Convert.ToDouble(rotateX1.Value),
                                    Convert.ToDouble(rotateY1.Value),
                                    Convert.ToDouble(rotateZ1.Value)),
                        new XYZPoint(Convert.ToDouble(rotateX2.Value),
                                    Convert.ToDouble(rotateY2.Value),
                                    Convert.ToDouble(rotateZ2.Value)),
                        Convert.ToDouble(rotateAngle.Value));

            pictureBox1.Refresh();
            //g.DrawLine(pen_shape, (int)rotateX1.Value, (int)rotateY1.Value, (int)rotateX2.Value, (int)rotateY2.Value);
            redrawImage();
        }

        private void ScaleCenter()
        {
            double C = (double)Scale_center.Value;
            Matrix.GetTransformesXYZPoints(Matrix.MatrixScaele(C, C, C), points);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ScaleCenter();
            redrawImage();
        }
    }
}
