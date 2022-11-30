using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DLab6
{
    class XYZPoint
    {
        public double X, Y, Z;
        public XYZPoint(double x = 0, double y = 0, double z = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /*public DPoint()
        {
            this.X = this.Y = this.Z = 0;
        } */

        public static XYZPoint MultiplyTwoVectors(XYZPoint v1, XYZPoint v2)
        {
            XYZPoint res = new XYZPoint();
            res.X = (v1.Y * v2.Z - v1.Z * v2.Y);
            res.Y = (v1.Z * v2.X - v1.X * v2.Z);
            res.Z = (v1.X * v2.Y - v1.Y * v2.X);
            return res;
        }

        public XYZPoint GetNormal(List<Edge> edges)
        {
            XYZPoint res = new XYZPoint(0, 0, 0);
            foreach (var item in edges)
            {
                res.X += item.GetNormal().X;
                res.Y += item.GetNormal().Y;
                res.Z += item.GetNormal().Z;
            }
            res.X /= edges.Count;
            res.Y /= edges.Count;
            res.Z /= edges.Count;
            return res;
        }

        public double GetLength()
        {
            return Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
        }
    }
}
