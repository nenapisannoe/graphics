using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab06
{
    class Matrix
    {
        static public float[,] matrixColumnFromXYZPoint(XYZPoint point)
        {
            return new float[,] { { point.X }, { point.Y }, { point.Z }, { 1 } };

        }

        static public void ChangeFigure(Figure figure, float[,] matrix)
        {
            List<XYZPoint> points = new List<XYZPoint>();
            for (int i = 0; i < figure.Vertexes.Count; ++i) // применяем преобразования к каждой точке
            {
                var matrixPoint = Projection.MultMatrix(matrix, matrixColumnFromXYZPoint(figure.Vertexes[i]));
                XYZPoint newPoint = new XYZPoint(matrixPoint[0, 0] / matrixPoint[3, 0], matrixPoint[1, 0] / matrixPoint[3, 0], matrixPoint[2, 0] / matrixPoint[3, 0]);
                figure.Vertexes[i] = newPoint;
            }
        }

        public static List<XYZPoint> GetTransformesXYZPoints(float[,] afin_matrix, List<XYZPoint> PointFs)
        {
            for (int i = 0; i < PointFs.Count(); ++i)
            {
                float[] transformed = Matrix.MatrixMult(afin_matrix, new float[4] { PointFs[i].X, PointFs[i].Y, PointFs[i].Z, 1 });
                PointFs[i].X = transformed[0] / transformed[3];
                PointFs[i].Y = transformed[1] / transformed[3];
                PointFs[i].Z = transformed[2] / transformed[3];
            }

            return PointFs;
        }

        public static List<XYZPoint> GetTransformedXYZPointsRight(float[,] afin_matrix, List<XYZPoint> PointFs)
        {
            for (int i = 0; i < PointFs.Count(); ++i)
            {
                float[] transformed = Matrix.MatrixMultRight(afin_matrix, new float[4] { PointFs[i].X, PointFs[i].Y, PointFs[i].Z, 1 });
                PointFs[i].X = transformed[0] * transformed[3];
                PointFs[i].Y = transformed[1] * transformed[3];
                PointFs[i].Z = transformed[2] * transformed[3];
            }

            return PointFs;
        }

        public static float[] MatrixMult(float[,] afin_matrix, float[] PointF)
        {
            float[] res = new float[4];

            for (int i = 0; i < 4; ++i)
            {
                res[i] = 0;
                for (int k = 0; k < 4; ++k)
                    res[i] += afin_matrix[k, i] * PointF[k];
            }

            float[] result = new float[4];
            for (int i = 0; i < 4; ++i)
                result[i] = res[i];
            return result;
        }

        public static float[] MatrixMultRight(float[,] afin_matrix, float[] PointF)
        {
            float[] res = new float[4];

            for (int i = 0; i < 4; ++i)
            {
                res[i] = 0;
                for (int k = 0; k < 4; ++k)
                    res[i] += afin_matrix[i, k] * PointF[k];
            }

            float[] result = new float[4];
            for (int i = 0; i < 4; ++i)
                result[i] = res[i];
            return result;
        }

        public static float[,] MatrixMult2(float[,] afin_matrix1, float[,] afin_matrix2)
        {
            float[,] res = new float[afin_matrix1.GetLength(0), afin_matrix2.GetLength(1)];

            for (int i = 0; i < afin_matrix1.GetLength(0); ++i)
                for (int k = 0; k < afin_matrix2.GetLength(0); ++k)
                    for (int j = 0; j < afin_matrix2.GetLength(1); ++j)
                        res[i, k] += afin_matrix1[i, j] * afin_matrix2[j, k];

            return res;
        }

        static public float[,] move(Figure figure, float tx, float ty, float tz)
        {
            float[,] afin_matrix = new float[4, 4];

            for (int i = 0; i < 4; ++i)
                for (int i1 = 0; i1 < 4; ++i1)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else afin_matrix[i, i1] = 1;

            afin_matrix[3, 0] = tx;
            afin_matrix[3, 1] = ty;
            afin_matrix[3, 2] = tz;

            return afin_matrix;
        }

        static public float[,] scale(Figure figure, float mx, float my, float mz)
        {
            float[,] afin_matrix = new float[4, 4];

            for (int i = 0; i < 4; ++i)
                for (int i1 = 0; i1 < 4; ++i1)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else
                        afin_matrix[i, i1] = 1;

            afin_matrix[0, 0] = mx;
            afin_matrix[1, 1] = my;
            afin_matrix[2, 2] = mz;

            return afin_matrix;
        }

        static public void rotation(Figure figure, float angleX, float angleY, float angleZ)
        {
            XYZPoint shiftPoint = figure.Center();
            float shiftX = shiftPoint.X,
                  shiftY = shiftPoint.Y,
                  shiftZ = shiftPoint.Z;

            move(figure, -shiftX, -shiftY, -shiftZ);

            float sin = (float)Math.Sin(angleX * Math.PI / 180);
            float cos = (float)Math.Cos(angleX * Math.PI / 180);
            float[,] matrixX = { { 1,  0,   0,  0},
                                 { 0, cos,-sin, 0},
                                 { 0, sin, cos, 0},
                                 { 0,  0,   0,  1}};

            sin = (float)Math.Sin(angleY * Math.PI / 180);
            cos = (float)Math.Cos(angleY * Math.PI / 180);
            float[,] matrixY = { { cos, 0, sin, 0},
                                 {  0,  1,  0,  0},
                                 {-sin, 0, cos, 0},
                                 {  0,  0,  0,  1}};

            sin = (float)Math.Sin(angleZ * Math.PI / 180);
            cos = (float)Math.Cos(angleZ * Math.PI / 180);
            float[,] matrixZ = { { cos, -sin, 0, 0},
                                 { sin,  cos, 0, 0},
                                 {  0,    0,  1, 0},
                                 {  0,    0,  0, 1}};

            ChangeFigure(figure, Projection.MultMatrix(Projection.MultMatrix(matrixX, matrixY), matrixZ));

            move(figure, shiftX, shiftY, shiftZ);
        }


        public static float[,] MatrixRotationXAngular(float rad_angle)
        {
            float cos_ang = (float)Math.Cos(rad_angle);
            float sin_ang = (float)Math.Sin(rad_angle);
            float[,] afin_matrix = new float[4, 4];

            for (int i = 0; i < 4; i++)
                for (int i1 = 0; i1 < 4; i1++)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else
                        afin_matrix[i, i1] = 1;

            afin_matrix[1, 1] = cos_ang;
            afin_matrix[1, 2] = -sin_ang;
            afin_matrix[2, 1] = sin_ang;
            afin_matrix[2, 2] = cos_ang;
            return afin_matrix;
        }

        public static float[,] MatrixRotationYAngular(float rad_angle)
        {
            float cos_ang = (float)Math.Cos(rad_angle);
            float sin_ang = (float)Math.Sin(rad_angle);
            float[,] afin_matrix = new float[4, 4];

            for (int i = 0; i < 4; i++)
                for (int i1 = 0; i1 < 4; i1++)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else
                        afin_matrix[i, i1] = 1;

            afin_matrix[0, 0] = cos_ang;
            afin_matrix[0, 2] = -sin_ang;
            afin_matrix[2, 0] = sin_ang;
            afin_matrix[2, 2] = cos_ang;
            return afin_matrix;
        }

        public static float[,] MatrixRotationZAngular(float rad_angle)
        {
            float cos_ang = (float)Math.Cos(rad_angle);
            float sin_ang = (float)Math.Sin(rad_angle);
            float[,] afin_matrix = new float[4, 4];

            for (int i = 0; i < 4; i++)
                for (int i1 = 0; i1 < 4; i1++)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else
                        afin_matrix[i, i1] = 1;

            afin_matrix[0, 0] = cos_ang;
            afin_matrix[0, 1] = -sin_ang;
            afin_matrix[1, 0] = sin_ang;
            afin_matrix[1, 1] = cos_ang;
            return afin_matrix;
        }

        public static void reflection(Figure figure, string plane)
        {
            float[,] matrix;
            switch (plane)
            {
                case "xy":
                    matrix = new float[,] {{ 1, 0,  0, 0 },
                                           { 0, 1,  0, 0 },
                                           { 0, 0, -1, 0 },
                                           { 0, 0,  0, 1 }};
                    break;
                case "xz":
                    matrix = new float[,] {{ 1,  0, 0, 0 },
                                           { 0, -1, 0, 0 },
                                           { 0,  0, 1, 0 },
                                           { 0,  0, 0, 1 }};
                    break;
                case "yz":
                    matrix = new float[,] {{ -1, 0, 0, 0 },
                                           {  0, 1, 0, 0 },
                                           {  0, 0, 1, 0 },
                                           {  0, 0, 0, 1 }};
                    break;
                default:
                    matrix = new float[,] {{ 1, 0, 0, 0 },
                                           { 0, 1, 0, 0 },
                                           { 0, 0, 1, 0 },
                                           { 0, 0, 0, 1 }};
                    break;
            }
            ChangeFigure(figure, matrix);
        }

        // Масштабирование относительно центра
        public static void scaleCenter(Figure figure, float a)
        {
            XYZPoint shiftPoint = figure.Center();
            float shiftX = shiftPoint.X,
                  shiftY = shiftPoint.Y,
                  shiftZ = shiftPoint.Z;

            move(figure, -shiftX, -shiftY, -shiftZ);

            float[,] scale = { { a, 0, 0, 0 },
                               { 0, a, 0, 0 },
                               { 0, 0, a, 0 },
                               { 0, 0, 0, 1 }};

            ChangeFigure(figure, scale);
            move(figure, shiftX, shiftY, shiftZ);
        }

        // Вращение многогранника вокруг прямой, проходящей через центр, параллельно выбранно координатной оси
        public static void rotateCenter(Figure figure, float angleX, float angleY, float angleZ)
        {
            var center = figure.Center();
            move(figure, -center.X, -center.Y, -center.Z);
            rotation(figure, angleX, angleY, angleZ);
            move(figure, center.X, center.Y, center.Z);
        }

        public static void rotateAboutLine(Figure figure, float angle, Edge line)
        {
            var vect = line.To - line.From;
            var len = Math.Sqrt(Math.Pow(vect.X, 2) + Math.Pow(vect.Y, 2) + Math.Pow(vect.Z, 2));
            var (l, m, n) = ((float)(vect.X / len), (float)(vect.Y / len), (float)(vect.Z / len));

            float sin = (float)Math.Sin(angle * Math.PI / 180);
            float cos = (float)Math.Cos(angle * Math.PI / 180);

            float[,] matr = { { l*l+cos*(1-l*l),   l*(1-cos)*m-n*sin, l*(1-cos)*n+m*sin, 0 },
                              { l*(1-cos)*m+n*sin, m*m+cos*(1-m*m),   m*(1-cos)*n-l*sin, 0 },
                              { l*(1-cos)*n-m*sin, m*(1-cos)*n+l*sin, n*n+cos*(1-n*n),   0 },
                              { 0,                 0,                 0,                 1 }};

            ChangeFigure(figure, matr);
        }
    }
}
