using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            string userInput;
            List<int> list = new List<int>();

            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine("Введите следующее число или слово \"sum\" что бы просумировать все предыдущие числа");
                Console.WriteLine("Что бы выйти, введите \"exit\"");
                userInput = Console.ReadLine();

                if(userInput == "exit")
                {
                    isPlaying = false;
                }
                else if(userInput == "sum")
                {
                    ShowSum(list);
                }
                else if(Int32.TryParse(userInput, out int result))
                {
                    list.Add(result);
                }
            }

            ShowSum(list);
        }

        static int SumOfNumbers(List<int> list)
        {
            int sum = 0;

            foreach (int number in list)
            {
                sum += number;
            }

            return sum;
        }

        static void ShowSum(List<int> list)
        {
            Console.WriteLine($"Cумма: {SumOfNumbers(list)}");
            Console.ReadLine();
        }
    }
}