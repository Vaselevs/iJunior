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
            int number = GetUserNumber();

            Console.WriteLine(number);
        }

        static int GetUserNumber()
        {
            int number;
            bool isConvert = false;
            string userInput = "nothing";

            while (isConvert == false)
            {
                Console.Write("Введите число: ");
                userInput = Console.ReadLine();
                isConvert = int.TryParse(userInput, out number);
            }
            
            number = Convert.ToInt32(userInput);

            return number;
        }
    }
}
