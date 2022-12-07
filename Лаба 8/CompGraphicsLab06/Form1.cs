using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;
using System.IO;
using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using System.Xml.Linq;
using System.Reflection;

namespace Lab08
{     
    public partial class Form1 : Form
    {
        private Graphics g;
        private Pen pen;
        private Projection projection;
        private List<XYZPoint> pointsRotate;
        private static List<Color> Colors;
        private Camera camera = new Camera();
        private Figure curFigure;
        private List<Figure> scene = new List<Figure>();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            pen = new Pen(Color.DarkRed, 2);
            projection = new Projection();
            radioButton1.Checked = true;
            projBox.SelectedIndex = 0;
            pointsRotate = new List<XYZPoint>();

            Colors = new List<Color>();
            Random r = new Random(0);
            for (int i = 0; i < 1000; ++i)
                Colors.Add(Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));

            camera.Position = new XYZPoint(int.Parse(camPosX.Text), int.Parse(camPosY.Text), int.Parse(camPosZ.Text)); //(299, 180, 0)
            camera.Focus = new XYZPoint(0, 0, 1000);
            camera.Offset = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);

        }

        private void ClearPictureBox()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
        }

        private void Draw()
        {
            if (checkBox1.Checked)
            {
                float x = float.Parse(camPosX.Text);
                float y = float.Parse(camPosY.Text);
                float z = float.Parse(camPosZ.Text);
                DrawByFaces(DeleteNonFrontFaces.DeleteFaces(curFigure, new XYZPoint(x * 100, y * 100, z * 100)));
            }
            else if (FreeCam.Checked)
            {
                DrawCam();
            }
            else
            {
                if (checkBox2.Checked)
                {
                    DrawByEdges();
                    ZBufferOn(Colors);
                }
                else
                {
                    DrawByEdges();
                }
            }
        }

        public void DrawCam()
        {
            g.Clear(Color.White);

            //change position of camera
            double dist = camera.Position.DistanceTo(camera.Focus);
            double angleBeta = (180 - camera.AngleX) / 2;
            double angleGamma = 90 - angleBeta;
            float l = (float)(dist * Math.Sqrt(2 * (1 - Math.Cos(camera.AngleX * Math.PI / 180))));
            float x = (float)(l * Math.Cos(angleGamma * Math.PI / 180));
            float z = (float)(l * Math.Sin(angleGamma * Math.PI / 180));
            XYZPoint currentPosition = camera.Position + new XYZPoint(x, 0, z);

            Vector3 mT = new Vector3(camera.Focus.X, camera.Focus.Y, camera.Focus.Z);
            Vector3 cT = new Vector3(currentPosition.X, currentPosition.Y, currentPosition.Z);
            Vector3 cL = (mT - cT).Normalize();
            Vector3 cR = (Vector3.VectorProduct(new Vector3(0, 1, 0), cL)).Normalize();
            Vector3 cU = (Vector3.VectorProduct(cL, cR)).Normalize();

            float[,] matrixV =
                 {
                     { cR.X, cR.Y, cR.Z, -Vector3.ScalarProduct(cR, cT) },
                     { cU.X, cU.Y, cU.Z, -Vector3.ScalarProduct(cU, cT) },
                     { cL.X, cL.Y, cL.Z, -Vector3.ScalarProduct(cL, cT) },
                     { 0, 0, 0, 1 }
                 };

            foreach (var Figure in scene)
            {
                Figure curFigure = new Figure(Figure);
                var points = curFigure.Vertexes;
                Matrix.GetTransformesXYZPoints(matrixV, points);
                foreach (var line in projection.Project(curFigure, 0))
                    g.DrawLine(new Pen(Color.Black), PointSum(line.From.ConvertToPoint(), camera.Offset), PointSum(line.To.ConvertToPoint(), camera.Offset));
            }
            pictureBox1.Invalidate();
        }

        public static Point PointSum(Point p1,PointF p2)
        {
            return new Point(p1.X + (int)p2.X, p1.Y + (int)p2.Y);
        }
        
        private void DrawByEdges()
        {
            if (curFigure.IsEmpty())
                return;
            Random r = new Random(0);

            ClearPictureBox();
            foreach (var curFigure in scene)
            {
                if (curFigure.IsEmpty())
                    return;

                pen = new Pen(Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)), 2);
                List<Edge> edges = projection.Project(curFigure, projBox.SelectedIndex);

                //Смещение по центру pictureBox
                var centerX = pictureBox1.Width / 2;
                var centerY = pictureBox1.Height / 2;

                //Смещение по центру фигуры
                var figureLeftX = edges.Min(e => e.From.X < e.To.X ? e.From.X : e.To.X);
                var figureLeftY = edges.Min(e => e.From.Y < e.To.Y ? e.From.Y : e.To.Y);
                var figureRightX = edges.Max(e => e.From.X > e.To.X ? e.From.X : e.To.X);
                var figureRightY = edges.Max(e => e.From.Y > e.To.Y ? e.From.Y : e.To.Y);
                var figureCenterX = (figureRightX - figureLeftX) / 2;
                var figureCenterY = (figureRightY - figureLeftY) / 2;

                var fixX = centerX - figureCenterX + (figureLeftX < 0 ? Math.Abs(figureLeftX) : -Math.Abs(figureLeftX));
                var fixY = centerY - figureCenterY + (figureLeftY < 0 ? Math.Abs(figureLeftY) : -Math.Abs(figureLeftY));
                
                foreach (Edge line in edges)
                {
                    var p1 = (line.From).ConvertToPoint();
                    var p2 = (line.To).ConvertToPoint();
                    g.DrawLine(pen, p1.X + fixX, p1.Y + fixY, p2.X + fixX, p2.Y + fixY);
                }
                pictureBox1.Invalidate();
            }
        }

        private void DrawByFaces(List<List<int>> visibleFaces)
        {
            if (curFigure.IsEmpty())
                return;
            ClearPictureBox();
            Random r = new Random(0);
            pen = new Pen(Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)), 2);
            List<Edge> edges = projection.Project(curFigure, projBox.SelectedIndex);

            //Смещение по центру pictureBox
            var centerX = pictureBox1.Width / 2;
            var centerY = pictureBox1.Height / 2;

            //Смещение по центру фигуры
            var figureLeftX = edges.Min(e => e.From.X < e.To.X ? e.From.X : e.To.X);
            var figureLeftY = edges.Min(e => e.From.Y < e.To.Y ? e.From.Y : e.To.Y);
            var figureRightX = edges.Max(e => e.From.X > e.To.X ? e.From.X : e.To.X);
            var figureRightY = edges.Max(e => e.From.Y > e.To.Y ? e.From.Y : e.To.Y);
            var figureCenterX = (figureRightX - figureLeftX) / 2;
            var figureCenterY = (figureRightY - figureLeftY) / 2;

            var fixX = centerX - figureCenterX + (figureLeftX < 0 ? Math.Abs(figureLeftX) : -Math.Abs(figureLeftX));
            var fixY = centerY - figureCenterY + (figureLeftY < 0 ? Math.Abs(figureLeftY) : -Math.Abs(figureLeftY));

            //Рисование по граням 
            List<XYZPoint> points = projection.Project2(curFigure, projBox.SelectedIndex);

            //List<Edge> edgess = projection.Project2(curFigure, projBox.SelectedIndex);
            pen = new Pen(Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)), 2);

            foreach (List<int> face in visibleFaces)
            {
                var p1 = points[face[0]].ConvertToPoint();
                var p2 = points[face[face.Count - 1]].ConvertToPoint();
                g.DrawLine(pen, p1.X + fixX, p1.Y + fixY, p2.X + fixX, p2.Y + fixY);
                for (var i = 1; i < face.Count; i++)
                {
                    p1 = points[face[i - 1]].ConvertToPoint();
                    p2 = points[face[i]].ConvertToPoint();
                    g.DrawLine(pen, p1.X + fixX, p1.Y + fixY, p2.X + fixX, p2.Y + fixY);

                }
            }
            pictureBox1.Invalidate();
        }

        // Построение куба
        private void button1_Click(object sender, EventArgs e)
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

            curFigure.AddFace(new List<int> { 3, 2, 1, 0 });
            curFigure.AddFace(new List<int> { 1, 2, 6, 5 });
            curFigure.AddFace(new List<int> { 0, 4, 7, 3 });
            curFigure.AddFace(new List<int> { 7, 4, 5, 6 });
            curFigure.AddFace(new List<int> { 2, 3, 7, 6 });
            curFigure.AddFace(new List<int> { 0, 1, 5, 4 });

            scene.Add(curFigure);
            Draw();
        }

        // Построение тетраэдра
        private void button2_Click(object sender, EventArgs e)
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

            curFigure.AddFace(new List<int> { 0, 2, 1 });
            curFigure.AddFace(new List<int> { 0, 1, 3 });
            curFigure.AddFace(new List<int> { 0, 3, 2 });
            curFigure.AddFace(new List<int> { 1, 2, 3 });

            scene.Add(curFigure);
            Draw();
        }

        // Очистить экран
        private void Clear_Click(object sender, EventArgs e)
        {
            curFigure.Clear();
            scene.Clear();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);

            pointsRotate.Clear();
        }

        // Построение октаэдра
        private void button4_Click(object sender, EventArgs e)
        {
            XYZPoint start = new XYZPoint(0, 0, 0); //= new XYZPoint(250 + 75, 150, 200 + 75);
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
            curFigure.AddFace(new List<int> { 0, 4, 1 });
            curFigure.AddFace(new List<int> { 0, 3, 2 });
            curFigure.AddFace(new List<int> { 0, 2, 4 });
            curFigure.AddFace(new List<int> { 1, 5, 3 });
            curFigure.AddFace(new List<int> { 5, 1, 4 });
            curFigure.AddFace(new List<int> { 3, 5, 2 });
            curFigure.AddFace(new List<int> { 5, 4, 2 });

            scene.Add(curFigure);
            Draw();
        }

        // Применить преобразования
        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) // Смещение
            {
                float x = (float)numericUpDown1.Value;
                float y = (float)numericUpDown2.Value;
                float z = (float)numericUpDown3.Value;

                var points = curFigure.Vertexes;
                XYZPoint center_P = curFigure.Center();
                Matrix.GetTransformesXYZPoints(Matrix.MatrixOffset(-center_P.X, -center_P.Y, -center_P.Z), points);
                Matrix.GetTransformesXYZPoints(Matrix.MatrixOffset(x, y, z), points);
                Draw();
            }
            if (radioButton2.Checked) // Масштаб
            {
                float x = (float)numericUpDown1.Value;
                float y = (float)numericUpDown2.Value;
                float z = (float)numericUpDown3.Value;
                if (x > 0 && y > 0 && z > 0)
                {
                    var points = curFigure.Vertexes;
                    XYZPoint center_P = curFigure.Center();
                    Matrix.GetTransformesXYZPoints(Matrix.MatrixOffset(-center_P.X, -center_P.Y, -center_P.Z), points);
                    Matrix.GetTransformesXYZPoints(Matrix.MatrixScaele(x, y, z), points);
                    Matrix.GetTransformesXYZPoints(Matrix.MatrixOffset(center_P.X, center_P.Y, center_P.Z), points);
                    Draw();
                }
            }
            if (radioButton3.Checked) // Поворот
            {
                float x = (float)((double)numericUpDown1.Value * Math.PI) / 180;
                float y = (float)((double)numericUpDown2.Value * Math.PI) / 180;
                float z = (float)((double)numericUpDown3.Value * Math.PI) / 180;
                var points = curFigure.Vertexes;
                Matrix.GetTransformesXYZPoints(Matrix.MatrixRotationXAngular(x), points);
                Matrix.GetTransformesXYZPoints(Matrix.MatrixRotationYAngular(y), points);
                Matrix.GetTransformesXYZPoints(Matrix.MatrixRotationZAngular(z), points);
                Draw();
            }
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 1;
        }

        private void radioButton3_MouseClick(object sender, MouseEventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
        }

        private void projBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (curFigure != null)
                Draw();
        }

        // добавить точку для фигуры вращения
        private void addPointButton_Click(object sender, EventArgs e)
        {
            float x = float.Parse(textBox6.Text);
            float y = float.Parse(textBox7.Text);
            float z = float.Parse(textBox8.Text);

            pointsRotate.Add(new XYZPoint(x, y, z));
            DrawCurve();
        }

        // рисует кривую по точкам для фигуры вращения
        private void DrawCurve()
        {
            g.Clear(Color.White);
            int startX = pictureBox1.Width / 2;
            int startY = pictureBox1.Height / 2;
            if (pointsRotate.Count > 1)
                for (int i = 1; i < pointsRotate.Count; i++)
                    g.DrawLine(new Pen(Color.Black), startX + pointsRotate[i - 1].ConvertToPoint().X,
                                                     startY + pointsRotate[i - 1].ConvertToPoint().Y,
                                                     startX + pointsRotate[i].ConvertToPoint().X,
                                                     startY + pointsRotate[i].ConvertToPoint().Y);
            pictureBox1.Invalidate();
        }

        // Нарисовать фигуру вращения
        private void drawFigureRotationButton_Click(object sender, EventArgs e)
        {
            int count = int.Parse(textBox5.Text); // количество разбиений
            string axis = comboBox2.Text;
            char axisF;
            if (axis == "Ось Oz")
                axisF = 'z';
            else if (axis == "Ось Oy")
                axisF = 'y';
            else axisF = 'x';

            curFigure = RotateFigure.createFigureForRotateFigure(pointsRotate, count, axisF);
            scene.Add(curFigure);
            Draw();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "3-d files (*.trd)|*.trd";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                if (openFileDialog1.CheckFileExists)
                {
                    curFigure = JsonConvert.DeserializeObject<Figure>(File.ReadAllText(openFileDialog1.FileName, Encoding.UTF8));
                    scene.Add(curFigure);
                    Draw();
                }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string file_str = JsonConvert.SerializeObject(curFigure);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "3-d files (*.trd)|*.trd";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.CheckFileExists)
                    File.Delete(saveFileDialog1.FileName);
                File.WriteAllText(saveFileDialog1.FileName, file_str);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void ZBufferOn(List<Color> colors)
        {
            Bitmap bmp = Z_Buffer.Z_buffer(pictureBox1.Width, pictureBox1.Height, scene, colors, projBox.SelectedIndex);
            pictureBox1.Image = bmp;
            pictureBox1.Invalidate();
        }

        private void FreeCam_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void UpBtn_Click(object sender, EventArgs e)
        {
            camera.MoveCamera(0, 0, -4);
            Draw();
        }

        private void DBtn_Click(object sender, EventArgs e)
        {
            camera.MoveCamera(0, 0, 4);
            Draw();
        }

        private void RBtn_Click(object sender, EventArgs e)
        {
            camera.MoveCamera(4, 0, 0);
            Draw();
        }

        private void LBtn_Click(object sender, EventArgs e)
        {
            camera.MoveCamera(-4, 0, 0);
            Draw();
        }

        private void QBtn_Click(object sender, EventArgs e)
        {
            camera.RotateCamera(-2, 0);
            Draw();
        }

        private void EBtn_Click(object sender, EventArgs e)
        {
            camera.RotateCamera(2, 0);
            Draw();
        }
    }
}
