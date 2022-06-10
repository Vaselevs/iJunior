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

            FillingList(ref list1);
            FillingList(ref list2);

            ShowList(list1);
            ShowList(list2);

            Console.ReadLine();
        }

        static void FillingList(ref List<int> list)
        {
            Random random = new Random();
            int randomMinValue = 0;
            int randomMaxValue = 1000;

            foreach (int item in list)
            {
                int randomNumber = random.Next(randomMinValue, randomMaxValue);
                list.Add(item);
            }
            Console.ReadLine();
        }

        static void ShowList(List<int> list)
        {
            foreach(int item in list)
            {
                Console.Write(list[item] + " ");
            }
        }
    }
}
