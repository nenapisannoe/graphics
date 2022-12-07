using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointF = System.Drawing.PointF;

namespace Lab08
{
    class Camera
    {
        public XYZPoint Position { get; set; } = new XYZPoint(0, 0, 0);
        public XYZPoint Focus { get; set; } = new XYZPoint(0, 0, 0);
        public PointF Offset { get; set; } = new PointF(0, 0);
        public double AngleX { get; private set; } = 0;
        public double AngleY { get; private set; } = 0;
 

        public void MoveCamera(int dx, int dy, int dz)
        {
            Position += new XYZPoint(dx, dy, dz);
            Focus += new XYZPoint(dx, dy, 0);
        }

        public void RotateCamera(double ax, double ay)
        {
            AngleX += ax; AngleY += ay;
            if (AngleX > 360) AngleX -= 360;
            else if (AngleX < 0) AngleX += 360;
        }
    }

    class Projection
    {
        /*
        private static float c = 1000;
        static private float[,] perspective =
        {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 0, -1 / c },
            { 0, 0, 0, 1 }
        };

        static private float[,] isometric =
            {  { (float)Math.Sqrt(0.5), 0, (float)-Math.Sqrt(0.5), 0 },
               { 1 / (float)Math.Sqrt(6), 2 /(float) Math.Sqrt(6), 1 / (float)Math.Sqrt(6), 0 },
               { 1 / (float)Math.Sqrt(3), -1 / (float)Math.Sqrt(3), 1 / (float)Math.Sqrt(3), 0 },
               { 0, 0, 0, 1 }};

        //перемножение матриц
        static public float[,] MultMatrix(float[,] m1, float[,] m2)
        {
            float[,] res = new float[m1.GetLength(0), m2.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); ++i)
                for (int j = 0; j < m2.GetLength(1); ++j)
                    for (int k = 0; k < m2.GetLength(0); k++)
                    {
                        res[i, j] += m1[i, k] * m2[k, j];
                    }

            return res;
        }
        */

        // Выполняет проекцию
        public List<Edge> Project(Figure Figure, int mode)
        {
            float[,] matr;
            switch (mode)
            {
                case 0:
                    matr = Matrix.MatrixPerspective(1000);
                    break;
                case 1:
                    matr = Matrix.MatrixIsometry();
                    break;
                default:
                    throw new ArgumentException();
            }
            List<Edge> edges = new List<Edge>();

            int i = 0;
            // Для каждой вершины обрабатываем её и запускаем обработку смежных с ней
            foreach (XYZPoint p in Figure.Vertexes)
            {
                XYZPoint p1 = p;
                float[,] tmp = Matrix.MatrixMult2(new float[,] { { p1.X, p1.Y, p1.Z, 1 } }, matr);
                XYZPoint from = new XYZPoint(tmp[0, 0] / tmp[0, 3], tmp[0, 1] / tmp[0, 3]);

                // Обработка смежных с вершиной
                foreach (int index in Figure.Adjacency[i])
                {
                    XYZPoint t = Figure.Vertexes[index];

                    float[,] tmp1 = Matrix.MatrixMult2(new float[,] { { t.X, t.Y, t.Z, 1 } }, matr);
                    XYZPoint to = new XYZPoint(tmp1[0, 0] / tmp1[0, 3], tmp1[0, 1] / tmp1[0, 3]);
                    edges.Add(new Edge(from, to));
                }
                i++;
            }
            return edges;
        }

        
        // Выполняет проекцию (возвращает список точек на плоскости)
        public List<XYZPoint> Project2(Figure Figure, int mode)
        {
            float[,] matr;
            switch (mode)
            {
                case 0:
                    matr = Matrix.MatrixPerspective(1000);
                    break;
                case 1:
                    matr = Matrix.MatrixIsometry();
                    break;
                default:
                    throw new ArgumentException();
            }
            List<XYZPoint> points = new List<XYZPoint>(Figure.Vertexes);

            for (int i = 0; i < points.Count; ++i)
            {
                float[,] tmp1 = Matrix.MatrixMult2(new float[,] { { points[i].X, points[i].Y, points[i].Z, 1 } }, matr);
                points[i] = new XYZPoint(tmp1[0, 0] / tmp1[0, 3], tmp1[0, 1] / tmp1[0, 3]);
            }
            return points;

                    }

        public List<XYZPoint> Project3(List<XYZPoint> fase, int mode = 0)
        {
            float[,] matr;
            switch (mode)
            {
                case 0:
                    matr = Matrix.MatrixPerspective(1000);
                    break;
                case 1:
                    matr = Matrix.MatrixIsometry();
                    break;
                default:
                    throw new ArgumentException();
            }
            List<XYZPoint> points = new List<XYZPoint>(fase);

            for (int i = 0; i < points.Count; ++i)
            {
                float[,] tmp1 = Matrix.MatrixMult2(new float[,] { { points[i].X, points[i].Y, points[i].Z, 1 } }, matr);
                points[i] = new XYZPoint(tmp1[0, 0] / tmp1[0, 3], tmp1[0, 1] / tmp1[0, 3], points[i].Z);
            }
            return points;
        }
    }
}
