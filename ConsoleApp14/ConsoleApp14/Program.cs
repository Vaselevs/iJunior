using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countGranny;
            int countMinuteInHour = 60;
            int timeTherapy = 10;

            Console.WriteLine($"Введите количество старушек:");
            
            countGranny = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Время ожидания в очереди составляет " +
                $"{countGranny * timeTherapy / countMinuteInHour} час(ов) " +
                $"и {countGranny * timeTherapy % countMinuteInHour} минут");
        }
    }
}
