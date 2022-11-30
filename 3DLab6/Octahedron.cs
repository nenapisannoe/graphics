using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DLab6
{
    class Octahedron : Primitive
    {

		//private List<XYZPoint> points = new List<XYZPoint>();

		//private List<Edge> edges = new List<Edge>();

		//public List<XYZPoint> Points { get { return points; } }
		//public List<Edge> Edges { get { return edges; } }


		public Octahedron(double size)
		{

			Points = new List<XYZPoint>();

			Points.Add(new XYZPoint(-size / 2, 0, 0));
			Points.Add(new XYZPoint(0, -size / 2, 0));
			Points.Add(new XYZPoint(0, 0, -size / 2));
			Points.Add(new XYZPoint(size / 2, 0, 0));
			Points.Add(new XYZPoint(0, size / 2, 0));
			Points.Add(new XYZPoint(0, 0, size / 2));

			Edges.Add(new Edge(new List<XYZPoint> { Points[0], Points[2], Points[4] }));
			Edges.Add(new Edge(new List<XYZPoint> { Points[2], Points[4], Points[3] }));
			Edges.Add(new Edge(new List<XYZPoint> { Points[4], Points[5], Points[3] }));
			Edges.Add(new Edge(new List<XYZPoint> { Points[0], Points[5], Points[4] }));
			Edges.Add(new Edge(new List<XYZPoint> { Points[0], Points[5], Points[1] }));
			Edges.Add(new Edge(new List<XYZPoint> { Points[5], Points[3], Points[1] }));
			Edges.Add(new Edge(new List<XYZPoint> { Points[0], Points[2], Points[1] }));
			Edges.Add(new Edge(new List<XYZPoint> { Points[2], Points[1], Points[3] }));
		}

	}
}
