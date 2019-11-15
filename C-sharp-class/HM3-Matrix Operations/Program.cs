using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM3_Matrix_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix[] Matr = new Matrix[2];
            Matr[0] = new Matrix(3, 4);
            Matr[1] = new Matrix(4, 2);
            Matrix Addition = Matrix.Add(Matr);
            Matrix Multiplication = Matrix.Multiply(Matr);
        }
    }
}
