using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Table[] tables = { new Table(1, 5), new Table(2, 10), new Table(3, 30)};

            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("Администрирование кафе\n");

                for (int i = 0; i < tables.Length; i++)
                {
                    tables[i].ShowInfo();
                }

                isOpen = false;
            }


        }

        class Table
        {
            private int _number;
            private int _maxPlace;
            private int _freePlace;

            public Table(int number, int maxPlace)
            {
                _number = number;
                _maxPlace = maxPlace;
                _freePlace = maxPlace;
            }

            public Table()
            {

            }

            public void ShowInfo()
            {
                Console.WriteLine($"Стол номер - {_number}. Кол-во мест - {_maxPlace}. Кол-во свободных мест - {_freePlace}");
            }
        }
    }
}
