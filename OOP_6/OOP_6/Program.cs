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
            Player player = new Player("Вася", "Обычный путешественник", 1000);
            Seller seller = new Seller("Тайный продавец", "Самый секретный продавец в мире", 0);

            player.Game(seller);
        }
    }

    class Human
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Money { get; protected set; }
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
            for(int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine($"#####\n {i+1}\n#####");
                Inventory[i].Show();
            }
        }
    }

    class Player : Human
    {
        public Player(string name, string description, int money) : base(name, description, money)
        {
            Inventory = new List<Item>();
        }

        public void Game(Seller seller)
        {
            bool isPlaying = true;
            string userInput;

            while (isPlaying)
            {
                ShowStats();
                Console.WriteLine($"Игрок {Name} повстречал на своём пути продавца {seller.Name}");
                seller.ShowStats();
                Console.WriteLine($"Выберите пункт меню, для дальнейшего взаимодействия\n");
                Console.WriteLine("1. Показать список предметов продавца");
                Console.WriteLine("2. Показать ваш список предметов");
                Console.WriteLine("3. Купить предмет у продовца");
                Console.WriteLine("4. Добавить предмет продавцу");
                Console.WriteLine("5. Уйти");

                userInput = Console.ReadLine();

                if(Int32.TryParse(userInput, out int userChoise))
                {
                    switch (userChoise)
                    {
                        case 1:
                            seller.ShowInventory();
                            break;
                        case 2:
                            ShowInventory();
                            break;
                        case 3:
                            BuyItem(seller);
                            break;
                        case 4:
                            seller.CreateSellingItems();
                            break;
                        case 5:
                            isPlaying = false;
                            break;
                        default:

                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Не верный формат ввода!");
                }

                Console.ReadLine();
            }
        }

        public void BuyItem(Seller seller)
        {
            Console.Clear();
            ShowStats();
            seller.ShowInventory();
            Console.Write("Выберите предмет который хотите купить: ");
            if (Int32.TryParse(Console.ReadLine(), out int userChoise))
            {
                if (userChoise <= seller.Inventory.Count + 1)
                {
                    if (seller.Inventory[userChoise].Cost <= Money)
                    {
                        Money -= seller.Inventory[userChoise].Cost;
                        seller.SellItem(userChoise);
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Не верный формат ввода!");
            }
        }

        private void ShowStats()
        {
            Console.WriteLine($"Имя игрока: {Name} | Кошелёк игрока: {Money}\n");
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
            if (buyingItemID < Inventory.Count)
            {
                Item sellingItem = Inventory[buyingItemID];
                Inventory.RemoveAt(buyingItemID);
                Money += sellingItem.Cost;
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

        public void CreateSellingItems()
        {
            bool isPlaying = true;

            while (isPlaying)
            {
                ConsoleKeyInfo userInput;

                Console.Clear();
                Console.WriteLine("Нажмите пробел, что бы добавить новый предмет в инветарь");
                Console.WriteLine("Нажмите Esc что бы выйти из режима добавления предметов продавцу\n");

                userInput = Console.ReadKey();

                switch (userInput.Key)
                {
                    case ConsoleKey.Spacebar:
                        AddItem();
                        break;
                    case ConsoleKey.Escape:
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }
            }
        }

        private void AddItem()
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
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"Имя продавца: {Name} | Кошелёк продавца: {Money}\n");
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
