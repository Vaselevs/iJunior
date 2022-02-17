using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String password = "12345";
            String secretPhrase = "В шкафу спрятано золото";
            int countTry = 3;

            while(countTry > 0)
            {
                String tempPassword;
                Console.Write($"Введите пароль и узнаете секрет! У Вас осталось {countTry} попытки(ок):");
                tempPassword = Console.ReadLine();

                if(tempPassword == password)
                {
                    Console.WriteLine($"{secretPhrase}\nПоздравляю с победой!");
                    countTry = 0;
                }
                else
                {
                    countTry--;
                    Console.WriteLine($"Пароль не верен! У вас осталось {countTry} попытки(ок)");
                }
            }
        }
    }
}
