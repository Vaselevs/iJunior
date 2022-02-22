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
            String[,] personName = new String[0,2];
            String[] personPosition = new string[0];
            bool isWorking = true;
            char userChoice;

            while (isWorking)
            {
                Console.Clear();
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
                        AddProfile(personName, personPosition);
                        break;
                    case '2':
                        AllProfileView(personName, personPosition);
                        break;
                    case '3':
                        Console.WriteLine("Вы выбрали пункт 3");
                        break;
                    case '4':
                        Console.WriteLine("Вы выбрали пункт 4");
                        break;
                    case '5':
                        Console.WriteLine("Спасибо за использование нашей картотеки, до свидания!");
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню!");
                        break;
                }


                Console.ReadLine();
            }
        }

        static void AddProfile(String[,] personNameinFunction, String[] personPositioninFunction)
        {
            String personFirstName;
            String personLastName;
            String personPosition;

            Console.Clear ();
            Console.WriteLine("Создаём новую запись в картотеке.");
            Console.Write("Введите фамилию: ");
            personLastName = Console.ReadLine();
            Console.Write("Введите имя и очество: ");
            personFirstName = Console.ReadLine();
            Console.Write("Введите должность:");
            personPosition = Console.ReadLine();

            String[,] personNameinFunctionTemp = new String[personNameinFunction.GetLength(0) + 1, personNameinFunction.GetLength(1)];
            String[] personPositioninFunctionTemp = new String[personPositioninFunction.Length + 1];

            for (int i = 0; i < personNameinFunction.GetLength(0); i++)
            {
                for (int j = 0; j < personNameinFunction.GetLength(1); j++)
                {
                    personNameinFunctionTemp[i, j] = personNameinFunction[i, j];
                }
                personPositioninFunctionTemp[i] = personPositioninFunction[i];
            }

            personNameinFunctionTemp[personNameinFunctionTemp.GetLength(0), personNameinFunctionTemp.GetLength(1)-1] = personLastName;
            personNameinFunctionTemp[personNameinFunctionTemp.GetLength(0), personNameinFunctionTemp.GetLength(1)] = personFirstName;
            personPositioninFunctionTemp[personPositioninFunctionTemp.Length - 1] = personPosition;

            personPositioninFunction = personPositioninFunctionTemp;
            personNameinFunction = personNameinFunctionTemp;
        }
        static void AllProfileView(String[,] personNameinFunction, String[] personPositioninFunction)
        {
            Console.Clear();
            Console.WriteLine("Вывожу список всех досье:");
            for (int i = 0; i < personNameinFunction.GetLength(0); i++)
            {
                Console.WriteLine($"{i}. {personNameinFunction[i, 0]} {personNameinFunction[i, 1]}. Должность: {personPositioninFunction[i]}");
            }
        }
    }
}
