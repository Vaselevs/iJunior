using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Play();
        }
    }

    public class Game
    {
        private HospitalBook _hospitalBook;
        public Game()
        {
            _hospitalBook = new HospitalBook();
        }

        public void Play()
        {
            bool isPlaying = true;

            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Отсортировать список больных по имени");
                Console.WriteLine("2. Отсортировать список больных по возрасту");
                Console.WriteLine("3. Найти пациентов с определённой болезнью");
                Console.WriteLine("4. Выйти");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowInfo(_hospitalBook.SortByName());
                        break;
                    case "2":
                        ShowInfo(_hospitalBook.SortByAge());
                        break;
                    case "3":
                        ShowInfo(_hospitalBook.FindByDisease());
                        break;
                    case "4":
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта в меню!");
                        break;
                }
                Console.ReadLine();
            }

            void ShowInfo(List<Patient> patients)
            {
                foreach(Patient patient in patients)
                {
                    patient.ShowInfo();
                }
            }
        }
    }

    public class HospitalBook
    {
        private Patient[] _patients;

        public HospitalBook()
        {
            _patients = new Patient[10]
            {
                new Patient("Иван", 23, "Астма"),
                new Patient("Антон", 26, "Язва"),
                new Patient("Владимир", 43, "Грыжа"),
                new Patient("Игорь", 33, "Растяжение"),
                new Patient("Саша", 74, "Астма"),
                new Patient("Коля", 34, "Рак"),
                new Patient("Петя", 21, "Перелом"),
                new Patient("Илья", 52, "Недомагание"),
                new Patient("Анатолий", 61, "Язва"),
                new Patient("Макс", 72, "Ушиб")
            };
        }

        public List<Patient> SortByName()
        {
            var sortingByNamePatients = _patients.OrderBy(patient => patient.Name);
            return sortingByNamePatients.ToList();
        }

        public List<Patient> SortByAge()
        {
            var sortingByAgePatients = _patients.OrderBy(patient => patient.Age);
            return sortingByAgePatients.ToList();
        }

        public List<Patient> FindByDisease()
        {
            Console.WriteLine("Введите название болезни:");
            string disease = Console.ReadLine();

            var findedByDisease = from Patient patient in _patients
                                  where patient.Disease == disease
                                  select patient;

            return findedByDisease.ToList();
        }
    }

    public class Patient
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Age} - {Disease}");
        }
    }
}
