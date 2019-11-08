using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2___Arrays
{
    class Array_copy
    {
        static void Main(string[] args)
        {
            int N;
            N = int.Parse(Console.ReadLine());
            double[] D = new double[N];
            string line = Console.ReadLine();
            string[] splt = line.Split(' ');
            for (int i = 0; i < N; ++i)
            {
                D[i] = Double.Parse(splt[i]);
            }
            int[] Converted = doubleToInt(D);
            for (int i = 0; i < N; ++i)
            {
                Console.Write($"{Converted[i]} ");
            }
                        
        }
        static int [] doubleToInt (double[] Array)
        {
            int N = Array.Length;
            int[] Converted = new int[N];
            for (int i = 0; i < N; ++i)
            {
                Converted[i] = Convert.ToInt32(Array[i]);
            }
            return Converted;
        }
    }
}
