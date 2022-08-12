using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_5
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
        private Storage _storage;

        public Game()
        {
            _storage = new Storage();
        }

        public void Play()
        {
            ShowInfo(_storage.GetOverdueStew());

            void ShowInfo(List<CanOfStew> cansOfStew)
            {
                foreach (CanOfStew canOfStew in cansOfStew)
                {
                    canOfStew.ShowInfo();
                }
            }
        }
    }

    public class Storage
    {
        private List<CanOfStew> _cansOfStew;

        public Storage()
        {
            _cansOfStew = new List<CanOfStew>()
            {
                new CanOfStew("Бурёнка", new DateTime(2015, 1, 1), new DateTime(2020, 1, 1)),
                new CanOfStew("Солёнка", new DateTime(2013, 1, 1), new DateTime(2023, 1, 1)),
                new CanOfStew("Харчо", new DateTime(2012, 1, 1), new DateTime(2019, 1, 1)),
                new CanOfStew("Свинина", new DateTime(2016, 1, 1), new DateTime(2022, 1, 1)),
                new CanOfStew("Марочная", new DateTime(2012, 1, 1), new DateTime(2015, 1, 1)),
                new CanOfStew("Именная", new DateTime(2018, 1, 1), new DateTime(2026, 1, 1))
            };
        }

        public List<CanOfStew> GetOverdueStew()
        {
            return _cansOfStew.Where(_canOfStews => _canOfStews.ExpirationDate.Year < DateTime.Now.Year).ToList();
        }
    }

    public class CanOfStew
    {
        public string Name { get; private set; }
        public DateTime DateOfManufacture { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public CanOfStew(string name, DateTime dateOfManufacture, DateTime expirationDate)
        {
            Name = name;
            DateOfManufacture = dateOfManufacture;
            ExpirationDate = expirationDate;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {DateOfManufacture.Year} - {ExpirationDate.Year}");
        }
    }
}
