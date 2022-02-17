using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age;
            Console.Write("Введите ваш возраст:");
            age = Convert.ToInt32(Console.ReadLine());

            if (age >= 18)
            {
                Console.WriteLine("Пожалуйста, проходите!");
            } 
            else
            {
                Console.WriteLine("Вам нет 18 лет!");
            }

            Console.WriteLine("А теперь отойдите, мне надо работать!");
        }
    }
}
