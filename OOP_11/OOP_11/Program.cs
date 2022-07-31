using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Play();
        }
    }

    class Game
    {
        private Aquarium _aquarium;

        public Game()
        {
            _aquarium = new Aquarium();
        }

        public void Play()
        {
            bool isPlaying = true;
            bool isShowFish = false;

            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine($"Текущее количество рыб в аквариуме: {_aquarium.GetCountOfFishes()}");

                if (isShowFish) 
                    _aquarium.ShowAllFishes();

                Console.WriteLine("Выберите пункт меню: ");
                Console.WriteLine();
                Console.WriteLine("1. Показать или не показывать текущих рыб в аквариуме");
                Console.WriteLine("2. Добавить рыбу в аквариум");
                Console.WriteLine("3. Выйти");

                if (int.TryParse(Console.ReadLine(), out int userChoise))
                {
                    switch (userChoise)
                    {
                        case 1:
                            isShowFish = isShowFish == false;
                            break;
                        case 2:
                            _aquarium.AddFish();
                            break;
                        case 3:
                            isPlaying = false;
                            break;
                    }
                }

                _aquarium.DecreaseFishesHealthByTime();
                _aquarium.CleanFromDeadFishBody();
            }
        }
    }

    class Aquarium
    {
        private List<Fish> _fishes;

        public Aquarium()
        {
            _fishes = new List<Fish>();
        }

        public void AddFish()
        {
            string fishName;

            Console.WriteLine("Введите имя рыбы: ");
            fishName = Console.ReadLine();
            Console.WriteLine("Введите здоровье рыбы: ");

            if(Int32.TryParse(Console.ReadLine(), out int fishHealth))
            {
                _fishes.Add(new Fish(fishName, fishHealth));
            } 
            else
            {
                Console.WriteLine("Вы ввели не верное здоровье рыбы!");
            }
        }

        public void ShowAllFishes()
        {
            if(_fishes.Count > 0)
            {
                foreach (Fish fish in _fishes)
                {
                    fish.ShowInfo();
                }
            }
        }

        public int GetCountOfFishes() => _fishes.Count();

        public void DecreaseFishesHealthByTime()
        {
            if (_fishes.Count > 0)
            {
                for(int i = 0; i < _fishes.Count; i++)
                {
                    _fishes[i].DecreaseHealth();
                }
            }   
        }

        public void CleanFromDeadFishBody()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].Health <= 0)
                {
                    _fishes.Remove(_fishes[i]);
                }
            }
        }
    }

    class Fish
    {
        public string Name { get; private set; }
        public int Health { get; private set; }

        public Fish(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void ShowInfo() => Console.WriteLine($"{Name} - {Health} HP");

        public void DecreaseHealth() => Health--;
    }
}
