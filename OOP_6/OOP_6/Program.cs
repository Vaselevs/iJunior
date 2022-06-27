using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_6
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        class Human
        {
            public string Name { get; private set; }
            public string Description { get; private set; }
            public int Money { get; private set; }
            public List<Item> Inventory { get; private set; }

            public Human(string name, string description, int money)
            {
                Name = name;
                Description = description;
                Money = money;
            }
        }

        class Player : Human
        {

            public Player(string name, string description, int money) : base(name, description, money)
            {

            }

        }

        class Seller : Human
        {
            public Seller(string name, string description, int money) : base(name, description, money)
            {

            }
        }

        class Item
        {
            public string Name { get; private set; }
            public int Cost { get; private set; }

        }
    }
}
