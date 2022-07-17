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

        }
    }

    public class Game
    {
        public void Play(Player player)
        {
            Voyage activeVoyage;
            bool isPlaying = true;

            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine($"Текущий рейс: {player.GetLastVoyage().PointOfDeparture} - {player.GetLastVoyage().PointOfArrival}");
                Console.WriteLine($"Количество ещё необработанных рейсов - {player.GetAmountOfVoyages()}");
            }
        }
    }

    public class Player
    {
        private Queue<Voyage> voyageQueue;

        public Player()
        {
            voyageQueue = new Queue<Voyage>();
        }

        public void AddNewVoyage()
        {
            Console.Write("Введите название пункта отправления - ");
            string pointOfDeparture = Console.ReadLine();
            Console.Write("Введите название пункта прибытия - ");
            string pointOfArrival = Console.ReadLine();

            Voyage newVoyage = new Voyage(pointOfDeparture, pointOfArrival);

            voyageQueue.Enqueue(newVoyage);
        }

        public Voyage GetLastVoyage()
        {
            return voyageQueue.Peek();
        }

        public int GetAmountOfVoyages()
        {
            return voyageQueue.Count();
        }

    }

    public class Voyage
    {
        public string PointOfDeparture { get; private set; }
        public string PointOfArrival { get; private set; }
        public int Duration { get; private set; }
        private Train train;
        private DateTime finishTime;
        private int minDurations = 0;
        private int maxDurations = 5;
        private int NumberOfPassengers;
        private int minNumberOfPassengers = 10;
        private int maxNumberOfPassengers = 500;

        public Voyage(string pointOfDeparture, string pointOfArrival)
        {
            Random random = new Random();
            train = new Train();
            Duration = random.Next(minDurations, maxDurations);
            NumberOfPassengers = random.Next(minNumberOfPassengers, maxNumberOfPassengers);
            PointOfDeparture = pointOfDeparture;
            PointOfArrival = pointOfArrival;
        }

        public int GetNumberOfPassengers()
        {
            return NumberOfPassengers;
        }

        public void CreateTheTrain()
        {
            bool isCreating = true;

            while (isCreating)
            {
                ConsoleKey userInput;

                Console.WriteLine($"Количество желающих поехать на этом маршруте - {NumberOfPassengers}");
                Console.WriteLine($"Количество мест в поезде: {train.GetNumberOfPassengersSeats()}");
                Console.WriteLine("Вам надо создать поезд, вмещающий всех пассажиров");
                Console.WriteLine("Что бы добвать вагон, нажмите Space");

                userInput = Console.ReadKey().Key;
                
                if(userInput == ConsoleKey.Spacebar)
                {
                    train.AddNewCarriage();
                }
                else
                {
                    Console.WriteLine("Не верный формат ввода!");
                    Console.ReadLine();
                }

                Console.Clear();
            }
        }

    }


    public class Train
    {
        private List<PassengerCarriage> Carriages { get; set; }

        public Train()
        {
            Carriages = new List<PassengerCarriage>();
        }

        public void AddNewCarriage()
        {
            Console.Write("Введите количество мест в пассажирском вагоне: ");
            if(Int32.TryParse(Console.ReadLine(), out int numberOfSeats))
            {
                Carriages.Add(new PassengerCarriage(numberOfSeats));
            }
            else
            {
                Console.WriteLine("Не верный формат ввода!");
            }
        }

        public int GetNumberOfPassengersSeats()
        {
            int numberOfSeats = 0;
            foreach(PassengerCarriage Carriage in Carriages)
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
