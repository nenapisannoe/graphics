using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08
{
    class RotateFigure
    {
        /// <summary>
        /// Применения матрицы преобразований к точке
        /// </summary>
        /// <param name="pnt"> Точка </param>
        /// <param name="matrix"> Матрица </param>
        /// <returns></returns>
        static private XYZPoint ChangePoint(XYZPoint pnt, float[,] matrix)
        {
            var matrixPoint = Matrix.MatrixMult2(matrix, Matrix.matrixColumnFromXYZPoint(pnt));
            XYZPoint newPoint = new XYZPoint(matrixPoint[0, 0] / matrixPoint[3, 0], matrixPoint[1, 0] / matrixPoint[3, 0], matrixPoint[2, 0] / matrixPoint[3, 0]);
            return newPoint;

        }

        /// <summary>
        /// Поворот списка точек (образующей)
        /// </summary>
        /// <param name="lstPoints"> Список точек </param>
        /// <param name="angle"> Угол </param>
        /// <param name="axis"> Ось вращения </param>
        /// <returns></returns>
        static public List<XYZPoint> rotatePoints(List<XYZPoint> lstPoints, float angle, char axis)
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
            List<XYZPoint> res = new List<XYZPoint>();
            foreach (var pnt in lstPoints)
            {
                res.Add(ChangePoint(pnt, matrix));
            }
            return res;
        }

        /// <summary>
        /// Получение многогранника (фигура вращения) по заданной образующей
        /// </summary>
        /// <param name="lst"> Образующая </param>
        /// <param name="partitions"> Количество разбиений </param>
        /// <param name="axis"> Ось вращения </param>
        /// <returns></returns>
        static public Figure createFigureForRotateFigure(List<XYZPoint> lst, int partitions, char axis)
        {
            List<XYZPoint> res = new List<XYZPoint>(); // Содержит все точки многогранника (фигуры вращения)
            int lstCount = lst.Count; // количество точек в кривой, которая задаёт образующую
            float angle = 360.0f / partitions; // угол вращения
            res.AddRange(lst); // Добавляем точки образующей в список точек многогранника
            for (int i = 1; i < partitions; i++)
            {
                res.AddRange(rotatePoints(lst, angle * i, axis));
            }

            Figure figure = new Figure(res);

            // Добавляем рёбра
            for (int i = 0; i < partitions; i++)
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
                        figure.AddFace(new List<int> { current, current+1, (current + 1 + lstCount) % res.Count, (current + lstCount) % res.Count });
                    }

                }
            }
            return figure;
        }
    }
}
