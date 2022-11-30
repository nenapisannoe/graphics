using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using System.Reflection;

namespace _3DLab6
{
    class Dodecaedron : Primitive
    {
        /*
        // кол-во вершин = 20
        private List<XYZPoint> points = new List<XYZPoint>();

        // кол-во граней = 12
        private List<Verge> verges = new List<Verge>();

        public List<XYZPoint> Points { get { return points; } }
        public List<Verge> Verges { get { return verges; } }
        */

        public XYZPoint Center
        {
            get
            {
                XYZPoint p = new XYZPoint(0, 0, 0);
                return p;
            }
        }

        public Dodecaedron(double size)
        {
            List<XYZPoint> points = new List<XYZPoint>();
            double r = 100 * (3 + Math.Sqrt(5)) / 4;
            double x = 100 * (1 + Math.Sqrt(5)) / 4;
            points.Clear();

            points.Add(new XYZPoint(0, -50, -r));
            points.Add(new XYZPoint(0, 50, -r));
            points.Add(new XYZPoint(x, x, -x));
            points.Add(new XYZPoint(r, 0, -50));
            points.Add(new XYZPoint(x, -x, -x));
            points.Add(new XYZPoint(50, -r, 0));
            points.Add(new XYZPoint(-50, -r, 0));
            points.Add(new XYZPoint(-x, -x, -x));
            points.Add(new XYZPoint(-r, 0, -50));
            points.Add(new XYZPoint(-x, x, -x));
            points.Add(new XYZPoint(-50, r, 0));
            points.Add(new XYZPoint(50, r, 0));
            points.Add(new XYZPoint(-x, -x, x));
            points.Add(new XYZPoint(0, -50, r));
            points.Add(new XYZPoint(x, -x, x));
            points.Add(new XYZPoint(0, 50, r));
            points.Add(new XYZPoint(-x, x, x));
            points.Add(new XYZPoint(x, x, x));
            points.Add(new XYZPoint(-r, 0, 50));
            points.Add(new XYZPoint(r, 0, 50));
        }
    }
}
