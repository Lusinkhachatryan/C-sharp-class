using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2___Arrays
{
    class Array_deleteElement
    {
        static void Main(string[] args)
        {
            int N;
            N = int.Parse(Console.ReadLine());
            int[] Array = new int[N];
            string line = Console.ReadLine();
            string[] splt = line.Split(' ');
            for (int i = 0; i < N; ++i)
            {
                Array[i] = int.Parse(splt[i]);
            }
            int position = int.Parse(Console.ReadLine());
            int[] NewArray = deleteElement(ref Array, position);
                       
            for (int i = 0; i < NewArray.Length; ++i)
            {
                Console.Write($"{NewArray[i]} ");
            }
        }
        static int[] deleteElement(ref int[] Array, int position)
        {
            int N = Array.Length;
            int[] NewArray = new int[N - 1];
            for (int i = 0; i < N; ++i)
            {
                if (i < position - 1)
                {
                    NewArray[i] = Array[i];
                }
                else if (i > position - 1)
                {
                    NewArray[i - 1] = Array[i];
                }
            }
            return NewArray;
        }
    }
}
