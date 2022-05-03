using System;

namespace OperatorsAndCycle_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            String targetString = "(((())))";
            int tempNestingDepth = 0;
            int maxNestingDepth = 0;
            bool isCorrect = true;

            if (targetString.Length % 2 == 0)
            {
                if (targetString.Length != 2 && targetString.Length != 4)
                {
                    for (int i = 1; i < targetString.Length; i++)
                    {
                        if (targetString[i] == targetString[i - 1])
                            tempNestingDepth++;
                        else
                        {
                            maxNestingDepth = tempNestingDepth + 1;
                            tempNestingDepth = 0;
                        }
                    }
                }
                else if (targetString == "()")
                    maxNestingDepth = 1;
                else if (targetString == "(())")
                    maxNestingDepth = 2;
                else
                    isCorrect = false;

                
            }
            else
                isCorrect = false;
            


            Console.WriteLine($"Исходная строка: {targetString}");


            if (isCorrect)
            {
                Console.WriteLine("Исходная строка корректна!");
                Console.WriteLine($"Глубина вложенности: {maxNestingDepth}");
            }    
            else
                Console.WriteLine("Исходная строка не корректна!");
        }
    }
}
