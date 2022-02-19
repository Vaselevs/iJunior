using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[,] personName;
            String[] personPosition;
            bool isWorking = true;
            char userChoice;

            while(isWorking)
            {
                
                Console.WriteLine("Добро пожаловать в электронную картотеку!\n");
                Console.WriteLine("1. Добавить досье");
                Console.WriteLine("2. Вывести все досье");
                Console.WriteLine("3. Удалить досье");
                Console.WriteLine("4. Поиск по фамилии");
                Console.WriteLine("5. Выход\n");
                Console.Write("Выберите пункт меню: ");
                userChoice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (userChoice)
                {
                    case '1':
                        Console.WriteLine("Вы выбрали пункт 1");
                        break;
                    case '2':
                        Console.WriteLine("Вы выбрали пункт 2");
                        break;
                    case '3':
                        Console.WriteLine("Вы выбрали пункт 3");
                        break;
                    case '4':
                        Console.WriteLine("Вы выбрали пункт 4");
                        break;
                    case '5':
                        Console.WriteLine("Вы выбрали пункт 5");
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню!");
                        break;
                }
                    

                Console.ReadLine();
            }
        }
    }
}
