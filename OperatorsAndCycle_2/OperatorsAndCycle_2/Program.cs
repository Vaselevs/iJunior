using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsAndCycle_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumberMin = 1;
            int randomNumberMax = 28;
            int number = random.Next(randomNumberMin, randomNumberMax);
            int countOfNumber = 0;

            Console.WriteLine($"Число - {number}");

            for (int i = 0; i < System.Int32.MaxValue; i += number)
            {
                countOfNumber++;
            }

            Console.WriteLine($"Количество кратных чисел: {countOfNumber}");
        }
    }
}
