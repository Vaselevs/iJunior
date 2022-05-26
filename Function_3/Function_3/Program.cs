using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;

            number = GetNumber();

            Console.WriteLine(number);
        }

        static int GetNumber()
        {
            int number = 0;
            bool isConvert = false;
            string userInput;

            while (isConvert == false)
            {
                Console.Write("Введите число: ");
                userInput = Console.ReadLine();
                isConvert = int.TryParse(userInput, out number);
            }

            return number;
        }
    }
}