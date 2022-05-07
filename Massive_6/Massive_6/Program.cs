using System;

namespace Massive_6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int minRandomNumber = 0;
            int maxRandomNumber = 100;
            int numbersOnRightPosition = 0;
            int[] array = new int[10];

            Console.Write("Исходный массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minRandomNumber, maxRandomNumber);
                Console.Write($"{array[i]} ");
            };

            while (numbersOnRightPosition<array.Length-1)
            {
                numbersOnRightPosition = 0;
                for (int i = 1; i < array.Length; i++)
                {
                    int tempNumber;
                    if (array[i] < array[i - 1])
                    {
                        tempNumber = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = tempNumber;
                    } else
                    {
                        numbersOnRightPosition++;
                    }
                } 
            }

            Console.WriteLine();
            Console.Write("Отсортированный массив: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            };

            Console.WriteLine();
        }
    }
}