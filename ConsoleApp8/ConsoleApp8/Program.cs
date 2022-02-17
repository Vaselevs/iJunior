using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "scp-001";
            string userInput;

            Console.Write("Введите пароль:");
            userInput = Console.ReadLine();

            if (userInput == password)
            {
                Console.WriteLine("Добро пожаловать в клуб, тушка!");
            }
            else
            {
                Console.WriteLine("А вот и новый шашлык пожаловал");
            }



        }
    }
}
