using System;

namespace Massive_8
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int minRandomNumber = 0;
            int maxRandomNumber = 10;
            int[] array = new int[10];
            int userDisplacement = 3;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minRandomNumber, maxRandomNumber);
                Console.Write(array[i] + " ");
            }

            for(int i = 0; i<userDisplacement; i++)
            {
                int tempNumber = array[0];

                for(int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }

                array[array.Length-1] = tempNumber;
            }

            Console.WriteLine();
            foreach (int number in array)
                Console.Write(number + " ");
        }
    }
}