using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Lab06
{
#pragma warning disable CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
#pragma warning disable CS0661 // Тип определяет оператор == или оператор !=, но не переопределяет Object.GetHashCode()
    public class XYZPoint
#pragma warning restore CS0661 // Тип определяет оператор == или оператор !=, но не переопределяет Object.GetHashCode()
#pragma warning restore CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
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
    }

    // Ребро в пространтсве
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

    // Многогранник
    public class Figure
    {
        // Список вершин
        public List<XYZPoint> Vertexes { get; set; } = new List<XYZPoint>();

        // Список ребер
        public List<Edge> Edges { get; } = new List<Edge>();

        // Список граней. Грани заданы списком вершин (вершины заданы индексами в списке вершин)
        public List<List<int>> Faces { get; } = new List<List<int>>();

        // Матрица смежности - для каждой точки хранит список смежных с ней
        public Dictionary<int, List<int>> Adjacency { get; } = new Dictionary<int, List<int>>();

        // Получить центр многогранника
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

        // Конструктор многогранника от списка вершин
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

        // Добавить ребро
        public void AddEdge(int startEdge, int endEdge)
        {
            if (!Adjacency.ContainsKey(startEdge))
                Adjacency.Add(startEdge, new List<int> { endEdge });
            else
                Adjacency[startEdge].Add(endEdge);
        }

        // Добавить множество ребер из точки FROM в каждую точку списка LIST
        public void AddEdges(int from, List<int> list)
        {
            foreach (int to in list)
                AddEdge(from, to);
        }

        public void AddFace(List<int> list)
        {
            Faces.Add(list);
        }
    }
}
