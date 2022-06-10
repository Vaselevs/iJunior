using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userWord;
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                { "мама", "mama" },
                { "папа", "papa" }
            };

            Console.Write("Введите слово: ");
            userWord = Console.ReadLine();
            Console.WriteLine($"Вот что вернул словарь: {FindInDictionary(dictionary, userWord)}");
        }

        static string FindInDictionary(Dictionary<string,string> dictionary, string quastion)
        {

            if (dictionary.TryGetValue(quastion, out string answer) == false)
            {
                answer = "Такого слова нет в словаре!";
            }

            return answer;
        }
    }
}
