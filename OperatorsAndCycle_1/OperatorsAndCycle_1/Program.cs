using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsAndCycle_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomMin = 0;
            int randomMax = 101;
            int sum = 0;
            int divider1 = 3;
            int divider2 = 5;
            int number = random.Next(randomMin,randomMax);
            Console.WriteLine(number);
            Console.WriteLine();

            for (int i = 0; i <= number; i++)
            {
                if(i % divider1 == 0 || i % divider2 == 0)
                {
                    sum += i;
                }
            }

        }
    }
}
