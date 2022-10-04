using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4
{
    class Matrix
    {
        public int _n1, _n2;
        double[,] _m;

        public double this[int x, int y]
        {
            get { return _m[x, y]; }
            set { _m[x, y] = value; }
        }

        public Matrix(int n)
        {
            _n1 = n;
            _n2 = n;
            _m = new double[_n1, _n2];
        }

        public Matrix(int n1, int n2)
        {
            _n1 = n1;
            _n2 = n2;
            _m = new double[_n1, _n2];
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            var res = new Matrix(m1._n1, m2._n2);

            for (int i = 0; i < m1._n1; i++)            
                for (int j = 0; j < m2._n2; j++)            
                    for (int k = 0; k < m2._n1; k++)                    
                        res._m[i, j] += m1._m[i, k] * m2._m[k, j];

            return res;
        }
    }
}
