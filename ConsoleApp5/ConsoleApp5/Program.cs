using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int money, eatCount, eatPrice = 10;
            bool enoughMoney;

            Console.WriteLine("Добро пожаловать в Пекарню!");
            Console.WriteLine($"Сегодня еда по {eatPrice} монет.");
            Console.Write("Сколько у вас монет:");
            money = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько еды вам нужно:");
            eatCount = Convert.ToInt32(Console.ReadLine());

            enoughMoney = money >= eatCount * eatPrice;
            eatCount *= Convert.ToInt32(enoughMoney);
            money -= eatCount * eatPrice;

            Console.WriteLine($"После покупки у вас в сумке {eatCount} еды и {money} монет!");


        }
    }
}
