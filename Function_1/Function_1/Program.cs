using System;

namespace Function_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[,] fullNameOfPerson = new string[0,3];
            string[] personFunction = new string[0];
            bool isWorking = true;
            string playerChoiсe;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("Приветствую в электронной картотеке!");
                Console.WriteLine("1. Добавить досье.");
                Console.WriteLine("2. Вывести все досье.");
                Console.WriteLine("3. Удалить досье по порядковому номеру.");
                Console.WriteLine("4. Поиск по фамилии.");
                Console.WriteLine("5. Выход из картотеки.");
                Console.WriteLine();
                Console.Write("Выберите пункт меню: ");
                playerChoiсe = Console.ReadLine();

                switch (playerChoiсe)
                {
                    case "1":
                        AddDossier(ref fullNameOfPerson, ref personFunction);
                        break;
                    case "2":
                        ViewAllDossier(fullNameOfPerson, personFunction);
                        break;
                    case "3":
                        DeleteDossier(ref fullNameOfPerson, ref personFunction);
                        break;
                    case "4":
                        FindBySurname(fullNameOfPerson, personFunction);
                        break;
                    case "5":
                        Exit(ref isWorking);
                        break;
                    default:
                        Console.WriteLine("нет такого пункта меню.");
                        break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("До свидания, приходите ещё!");
            Console.ReadKey();
        }

        static void AddDossier(ref string [,] name, ref string[] position)
        {
            int tempLength = position.Length;
            string[,] tempName = new string[tempLength + 1, name.GetLength(1)];
            string[] tempPosition = new string[tempLength + 1];

            for(int i = 0; i< tempLength; i++)
            {
                for(int j = 0; j < name.GetLength(1); j++)
                {
                    tempName[i, j] = name[i, j];
                }
                tempPosition[i] = position[i];
            }

            Console.Clear();
            Console.Write("Введите ФАМИЛИЮ: ");
            tempName[tempLength, 0] = Console.ReadLine();
            Console.Write("Введите ИМЯ: ");
            tempName[tempLength, 1] = Console.ReadLine();
            Console.Write("Введите ОТЧЕСТВО: ");
            tempName[tempLength, 2] = Console.ReadLine();
            Console.Write("Введите ДОЛЖНОСТЬ: ");
            tempPosition[tempLength] = Console.ReadLine();

            name = tempName;
            position = tempPosition;
        }

        static void ViewAllDossier(string[,] name, string[] position)
        {
            Console.Clear();
            Console.WriteLine("Все досье:");

            for(int i = 0; i < name.GetLength(0); i++)
            {
                Console.Write(i + 1 + ".");

                for(int j = 0; j < name.GetLength(1); j++)
                {
                    Console.Write(name[i, j] + " ");
                }

                Console.WriteLine("- " + position[i] + ".");
            }

            Console.ReadLine();
        }

        static void DeleteDossier(ref string[,] name, ref string[] position)
        {
            int numberOfDelitingDossier;

            Console.Clear();
            Console.Write("Введите номер удаляемого досье: ");

            numberOfDelitingDossier = Convert.ToInt32(Console.ReadLine()) - 1;

            if(numberOfDelitingDossier > position.Length)
            {
                Console.WriteLine("Вы привысили допустимый диапазон номеров!");
                Console.ReadLine();
            }
            else
            {
                string[,] tempName = new string[name.GetLength(0) - 1, 3];
                string[] tempPosition = new string[position.Length - 1];

                for(int i = 0; i<tempName.GetLength(0); i++)
                {
                    for(int j = 0; j<tempName.GetLength(1); j++)
                    {
                        if (i >= numberOfDelitingDossier)
                        {
                            tempName[i, j] = name[i + 1, j];
                        }
                        else
                        {
                            tempName[i, j] = name[i, j];
                        }
                    }
                    if (i >= numberOfDelitingDossier)
                    {
                        tempPosition[i] = position[i + 1];
                    }
                    else
                    {
                        tempPosition[i] = position[i];
                    }
                }

                name = tempName;
                position = tempPosition;
            }
        }

        static void FindBySurname(string[,] name, string[] position)
        {
            string surname;
            int surnameIndex = -1;

            Console.Clear();
            Console.Write("Введите фамилию для поиска в картотеке: ");
            surname = Console.ReadLine();

            for (int i = 0; i < name.GetLength(0); i++)
            {
                if(name[i,0] == surname)
                {
                    surnameIndex = i;
                }
            }

            if(surnameIndex != -1)
            {
                Console.WriteLine("Запись найдена в картотеке!");
                Console.Write(surnameIndex + 1 + ". ");

                for(int i = 0; i < name.GetLength(1); i++)
                {
                    Console.Write(name[surnameIndex, i] + " ");
                }

                Console.WriteLine("- " + position[surnameIndex]);
            }
            else
            {
                Console.WriteLine("Запись в картотеке не найдена!");
            }

            Console.ReadLine();
        }

        static void Exit(ref bool isWorking)
        {
            isWorking = false;
        }
    }
}