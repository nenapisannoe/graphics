using System;
using System.Collections.Generic;

namespace Lab06
{
    class Projection
    {
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

        public List<Edge> Project(Figure Figure, int projection)
        {
            bool isPerspective = projection == 0;
            float[,] matr = isPerspective ? perspective : isometric;
            List<Edge> edges = new List<Edge>();

            int i = 0;
            // Для каждой вершины обрабатываем её и запускаем обработку смежных с ней
            foreach (XYZPoint p in Figure.Vertexes)
            {
                // Все многогранники начинаются в (0, 0, 0). Добавляем смещение, чтобы фигуры были примерно по центру
                XYZPoint p1 = p;
                float[,] tmp = MultMatrix(new float[,] { { p1.X, p1.Y, p1.Z, 1 } }, matr);
                XYZPoint from = new XYZPoint(tmp[0, 0] / tmp[0, 3], tmp[0, 1] / tmp[0, 3]);


                // Обработка смежных с вершиной
                foreach (int index in Figure.Adjacency[i])
                {
                    // Все многогранники начинаются в (0, 0, 0). Добавляем смещение, чтобы фигуры были примерно по центру
                    XYZPoint t = Figure.Vertexes[index];

                    float[,] tmp1 = Projection.MultMatrix(new float[,] { { t.X, t.Y, t.Z, 1 } }, matr);
                    XYZPoint to = new XYZPoint(tmp1[0, 0] / tmp1[0, 3], tmp1[0, 1] / tmp1[0, 3]);
                    edges.Add(new Edge(from, to));
                }
                i++;
            }

            return edges;
        }

        public List<XYZPoint> Project2(Figure Figure, int projection)
        {
            bool isPerspective = projection == 0;
            float[,] matr = isPerspective ? perspective : isometric;
            List<XYZPoint> points = new List<XYZPoint>(Figure.Vertexes);

            for (int i = 0; i < points.Count; ++i)
            {
                float[,] tmp1 = Projection.MultMatrix(new float[,] { { points[i].X, points[i].Y, points[i].Z, 1 } }, matr);
                points[i] = new XYZPoint(tmp1[0, 0] / tmp1[0, 3], tmp1[0, 1] / tmp1[0, 3]);
            }
            return points;
        }
    }
}
