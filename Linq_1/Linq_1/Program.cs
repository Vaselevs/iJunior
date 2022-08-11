using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_1
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
        private Criminal[] _criminals;

        public Game()
        {
            _criminals = new Criminal[5] { 
                new Criminal("Петя", true, 123, 55, "Римлянин"), 
                new Criminal("Вася", false, 175, 70, "Француз"),
                new Criminal("Антон", false, 175, 71, "Француз"),
                new Criminal("Женя", false, 174, 69, "Китаец"),
                new Criminal("Игорь", true, 175, 70, "Японец")
            };
        }

        public void Play()
        {
            int growth = 0;
            int weight = 0;
            string nationality;

            Console.Write("Введите рост преступника: ");
            CheckData(ref growth);
            Console.Write("Введите вес преступника: ");
            CheckData(ref weight);
            Console.Write("Введите национальность преступника: ");
            nationality = Console.ReadLine();

            var findedCriminals = from Criminal criminal in _criminals
                                  where criminal.IsArrested == false && criminal.Weight == weight && criminal.Nationality == nationality
                                  select new
                                  {
                                      criminal.Name
                                  };

            foreach(var criminal in findedCriminals)
            {
                Console.WriteLine($"{criminal.Name}");
            }

            void CheckData(ref int data)
            {
                if (Int32.TryParse(Console.ReadLine(), out data))
                    Console.WriteLine("Вы успешнно ввели данные");
                else
                    Console.WriteLine("Вы ошиблись при вооде данных");
            }
        }
    }

    public class Criminal
    {
        public string Name { get; private set; }
        public bool IsArrested { get; private set; }
        public int Growth { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public Criminal(string name, bool isArrested, int growth, int weight, string nationality)
        {
            Name = name;
            IsArrested = isArrested;
            Growth = growth;
            Weight = weight;
            Nationality = nationality;
        }
    }
}
