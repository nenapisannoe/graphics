using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB_3D
{
    class Matrixes
    {
        public List<my_point> get_transformed_my_points(double[,] afin_matrix, List<my_point> PointFs)
        {
            for (int i = 0; i < PointFs.Count(); ++i)
            {
                double[] transformed = matrix_mult(afin_matrix, new double[4] { PointFs[i].X, PointFs[i].Y, PointFs[i].Z, 1 });
                PointFs[i].X = transformed[0] / transformed[3];
                PointFs[i].Y = transformed[1] / transformed[3];
                PointFs[i].Z = transformed[2] / transformed[3];
            }

            return PointFs;
        }

        public List<my_point> get_transformed_my_points_nobr(double[,] afin_matrix, List<my_point> PointFs)
        {
            List<my_point> res = new List<my_point>();
            for (int i = 0; i < PointFs.Count(); ++i)
            {
                double[] transformed = matrix_mult(afin_matrix, new double[4] { PointFs[i].X, PointFs[i].Y, PointFs[i].Z, 1 });
                res.Add(new my_point(transformed[0] / transformed[3], transformed[1] / transformed[3], transformed[2] / transformed[3]));
            }

            return res;
        }

        public List<my_point> get_transformed_my_points_right(double[,] afin_matrix, List<my_point> PointFs)
        {
            for (int i = 0; i < PointFs.Count(); ++i)
            {
                double[] transformed = matrix_mult_right(afin_matrix, new double[4] { PointFs[i].X, PointFs[i].Y, PointFs[i].Z, 1 });
                PointFs[i].X = transformed[0] * transformed[3];
                PointFs[i].Y = transformed[1] * transformed[3];
                PointFs[i].Z = transformed[2] * transformed[3];
            }

            return PointFs;
        }

        public double[] matrix_mult(double[,] afin_matrix, double[] PointF)
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

        public double[] matrix_mult_right(double[,] afin_matrix, double[] PointF)
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

        public double[,] matrix_offset(double dx, double dy, double dz)
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

        public double[,] matrix_rotation_x(double n, double m, double d)
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

        public double[,] matrix_rotation_y(double l, double d)
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

        public double[,] matrix_rotation_z(double rad_angle)
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

        public double[,] matrix_rotation(double angle)
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

        public double[,] matrix_rotate_general(double l, double m, double n, double angle)
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

        public double[,] matrix_refl(double koef_x, double koef_y, double koef_z)
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

        public double[,] matrix_scale(double koef_x, double koef_y, double koef_z)
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

        public double[,] matrix_rotation_x_angular(double rad_angle)
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

        public double[,] matrix_rotation_y_angular(double rad_angle)
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

        public double[,] matrix_rotation_z_angular(double rad_angle)
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

        public double[,] matrix_isometry()
        {
            double[,] res_matrix = new double[4, 4];
            double cos_x = Math.Cos(Math.PI / 5);
            double sin_x = Math.Sin(Math.PI / 5);

            double cos_y = Math.Cos((-1) * Math.PI / 4);
            double sin_y = Math.Sin((-1) * Math.PI / 4);

            res_matrix[0, 0] = cos_y;
            res_matrix[0, 1] = sin_y * sin_x;
            res_matrix[1, 1] = cos_x;
            res_matrix[2, 0] = sin_y;
            res_matrix[2, 1] = -cos_y * sin_x;
            res_matrix[3, 3] = 1;

            return res_matrix;
        }

        public double[,] matrix_perspective(double r)
        {
            double[,] res_matrix = new double[4, 4] { { 1, 0, 0, 0},
                                                    { 0, 1, 0, 0 },
                                                    { 0, 0, 0, -1/r },
                                                    { 0, 0, 0, 1 }};
            return res_matrix;
        }

        public Matrixes()
        {; }
    }
}