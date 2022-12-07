using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08
{
    public class XYZPoint
    {
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;
        public float Z { get; set; } = 0;

        public XYZPoint(float x, float y, float z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        static public bool operator ==(XYZPoint point1, XYZPoint point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y && point1.Z == point2.Z;
        }

        static public bool operator !=(XYZPoint point1, XYZPoint point2)
        {
            return !(point1 == point2);
        }

        static public XYZPoint operator +(XYZPoint point1, XYZPoint point2)
        {
            return new XYZPoint(point1.X + point2.X, point1.Y + point2.Y, point1.Z + point2.Z);
        }

        static public XYZPoint operator -(XYZPoint point1, XYZPoint point2)
        {
            return new XYZPoint(point1.X - point2.X, point1.Y - point2.Y, point1.Z - point2.Z);
        }

        public Point ConvertToPoint() 
        { 
            return new Point((int)X, (int)Y); 
        }

        public float DistanceTo(XYZPoint p2)
        {
            return (float)Math.Sqrt((X - p2.X) * (X - p2.X) + (Y - p2.Y) * (Y - p2.Y) + (Z - p2.Z) * (Z - p2.Z));
        }
    }

    class Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Length
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public Vector3(float x, float y, float z)
        {
            X = x; Y = y; Z = z;
        }

        public Vector3 Normalize() => Length > 0 ? new Vector3(X / Length, Y / Length, Z / Length) : new Vector3(0, 0, 0);

        public static float ScalarProduct(Vector3 v1, Vector3 v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        public static Vector3 VectorProduct(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2) => new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        public static Vector3 operator -(Vector3 v1, Vector3 v2) => new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    public class Edge
    {
        public XYZPoint From { get; set; }
        public XYZPoint To { get; set; }

        public Edge(XYZPoint point1, XYZPoint point2)
        {
            From = point1;
            To = point2;
        }
        public Edge(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            From = new XYZPoint(x1, y1, z1);
            To = new XYZPoint(x2, y2, z2);
        }
    }

    public class Figure
    {
        public List<XYZPoint> Vertexes { get; set; } = new List<XYZPoint>();

        public List<Edge> Edges { get; set; } = new List<Edge>();

        public List<List<int>> Faces { get; } = new List<List<int>>();

        public Dictionary<int, List<int>> Adjacency { get; set; } = new Dictionary<int, List<int>>();

        public XYZPoint Center()
        {
            float x = Vertexes.Average(point => point.X);
            float y = Vertexes.Average(point => point.Y);
            float z = Vertexes.Average(point => point.Z);
            return new XYZPoint(x, y, z);
        }

        public bool IsEmpty() => Vertexes.Count < 1;

        public void Clear()
        {
            Vertexes.Clear();
            Edges.Clear();
            Faces.Clear();
            Adjacency.Clear();
        }

        public Figure(List<XYZPoint> points)
        {
            Vertexes = points;
            int i = 0;
            foreach (XYZPoint point in points)
            {
                i++;
                Adjacency.Add(i, new List<int>());
            }
        }

        public Figure() { }

        public Figure(Figure old)
        {
            Vertexes = new List<XYZPoint>(old.Vertexes);
            Edges = new List<Edge>(old.Edges);
            Adjacency = new Dictionary<int, List<int>>();
            foreach (var ad in old.Adjacency)
                Adjacency.Add(ad.Key, new List<int>(ad.Value));
            Faces = new List<List<int>>();
            foreach (var f in old.Faces)
                Faces.Add(new List<int>(f));            
        }

        public void AddEdge(int from, int to)
        {
            if (!Adjacency.ContainsKey(from))
                Adjacency.Add(from, new List<int> { to });
            else
                Adjacency[from].Add(to);
        }

        public void AddEdges(int from, List<int> lst)
        {
            foreach (int to in lst)
                AddEdge(from, to);
        }

        public void AddFace(List<int> lst)
        {
            Faces.Add(lst);
        }

        public XYZPoint[] GetPoints(List<int> face)
        {
            XYZPoint[] XYZPoints = new XYZPoint[face.Count];

            for (int i = 0; i < face.Count; ++i)
                XYZPoints[i] = (Vertexes[i]);

            return XYZPoints;
        }

    }
}
