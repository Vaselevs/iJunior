using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Game
    {
        private Criminal[] _criminals;

        public Game()
        {
            _criminals = new Criminal[5]
            {
                new Criminal("Вася", "Разбой"),
                new Criminal("Петя", "Грабёж"),
                new Criminal("Коля", "Антиправительственное"),
                new Criminal("Саша", "Угон"),
                new Criminal("Дима", "Антиправительственное")
            };
        }

        public void Play()
        {

        }
    }

    public class Criminal
    {
        public string Name { get; private set; }
        public string Crime { get; private set; }

        public Criminal(string name, string crime)
        {
            Name = name;
            Crime = crime;
        }
    }
}
