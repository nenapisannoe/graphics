using System;
using System.Collections.Generic;

namespace Lab06
{
    class RotateFigure
    {
        static private XYZPoint ChangePoint(XYZPoint point, float[,] matrix)
        {
            var matrixPoint = Projection.MultMatrix(matrix, Matrix.matrixColumnFromXYZPoint(point));
            XYZPoint newPoint = new XYZPoint(matrixPoint[0, 0] / matrixPoint[3, 0],
                                           matrixPoint[1, 0] / matrixPoint[3, 0],
                                           matrixPoint[2, 0] / matrixPoint[3, 0]);
            return newPoint;
        }

        static public List<XYZPoint> rotatePoints(List<XYZPoint> listPoints, float angle, char axis)
        {
            float sin = (float)Math.Sin(angle * Math.PI / 180);
            float cos = (float)Math.Cos(angle * Math.PI / 180);
            float[,] matrix;
            switch (axis)
            {
                case 'x':
                    matrix = new float[,]{{ 1,  0,   0,  0},
                                          { 0, cos,-sin, 0},
                                          { 0, sin, cos, 0},
                                          { 0,  0,   0,  1}};
                    break;
                case 'y':
                    matrix = new float[,]{{ cos, 0, sin, 0},
                                          {  0,  1,  0,  0},
                                          {-sin, 0, cos, 0},
                                          {  0,  0,  0,  1}};
                    break;
                case 'z':
                    matrix = new float[,]{{ cos, -sin, 0, 0},
                                          { sin,  cos, 0, 0},
                                          {  0,    0,  1, 0},
                                          {  0,    0,  0, 1}};
                    break;
                default:
                    matrix = new float[,] {{ 1, 0, 0, 0 },
                                           { 0, 1, 0, 0 },
                                           { 0, 0, 1, 0 },
                                           { 0, 0, 0, 1 }};
                    break;
            }
            List<XYZPoint> result = new List<XYZPoint>();
            foreach (var point in listPoints)
            {
                result.Add(ChangePoint(point, matrix));
            }
            return result;
        }

        // forming - образующая
        // Получение фигура вращения по заданной образующей
        static public Figure createFigureForRotateFigure(List<XYZPoint> forming, int numberPartitions, char axis)
        {
            List<XYZPoint> res = new List<XYZPoint>(); // Содержит все фигуры вращения
            int lstCount = forming.Count; // количество точек образующей
            float angle = 360.0f / numberPartitions;
            res.AddRange(forming); // точки образующей
            for (int i = 1; i < numberPartitions; i++)
            {
                res.AddRange(rotatePoints(forming, angle * i, axis));
            }

            Figure figure = new Figure(res);

            for (int i = 0; i < numberPartitions; i++)
            {
                for (int j = 0; j < lstCount; j++)
                {
                    int current = i * lstCount + j;
                    if ((current + 1) % lstCount == 0)
                        figure.AddEdges(current, new List<int> { (current + lstCount) % res.Count });
                    else
                    {
                        figure.AddEdges(current, new List<int> { current + 1, (current + lstCount) % res.Count });
                        // добавляем точки грани в порядке: текущая, ниже текущей, правее предыдущей, выше предыдущей (правее текущей)
                        figure.AddFace(new List<int> { current, current + 1, (current + 1 + lstCount) % res.Count, (current + lstCount) % res.Count });
                    }

                }
            }
            return figure;
        }
    }
}
