using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPLaying = true;
            BaseOfPLayers newBaseOfPLayers = new BaseOfPLayers();

            while (isPLaying)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в панель информаиции и управления игроками.");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Добавить нового игрока");
                Console.WriteLine("2. Посмотреть список всех игроков");
                Console.WriteLine("3. Забанить игрока по номеру");
                Console.WriteLine("4. Разбанить игрока по номеру");
                Console.WriteLine("5. Удалить игрока по номеру");
                Console.WriteLine("6. Выйти из программы");

                if (int.TryParse(Console.ReadLine(), out int playerChoise))
                {
                    Console.Clear();
                    switch (playerChoise)
                    {
                        case 1:
                            newBaseOfPLayers.AddPlayer();
                            break;
                        case 2:
                            newBaseOfPLayers.ShowAllPlayers();
                            break;
                        case 3:
                            newBaseOfPLayers.BanTargetPlayer();
                            break;
                        case 4:
                            newBaseOfPLayers.UnBanTargetPlayer();
                            break;
                        case 5:
                            newBaseOfPLayers.DeletePlayer();
                            break;
                        case 6:
                            isPLaying = false;
                            break;
                        default:
                            Console.WriteLine("Вы ввели не существующий пункт меню!");
                            break;
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Некоректный ввод!");
                }
            }

            Console.WriteLine("Спасибо за использование нашей программы, до свидания!");
        }
    }

    class BaseOfPLayers
    {
        private List<Player> _dataBase;

        public BaseOfPLayers()
        {
            _dataBase = new List<Player>();
        }

        public void AddPlayer()
        {
            bool isNotCorrectInput = true;
            string playerName;

            while (isNotCorrectInput)
            {
                Console.Clear();
                Console.Write("Введите имя нового игрока: ");
                playerName = Console.ReadLine();
                Console.Write("Введите уровень нового игрока: ");
                if(Int32.TryParse(Console.ReadLine(), out int playerLevel))
                {
                    Console.Write("Если игрок забанен, введите true. Если нет, введите false: ");
                    if(Boolean.TryParse(Console.ReadLine(), out bool playerBanStatus))
                    {
                        Console.WriteLine("Данные введены корректно, заношу в базу...");
                        _dataBase.Add(new Player(playerName, playerLevel, playerBanStatus));
                        isNotCorrectInput = false;
                    } else
                    {
                        Console.WriteLine("Вы ошиблись в формате ввода. Повторите ввод.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Вы ошиблись в формате ввода. Повторите ввод.");
                    Console.ReadLine();
                }
            }
        }

        public void BanTargetPlayer()
        {
            Console.WriteLine("Введите номер игрока, которого решили забанить:\n");

            ShowAllPlayers();

            Console.SetCursorPosition(0, 1);

            if(Int32.TryParse(Console.ReadLine(), out int playerNumber))
            {
                if (_dataBase.FindIndex(x => x.Id == playerNumber) != -1)
                {
                    _dataBase.Find(x => x.Id == playerNumber).Ban();
                    Console.WriteLine($"Игрок {_dataBase.Find(x => x.Id == playerNumber).Name} успешно забанен!");
                }
                else
                {
                    Console.WriteLine("Нет игрока с таким номером!");
                }
            }
            else
            {
                Console.WriteLine("Не верно введён номер игрока, не удалось забанить игрока.");
            }
        }

        public void UnBanTargetPlayer()
        {
            Console.WriteLine("Введите номер игрока, которого решили разбанить:\n");

            ShowAllPlayers();

            Console.SetCursorPosition(0, 1);

            if (Int32.TryParse(Console.ReadLine(), out int playerNumber))
            {
                if(_dataBase.FindIndex(x => x.Id == playerNumber) != -1)
                {
                    _dataBase.Find(x => x.Id == playerNumber).UnBan();
                    Console.WriteLine($"Игрок {_dataBase.Find(x => x.Id == playerNumber).Name} успешно разбанен!");
                }
                else
                {
                    Console.WriteLine("Нет игрока с таким номером!");
                }
                    
            }
            else
            {
                Console.WriteLine("Не верно введён номер игрока, не удалось разбанить игрока.");
            }
        }

        public void DeletePlayer()
        {
            Console.WriteLine("Введите номер игрока, которого решили удалить:\n");

            ShowAllPlayers();

            Console.SetCursorPosition(0, 1);

            if (Int32.TryParse(Console.ReadLine(), out int playerNumber))
            {
                if(_dataBase.FindIndex(x => x.Id == playerNumber) != -1)
                {
                    _dataBase.RemoveAt(_dataBase.FindIndex(x => x.Id == playerNumber));
                    Console.WriteLine("Игрок успешно удалён!");
                }
                else
                {
                    Console.WriteLine("Нет игрока с таким номером!");
                }
            }
            else
            {
                Console.WriteLine("Не верно введён номер игрока, не получилось удалить игрока.");
            }
        }

        public void ShowAllPlayers()
        {
            foreach(Player player in _dataBase)
            {
                player.ShowInfo();
            }
        }
    }

    class Player
    {
        public static int Ids = 0;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(string name, int level, bool isBanned)
        {
            Id = ++Ids;
            Name = name;
            Level = level;
            IsBanned = isBanned;
        }

        public void ShowInfo()
        {
            Console.Write($"Уникальный номер - {Id}, Имя - {Name}, Уровень - {Level}, Статус бана - {IsBanned}");
        }

        public bool Ban()
        {
            if (this.IsBanned == false)
            {
                this.IsBanned = true;
                return true;
            }
            else
            {
                Console.WriteLine("Игрок уже находится в бане!");
                return false;
            }
        }

        public bool UnBan()
        {
            if (this.IsBanned == true)
            {
                this.IsBanned = false;
                return true;
            }
            else
            {
                Console.WriteLine("Игрок не был в бане.");
                return false;
            }
        }
    }
}
