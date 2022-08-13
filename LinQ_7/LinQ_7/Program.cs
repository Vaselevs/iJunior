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
        private List<Soldier> _soldiersSquadOne;
        private List<Soldier> _soldiersSquadTwo;
        private char _filterChar;

        public Game()
        {
            _filterChar = 'Б';

            _soldiersSquadOne = new List<Soldier>()
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

            _soldiersSquadTwo = new List<Soldier>()
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

        public void Play()
        {
            _soldiersSquadTwo = _soldiersSquadTwo.Concat(_soldiersSquadOne.Where(soldier => soldier.Name.First() == _filterChar)).ToList();
            _soldiersSquadOne = _soldiersSquadOne.Where(soldier => soldier.Name.First() != _filterChar).ToList();

            foreach (Soldier soldier in _soldiersSquadTwo)
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
