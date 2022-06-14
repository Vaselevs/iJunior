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
            Random random = new Random();
            int randomMinValue = 0;
            int randomMaxValue = 10;
            int numberOfElementsInList = 10;

            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            List<int> finallist = new List<int>();

            FillingList(list1, numberOfElementsInList, random, randomMinValue, randomMaxValue);
            FillingList(list2, numberOfElementsInList, random, randomMinValue, randomMaxValue);

            ShowList(list1);
            ShowList(list2);

            MergerList(list1,list2, finallist);

            ShowList(finallist);
        }

        static void FillingList(List<int> list, int numberOfElements, Random random, int randomMinValue, int randomMaxValue)
        {
            int randomNumber;

            for (int i = 0; i < numberOfElements; i++)
            {
                randomNumber = random.Next(randomMinValue, randomMaxValue);
                list.Add(randomNumber);
            }
        }

        static void ShowList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        static void MergerList(List<int> firstList, List<int> secondList, List<int> finalList)
        {
            finalList.AddRange(firstList);
            finalList.AddRange(secondList);

            for(int i = 1; i < finalList.Count; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (finalList[i] == finalList[j])
                    {
                        finalList.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }
}
