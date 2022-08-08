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

        public Game()
        {
            int brokenCarCount = 20;
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

            _carService = new CarService(_details, 100);

            for (int i = 0; i < brokenCarCount; i++)
            {
                _cars.Enqueue(new Car(_details));
            }
        }

        public void Play()
        {
            bool isPlaying = true;

            while (isPlaying && _cars.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в мастерскую!");
                Console.WriteLine($"У вас {_carService.Money} денег");
                Console.WriteLine("На вашем складе есть следующие детали: ");
                Console.WriteLine();

                _carService.ShowStorage();

                Console.WriteLine("К вам приехал клиент!");
                Console.WriteLine();

                Car car = _cars.Dequeue();
                int payment = car.BrokenDetail.Price + _carService.ServiceTax;

                Console.WriteLine($"У машины клиента сломан - {car.BrokenDetail.Name}, цена починки: {payment}");
                Console.WriteLine("Выберите что сделать с клиентом: ");
                Console.WriteLine($"1. Отказать клиенту. Это будет вам стоить {_carService.ServicePenalty}");
                Console.WriteLine($"2. Попытаться починить машину из деталей на складе. Вы получите награду {payment}");
                Console.WriteLine($"В случае установки не правильной детали, вам так же надо будет заплатить штраф: {_carService.ServicePenalty}");
                Console.WriteLine($"Что бы выйти из прогрммы нажмите ENTER");

                if(Int32.TryParse(Console.ReadLine(), out int userChoise))
                {
                    switch (userChoise)
                    {
                        case 2:
                            _carService.RepairCar(car);
                            break;
                        default:
                            _carService.RefuseClient();
                            break;
                    }
                }
                else
                {
                    isPlaying = false;
                }
            }
        }
    }

    public class CarService
    {
        private List<Cell> _detailsStorage;
        public int Money { get; private set; }
        public int ServiceTax { get; private set; }
        public int ServicePenalty { get; private set; }

        public CarService(Detail[] _details, int money)
        {
            int maxDetailsCount = _details.Length;
            Random random = new Random();
            ServiceTax = 20;
            ServicePenalty = 50;
            
            _detailsStorage = new List<Cell>();

            for (int i = 0; i < _details.Length; i++)
            {
                int detailsCount = random.Next(maxDetailsCount);
                Cell product = new Cell(_details[i], detailsCount);
                _detailsStorage.Add(product);
            }

            Money = money;
        }

        public void ShowStorage()
        {
            for(int i = 0; i < _detailsStorage.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_detailsStorage.ElementAt(i).Detail.Name} | Цена: {_detailsStorage.ElementAt(i).Detail.Name} | Количество: {_detailsStorage.ElementAt(i).Count}");
            }
        }

        public void RepairCar(Car car)
        {
            Console.Write("Выберите номер детали из склада выше: ");

            if (Int32.TryParse(Console.ReadLine(), out int userChoise))
            {

                if (GetDetailByIndex(userChoise - 1).Name == car.BrokenDetail.Name && GetDetailCountByIndex(userChoise - 1) > 0)
                {
                    Console.WriteLine($"Вы успешно починили деталь и заработали {car.BrokenDetail.Price + ServiceTax}");

                    AddPayment(car.BrokenDetail.Price);
                    DecreaseDetailCount(car.BrokenDetail.Name);
                }
                else
                {
                    DecreaseDetailCount(GetDetailByIndex(userChoise - 1).Name);
                    RefuseClient();
                }
            }
        }

        public Detail GetDetailByIndex(int userChoise)
        {
            return _detailsStorage.ElementAt(userChoise).Detail;
        }

        public int GetDetailCountByIndex(int userChoise)
        {
            return _detailsStorage.ElementAt(userChoise).Count;
        }

        public void AddPayment(int tax)
        {
            Money += tax + ServiceTax;
        }

        public void DecreaseDetailCount(string detailName)
        {
            for(int i = 0; i < _detailsStorage.Count; i++)
            {
                if (detailName == _detailsStorage.ElementAt(i).Detail.Name)
                {
                    _detailsStorage.ElementAt(i).DecrementCount();
                    break;
                }
            }
        }

        public void RefuseClient()
        {
            Money -= ServicePenalty;
            if (Money < 0)
                Money = 0;
            Console.WriteLine($"Вы не обслужили клиента! Вы получаете штраф {ServicePenalty}");
        }
    }

    public class Cell
    {
        public Detail Detail { get; private set; }
        public int Count { get; private set; }

        public Cell(Detail detail, int count)
        {
            Detail = detail;
            Count = count;
        }

        public void DecrementCount()
        {
            if(Count > 0)
            {
                Count--;
            }
        }
    }

    public class Car
    {
        public Detail BrokenDetail { get; private set; }

        public Car(Detail[] _details)
        {
            Random random = new Random();
            BrokenDetail = _details[random.Next(_details.Length)];
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
