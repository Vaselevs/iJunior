using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char fillChar;
            String playerName;
            ushort playerNameLong;

            Console.Write("Введите желаемый символ:");
            fillChar = Convert.ToChar(Console.ReadLine());
            Console.Write("Введите Ваше имя:");
            playerName = Console.ReadLine();

            playerNameLong = (ushort)playerName.Length;

            for (int i = 0; i < playerNameLong+2; i++)
            {
                Console.Write(fillChar);
            }

            Console.WriteLine();
            Console.WriteLine(fillChar + playerName + fillChar);

            for (int i = 0; i < playerNameLong + 2; i++)
            {
                Console.Write(fillChar);
            }


        }
    }
}
