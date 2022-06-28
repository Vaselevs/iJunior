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
            public List<Item> Inventory { get; protected set; }

            public Human(string name, string description, int money)
            {
                Name = name;
                Description = description;
                Money = money;
                Inventory = new List<Item>();
            }

            public void ShowInventory()
            {
                foreach(Item item in Inventory)
                {
                    item.Show();
                }
            }
        }

        class Player : Human
        {

            public Player(string name, string description, int money) : base(name, description, money)
            {
                Inventory = new List<Item>();
            }

        }

        class Seller : Human
        {
            public Seller(string name, string description, int money) : base(name, description, money)
            {
                Inventory = new List<Item>();
            }

            public void SellItem(int buyingItemID)
            {
                if (buyingItemID < Inventory.Count && Inventory[buyingItemID].Cost < Money)
                {
                    Item sellingItem = Inventory[buyingItemID];
                    Inventory.RemoveAt(buyingItemID);
                    Console.WriteLine($"{Name} успешно продал товар {sellingItem.Name} за {sellingItem.Cost}");
                }
                else if (buyingItemID >= Inventory.Count)
                {
                    Console.WriteLine("Нет товара с таким номером!");
                }
                else
                {
                    Console.WriteLine("Покупателю не хватает денег!");
                }
            }

            public void AddItemToSeller(string name, string cost)
            {
                Item userInputItem = new Item();


            }
            
        }

        class Item
        {
            public string Name { get; private set; }
            public int Cost { get; private set; }

            public Item(string name, int cost)
            {
                Name = name;
                Cost = cost;
            }

            public void Show()
            {
                Console.WriteLine(Name + " - " + Cost);
            }



        }
    }
}
