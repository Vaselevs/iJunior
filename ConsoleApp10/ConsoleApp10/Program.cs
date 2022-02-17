using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            float health1 = random.Next(800, 1000);
            int damage1 = random.Next(10, 20);
            int armor1 = random.Next(65, 101);
            int armor2 = random.Next(60, 80);
            float health2 = random.Next(700, 900);
            int damage2 = random.Next(13, 19);

            while(health1 > 0 && health2 > 0)
            {
                health1 -= Convert.ToSingle(damage2) / 100 * armor1;
                health2 -= Convert.ToSingle(damage1) / 100 * armor2;

                Console.WriteLine($"У первого гладиатора осталось {health1} здоровья");
                Console.WriteLine($"У второго гладиатора осталось {health2} здоровья");

            }

            if (health1 <= 0 && health2 <= 0)
            {
                Console.WriteLine("Оба гладиатора пали в бою");
            } 
            else if (health1 <= 0)
            {
                Console.WriteLine("Первый гладиатор пал смертью храбрых");
            }
            else if (health2 <= 0)
            {
                Console.WriteLine("Второй гладиатор пал смертью храбрых");
            }




        }
    }
}
