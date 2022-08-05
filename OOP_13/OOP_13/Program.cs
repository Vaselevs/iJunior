using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_13
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
        private CarService _carService;
        private Detail[] _details;
        private Queue<Car> _cars;
        private int _playerMoney;

        public Game()
        {
            _playerMoney = 1000;
            int brokenCarCount = 15;
            _cars = new Queue<Car>();
            _details = new Detail[10]
            {
                new Detail("Карбюратор", 30),
                new Detail("Бампер", 20),
                new Detail("Корбка передач", 75),
                new Detail("Крыша", 35),
                new Detail("Колесо", 5),
                new Detail("Двигатель", 110),
                new Detail("Шасси", 90),
                new Detail("Руль", 7),
                new Detail("Тормоза", 45),
                new Detail("Выхлоп", 12)
            };
            _carService = new CarService(_details, 1000);

            for (int i = 0; i < brokenCarCount; i++)
            {
                _cars.Enqueue(new Car(_details));
            }
        }

        public void Play()
        {
            bool isPlaying = true;

            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в мастерскую!");
                Console.WriteLine($"У вас {_playerMoney} денег");

                Console.WriteLine("На вашем складе есть следующие детали: ");
                Console.WriteLine();

                _carService.ShowStorage();

                Console.WriteLine("К вам приехал клиент!");

                Car car = _cars.Dequeue();

                Console.WriteLine($"У машины клиента сломан - {car.GetBrokenDetailName()}, цена починки: {car.GetBrokenDetailPrice() + _carService.ServiceTax}");
                Console.WriteLine("Выберите что сделать с клиентом: ");
                Console.WriteLine($"1. Отказать клиенту. Это будет вам стоить {_carService.ServicePenalty}");
                Console.WriteLine($"2. Попытаться починить машину из деталей на складе. Вы получите награду в виде стоимости детали + {_carService.ServiceTax}");

                if(Int32.TryParse(Console.ReadLine(), out int userChoise))
                {
                    switch (userChoise)
                    {
                        case 1:
                            RefuseClient();
                            break;
                        case 2:

                            break;
                        default:

                            break;
                    }
                }
            }

            void RefuseClient()
            {
                _carService.TakePenalty();
                Console.WriteLine($"Вы отказали клиенту в обслуживании! Вы получаете штраф {_carService.ServiceTax}");
            }
        }
    }

    public class CarService
    {
        private Dictionary<Detail, int> _detailsStorage;
        private Random _random;
        public int Money { get; private set; }
        public int ServiceTax { get; private set; }
        public int ServicePenalty { get; private set; }

        public CarService(Detail[] _details, int money)
        {
            ServiceTax = 20;
            ServicePenalty = 50;
            int maxDetailsCount = _details.Length;

            _random = new Random();
            _detailsStorage = new Dictionary<Detail, int>();

            for (int i = 0; i < _details.Length; i++)
            {
                int detailsCount = _random.Next(maxDetailsCount);

                if (detailsCount > 0)
                {
                    _detailsStorage.Add(_details[i], detailsCount);
                }
            }

            Money = money;
        }

        public void ShowStorage()
        {
            for(int i = 0; i < _detailsStorage.Count; i++)
            {
                Console.WriteLine($"Наименование: {_detailsStorage.ElementAt(i).Key.Name} | Цена: {_detailsStorage.ElementAt(i).Key.Price} | Количество: {_detailsStorage.ElementAt(i).Value}");
            }
        }

        public void TakePenalty()
        {
            Money -= ServicePenalty;
            
        }
    }

    public class Car
    {
        private Detail _brokenDetail;
        private Random _random;

        public Car(Detail[] _details)
        {
            _random = new Random();
            _brokenDetail = _details[_random.Next(_details.Length)];
        }

        public string GetBrokenDetailName()
        {
            return _brokenDetail.Name;
        }

        public int GetBrokenDetailPrice()
        {
            return _brokenDetail.Price;
        }
    }

    public class Detail
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Detail(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
