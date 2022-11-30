using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DLab6
{
    class Edge
    {
        public List<XYZPoint> Points;
        public XYZPoint Normal;

        public Edge()
        {
            Points = new List<XYZPoint>();
        }

        public Edge(List<XYZPoint> points)
        {
            Points = new List<XYZPoint>();

            foreach (var p in points)
            {
                Points.Add(p);
            }
        }

        public void Add(XYZPoint p)
        {
            Points.Add(p);
        }

        public XYZPoint GetNormal()
        {
            XYZPoint p0 = Points[0];
            XYZPoint p1 = Points[1];
            XYZPoint p2 = Points[Points.Count - 1];
            XYZPoint v1 = new XYZPoint(p1.X - p0.X, p1.Y - p0.Y, p1.Z - p0.Z);
            XYZPoint v2 = new XYZPoint(p2.X - p0.X, p2.Y - p0.Y, p2.Z - p0.Z);
            return XYZPoint.MultiplyTwoVectors(v1, v2);
        }

        public XYZPoint GetCenter()
        {
            XYZPoint center = new XYZPoint();
            foreach (var item in this.Points)
            {
                center.X += item.X;
                center.Y += item.Y;
                center.Z += item.Z;
            }
            center.X = center.X / Points.Count;
            center.Y = center.Y / Points.Count;
            center.Z = center.Z / Points.Count;
            return center;
        }
    }
}
