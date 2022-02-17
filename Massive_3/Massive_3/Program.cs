using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numberOfElements = 30;
            int[] newArray = new int[numberOfElements];

            for (int i = 0; i< newArray.Length; i++)
            {
                newArray[i] = random.Next(1,10);
            }

            if (newArray[0] > newArray[1])
                Console.Write(newArray[0] + " ");
            
            for (int i = 1; i<newArray.Length-1; i++)
            {
                if (newArray[i - 1] < newArray[i] && newArray[i] > newArray[i + 1])
                    Console.Write(newArray[i] + " ");
            }

            if (newArray[newArray.Length - 2] < newArray[newArray.Length - 1])
                Console.Write(newArray[newArray.Length - 1] + " ");
        }
    }
}
