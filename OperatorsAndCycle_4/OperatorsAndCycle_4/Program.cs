using System;

namespace OperatorsAndCycle_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            String targetString = "(((()((()(())()())))))";
            int maxNestingDepth = 0;
            int notClosedBrackets = 0;
            bool isCorrect = true;

            if (targetString.Length % 2 == 0)
            {
                for (int i = 0; i < targetString.Length; i++)
                {
                    if (targetString[i] == '(')
                        notClosedBrackets++;
                    else
                        notClosedBrackets--;

                    if (notClosedBrackets < 0)
                    {
                        isCorrect = false;
                        break;
                    }

                    if (notClosedBrackets > maxNestingDepth)
                        maxNestingDepth = notClosedBrackets;
                }
            }
            else
                isCorrect = false;

            if (notClosedBrackets > 0)
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