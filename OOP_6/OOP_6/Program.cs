﻿using System;
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
            Player player = new Player("Вася", "Обычный путешественник", 1000);
            Seller seller = new Seller("Тайный продавец", "Самый секретный продавец в мире", 0);
            Game game = new Game();

            game.Work(player, seller);

        }
    }

    class Game
    {
        public void Work(Player player, Seller seller)
        {
            bool isPlaying = true;
            string userInput;

            while (isPlaying)
            {
                Console.Clear();
                player.ShowStats();
                Console.WriteLine($"Игрок {player.Name} повстречал на своём пути продавца {seller.Name}\n");
                seller.ShowStats();
                Console.WriteLine($"Выберите пункт меню, для дальнейшего взаимодействия\n");
                Console.WriteLine("1. Показать список предметов продавца");
                Console.WriteLine("2. Показать ваш список предметов");
                Console.WriteLine("3. Купить предмет у продовца");
                Console.WriteLine("4. Добавить предмет продавцу");
                Console.WriteLine("5. Уйти");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        seller.ShowInventory();
                        break;
                    case "2":
                        player.ShowInventory();
                        break;
                    case "3":
                        player.BuyItem(seller);
                        break;
                    case "4":
                        seller.CreateSellingItems();
                        break;
                    case "5":
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню!");
                        break;
                }

                Console.ReadLine();
            }
        }
    }

    class Human
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Money { get; protected set; }
        protected List<Item> Inventory;

        public Human(string name, string description, int money)
        {
            Name = name;
            Description = description;
            Money = money;
        }

        public void ShowInventory()
        {
            for(int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine("Номер - Название - Цена\n");
                Console.Write($"#####\n {i+1} - ");
                Inventory[i].Show();
                Console.WriteLine("#####");
            }
        }

        public int GetInventoryCount()
        {
            return Inventory.Count;
        }

        public Item GetItemFromInventory(int itemPosition)
        {
            return Inventory[itemPosition];
        }
    }

    class Player : Human
    {
        public Player(string name, string description, int money) : base(name, description, money)
        {
            Inventory = new List<Item>();
        }

        public void BuyItem(Seller seller)
        {
            Console.Clear();
            ShowStats();
            seller.ShowInventory();
            Console.Write("Выберите предмет который хотите купить: ");
            if (Int32.TryParse(Console.ReadLine(), out int userChoise))
            {
                userChoise -= 1;
                
                if(userChoise > 0 && userChoise < seller.GetInventoryCount())
                {
                    if(seller.GetItemFromInventory(userChoise).Cost < Money)
                    {
                        Money -= seller.GetItemFromInventory(userChoise).Cost;
                        Inventory.Add(seller.GetItemFromInventory(userChoise));
                        seller.SellItem(userChoise);
                    }
                    else
                    {
                        Console.WriteLine("У вас не достаточно денег!");
                    }
                }
                else
                {
                    Console.WriteLine("Вы вышли за диапазон инвентаря!");
                }
            }
            else
            {
                Console.WriteLine("Не верный формат ввода!");
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"Имя игрока: {Name} | Количество предметов в инвентаре: {Inventory.Count} | Кошелёк игрока: {Money}\n");
        }
    }

    class Seller : Human
    {
        public Seller(string name, string description, int money) : base(name, description, money)
        {
            Inventory = new List<Item>();
            CreateSellingItems();
        }

        public void SellItem(int buyingItemID)
        {
            Money += Inventory[buyingItemID].Cost;
            Inventory.RemoveAt(buyingItemID);
        }

        public void CreateSellingItems()
        {
            bool isPlaying = true;

            while (isPlaying)
            {
                ConsoleKeyInfo userInput;

                Console.Clear();
                Console.WriteLine("Нажмите пробел, что бы добавить новый предмет в инветарь");
                Console.WriteLine("Нажмите Esc что бы выйти из режима добавления предметов продавцу\n");

                userInput = Console.ReadKey(true);

                switch (userInput.Key)
                {
                    case ConsoleKey.Spacebar:
                        AddItemInInventory();
                        break;
                    case ConsoleKey.Escape:
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды нет");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void AddItemInInventory()
        {
            string name;
            string cost;

            Console.Write("Введите название нового предмета: ");

            name = Console.ReadLine();

            Console.Write("Введите стоимость нового предмета:");

            cost = Console.ReadLine();

            if (Int32.TryParse(cost, out int costInInt))
            {
                Item userInputItem = new Item(name, costInInt);
                Inventory.Add(userInputItem);
                Console.WriteLine("Предмет успешно добавлен в инвентарь");
            }
            else
            {
                Console.WriteLine("Вы ввели неверную цену нового предмета");
                Console.ReadLine();
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"Имя продавца: {Name} | Количество предметов в инвентаре: {Inventory.Count} | Кошелёк продавца: {Money}\n");
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
