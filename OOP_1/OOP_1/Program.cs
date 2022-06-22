using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player NewPlayer = new Player("Ivan", 100, 10);

            NewPlayer.ShowInfo();
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Mana { get; private set; }

        public Player(string name, int health, int mana)
        {
            Name = name;
            Health = health;
            Mana = mana;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Игрока зовут - {Name}. У него {Health} здоровья и {Mana} маны.");
        }
    }
}
