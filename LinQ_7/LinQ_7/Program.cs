using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_7
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
        private Squad _squadOne;
        private Squad _squadTwo;

        public Game()
        {
            _squadOne = new Squad();
            _squadTwo = new Squad();

        }

        public void Play()
        {
            _squadOne.Concat(_squadTwo.GetSoldiers());

            _squadOne.ShowInfo();
            Console.WriteLine();
            _squadTwo.ShowInfo();
        }
    }

    public class Squad
    {
        private List<Soldier> _soldier;
        private char _char;

        public Squad()
        {
            _char = 'Б';
            _soldier = new List<Soldier>()
            {
                new Soldier("Иван"),
                new Soldier("Борис"),
                new Soldier("Антон"),
                new Soldier("Гриша"),
                new Soldier("Витя"),
                new Soldier("Дима"),
                new Soldier("Боря"),
                new Soldier("Батя"),
                new Soldier("Вова"),
                new Soldier("Братан"),
                new Soldier("Гиря")
            };
        }

        public void Concat(List<Soldier> soldiers)
        {
            _soldier.AddRange(soldiers);
        }

        public List<Soldier> GetSoldiers()
        {
            List<Soldier> filtredSoldiers = _soldier.Where(_soldier => _soldier.Name.First() == _char).ToList();

            _soldier.RemoveAll(_soldier => _soldier.Name.First() == _char);

            return filtredSoldiers;
        }

        public void ShowInfo()
        {
            foreach(Soldier soldier in _soldier)
            {
                Console.WriteLine(soldier.Name);
            }
        }
    }

    public class Soldier
    {
        public string Name { get; private set; }

        public Soldier(string name)
        {
            Name = name;
        }
    }
}
