using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            string userInput;
            Dictionary<string, string> companyEmployees = new Dictionary<string, string>();

            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine("Приветствую в картотеки сотрудников 2.0!\nВот доступные вам пункты меню:");
                Console.WriteLine("1.Добавить досье");
                Console.WriteLine("2.Вывести все досье");
                Console.WriteLine("3.Удалить досье");
                Console.WriteLine("4.Выход");

                userInput = Console.ReadLine();

                if (Int32.TryParse(userInput, out int result))
                {
                    Console.Clear();
                    switch (result)
                    {
                        case 1:
                            AddDosier(companyEmployees);
                            break;
                        case 2:
                            ShowAllDosiers(companyEmployees);
                            break;
                        case 3:
                            DeleteDosier(companyEmployees);
                            break;
                        case 4:
                            isPlaying = false;
                            break;
                        default:
                            Console.WriteLine("Такого пункта нет в меню!");
                            break;
                    }
                }
                Console.ReadLine();
            }
            Console.WriteLine("Спасибо что пользовались нашей картотекой! До свидания!");
        }

        static void AddDosier(Dictionary<string,string> companyEmployees)
        {
            string nameOfEmploye;
            string positionOfEmploye;
            Console.Clear();
            Console.Write("Введите ФИО сотрудника: ");
            nameOfEmploye = Console.ReadLine();

            if (companyEmployees.ContainsKey(nameOfEmploye))
            {
                Console.WriteLine("Досье этого сотрудника уже есть в базе!");
            }
            else
            {
                Console.Write("Введите должность сотрудника: ");
                positionOfEmploye = Console.ReadLine();
                companyEmployees.Add(nameOfEmploye, positionOfEmploye);
            }
        }

        static void ShowAllDosiers(Dictionary<string, string> companyEmployees)
        {
            int numberOfDosier = 1;
            foreach(var employee in companyEmployees)
            {
                Console.WriteLine($"{numberOfDosier}. {employee.Key} - {employee.Value}");
                numberOfDosier++;
            }
        }

        static void DeleteDosier(Dictionary<string, string> companyEmployees)
        {
            string userInput;

            Console.WriteLine("Введите ФИО удаляемого досье: ");

            ShowAllDosiers(companyEmployees);

            userInput = Console.ReadLine();

            if (companyEmployees.ContainsKey(userInput))
            {
                companyEmployees.Remove(userInput);
                Console.WriteLine($"Сотрудник {userInput} успешно удалён из картотеки!");
            } else
            {
                Console.WriteLine($"Сотрудник {userInput} не найден! Попробуйте заново.");
            }
        }
    }
}
