using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Math;

namespace Lab06
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Pen pen;
        private Projection projection;
        private List<XYZPoint> pointsRotate;
        private Figure curFigure;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
            pen = new Pen(Color.DarkRed, 2);
            projection = new Projection();
            projBox.SelectedIndex = 0;
            pointsRotate = new List<XYZPoint>();
        }
        private void Draw()
        {
            if (curFigure.IsEmpty())
                return;
            graphics.Clear(Color.White);
            Random r = new Random();
            pen = new Pen(Color.Red, 2);
            List<Edge> edges = projection.Project(curFigure, projBox.SelectedIndex);

            var centerX = pictureBox1.Width / 2;
            var centerY = pictureBox1.Height / 2;

            //Смещение по центру фигуры
            var figureLeftX = edges.Min(e => e.From.X < e.To.X ? e.From.X : e.To.X);
            var figureLeftY = edges.Min(e => e.From.Y < e.To.Y ? e.From.Y : e.To.Y);
            var figureRightX = edges.Max(e => e.From.X > e.To.X ? e.From.X : e.To.X);
            var figureRightY = edges.Max(e => e.From.Y > e.To.Y ? e.From.Y : e.To.Y);
            var figureCenterX = (figureRightX - figureLeftX) / 2;
            var figureCenterY = (figureRightY - figureLeftY) / 2;

            var fixX = centerX - figureCenterX + (figureLeftX < 0 ? Abs(figureLeftX) : -Abs(figureLeftX));
            var fixY = centerY - figureCenterY + (figureLeftY < 0 ? Abs(figureLeftY) : -Abs(figureLeftY));

            foreach (Edge line in edges)
            {
                var p1 = (line.From).ConvertToPoint();
                var p2 = (line.To).ConvertToPoint();
                graphics.DrawLine(pen, p1.X + centerX - figureCenterX, p1.Y + centerY - figureCenterY, p2.X + centerX - figureCenterX, p2.Y + centerY - figureCenterY);
            }

            pictureBox1.Invalidate();
        }

        // Применить преобразования
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.StartsWith("Отражение по "))
            {
                string plane = "";
                switch (comboBox1.Text)
                {
                    case "Отражение по Z":
                        plane = "xy";
                        break;
                    case "Отражение по Y":
                        plane = "xz";
                        break;
                    case "Отражение по X":
                        plane = "yz";
                        break;
                }
                if (plane != "")
                {
                    Matrix.reflection(curFigure, plane);
                    Draw();
                }
                return;
            }
            
            float.TryParse(textBox1.Text, out float x);
            float.TryParse(textBox2.Text, out float y);
            float.TryParse(textBox3.Text, out float z);
            switch (comboBox1.Text)
            {
                case "Смещение по оси":
                    Matrix.GetTransformesXYZPoints(Matrix.move(curFigure, x, y, z), curFigure.Vertexes);
                    break;
                case "Масштабирование":
                    x = x == 0 ? 1 : x;
                    y = y == 0 ? 1 : y;
                    z = z == 0 ? 1 : z;
                    XYZPoint center_P = curFigure.Center();
                    //Matrix.GetTransformesXYZPoints(Matrix.move(curFigure, -center_P.X, -center_P.Y, -center_P.Z), curFigure.Vertexes);
                    Matrix.GetTransformesXYZPoints(Matrix.scale(curFigure, x, y, z), curFigure.Vertexes);
                    //Matrix.GetTransformesXYZPoints(Matrix.move(curFigure, center_P.X, center_P.Y, center_P.Z), curFigure.Vertexes);
                    break;
                case "Поворот":
                    float x_angle = (float)(x * Math.PI) / 180;
                    float y_angle = (float)(y * Math.PI) / 180;
                    float z_angle = (float)(z * Math.PI) / 180;
                    Matrix.GetTransformesXYZPoints(Matrix.MatrixRotationXAngular(x_angle), curFigure.Vertexes);
                    Matrix.GetTransformesXYZPoints(Matrix.MatrixRotationYAngular(y_angle), curFigure.Vertexes);
                    Matrix.GetTransformesXYZPoints(Matrix.MatrixRotationZAngular(z_angle), curFigure.Vertexes);
                    break;
            }
            Draw();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            curFigure.Clear();
            graphics.Clear(Color.White);
            pictureBox1.Invalidate();
            pointsRotate.Clear();
        }

        private void projBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (curFigure != null)
                Draw();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;
                if (File.Exists(fName))
                {
                    curFigure = JsonConvert.DeserializeObject<Figure>(File.ReadAllText(fName, Encoding.UTF8));
                    Draw();
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = saveFileDialog1.FileName;
                File.WriteAllText(fName, JsonConvert.SerializeObject(curFigure, Formatting.Indented), Encoding.UTF8);
            }
        }

        private void rotateBtn_Click(object sender, EventArgs e)
        {
            if (point1X.Text == point2X.Text && point1Y.Text == point2Y.Text && point1Z.Text == point2Z.Text)
                return;

            Matrix.rotateAboutLine(curFigure, float.Parse(rotateAngle.Text), new Edge(float.Parse(point1X.Text), float.Parse(point1Y.Text), float.Parse(point1Z.Text),
                float.Parse(point2X.Text), float.Parse(point2Y.Text), float.Parse(point2Z.Text)));
            Draw();
        }

        // добавить точку для фигуры вращения
        private void addPointButton_Click(object sender, EventArgs e)
        {
            float x = float.Parse(figureX.Text);
            float y = -float.Parse(figureY.Text);
            float z = float.Parse(figuraZ.Text);

            pointsRotate.Add(new XYZPoint(x, y, z));
            DrawCurve();
        }

        // рисует кривую по точкам для фигуры вращения
        private void DrawCurve()
        {
            graphics.Clear(Color.White);
            int startX = pictureBox1.Width / 2;
            int startY = pictureBox1.Height / 2;
            if (pointsRotate.Count > 1)
            {
                for (int i = 1; i < pointsRotate.Count; i++)
                {

                    graphics.DrawLine(new Pen(Color.Black), startX + pointsRotate[i - 1].ConvertToPoint().X,
                                                            startY + pointsRotate[i - 1].ConvertToPoint().Y,
                                                            startX + pointsRotate[i].ConvertToPoint().X,
                                                            startY + pointsRotate[i].ConvertToPoint().Y);
                }
            }
            pictureBox1.Invalidate();
        }

        private void drawFigureRotationButton_Click(object sender, EventArgs e)
        {
            char axis = 'x';
            switch (comboBox2.Text) {
                case "Z":
                    axis = 'z';
                    break;
                case "Y":
                    axis = 'y';
                    break;
            }

            int count = int.Parse(figuraCount.Text);

            curFigure = RotateFigure.createFigureForRotateFigure(pointsRotate, count, axis);
            Draw();
        }

        delegate float delegat(float x, float y);

        private void drawGraphic(float X0, float X1, float Y0, float Y1, int countSplit, delegat f)
        {
            float dx = (X1 - X0) / countSplit;
            float dy = (Y1 - Y0) / countSplit;
            float currentX, currentY = Y0;

            List<XYZPoint> points = new List<XYZPoint>();

            for (int i = 0; i <= countSplit; ++i)
            {
                currentX = X0;
                for (int j = 0; j <= countSplit; ++j)
                {
                    points.Add(new XYZPoint(currentX, currentY, f(currentX, currentY)));
                    currentX += dx;
                }
                currentY += dy;
            }
            Figure Figure = new Figure(points);


            int N = countSplit + 1;

            // Делаем сетку из ребер. Из каждой точки идет ребро вправо и вниз (таким образом делается сетка)
            for (int x = 0; x < N; ++x)
                for (int y = 0; y < N; ++y)
                {
                    if (y != N - 1) // вправо
                        Figure.AddEdge(x * N + y, x * N + y + 1);
                    if (x != N - 1) // вниз
                        Figure.AddEdge(x * N + y, (x + 1) * N + y);
                    if (y != N - 1 && x != N - 1) // текущая точка, вправо от тек., вниз от тек., вправо и вниз от тек. образуют грань 
                        Figure.AddFace(new List<int> { x * N + y, x * N + y + 1, (x + 1) * N + y, (x + 1) * N + (y + 1) });
                }
            Matrix.scaleCenter(Figure, 40);
            Matrix.rotateCenter(Figure, 60, 0, 0);
            Matrix.move(Figure, 200, 120, 0);
            curFigure = Figure;

            Draw();
        }

        private void DrawGraphic_Click(object sender, EventArgs e)
        {
            delegat f = (x, y) => 0;
            switch (graphicsList.SelectedIndex)
            {
                case 0:
                    f = (x, y) => (float)Sin(x + y);
                    break;
                case 1:
                    f = (x, y) => (float)Cos(x+y);
                    break;
                case 2:
                    f = (x, y) => (float)(Sin(x*x+y*y)/(x*x+y*y));
                    break;
                case 3:
                    f = (x, y) => (float)(Sin(x +y)/(x+y));
                    break;
                case 4:
                    f = (x, y) => (float)(Sin(x)*Cos(y)*Sin(y));
                    break;
            }

            var x1 = float.Parse(graphX1.Text);
            var y1 = float.Parse(graphX2.Text);
            var x2 = float.Parse(graphY1.Text);
            var y2 = float.Parse(graphY2.Text);
            var countSplit = int.Parse(this.countSplit.Text);

            drawGraphic(x1, y1, x2, y2, countSplit, f);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tetra_Click(object sender, EventArgs e)
        {
            XYZPoint start = new XYZPoint(0, 0, 0);
            float len = 150;

            List<XYZPoint> points = new List<XYZPoint>
            {
                start,
                start + new XYZPoint(len, 0, len),
                start + new XYZPoint(len, len, 0),
                start + new XYZPoint(0, len, len),
            };

            curFigure = new Figure(points);
            curFigure.AddEdges(0, new List<int> { 1, 3, 2 });
            curFigure.AddEdges(1, new List<int> { 3 });
            curFigure.AddEdges(2, new List<int> { 1, 3 });

            curFigure.AddFace(new List<int> { 0, 1, 2 });
            curFigure.AddFace(new List<int> { 0, 1, 3 });
            curFigure.AddFace(new List<int> { 0, 2, 3 });
            curFigure.AddFace(new List<int> { 1, 2, 3 });

            Draw();
        }

        private void gecsa_Click(object sender, EventArgs e)
        {
            XYZPoint start = new XYZPoint(0, 0, 0);
            float len = 150;

            List<XYZPoint> points = new List<XYZPoint>
            {
                start,
                start + new XYZPoint(len, 0, 0),
                start + new XYZPoint(len, 0, len),
                start + new XYZPoint(0, 0, len),

                start + new XYZPoint(0, len, 0),
                start + new XYZPoint(len, len, 0),
                start + new XYZPoint(len, len, len),
                start + new XYZPoint(0, len, len)
            };

            curFigure = new Figure(points);
            curFigure.AddEdges(0, new List<int> { 1, 4 });
            curFigure.AddEdges(1, new List<int> { 2, 5 });
            curFigure.AddEdges(2, new List<int> { 6, 3 });
            curFigure.AddEdges(3, new List<int> { 7, 0 });
            curFigure.AddEdges(4, new List<int> { 5 });
            curFigure.AddEdges(5, new List<int> { 6 });
            curFigure.AddEdges(6, new List<int> { 7 });
            curFigure.AddEdges(7, new List<int> { 4 });

            curFigure.AddFace(new List<int> { 0, 1, 2, 3 });
            curFigure.AddFace(new List<int> { 1, 2, 6, 5 });
            curFigure.AddFace(new List<int> { 0, 3, 7, 4 });
            curFigure.AddFace(new List<int> { 4, 5, 6, 7 });
            curFigure.AddFace(new List<int> { 2, 3, 7, 6 });
            curFigure.AddFace(new List<int> { 0, 1, 5, 4 });

            Draw();
        }

        private void okta_Click(object sender, EventArgs e)
        {
            XYZPoint start = new XYZPoint(0, 0, 0);
            float len = 150;

            List<XYZPoint> points = new List<XYZPoint>
            {
                start,
                start + new XYZPoint(len , len , 0),
                start + new XYZPoint(-len, len , 0),
                start + new XYZPoint(0, len , -len ),
                start + new XYZPoint(0, len , len ),
                start + new XYZPoint(0,  2 *len, 0),
            };

            curFigure = new Figure(points);
            curFigure.AddEdges(0, new List<int> { 1, 3, 2, 4 });
            curFigure.AddEdges(5, new List<int> { 1, 3, 2, 4 });
            curFigure.AddEdges(1, new List<int> { 3 });
            curFigure.AddEdges(3, new List<int> { 2 });
            curFigure.AddEdges(2, new List<int> { 4 });
            curFigure.AddEdges(4, new List<int> { 1 });

            curFigure.AddFace(new List<int> { 0, 1, 3 });
            curFigure.AddFace(new List<int> { 0, 1, 4 });
            curFigure.AddFace(new List<int> { 0, 2, 3 });
            curFigure.AddFace(new List<int> { 0, 2, 4 });
            curFigure.AddFace(new List<int> { 5, 1, 3 });
            curFigure.AddFace(new List<int> { 5, 1, 4 });
            curFigure.AddFace(new List<int> { 5, 2, 3 });
            curFigure.AddFace(new List<int> { 5, 2, 4 });

            Matrix.move(curFigure, 150, 0, 0);
            Draw();
        }
    }
}
