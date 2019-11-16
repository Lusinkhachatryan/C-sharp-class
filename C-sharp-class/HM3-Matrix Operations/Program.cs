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
            //Matrix[] Matr = new Matrix[2];
            //Matr[0] = new Matrix(3, 4);
            //Matr[1] = new Matrix(4, 2);
            //Matrix Addition = Matrix.Add(Matr);
            //Matrix Multiplication = Matrix.Multiply(Matr);
            //Matrix[] MultiplicationByScalar = Matrix.MultiplyByScalar(Matr, 5);
            double[,] elemsforinverse = new double[,] { {3, 0, 2 }, {2, 0, -2}, { 0, 1, 1 } };
            Matrix ExForInverse = new Matrix(3, 3, elemsforinverse);
            double[,] elemsForTranspose = new double[,] { { 6, 4, 24 }, { 1, -9, 8 } };
            Matrix ExForTranspose = new Matrix(2, 3, elemsForTranspose);

            Matrix InversedMatr = Matrix.Inverse(ExForInverse);
            Matrix.Transpose(ref ExForTranspose);
        }
    }
}
