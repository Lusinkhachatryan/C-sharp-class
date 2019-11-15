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

        public Matrix(int rows, int columns, int[] elems)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.Matr = new double[this.Rows, this.Columns];
            int el = 0;
            for (int i = 0; i < this.Rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    Matr[i, j] = elems[el];
                    ++el;
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
