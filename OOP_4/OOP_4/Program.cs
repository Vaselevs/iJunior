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

            player.CardGame();
            player.ShowPlayersHand();
        }
    }

    class Player
    {
        private List<Card> _hand = new List<Card>();

        public Player()
        {

        }

        public void CardGame()
        {
            Deck deck = new Deck();

            bool needCard = true;

            while (needCard)
            {
                if(deck.GetCountOfCards() > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Что бы вытянуть карту, нажмите Space");
                    Console.WriteLine("Что бы вытянуть больше одной карты, нажмите Enter");
                    Console.WriteLine("Что бы выйти, нажмите Esc");
                    Console.WriteLine($"На данный момент в руке игрока {_hand.Count} карт");

                    ConsoleKeyInfo userInputKey = Console.ReadKey();

                    if (userInputKey.Key == ConsoleKey.Spacebar)
                    {
                        _hand.Add(deck.GetRandomCardFromDeck());
                    }
                    else if (userInputKey.Key == ConsoleKey.Escape)
                    {
                        needCard = false;
                    }
                    else if (userInputKey.Key == ConsoleKey.Enter)
                    {
                        TakeOneCard(deck);
                    } 
                    else
                    {
                        Console.WriteLine("Не верная кнопка");
                        Console.ReadLine();
                    }
                } 
                else
                {
                    needCard = false;
                    Console.WriteLine("В колоде закончились карты!");
                }
            }
        }

        public void ShowPlayersHand()
        {
            Console.WriteLine($"У вас в руках: {_hand.Count}");

            foreach (Card card in _hand)
            {
                card.ShowCard();
            }
        }

        private void TakeOneCard(Deck deck)
        {
            string userInput;
            Console.Clear();
            Console.Write("Введите количество карт: ");
            userInput = Console.ReadLine();
            if (Int32.TryParse(userInput, out int countOfCards))
            {
                if (countOfCards < deck.GetCountOfCards())
                {
                    for (int i = 0; i < countOfCards; i++)
                    {
                        _hand.Add(deck.GetRandomCardFromDeck());
                    }
                }
                else
                {
                    Console.WriteLine("В колоде нет столько карт!");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число!");
                Console.ReadLine();
            }
        }
    }

    class Deck
    {
        private List<Card> _deck;

        private string[] _suits;
        private string[] _nominals;

        public Deck()
        {
            _suits = new string[] { "Diamonds", "Hearts", "Clubs", "Spades" };
            _nominals = new string[] { "Ace", "Jack", "Queen", "King", "10", "9", "8", "7", "6", "5", "4", "3", "2", "1" };
            _deck = new List<Card>();
            _deck = CreateDeck();
        }

        public int GetCountOfCards()
        {
            return _deck.Count;
        }

        public void ShowDeck()
        {
            foreach (Card card in _deck)
            {
                card.ShowCard();
            }
        }

        public Card GetRandomCardFromDeck()
        {
            Random random = new Random();
            int randomCard = random.Next(0, _deck.Count);
            Card removedCard = _deck[randomCard];
            _deck.RemoveAt(randomCard);
            return removedCard;
        }

        private List<Card> CreateDeck()
        {
            foreach(string suit in _suits)
            {
                foreach(string nominal in _nominals)
                {
                    Card card = new Card(suit, nominal);
                    _deck.Add(card);
                }
            }
            return _deck;
        }
    }

    class Card
    {
        private string _suit;
        private string _nominal;

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
            _suit = suit;
        }

        private void SetNominal(string nominal)
        {
            _nominal = nominal;
        }
    }
}
