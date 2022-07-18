using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Game game = new Game();

            game.Play(player);
        }
    }

    public class Game
    {
        public void Play(Player player)
        {
            Queue<Voyage> voyages = new Queue<Voyage>();
            Voyage activeVoyage = null;
            bool isPlaying = true;

            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine($"Текущий рейс: {ShowRoute()}");
                Console.WriteLine();
                Console.WriteLine("Выберите пункт меню: ");
                Console.WriteLine("1. Создать новый маршрут");
                Console.WriteLine("2. Посмотреть маршруты в очереди");
                Console.WriteLine("3. Выйти из программы");

                switch (Console.ReadLine())
                {
                    case "1":
                        voyages.Enqueue(player.AddNewVoyage());
                        break;
                    case "2":
                        ShowAllVoyages();
                        break;
                    case "3":
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Нет такой команды!");
                        break;
                }

                if (activeVoyage == null || DateTime.Now > activeVoyage.GetFinishTime())
                {
                    if (voyages.Count > 0)
                    {
                        activeVoyage = voyages.Dequeue();
                        activeVoyage.SetFinishTime();
                    }
                    else
                    {
                        activeVoyage = null;
                    }
                }
            }

            void ShowAllVoyages()
            {
                int voyageID = 1;
                if(voyages.Count > 0)
                {
                    foreach (Voyage voyage in voyages)
                    {
                        Console.WriteLine($"{voyageID}. {voyage.ShowRoute()}");
                    }
                }
                else
                {
                    Console.WriteLine("Список маршрутов пуст!");
                }

                Console.ReadLine();
            }

            string ShowRoute()
            {
                if (activeVoyage == null)
                {
                    return "Не задан текущий маршрут";
                }
                else
                {
                    return activeVoyage.ShowRoute();
                }
            }
        }
    }

    public class Player
    {
        public Voyage AddNewVoyage()
        {
            Console.Write("Введите название пункта отправления - ");
            string pointOfDeparture = Console.ReadLine();
            Console.Write("Введите название пункта прибытия - ");
            string pointOfArrival = Console.ReadLine();

            Voyage newVoyage = new Voyage(pointOfDeparture, pointOfArrival);

            Console.WriteLine();

            newVoyage.CreateTheTrain();

            Console.Clear();
            Console.WriteLine($"Отлично, вы создали новый маршрут: {newVoyage.ShowRoute()}");
            Console.WriteLine("А теперь нажмите любую клавишу, что бы добавить маршрут в очередь!");
            Console.Read();

            return newVoyage;
        }
    }

    public class Voyage
    {
        public string PointOfDeparture { get; private set; }
        public string PointOfArrival { get; private set; }
        public int Duration { get; private set; }
        private Train _train;
        private DateTime _finishTime;
        private int _minMinuteDurations = 0;
        private int _maxMinuteDurations = 5;
        private int _NumberOfPassengers;
        private int _minNumberOfPassengers = 10;
        private int _maxNumberOfPassengers = 500;

        public Voyage(string pointOfDeparture, string pointOfArrival)
        {
            Random random = new Random();
            _train = new Train();
            Duration = random.Next(_minMinuteDurations, _maxMinuteDurations);
            _NumberOfPassengers = random.Next(_minNumberOfPassengers, _maxNumberOfPassengers);
            PointOfDeparture = pointOfDeparture;
            PointOfArrival = pointOfArrival;
        }

        public void CreateTheTrain()
        {
            bool isCreating = true;

            while (isCreating)
            {
                Console.Clear();

                ConsoleKey userInput;

                Console.WriteLine($"Количество желающих поехать на этом маршруте: {_NumberOfPassengers}");
                Console.WriteLine($"Количество мест в поезде: {_train.GetNumberOfPassengersSeats()}");
                Console.WriteLine("Вам надо создать поезд, вмещающий всех пассажиров");
                Console.WriteLine("Что бы добвать вагон, нажмите Space");

                userInput = Console.ReadKey(true).Key;
                
                if(userInput == ConsoleKey.Spacebar)
                {
                    _train.AddNewCarriage();
                }
                else
                {
                    Console.WriteLine("Не верный формат ввода!");
                    Console.ReadLine();
                }

                if(_NumberOfPassengers <= _train.GetNumberOfPassengersSeats())
                {
                    isCreating = false;
                }
            }
        }

        public string ShowRoute()
        {
            if(PointOfDeparture == null && PointOfArrival == null)
            {
                return "МАРШРУТ НЕ СОЗДАН";
            } 
            else
            {
                return PointOfDeparture + " - " + PointOfArrival;
            }
        }

        public void SetFinishTime()
        {
            _finishTime = DateTime.Now.AddMinutes(Duration);
        }

        public DateTime GetFinishTime()
        {
            return _finishTime;
        }
    }

    public class Train
    {
        private List<PassengerCarriage> _carriages;

        public Train()
        {
            _carriages = new List<PassengerCarriage>();
        }

        public void AddNewCarriage()
        {
            Console.Write("Введите количество мест в пассажирском вагоне: ");
            if(Int32.TryParse(Console.ReadLine(), out int numberOfSeats))
            {
                _carriages.Add(new PassengerCarriage(numberOfSeats));
            }
            else
            {
                Console.WriteLine("Не верный формат ввода!");
            }
        }

        public int GetNumberOfPassengersSeats()
        {
            int numberOfSeats = 0;
            foreach(PassengerCarriage Carriage in _carriages)
            {
                numberOfSeats += Carriage.NumberOfSeats;
            }
            return numberOfSeats;
        }
    }

    public class PassengerCarriage
    {
        public int NumberOfSeats { get; private set; }

        public PassengerCarriage(int numberOfSeats)
        {
            NumberOfSeats = numberOfSeats;
        }
    }
}
