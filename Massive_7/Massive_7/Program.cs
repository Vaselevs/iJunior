using System;

namespace Massive_7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string targetString = "Мама мыла раму.";
            string[] resultArray = targetString.Split(' ');

            Console.WriteLine(targetString);

            foreach(string tempString in resultArray)
            {
                Console.WriteLine(tempString);
            }
        }
    }
}