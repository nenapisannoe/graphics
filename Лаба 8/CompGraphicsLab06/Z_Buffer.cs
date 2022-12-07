using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab08
{
    class Z_Buffer
    {
        private static int ProjMode = 0;

        public static Bitmap Z_buffer(int width, int heigh, List<Figure> scene, List<Color> colors, int projMode = 0)
        {
            ProjMode = projMode;

            Bitmap newImg = new Bitmap(width, heigh);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < heigh; j++)
                    newImg.SetPixel(i, j, Color.White);

            float[,] zbuff = new float[width, heigh];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < heigh; j++)
                    zbuff[i, j] = float.MinValue;

            List<List<List<XYZPoint>>> rasterizedScene = new List<List<List<XYZPoint>>>();
            for (int i = 0; i < scene.Count; i++)
                rasterizedScene.Add(Rasterize(scene[i]));

            var centerX = width / 2;
            var centerY = heigh / 2;

            int ind = 0;
            for (int i = 0; i < rasterizedScene.Count; i++)
            {
                //Смещение по центру фигуры
                var figureLeftX = rasterizedScene[i].Where(face => face.Count != 0).Min(face => face.Min(vertex => vertex.X));
                var figureLeftY = rasterizedScene[i].Where(face => face.Count != 0).Min(face => face.Min(vertex => vertex.Y));
                var figureRightX = rasterizedScene[i].Where(face => face.Count != 0).Max(face => face.Max(vertex => vertex.X));
                var figureRightY = rasterizedScene[i].Where(face => face.Count != 0).Max(face => face.Max(vertex => vertex.Y));
                var figureCenterX = (figureRightX - figureLeftX) / 2;
                var figureCenterY = (figureRightY - figureLeftY) / 2;

                Random r = new Random(0);

                for (int j = 0; j < rasterizedScene[i].Count; j++)
                {
                    List<XYZPoint> curr = rasterizedScene[i][j];
                    foreach (XYZPoint point in curr)
                    {
                        int x = (int)(point.X + centerX - figureCenterX);
                        int y = (int)(point.Y + centerY - figureCenterY);
                        if (x < width && y < heigh && x > 0 && y > 0)
                        {
                            if (point.Z > zbuff[x, y])
                            {
                                zbuff[x, y] = point.Z;
                                newImg.SetPixel(x, y, colors[ind % colors.Count]);
                            }
                        }
                    }
                    ind++;
                }
            }
            return newImg;
        }

        private static List<List<XYZPoint>> Rasterize(Figure Figure)
        {
            List<List<XYZPoint>> rasterized = new List<List<XYZPoint>>();

            foreach (var facet in Figure.Faces)
            {
                List<XYZPoint> currentFac = new List<XYZPoint>();
                List<XYZPoint> facetXYZPoints = new List<XYZPoint>();
                for (int i = 0; i < facet.Count; i++)
                    facetXYZPoints.Add(Figure.Vertexes[facet[i]]);

                List<List<XYZPoint>> triangles = Triangulate(facetXYZPoints);
                foreach (List<XYZPoint> triangle in triangles)
                    currentFac.AddRange(RasterizeTriangle(MakeProj(triangle)));
                rasterized.Add(currentFac);
            }

            return rasterized;
        }

        private static List<XYZPoint> RasterizeTriangle(List<XYZPoint> points)
        {
            List<XYZPoint> res = new List<XYZPoint>();

            points.Sort((point1, point2) => point1.Y.CompareTo(point2.Y));
            var rpoints = points.Select(point => (X: (int)Math.Round(point.X), Y: (int)Math.Round(point.Y), Z: (int)Math.Round(point.Z))).ToList();

            var x01 = Interpolate(rpoints[0].Y, rpoints[0].X, rpoints[1].Y, rpoints[1].X);
            var x12 = Interpolate(rpoints[1].Y, rpoints[1].X, rpoints[2].Y, rpoints[2].X);
            var x02 = Interpolate(rpoints[0].Y, rpoints[0].X, rpoints[2].Y, rpoints[2].X);

            var z01 = Interpolate(rpoints[0].Y, rpoints[0].Z, rpoints[1].Y, rpoints[1].Z);
            var z12 = Interpolate(rpoints[1].Y, rpoints[1].Z, rpoints[2].Y, rpoints[2].Z);
            var z02 = Interpolate(rpoints[0].Y, rpoints[0].Z, rpoints[2].Y, rpoints[2].Z);

            x01.RemoveAt(x01.Count - 1);
            List<int> x012 = x01.Concat(x12).ToList();

            z01.RemoveAt(z01.Count - 1);
            List<int> z012 = z01.Concat(z12).ToList();

            int middle = x012.Count / 2;
            List<int> leftX, rightX, leftZ, rightZ;
            if (x02[middle] < x012[middle])
            {
                leftX = x02;
                leftZ = z02;
                rightX = x012;
                rightZ = z012;
            }
            else
            {
                leftX = x012;
                leftZ = z012;
                rightX = x02;
                rightZ = z02;
            }

            int y0 = rpoints[0].Y;
            int y2 = rpoints[2].Y;

            for (int ind = 0; ind <= y2 - y0; ind++)
            {
                int XL = leftX[ind];
                int XR = rightX[ind];

                List<int> intCurrZ = Interpolate(XL, leftZ[ind], XR, rightZ[ind]);

                for (int x = XL; x < XR; x++)
                    res.Add(new XYZPoint(x, y0 + ind, intCurrZ[x - XL]));
            }

            return res;
        }

        private static List<List<XYZPoint>> Triangulate(List<XYZPoint> points)
        {
            if (points.Count == 3)
                return new List<List<XYZPoint>> { points };

            List<List<XYZPoint>> res = new List<List<XYZPoint>>();
            for (int i = 2; i < points.Count; i++)
                res.Add(new List<XYZPoint> { points[0], points[i - 1], points[i] });

            return res;
        }

        private static List<int> Interpolate(int i0, int d0, int i1, int d1)
        {
            if (i0 == i1)
                return new List<int> { d0 };

            List<int> res = new List<int>();

            float step = (d1 - d0) * 1.0f / (i1 - i0);
            float value = d0;

            for (int i = i0; i <= i1; i++)
            {
                res.Add((int)value);
                value += step;
            }

            return res;
        }

        public static List<XYZPoint> MakeProj(List<XYZPoint> init)
        {
            return new Projection().Project3(init, ProjMode);
        }
    }
}

