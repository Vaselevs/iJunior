using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_6
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
        private Squad _squad;

        public Game()
        {
            _squad = new Squad();
        }

        public void Play()
        {
            ShowInfo(_squad.GetNameAndRank());

            void ShowInfo(Array inputArray)
            {
                foreach(var item in inputArray)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }

    public class Squad
    {
        private List<Soldier> _soldiers;

        public Squad()
        {
            _soldiers = new List<Soldier>()
            {
                new Soldier("Иван", "Магнум", "Рядовой", "12 месяцев"),
                new Soldier("Антон", "Пулемёт", "Полковник", "144 месяцев"),
                new Soldier("Коля", "Фомка", "Майор", "36 месяцев"),
                new Soldier("Петя", "Револьвер", "Лейтенант", "24 месяцев"),
                new Soldier("Вася", "Автомат", "Ефрейтор", "54 месяцев"),
                new Soldier("Саша", "Винтовка", "Сержант", "22 месяцев"),
                new Soldier("Игорь", "Танк", "Капитан", "16 месяцев"),
                new Soldier("Артур", "Снайперка", "Капрал", "15 месяцев"),
                new Soldier("Женя", "Мина", "Генерал", "23 месяцев"),
                new Soldier("Семён", "Подлодка", "Капитан", "122 месяцев"),
            };
        }

        public Array GetNameAndRank()
        {
            return _soldiers.Select(_soldiers => (_soldiers.Name, _soldiers.Rank)).ToArray();
        }
    }

    public class Soldier
    {
        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public string TermOfMilitaryService { get; private set; }

        public Soldier(string name, string weapon, string rank, string termOfMilitaryService)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            TermOfMilitaryService = termOfMilitaryService;
        }
    }
}
