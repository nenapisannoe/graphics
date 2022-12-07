using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab08
{
    class DeleteNonFrontFaces
    {
        private static XYZPoint GetNormalVector(List<int> facet, List<XYZPoint> vertexes)
        {
            XYZPoint firstVec = vertexes[facet[1]] - vertexes[facet[0]];
            XYZPoint secondVec = vertexes[facet[2]] - vertexes[facet[1]];
            if (secondVec.X == 0 && secondVec.Y == 0 && secondVec.Z == 0)
            {
                secondVec = vertexes[facet[3]] - vertexes[facet[2]];
            }
            return CrossProduct(firstVec, secondVec);
        }

        public static List<List<int>> DeleteFaces(Figure pl, XYZPoint viewDirection)
        {
            List<List<int>> res = new List<List<int>>();
            XYZPoint proec = pl.Center() - viewDirection; // вектор проекции
            foreach (var face in pl.Faces) // для каждой грани ищем вектор нормали
            {
                XYZPoint norm = GetNormalVector(face, pl.Vertexes);
                var scalar = norm.X * proec.X + norm.Y * proec.Y + norm.Z * proec.Z;
                var prodLength = Math.Sqrt(norm.X * norm.X + norm.Y * norm.Y + norm.Z * norm.Z) * Math.Sqrt(proec.X * proec.X + proec.Y * proec.Y + proec.Z * proec.Z);
                var cos = 0.0;
                if (prodLength != 0)
                    cos = scalar / prodLength;
                if (cos > 0)
                    res.Add(face);
            }
            return res;
        }

        // Векторное произведение векторов
        private static XYZPoint CrossProduct(XYZPoint vec1, XYZPoint vec2)
        {
            float x = vec1.Y * vec2.Z - vec1.Z * vec2.Y;
            float y = vec1.Z * vec2.X - vec1.X * vec2.Z;
            float z = vec1.X * vec2.Y - vec1.Y * vec2.X;
            return new XYZPoint(x, y, z);
        }
    }
}
