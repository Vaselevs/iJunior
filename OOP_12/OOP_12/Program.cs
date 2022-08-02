using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_12
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
        private Aviary[] _aviaries;
        private int _aviarysCount;

        public Game()
        {
            _aviarysCount = 5;

            _aviaries = new Aviary[_aviarysCount];

            for (int i = 0; i < _aviarysCount; i++)
            {
                _aviaries[i] = new Aviary();
            }
        }

        public void Play()
        {
            bool isPlaying = true;

            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine("Что бы выйти из программы нажмите Enter");
                Console.Write($"Вы стоите перед {_aviaries.Length} вольерами, выберите к какому подойти: ");
                
                if(Int32.TryParse(Console.ReadLine(), out int userChoise) && userChoise <= _aviaries.Length && userChoise > 0)
                {
                    Console.Clear();
                    _aviaries[userChoise-1].ShowInfo();
                    Console.WriteLine("Что бы вернуться в меню, нажмите любую клаваишу");
                    Console.ReadLine();
                } 
                else
                {
                    isPlaying = false;
                }
            }
        }
    }

    public class Aviary
    { 
        private Animal[] _animals;
        private Random _random;
        private int _minCountOfAnimals;

        public Aviary()
        {
            Animal[] _animalsToChoise;

            _minCountOfAnimals = 1;
            _random = new Random();
            _animalsToChoise = new Animal[5] { new Dog("male", "Гав"), new Cat("female", "Мяу"), new Horse("male", "Игого"), new Donkey("female", "Иа-Иа"), new Bear("male", "Гррррр") };
            _animals = new Animal[_random.Next(_minCountOfAnimals, _animalsToChoise.Length)];

            CreateAnimals(_animalsToChoise);
        }

        public void ShowInfo()
        {
            foreach (Animal animal in _animals)
            {
                animal.ShowInfo();
            }
        }

        private void CreateAnimals(Animal[] _animalsToChoise)
        {
            for (int i = 0; i < _animals.Length; i++)
            {
                _animals[i] = _animalsToChoise[_random.Next(_animalsToChoise.Length)];
            }

            System.Threading.Thread.Sleep(100);
        }
    }

    public abstract class Animal
    {
        private string _sex;
        private string _voice;

        public Animal(string sex, string voice)
        {
            _sex = sex;
            _voice = voice;
        }

        public void ShowInfo() => Console.WriteLine($"Животное {_sex} пола. Издаёт звук {_voice}");
    }

    public class Dog : Animal
    {
        public Dog(string sex, string voice) : base(sex, voice) { }
    }

    public class Cat : Animal
    {
        public Cat(string sex, string voice) : base(sex, voice) { }
    }

    public class Horse : Animal
    {
        public Horse(string sex, string voice) : base(sex, voice) { }
    }

    public class Donkey : Animal
    {
        public Donkey(string sex, string voice) : base(sex, voice) { }
    }

    public class Bear : Animal
    {
        public Bear(string sex, string voice) : base(sex, voice) { }
    }
}
