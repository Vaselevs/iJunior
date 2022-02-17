using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countGold;
            int countCristal;
            int priceCristal = 20;

            Console.WriteLine("Путник, приветствую Тебя в своём магазинчике!");
            Console.WriteLine("Скажи мне путник, сколько у тебя денег?");
            Console.Write("Введите количество ваших денег:");

            countGold = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Кристалы в моём магазине идут по {priceCristal} за штуку. Сколько ты хочешь:");

            countCristal = Convert.ToInt32(Console.ReadLine());

            countGold -= countCristal * priceCristal;

            Console.WriteLine($"Ты получаешь {countCristal} кристала. У тебя осталось {countGold} золота.");
            Console.WriteLine("Заходи ещё, путник. Тебе всегда здесь рады!");

        }
    }
}
