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
        private Aviary[] _aviary;

        public Game()
        {
            _aviary = new Aviary[5] { new Aviary(), new Aviary(), new Aviary(), new Aviary(), new Aviary() };
        }

        public void Play()
        {
            bool isPlaying = true;

            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine("Что бы выйти из программы нажмите цифру 0");
                Console.Write($"Вы стоите перед {_aviary.Length} вольерами, выберите к какому подойти: ");
                
                if(Int32.TryParse(Console.ReadLine(), out int userChoise) && userChoise <= _aviary.Length && userChoise > 0)
                {
                    Console.Clear();
                    _aviary[userChoise-1].ShowInfoAbout();
                    Console.WriteLine("Что бы вернуться в меню, нажмите любую клаваишу");
                    Console.ReadLine();
                } 
                else if(userChoise == 0)
                {
                    isPlaying = false;
                }
            }
        }
    }

    public class Aviary
    {
        private Animal[] _listOfAllAnimals;
        private Animal[] _animals;
        private Random _random;
        private int _minCountOfAnimals;

        public Aviary()
        {
            _minCountOfAnimals = 1;
            _random = new Random();
            _listOfAllAnimals = new Animal[5] { new Dog("male", "Гав"), new Cat("female", "Мяу"), new Horse("male", "Игого"), new Donkey("female", "Иа-Иа"), new Bear("male", "Гррррр") };
            _animals = new Animal[_random.Next(_minCountOfAnimals, _listOfAllAnimals.Length)];

            CreateAnimals();
        }

        public void ShowInfoAbout()
        {
            foreach (Animal animal in _animals)
            {
                animal.ShowInfo();
            }
        }

        public int GetCountOfAnimals()
        {
            return _animals.Length;
        }

        private void CreateAnimals()
        {
            for (int i = 0; i < _animals.Length; i++)
            {
                _animals[i] = _listOfAllAnimals[_random.Next(_listOfAllAnimals.Length)];
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

        public void ShowInfo()
        {
            Console.WriteLine($"Животное {_sex} пола. Издаёт звук {_voice}");
        }
    }

    public class Dog : Animal
    {
        public Dog(string sex, string voice) : base(sex, voice)
        {

        }
    }

    public class Cat : Animal
    {
        public Cat(string sex, string voice) : base(sex, voice)
        {

        }
    }

    public class Horse : Animal
    {
        public Horse(string sex, string voice) : base(sex, voice)
        {

        }
    }

    public class Donkey : Animal
    {
        public Donkey(string sex, string voice) : base(sex, voice)
        {

        }
    }

    public class Bear : Animal
    {
        public Bear(string sex, string voice) : base(sex, voice)
        {

        }
    }
}
