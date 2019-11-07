using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2___Arrays
{
    class UpperTriangle
    {
        static void Main(string[] args)
        {
            int N;
            N = int.Parse(Console.ReadLine());
            int[,] Array = new int[N,N];
            for (int i = 0; i < N; ++i)
            {
                string line = Console.ReadLine();
                string[] splt = line.Split(' ');
                for (int j = 0; j < N; ++j)
                {
                    Array[i,j] = Convert.ToInt32(splt[j]);
                }                
            }

            PrintUpperTriangle(ref Array);
 
        }
        static void PrintUpperTriangle (ref int[,] Array)
        {
            int N = Array.GetLength(0);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; ++j)
                {
                    if (j >= i)
                    {
                        Console.Write($"{Array[i, j]} ");
                    }
                    else
                    {
                        Console.Write($"{0} ");
                    }

                }

                Console.WriteLine();
            }
        }
    }
}
