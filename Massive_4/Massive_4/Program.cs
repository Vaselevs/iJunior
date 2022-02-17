using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];
            String userInput = "";

            while(userInput != "exit")
            {
                userInput = Console.ReadLine();

                if (userInput == "sum")
                {
                    int sumArray = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        sumArray += array[i];
                    }
                    Console.WriteLine(sumArray);
                }
                else if (userInput != "exit")
                {
                    int[] tempArray = new int[array.Length + 1];
                    for (int i = 0; i < array.Length; i++)
                    {
                        tempArray[i] = array[i];
                    }
                    tempArray[tempArray.Length-1] = Convert.ToInt32(userInput);
                    array = tempArray;
                }
            }
        }
    }
}
