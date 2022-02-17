using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] testMassive = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 }, { 9, 10 }, { 11, 12 } };

            int secondRowSum = 0;
            int firstColumnProduct = 1;

            for(int i = 0; i < testMassive.GetLength(1); i++)
            {
                secondRowSum += testMassive[1,i];
            }

            for (int i = 0; i < testMassive.GetLength(1); i++)
            {
                firstColumnProduct *= testMassive[0, i];
            }

            for (int i = 0; i < testMassive.GetLength(0); i++)
            {
                for(int j = 0; j < testMassive.GetLength(1); j++)
                {
                    Console.Write(testMassive[i,j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(secondRowSum);
            Console.WriteLine(firstColumnProduct);
        }
    }
}
