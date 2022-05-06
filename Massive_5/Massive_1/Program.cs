using System;

namespace Massive_5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int randomMin = 0;
            int randomMax = 5;
            int[] array = new int[30];
            int maxSubarray = 0;
            int tempMaxSubarray = 0;
            int numberWithMaxRepetitions = -1;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(randomMin,randomMax);

                Console.Write($"{array[i]} ");

                if (i > 0)
                {
                    if(array[i] == array[i-1])
                    {
                        tempMaxSubarray++;
                    }else
                    {
                        tempMaxSubarray = 0;
                    }

                    if (tempMaxSubarray >= maxSubarray)
                    {
                        maxSubarray = tempMaxSubarray + 1;
                        numberWithMaxRepetitions = array[i];
                    }
                }
            }

            Console.WriteLine();

            if(numberWithMaxRepetitions >= randomMin)
            {
                Console.WriteLine($"Число подмассива: {numberWithMaxRepetitions}");
                Console.WriteLine($"Макимальная длинна подмассива: {maxSubarray}");
            } else
            {
                Console.WriteLine("Все числа повторяются в массиве один раз");
            }     
        }
    }
}
