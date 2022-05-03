using System;

namespace OperatorsAndCycle_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int randomMin = 0;
            int randomMax = 15;
            int multiplyingNumber = 2;
            int degree = 1;

            int number = multiplyingNumber * degree;
            int targetNumber = random.Next(randomMin, randomMax);

            for(int i = 0; i < targetNumber; i++)
            {
                if(number < targetNumber)
                {
                    number *= multiplyingNumber;
                    degree += 1;
                }
            }

            Console.WriteLine($"Число, которое мы преодолеваем - {targetNumber}");
            Console.WriteLine($"Итоговая степень - {degree}");
            Console.WriteLine($"Итоговое число - {number}");
        }
    }
}