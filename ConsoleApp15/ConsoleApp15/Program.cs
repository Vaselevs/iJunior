using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String playerName;
            int playerAge;
            String playerZodiac;
            String playerWork;
            int playerSalary;
            int playerCountOfChild;



            Console.WriteLine("Здраствуйте! Вам выпала честь поучаствовать в нашем опроснике!");
            Console.Write("Как Вас зовут:");

            playerName = Console.ReadLine();

            Console.Write("Прекрасное имя! А сколько Вам лет:");

            playerAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Великолепно! А кто Вы по знаку зодиака:");

            playerZodiac = Console.ReadLine();

            Console.Write($"Ага, поняла. {playerName}, подскажите пожалуйста, а где Вы работаете:");

            playerWork = Console.ReadLine();

            Console.Write("Ого! А какая у Вас зарплата:");

            playerSalary = Convert.ToInt32(Console.ReadLine());

            Console.Write("Поняла. И последний вопрос, сколько у вас детей:");

            playerCountOfChild = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Отлично, спасибо за уделённое время! Итак, {playerName}, Вам {playerAge}, " +
                $"Вы {playerZodiac} по знаку зодиака. Вы работаете в {playerWork} и получаете там {playerSalary} рублей. " +
                $"И у вас {playerCountOfChild} детей.");


        }
    }
}
