using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playersMoney = 0;
            int maxCustomerMoney = 1000;
            int numbersOfCustomers = 10;
            Random random = new Random();

            Queue<int> Queue = new Queue<int>();

            for(int i = 0; i < numbersOfCustomers; i++)
            {
                Queue.Enqueue(random.Next(0, maxCustomerMoney));
            }
            
            foreach(int money in Queue)
            {
                Console.Clear();
                Console.WriteLine($"Ваш текущий баланс: {playersMoney}");
                Console.WriteLine($"Посетитель делает покупку на сумму: {money}");
                playersMoney += money;
                Console.ReadLine();
            }
        }
    }
}
