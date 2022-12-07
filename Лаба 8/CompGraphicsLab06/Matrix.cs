using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08
{
    class Matrix
    {
        static public float[,] matrixColumnFromXYZPoint(XYZPoint point)
        {
            return new float[,] { { point.X }, { point.Y }, { point.Z }, { 1 } };

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

        public static float[,] MatrixOffset(float dx, float dy, float dz)
        {
            float[,] afin_matrix = new float[4, 4];

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

        public static float[,] MatrixRotationX(float n, float m, float d)
        {
            float cos_ang = n / d;
            float sin_ang = m / d;
            float[,] afin_matrix = new float[4, 4];

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

        public static float[,] MatrixRotationY(float l, float d)
        {
            float cos_ang = l;
            float sin_ang = -d;
            float[,] afin_matrix = new float[4, 4];

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

        public static float[,] MatrixRotationZ(float rad_angle)
        {
            float cos_ang = (float)Math.Cos(rad_angle);
            float sin_ang = (float)Math.Sin(rad_angle);
            float[,] afin_matrix = new float[4, 4];

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

        public static float[,] MatrixRotation(float angle)
        {
            float rad_angle = (float)(angle / 180.0 * Math.PI);
            float[,] afin_matrix = new float[4, 4];

            for (int i = 0; i < 4; i++)
                for (int i1 = 0; i1 < 4; i1++)
                    if (i1 != i)
                        afin_matrix[i, i1] = 0;
                    else afin_matrix[i, i1] = 1;

            afin_matrix[0, 0] = (float)Math.Cos(rad_angle);
            afin_matrix[0, 1] = (float)Math.Sin(rad_angle);
            afin_matrix[1, 0] = (float)-Math.Sin(rad_angle);
            afin_matrix[1, 1] = (float)Math.Cos(rad_angle);
            return afin_matrix;
        }

        public static float[,] MatrixRotateGeneral(float l, float m, float n, float angle)
        {
            float rad_angle = (float)(angle / 180.0 * Math.PI);
            float cos_ang = (float)Math.Cos(rad_angle);
            float sin_ang = (float)Math.Sin(rad_angle);
            float[,] afin_matrix = new float[4, 4];

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

        public static float[,] MatrixRefl(float koef_x, float koef_y, float koef_z)
        {
            float[,] afin_matrix = new float[4, 4];

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

        public static float[,] MatrixScaele (float koef_x, float koef_y, float koef_z)
        {
            float[,] afin_matrix = new float[4, 4];

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

        public static float[,] translation_matrix(float dx, float dy, float dz)
        {
            return new float[,] { {1, 0, 0, 0 },
                                   { 0, 1, 0, 0},
                                   { 0, 0, 1, 0 },
                                   { dx, dy, dz, 1 } };
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
        public static float[,] rotation_matrix(XYZPoint a, XYZPoint dir, float angle)
        {
            float x = a.X;
            float y = a.Y;
            float z = a.Z;
            float[,] translate_to_a = translation_matrix(-x, -y, -z);
            float x1 = dir.X;
            float y1 = dir.Y;
            float z1 = dir.Z;
            float[,] rotation = MatrixRotateGeneral(x1, y1, z1, angle);
            float[,] translate_back = translation_matrix(x, y, z);
            return MatrixMult2(MatrixMult2(translate_to_a, rotation), translate_back);
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

        public static float[,] MatrixIsometry()
        {
            float[,] res_matrix = new float[4, 4];
            float cos_x = (float)Math.Cos(Math.PI / 5);
            float sin_x = (float)Math.Sin(Math.PI / 5);

            float cos_y = (float)Math.Cos((-1) * Math.PI / 4);
            float sin_y = (float)Math.Sin((-1) * Math.PI / 4);

            res_matrix[0, 0] = cos_y;
            res_matrix[0, 1] = sin_y * sin_x;
            res_matrix[1, 1] = cos_x;
            res_matrix[2, 0] = sin_y;
            res_matrix[2, 1] = -cos_y * sin_x;
            res_matrix[3, 3] = 1;

            return res_matrix;

            // 60 y

            /*
             
            float cos_x = Math.Cos(Math.PI/5);
            float sin_x = Math.Sin(Math.PI/5);
            //Math.PI+25

            float cos_y = Math.Cos((-1) * Math.PI / 4);
            float sin_y = Math.Sin((-1) * Math.PI / 4);
             */
        }

        public static float[,] MatrixPerspective(float r)
        {
            float[,] res_matrix = new float[4, 4] { { 1, 0, 0, 0},
                                                    { 0, 1, 0, 0 },
                                                    { 0, 0, 0, -1/r },
                                                    { 0, 0, 0, 1 }};
            return res_matrix;
        }

        public Matrix()
        {; }
    }
}

