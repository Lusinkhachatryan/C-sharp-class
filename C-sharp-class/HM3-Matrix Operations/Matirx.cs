using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM3_Matrix_Operations
{
    class Matrix
    {
        private int rows;
        public int Rows
        {
            get
            {
                return this.rows;
            }
            set
            {
                if (value > 0)
                {
                    this.rows = value;
                }
                else
                {
                    this.rows = 0;
                }
            }
        }

        private int columns;
        public int Columns
        {
            get
            {
                return this.columns;
            }
            set
            {
                if (value > 0)
                {
                    this.columns = value;
                }
                else
                {
                    this.columns = 0;
                }
            }
        }

        public double[,] Matr { get; set; }

        public Matrix(int rows, int columns, double defVal)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.Matr = new double[this.Rows, this.Columns];
            for (int i = 0; i < this.Rows; ++i)
            {
                for (int j = 0; j < this.Columns; ++j)
                {
                    Matr[i, j] = defVal;
                }

            }
        }

        public Matrix(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.Matr = new double[this.Rows, this.Columns];
            FillMatr(this.Matr);
        }
        void FillMatr(double[,] matr)
        {
            Random random = new Random();
            for (int i = 0; i < matr.GetLength(0); ++i)
            {
                for (int j = 0; j < matr.GetLength(1); ++j)
                {
                    matr[i, j] = random.Next(100);
                }
            }
        }

        public Matrix(int rows, int columns, double[,] elems)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.Matr = new double[this.Rows, this.Columns];
            
            for (int i = 0; i < this.Rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    Matr[i, j] = elems[i, j];                    
                }
            }
        } 

        static public Matrix Add(Matrix[] Matr_Array)
        {
            Matrix M3 = new Matrix(Matr_Array[0].Rows, Matr_Array[0].Columns, 0);
            if (Matr_Array.Length != 1 && IsAddable(Matr_Array))
            {
                for (int i = 0; i < Matr_Array[0].Rows; ++i)
                {
                    for (int j = 0; j < Matr_Array[0].Columns; ++j)
                    {
                        M3.Matr[i, j] = SumOfElems(Matr_Array, i, j);
                    }
                }
                return M3;
            }
            else
            {
                //////////////////poxel
                return M3;
            }            
        }

        static private double SumOfElems (Matrix[] M_Array, int row, int column, int N = 0)
        {
            if (N == M_Array.Length - 1)
            {
                return M_Array[N].Matr[row, column];
            }
            else
            {
                return M_Array[N].Matr[row, column] + SumOfElems(M_Array, row, column, ++N);
            }
        }

        static private bool IsAddable(Matrix[] M_Array)
        {
            for (int i = 1; i < M_Array.Length; ++i)
            {
                if(M_Array[i].Rows != M_Array[0].Rows || M_Array[i].Columns != M_Array[0].Columns)
                {
                    return false;
                }
            }
            return true;
            
        }
        

        static public Matrix Multiply(Matrix[] Matr_Array)
        {
            int lenght = Matr_Array.Length;
            Matrix M = new Matrix(Matr_Array[0].Rows, Matr_Array[lenght - 1].Columns, 0);
            if (lenght != 1 && Matrix.IsMultipliable(Matr_Array, lenght - 1))
            {
                Matrix[] NewArray = new Matrix[lenght];
                Matrix.Copy(Matr_Array, ref NewArray);
                M.Matr = Multiply(ref NewArray);                
            }

            return M;
        }

        static private double[,] Multiply(ref Matrix[] M_Array)
        {
            int lenght = M_Array.Length;
            if (lenght == 1)
            {
                return M_Array[0].Matr;
            }
            double[,] M01 = new double[M_Array[0].Rows, M_Array[1].Columns];

            for (int i = 0; i < M01.GetLength(0); ++i)
            {
                for (int j = 0; j < M01.GetLength(1); ++j)
                {
                    double el = 0;
                    for (int k = 0; k < M_Array[0].Columns; ++k)
                    {
                        el = el + M_Array[0].Matr[i, k] * M_Array[1].Matr[k, j]; 
                    }
                    M01[i, j] = el;
                }
            }

            Matrix[] New_MatrArray = new Matrix[lenght - 1];
            M_Array[1].Rows = M01.GetLength(0);
            M_Array[1].Columns = M01.GetLength(1);
            M_Array[1].Matr = M01;
            Matrix.Copy(M_Array, ref New_MatrArray, 1);
            M_Array = New_MatrArray;
            return Multiply(ref M_Array);


            //for (int i = 0; i < M_Array[0].Rows; ++i)
            //{
            //    for (int j = 0; j < M_Array[1].Columns; ++j)
            //    {
            //        for (int k = 0; k < M_Array[0].Columns; ++k)
            //        {

            //        }

            //    }
            //}
        }


        static private bool IsMultipliable(Matrix[] M_Array, int N)
        {
            if (N == 0)
            {
                return true;
            }
            if (M_Array[N].Rows == M_Array[N - 1].Columns)
            {
                return IsMultipliable(M_Array, N - 1);
            }
            else
            {
                return false;              
            }            
        }

        static public Matrix [] MultiplyByScalar(Matrix [] M_Array, double scalar)
        {
            Matrix[] NewMArray = new Matrix[M_Array.Length];
            for (int i = 0; i < M_Array.Length; ++i)
            {
                NewMArray[i] = new Matrix(M_Array[i].Rows, M_Array[i].Columns, 0);
                for (int m = 0; m < M_Array[i].Rows; ++m)
                {
                    for (int n = 0; n < M_Array[i].Columns; ++n)
                    {
                        NewMArray[i].Matr[m, n] = M_Array[i].Matr[m, n] * scalar;
                    }
                }
            }
            return NewMArray;
        }

        static public Matrix MultiplyByScalar(Matrix Matr, double scalar)
        {
            Matrix NewMArray = new Matrix(Matr.Rows, Matr.Columns, 0);

            for (int i = 0; i < Matr.Rows; ++i)
            {
                for (int j = 0; j < Matr.Columns; ++j)
                {
                    NewMArray.Matr[i, j] = Math.Round(Matr.Matr[i, j] * scalar, 2);
                }
            }
            
            return NewMArray;
        }
        static public Matrix Inverse (Matrix matrix)
        {
            if (matrix.Rows == matrix.Columns)
            {
                double determinant = Math.Round(Matrix.Determinant(matrix.Matr), 2);
                if (determinant != 0)
                {
                    Matrix adjugate = new Matrix(matrix.Rows, matrix.Columns, 0);
                    double[,] matrForAdjugate = MatrixofMinors(matrix);
                    int sign1 = 1;
                    for (int i = 0; i < matrix.Rows; ++i)
                    {
                        int sign2 = sign1;
                        for (int j = 0; j < matrix.Columns; ++j)
                        {                            
                            adjugate.Matr[i, j] = matrForAdjugate[i, j] * sign2;
                            sign2 *= -1;
                        }
                        sign1 *= -1;
                    }
                    Matrix.Transpose(ref adjugate);
                    return Matrix.MultiplyByScalar(adjugate, Math.Round(1 / determinant, 2));
                }
                Matrix M1 = new Matrix(0, 0, 0);
                return M1;
            }
            Matrix M2 = new Matrix(0, 0, 0);
            return M2;
        }

        static public double Determinant(double[,] matrix)
        {
            int lenghti = matrix.GetLength(0);
            if (lenghti == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                int lenghtj = matrix.GetLength(1);
                Matrix[] NewArray = new Matrix[lenghtj];
                for (int j = 0; j < lenghtj; ++j)
                {
                    NewArray[j] = new Matrix(lenghti - 1, lenghtj - 1, 0);
                    for (int i = 1; i < lenghti; ++i)
                    {
                        for (int c1 = 0, c2 = 0; c2 < lenghtj; )
                        {
                            if (c2 == j)
                            {
                                ++c2;
                                continue;
                            }
                            else
                            {
                                NewArray[j].Matr[i - 1, c1] = matrix[i, c2];
                                ++c1;
                                ++c2;
                            }
                        }
                    }

                }
                //double[] determs = new double[lenghtj];
                double Det = 0;
                int sign = 1;
                for (int j = 0; j < lenghtj; ++j)
                {
                    Det += sign * matrix[0, j] * Determinant(NewArray[j].Matr);
                    sign *= -1;
                }
                return Det;
            }
            
        }

        static private double[,] MatrixofMinors(Matrix matrix)
        {
            int lenghti = matrix.Rows;
            int lenghtj = matrix.Columns;
            double[,] matr = new double[lenghti, lenghtj];
            for (int i = 0; i < lenghti; ++i)
            {
                for (int j = 0; j < lenghtj; ++j)
                {
                    double[,] newArray = new double[lenghti - 1, lenghtj - 1];
                    for (int r1 = 0, r2 = 0; r2 < lenghti; )
                    {
                        if (r2 == i)
                        {
                            ++r2;
                            continue;
                        }

                        for (int c1 = 0, c2 = 0; c2 < lenghtj;)
                        {
                            if (c2 == j)
                            {
                                ++c2;                                
                                continue;
                            }                            
                            else
                            {
                                newArray[r1, c1] = matrix.Matr[r2, c2];
                                ++c1;
                                ++c2;
                            }
                        }
                        ++r1;
                        ++r2;
                    }

                    matr[i, j] = Math.Round(Determinant(newArray), 2);
                }
            }
            return matr;
        }

        static public void Transpose(ref Matrix matrix)
        {
            int lenghti = matrix.Rows;
            int lenghtj = matrix.Columns;
            Matrix newMatr = new Matrix(lenghtj, lenghti);
            for (int i = 0; i < lenghti; ++i)
            {
                for (int j = 0; j < lenghtj; ++j)
                {
                    int newi = 0;
                    int newj = 0;
                    int dif = Math.Abs(i - j);
                    if (i > j)
                    {                        
                        newi = i - dif;
                        newj = j + dif;
                    }
                    else if (i < j)
                    {
                        newi = i + dif;
                        newj = j - dif;
                    }
                    else
                    {
                        newi = i;
                        newj = j;
                    }
                    newMatr.Matr[newi, newj] = matrix.Matr[i, j];
                }
            }
            matrix = newMatr;
        }

        static private void Copy(Matrix[] M1, ref Matrix[] M2, int start = 0)
        {
            int j = 0;

            for (int i = start; i < M1.Length; ++i)
            {

                M2[j] = new Matrix(M1[i].Rows, M1[i].Columns, 0);
                
                M2[j].Matr = M1[i].Matr;

                ++j;
            }

        }

    }
}
