using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_4
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
            ShowInfo(_squad.Players);
            Console.WriteLine("Топ-3 по силе:");
            ShowInfo(_squad.GetTopByPower());
            Console.WriteLine("Топ-3 по Lvl:");
            ShowInfo(_squad.GetTopByLevel());
            Console.ReadLine();
        }

        private void ShowInfo(List<Player> players)
        {
            foreach(var player in players)
            {
                player.ShowInfo();
            }
        }
    }

    public class Squad
    {
        public List<Player> Players { get; private set; }

        public Squad()
        {
            Players = new List<Player>
            {
                new Player("Вася", 10, 100),
                new Player("Коля", 12, 230),
                new Player("Петя", 233, 42340),
                new Player("Игорь", 32, 431),
                new Player("Антон", 521, 2534421),
                new Player("Иван", 234, 3424),
                new Player("Саша", 84, 2311),
                new Player("Люся", 34, 1231),
                new Player("Женя", 184, 14231),
                new Player("Вова", 325, 23451),
            };
        }
        public List<Player> GetTopByLevel()
        {
            return Players.OrderByDescending(_players => _players.Lvl).Take(3).ToList();
        }

        public List<Player> GetTopByPower()
        {
            return Players.OrderByDescending(_players => _players.Power).Take(3).ToList();
        }
    }

    public class Player
    {
        public string Name { get; private set; }
        public int Lvl { get; private set; }
        public int Power { get; private set; }

        public Player(string name, int lvl, int power)
        {
            Name = name;
            Lvl = lvl;
            Power = power;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Lvl} - {Power}");
        }
    }
}
