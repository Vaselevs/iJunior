using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startHeals, armor, damage;
            float heals;

            Console.Write("Введите количество жизней:");
            startHeals = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"У вас - {startHeals} жизней!");
            Console.Write("Введите количество брони:");
            armor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"У вас {armor} брони!");
            Console.Write($"Введите количество урона:");
            damage = Convert.ToInt32(Console.ReadLine());

            heals = startHeals - (Convert.ToSingle(damage) / 100 * (100-armor));

            Console.WriteLine($"Вы получили {startHeals - heals} урона! У вас осталось {heals} жизней!");
            
            
            


        }
    }
}
