using System;

namespace Function_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] fullNameOfPerson = new string[0];
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

        static void AddDossier(ref string [] name, ref string[] position)
        {
            int tempLength = position.Length;
            ExpansionArray(ref name);
            ExpansionArray(ref position);

            Console.Clear();
            Console.Write("Введите ФАМИЛИЮ: ");
            name[tempLength] = Console.ReadLine()+ " ";
            Console.Write("Введите ИМЯ: ");
            name[tempLength] += Console.ReadLine() + " ";
            Console.Write("Введите ОТЧЕСТВО: ");
            name[tempLength] += Console.ReadLine();
            Console.Write("Введите ДОЛЖНОСТЬ: ");
            position[tempLength] = Console.ReadLine();
        }

        static void ExpansionArray(ref string[] array)
        {
            int tempLength = array.Length;
            string[] tempArray = new string[tempLength + 1];

            for (int i = 0; i < tempLength; i++)
            {
                tempArray[i] = array[i];
            }

            array = tempArray;
        }      

        static void ViewAllDossier(string[] name, string[] position)
        {
            Console.Clear();
            Console.WriteLine("Все досье:");

            for(int i = 0; i < name.Length; i++)
            {
                Console.Write(i + 1 + "." + name[i] + " ");
                Console.WriteLine("- " + position[i] + ".");
            }

            Console.ReadLine();
        }

        static void DeleteDossier(ref string[] name, ref string[] position)
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
                DecreaseArray(ref name, numberOfDelitingDossier);
                DecreaseArray(ref position, numberOfDelitingDossier);
            }
        }

        static void DecreaseArray(ref string[] array, int position)
        {
            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < tempArray.Length; i++)
            {
                if (i >= position)
                {
                    tempArray[i] = array[i + 1];
                }
                else
                {
                    tempArray[i] = array[i];
                }
            }

            array = tempArray;
        }

        static void FindBySurname(string[] name, string[] position)
        {
            string surname;
            int surnameIndex = -1;

            Console.Clear();
            Console.Write("Введите фамилию для поиска в картотеке: ");
            surname = Console.ReadLine();

            for (int i = 0; i < name.Length; i++)
            {
                if(name[i].Contains(surname))
                {
                    surnameIndex = i;
                }
            }

            if(surnameIndex != -1)
            {
                Console.WriteLine("Запись найдена в картотеке!");
                Console.Write(surnameIndex + 1 + ". " + name[surnameIndex] + " ");
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