using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfElementsInList = 10;

            List<int> list1 = new List<int>(numberOfElementsInList);
            List<int> list2 = new List<int>(numberOfElementsInList);

            FillingList(list1);
            FillingList(list2);

            ShowList(list1);

            ShowList(list2);

            Console.ReadLine();
        }

        static void FillingList(List<int> list)
        {
            Random random = new Random();
            int randomMinValue = 0;
            int randomMaxValue = 1000;

            for(int i = 0; i < list.Count; i++)
            {
                int randomNumber = random.Next(randomMinValue, randomMaxValue);
                list.Add(randomNumber);
            }
        }

        static void ShowList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
        }
    }
}
