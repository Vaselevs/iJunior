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
            Random rand = new Random();
            int sum = 0;
            int dividerX = 3;
            int dividerY = 5;
            int number = rand.Next(0,101);
            Console.WriteLine(number);
            Console.WriteLine();

            for (int i = 0; i <= number; i++)
            {
                if(i % dividerX == 0 || i % dividerY == 0)
                {
                    sum += i;
                }
            }

        }
    }
}
