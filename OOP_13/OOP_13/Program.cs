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

        public Game()
        {
            _details = new Detail[10] {new Detail("Карбюратор", 30), new Detail("Бампер", 20), new Detail("Корбка передач", 75), new Detail("Крыша", 35), new Detail("Колесо", 5), new Detail("Двигатель", 110),
        new Detail("Шасси", 90), new Detail("Руль", 7), new Detail("Тормоза", 45), new Detail("Выхлоп", 12)};
            _carService = new CarService(_details, 1000);
        }

        public void Play()
        {
            _carService.ShowStorage();
        }

    }

    public class CarService
    {
        private Dictionary<Detail, int> _detailsStorage;
        private Random _random;
        public int Money { get; private set; }

        public CarService(Detail[] _details, int money)
        {
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
                Console.WriteLine($"Наименование и цена: {_detailsStorage.ElementAt(i).Key.GetInfo()} | количество - {_detailsStorage.ElementAt(i).Value}");
            }
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

        public void GetBrokenDetailInfo()
        {

        }
    }

    public class Detail
    {
        private string _name;
        private int _price;

        public Detail(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public string GetInfo()
        {
            return _name + " - " + _price;
        }
    }
}
