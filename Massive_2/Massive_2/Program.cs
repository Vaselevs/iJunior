using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numberRow = 10;
            int numberColumn = 10;
            int maxNumber = int.MinValue;
            int[,] array = new int[numberRow, numberColumn];
            int targetNumber = 0;

            for(int i = 0; i < numberRow; i++)
            {
                for(int j = 0; j < numberColumn; j++)
                {
                    array[i,j] = random.Next();
                    if(array[i,j] > maxNumber)
                        maxNumber = array[i,j];
                }
            }

            Console.WriteLine($"Максимальное число в массиве - {maxNumber}");
            Console.WriteLine("Исходный массив:");

            for (int i = 0; i < numberRow; i++)
            {
                for (int j = 0; j < numberColumn; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Изменённый массив:");

            for (int i = 0; i < numberRow; i++)
            {
                for (int j = 0; j < numberColumn; j++)
                {
                    if (array[i, j] == maxNumber)
                        array[i, j] = targetNumber;
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}