using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countPicture;
            int countColumn;

            countPicture = 52;
            countColumn = 3;

            Console.WriteLine($"{countPicture} картинок войдут в {countPicture/countColumn} ряда(ов).");
            Console.WriteLine($"При этом не войдут {countPicture%countColumn} картинка(ок).");



        }
    }
}
