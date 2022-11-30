using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DLab6
{
    class Tetrahedron : Primitive
    {
        private List<XYZPoint> _points = new List<XYZPoint>();
        private List<Edge> _edges = new List<Edge>();

        //public List<XYZPoint> Points { get { return _points; } }
        //public List<Edge> Edges { get { return _edges; } }

        public Tetrahedron(double size)
        {
            double h = Math.Sqrt(2.0 / 3.0) * size;
            _points = new List<XYZPoint>();

            Points.Add(new XYZPoint(-size / 2, 0, h / 3));
            Points.Add(new XYZPoint(0, 0, -h * 2 / 3));
            Points.Add(new XYZPoint(size / 2, 0, h / 3));
            Points.Add(new XYZPoint(0, h, 0));

            Edges.Add(new Edge(new List<XYZPoint> { Points[0], Points[1], Points[2] }));
            Edges.Add(new Edge(new List<XYZPoint> { Points[1], Points[3], Points[0] }));
            Edges.Add(new Edge(new List<XYZPoint> { Points[2], Points[3], Points[1] }));
            Edges.Add(new Edge(new List<XYZPoint> { Points[0], Points[3], Points[2] }));
        }
    }
}
