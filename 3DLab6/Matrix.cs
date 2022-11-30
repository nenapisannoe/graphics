using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _3DLab6
{
    class Matrix
    {
        public static List<XYZPoint> GetTransformesXYZPoints(double[,] afin_matrix, List<XYZPoint> PointFs)
        {
            for (int i = 0; i < PointFs.Count(); ++i)
            {
                double[] transformed = Matrix.MatrixMult(afin_matrix, new double[4] { PointFs[i].X, PointFs[i].Y, PointFs[i].Z, 1 });
                PointFs[i].X = transformed[0] / transformed[3];
                PointFs[i].Y = transformed[1] / transformed[3];
                PointFs[i].Z = transformed[2] / transformed[3];
            }

            return PointFs;
        }

        public static List<XYZPoint> GetTransformedXYZPointsRight(double[,] afin_matrix, List<XYZPoint> PointFs)
        {
            for (int i = 0; i < PointFs.Count(); ++i)
            {
                double[] transformed = Matrix.MatrixMultRight(afin_matrix, new double[4] { PointFs[i].X, PointFs[i].Y, PointFs[i].Z, 1 });
                PointFs[i].X = transformed[0] * transformed[3];
                PointFs[i].Y = transformed[1] * transformed[3];
                PointFs[i].Z = transformed[2] * transformed[3];
            }

            return PointFs;
        }

        public static double[] MatrixMult(double[,] afin_matrix, double[] PointF)
        {
            double[] res = new double[4];

            for (int i = 0; i < 4; ++i)
            {
                res[i] = 0;
                for (int k = 0; k < 4; ++k)
                    res[i] += afin_matrix[k, i] * PointF[k];
            }

            double[] result = new double[4];
            for (int i = 0; i < 4; ++i)
                result[i] = res[i];
            return result;
        }

        public static double[] MatrixMultRight(double[,] afin_matrix, double[] PointF)
        {
            double[] res = new double[4];

            for (int i = 0; i < 4; ++i)
            {
                res[i] = 0;
                for (int k = 0; k < 4; ++k)
                    res[i] += afin_matrix[i, k] * PointF[k];
            }

            double[] result = new double[4];
            for (int i = 0; i < 4; ++i)
                result[i] = res[i];
            return result;
        }

        public static double[,] MatrixMult2(double[,] afin_matrix1, double[,] afin_matrix2)
        {
            double[,] res = new double[afin_matrix1.GetLength(0), afin_matrix2.GetLength(1)];

            for (int i = 0; i < afin_matrix1.GetLength(0); ++i)
                for (int k = 0; k < afin_matrix2.GetLength(0); ++k)
                    for (int j = 0; j < afin_matrix2.GetLength(1); ++j)
                        res[i, k] += afin_matrix1[i, j] * afin_matrix2[j, k];

            return res;
        }

        public static double[,] MatrixOffset(double dx, double dy, double dz)
        {
            double[,] afin_matrix = new double[4, 4];

            for (int i = 0; i < 4; ++i)
                for (int i1 = 0; i1 < 4; ++i1)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else afin_matrix[i, i1] = 1;

            afin_matrix[3, 0] = dx;
            afin_matrix[3, 1] = dy;
            afin_matrix[3, 2] = dz;
            return afin_matrix;
        }

        public static double[,] MatrixRotationX(double n, double m, double d)
        {
            double cos_ang = n / d;
            double sin_ang = m / d;
            double[,] afin_matrix = new double[4, 4];

            for (int i = 0; i < 4; i++)
                for (int i1 = 0; i1 < 4; i1++)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else afin_matrix[i, i1] = 1;

            afin_matrix[1, 1] = cos_ang;
            afin_matrix[1, 2] = sin_ang;
            afin_matrix[2, 1] = -sin_ang;
            afin_matrix[2, 2] = cos_ang;
            return afin_matrix;
        }

        public static double[,] MatrixRotationY(double l, double d)
        {
            double cos_ang = l;
            double sin_ang = -d;
            double[,] afin_matrix = new double[4, 4];

            for (int i = 0; i < 4; i++)
                for (int i1 = 0; i1 < 4; i1++)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else afin_matrix[i, i1] = 1;

            afin_matrix[0, 0] = cos_ang;
            afin_matrix[0, 2] = sin_ang;
            afin_matrix[2, 0] = -sin_ang;
            afin_matrix[2, 2] = cos_ang;
            return afin_matrix;
        }

        public static double[,] MatrixRotationZ(double rad_angle)
        {
            double cos_ang = Math.Cos(rad_angle);
            double sin_ang = Math.Sin(rad_angle);
            double[,] afin_matrix = new double[4, 4];

            for (int i = 0; i < 4; i++)
                for (int i1 = 0; i1 < 4; i1++)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else afin_matrix[i, i1] = 1;

            afin_matrix[0, 0] = cos_ang;
            afin_matrix[1, 0] = -sin_ang;
            afin_matrix[0, 1] = sin_ang;
            afin_matrix[1, 1] = cos_ang;
            return afin_matrix;
        }

        public static double[,] MatrixRotation(double angle)
        {
            double rad_angle = (angle / 180.0 * Math.PI);
            double[,] afin_matrix = new double[4, 4];

            for (int i = 0; i < 4; i++)
                for (int i1 = 0; i1 < 4; i1++)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else afin_matrix[i, i1] = 1;

            afin_matrix[0, 0] = Math.Cos(rad_angle);
            afin_matrix[0, 1] = Math.Sin(rad_angle);
            afin_matrix[1, 0] = -Math.Sin(rad_angle);
            afin_matrix[1, 1] = Math.Cos(rad_angle);
            return afin_matrix;
        }

        public static double[,] MatrixRotateGeneral(double l, double m, double n, double angle)
        {
            double rad_angle = (angle / 180.0 * Math.PI);
            double cos_ang = Math.Cos(rad_angle);
            double sin_ang = Math.Sin(rad_angle);
            double[,] afin_matrix = new double[4, 4];

            afin_matrix[0, 0] = l * l + cos_ang * (1 - l * l);
            afin_matrix[0, 1] = l * (1 - cos_ang) * m + n * sin_ang;
            afin_matrix[0, 2] = l * (1 - cos_ang) * n - m * sin_ang;
            afin_matrix[1, 0] = l * (1 - cos_ang) * m - n * sin_ang;
            afin_matrix[1, 1] = m * m + cos_ang * (1 - m * m);
            afin_matrix[1, 2] = m * (1 - cos_ang) * n + l * sin_ang;
            afin_matrix[2, 0] = l * (1 - cos_ang) * n + m * sin_ang;
            afin_matrix[2, 1] = m * (1 - cos_ang) * n - l * sin_ang;
            afin_matrix[2, 2] = n * n + cos_ang * (1 - n * n);

            for (int i = 0; i < 3; i++)
            {
                afin_matrix[i, 3] = 0;
                afin_matrix[3, i] = 0;
            }

            afin_matrix[3, 3] = 1;
            return afin_matrix;
        }

        public static double[,] MatrixRefl(double koef_x, double koef_y, double koef_z)
        {
            double[,] afin_matrix = new double[4, 4];

            for (int i = 0; i < 4; ++i)
                for (int i1 = 0; i1 < 4; ++i1)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else
                        afin_matrix[i, i1] = 1;

            afin_matrix[0, 0] = koef_x;
            afin_matrix[1, 1] = koef_y;
            afin_matrix[2, 2] = koef_z;
            return afin_matrix;
        }

        public static double[,] MatrixScaele (double koef_x, double koef_y, double koef_z)
        {
            double[,] afin_matrix = new double[4, 4];

            for (int i = 0; i < 4; ++i)
                for (int i1 = 0; i1 < 4; ++i1)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else
                        afin_matrix[i, i1] = 1;

            afin_matrix[0, 0] = koef_x;
            afin_matrix[1, 1] = koef_y;
            afin_matrix[2, 2] = koef_z;
            return afin_matrix;
        }

        public static double[,] translation_matrix(double dx, double dy, double dz)
        {
            return new double[,] { {1, 0, 0, 0 },
                                   { 0, 1, 0, 0},
                                   { 0, 0, 1, 0 },
                                   { dx, dy, dz, 1 } };
        }

        public static double[,] MatrixRotationXAngular(double rad_angle)
        {
            double cos_ang = Math.Cos(rad_angle);
            double sin_ang = Math.Sin(rad_angle);
            double[,] afin_matrix = new double[4, 4];

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

        public static double[,] MatrixRotationYAngular(double rad_angle)
        {
            double cos_ang = Math.Cos(rad_angle);
            double sin_ang = Math.Sin(rad_angle);
            double[,] afin_matrix = new double[4, 4];

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
        public static double[,] rotation_matrix(XYZPoint a, XYZPoint dir, double angle)
        {
            double x = a.X;
            double y = a.Y;
            double z = a.Z;
            double[,] translate_to_a = translation_matrix(-x, -y, -z);
            double x1 = dir.X;
            double y1 = dir.Y;
            double z1 = dir.Z;
            double[,] rotation = MatrixRotateGeneral(x1, y1, z1, angle);
            double[,] translate_back = translation_matrix(x, y, z);
            return MatrixMult2(MatrixMult2(translate_to_a, rotation), translate_back);
        }

        public static double[,] MatrixRotationZAngular(double rad_angle)
        {
            double cos_ang = Math.Cos(rad_angle);
            double sin_ang = Math.Sin(rad_angle);
            double[,] afin_matrix = new double[4, 4];

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

        public static double[,] MatrixIsometry()
        {
            double[,] res_matrix = new double[4, 4];
            double cos_x = Math.Cos(Math.PI+25);
            double sin_x = Math.Sin(Math.PI+25);
            //Math.PI+25

            double cos_y = cos_x;
            double sin_y = sin_x;

            res_matrix[0, 0] = cos_y;
            res_matrix[0, 1] = sin_y * sin_x;
            res_matrix[1, 1] = cos_x;
            res_matrix[2, 0] = sin_y;
            res_matrix[2, 1] = -cos_y * sin_x;
            res_matrix[3, 3] = 1;

            return res_matrix;

            // 60 y
        }

        public static double[,] MatrixPerspective(double r)
        {
            double[,] res_matrix = new double[4, 4] { { 1, 0, 0, 0},
                                                    { 0, 1, 0, 0 },
                                                    { 0, 0, 0, -1/r },
                                                    { 0, 0, 0, 1 }};
            return res_matrix;
        }

        public Matrix()
        {; }
    }
}

