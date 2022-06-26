using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            player.GetCards();
            player.ShowPlayersHand();
        }
    }

    class Player
    {
        private List<Card> _playerHand = new List<Card>();

        public void GetCards()
        {
            Colode colode = new Colode();
            Queue<Card> randomColode = colode.NewRandomColode();

            bool gettingCard = true;

            while (gettingCard)
            {
                if(randomColode.Count > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Что бы вытянуть карту, нажмите Space");
                    Console.WriteLine("Что бы вытянуть больше одной карты, нажмите Enter");
                    Console.WriteLine("Что бы выйти, нажмите Esc");
                    Console.WriteLine($"На данный момент в руке игрока {_playerHand.Count} карт");

                    ConsoleKeyInfo userInputKey = Console.ReadKey();

                    if (userInputKey.Key == ConsoleKey.Spacebar)
                    {
                        _playerHand.Add(randomColode.Dequeue());
                    }
                    else if (userInputKey.Key == ConsoleKey.Escape)
                    {
                        gettingCard = false;
                    }
                    else if (userInputKey.Key == ConsoleKey.Enter)
                    {
                        string userInput;
                        Console.Clear();
                        Console.Write("Введите количество карт: ");
                        userInput = Console.ReadLine();
                        if (Int32.TryParse(userInput, out int countOfCards))
                        {
                            if(countOfCards < randomColode.Count)
                            {
                                for(int i = 0; i < countOfCards; i++)
                                {
                                    _playerHand.Add(randomColode.Dequeue());
                                }
                            } else
                            {
                                Console.WriteLine("В колоде нет столько карт!");
                                Console.ReadLine();
                            }
                        } else
                        {
                            Console.WriteLine("Вы ввели не число!");
                            Console.ReadLine();
                        } 
                    } else
                    {
                        Console.WriteLine("Не верная кнопка");
                        Console.ReadLine();
                    }
                } else
                {
                    gettingCard = false;
                    Console.WriteLine("В колоде закончились карты!");
                }
            }
        }

        public void ShowPlayersHand()
        {
            Console.WriteLine($"У вас в руках: {_playerHand.Count}");

            foreach (Card card in _playerHand)
            {
                card.ShowCard();
            }
        }
    }

    class Colode
    {
        private List<Card> _colode = new List<Card>();
        private string[] suits = { "Diamonds", "Hearts", "Clubs", "Spades" };
        private string[] nominals = { "Ace", "Jack", "Queen", "King", "10", "9", "8", "7", "6", "5", "4", "3", "2", "1" };

        public Colode()
        {
            _colode = NewStandartColode();
        }

        public void ShowColode()
        {
            foreach (Card card in _colode)
            {
                card.ShowCard();
            }
        }

        public Queue<Card> NewRandomColode()
        {
            Random random = new Random();
            List<Card> colode = NewStandartColode();
            Queue<Card> queue = new Queue<Card>();

            for (int i = 0; i < colode.Count; i++)
            {
                int randomNumberOfCard = random.Next(0, colode.Count);
                queue.Enqueue(colode[randomNumberOfCard]);
                colode.RemoveAt(randomNumberOfCard);
            }

            return queue;
        }

        private List<Card> NewStandartColode()
        {
            foreach(string suit in suits)
            {
                foreach(string nominal in nominals)
                {
                    Card card = new Card(suit, nominal);
                    _colode.Add(card);
                }
            }
            return _colode;
        }
    }

    class Card
    {
        private string _suit;
        private string _nominal;
        private string[] _suits = { "Diamonds", "Hearts", "Clubs", "Spades" };
        private string[] _nominals = { "Ace", "Jack", "Queen", "King", "10", "9", "8", "7", "6", "5", "4", "3", "2", "1" };

        public Card(string suit, string nominal)
        {
            SetNominal(nominal);
            SetSuit(suit);
        }

        public void ShowCard()
        {
            Console.WriteLine(_suit + " " + _nominal);
        }

        private void SetSuit(string suit)
        {
            if (_suits.Contains(suit))
            {
                _suit = suit;
            }
        }

        private void SetNominal(string nominal)
        {
            if (_nominals.Contains(nominal))
            {
                _nominal = nominal;
            }
        }
    }
}
