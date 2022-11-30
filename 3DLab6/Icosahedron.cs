using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace _3DLab6
{
    class Icosahedron : Primitive
    {
        public Icosahedron(double size)
        {
            double R = (size * Math.Sqrt(2.0 * (5.0 + Math.Sqrt(5.0)))) / 4;
            double r = (size * Math.Sqrt(3.0) * (3.0 + Math.Sqrt(5.0))) / 12;
            Points = new List<XYZPoint>();

            for (int i = 0; i < 5; i++)
            {
                Points.Add(new XYZPoint(r * Math.Cos(2 * Math.PI / 5 * i), R / 2, r * Math.Sin(2 * Math.PI / 5 * i)));
                Points.Add(new XYZPoint(r * Math.Cos(2 * Math.PI / 5 * i + 2 * Math.PI / 10), -R / 2, r * Math.Sin(2 * Math.PI / 5 * i + 2 * Math.PI / 10)));
            }

            Points.Add(new XYZPoint(0, R, 0));
            Points.Add(new XYZPoint(0, -R, 0));

            for (int i = 0; i < 10; i++)
                Edges.Add(new Edge(new List<XYZPoint> { Points[i], Points[(i + 1) % 10], Points[(i + 2) % 10] }));

            for (int i = 0; i < 5; i++)
            {
                Edges.Add(new Edge(new List<XYZPoint> { Points[2 * i], Points[10], Points[(2 * (i + 1)) % 10] }));
                Edges.Add(new Edge(new List<XYZPoint> { Points[2 * i + 1], Points[11], Points[(2 * (i + 1) + 1) % 10] }));
            }
        }

    }
}
