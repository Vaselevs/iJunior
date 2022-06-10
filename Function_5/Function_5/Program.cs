using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            ShowArray(array);

            Shuffle(array);

            ShowArray(array);
        }

        static void Shuffle(int[] array)
        {
            int shufflePosition;
            Random random = new Random();
            int bufferNumber;

            for(int i = 0; i < array.Length; i++)
            {
                shufflePosition = random.Next(array.Length);
                bufferNumber = array[i];
                array[i] = array[shufflePosition];
                array[shufflePosition] = bufferNumber;
            }
        }

        static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
