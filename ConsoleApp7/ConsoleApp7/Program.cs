using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string day;

            Console.Write("Введите название дня недели с большой буквы:");
            day = Console.ReadLine();


            switch (day)
            {
                case "Суббота":
                case "Понедельник":
                    Console.WriteLine("Идём в кино");
                    break;
                case "Вторник":
                    Console.WriteLine("Моем попу");
                    break;
                case "Среда":
                    Console.WriteLine("Смотрим в окно");
                    break;
                default: 
                    Console.WriteLine("Чё за день, а?");
                break;
            }







            if (day == "Понедельник")
            {
                Console.WriteLine("Делаем ДЗ");

            }
            else if (day == "Вторник")
            {
                Console.WriteLine("Моем попу");
            }


        }
    }
}
