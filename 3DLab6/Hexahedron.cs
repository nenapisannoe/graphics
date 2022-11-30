using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DLab6
{
    class Hexahedron : Primitive
    {

		//private List<XYZPoint> points = new List<XYZPoint>();

		//private List<Edge> edges = new List<Edge>();

		//public List<XYZPoint> Points { get { return points; } }
		//public List<Edge> Edges { get { return edges; } }

		public Hexahedron(double size)
		{
			Points = new List<XYZPoint>();

			Points.Add(new XYZPoint(-size / 2, -size / 2, -size / 2));
			Points.Add(new XYZPoint(-size / 2, -size / 2, size / 2));
			Points.Add(new XYZPoint(-size / 2, size / 2, -size / 2));
			Points.Add(new XYZPoint(size / 2, -size / 2, -size / 2));
			Points.Add(new XYZPoint(-size / 2, size / 2, size / 2));
			Points.Add(new XYZPoint(size / 2, -size / 2, size / 2));
			Points.Add(new XYZPoint(size / 2, size / 2, -size / 2));
			Points.Add(new XYZPoint(size / 2, size / 2, size / 2));

			Edges.Add(new Edge(new List<XYZPoint> { Points[0], Points[1], Points[5], Points[3] }));
			Edges.Add(new Edge(new List<XYZPoint> { Points[2], Points[6], Points[3], Points[0] }));
			Edges.Add(new Edge(new List<XYZPoint> { Points[4], Points[1], Points[0], Points[2] }));
			Edges.Add(new Edge(new List<XYZPoint> { Points[7], Points[5], Points[3], Points[6] }));
			Edges.Add(new Edge(new List<XYZPoint> { Points[2], Points[4], Points[7], Points[6] }));
			Edges.Add(new Edge(new List<XYZPoint> { Points[4], Points[1], Points[5], Points[7] }));

		}

		public XYZPoint Center
		{
			get
			{
				XYZPoint p = new XYZPoint(0, 0, 0);
				for (int i = 0; i < 8; i++)
				{
					p.X += Points[i].X;
					p.Y += Points[i].Y;
					p.Z += Points[i].Z;
				}
				p.X /= 8;
				p.Y /= 8;
				p.Z /= 8;
				return p;
			}
		}

	}
}
