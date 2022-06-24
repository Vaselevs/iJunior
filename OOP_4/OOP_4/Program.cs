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
            Colode colode = new Colode();

            colode.ShowColode();

            Console.WriteLine();

            Queue<Card> queue = colode.NewRandomColode();
            
            colode.ShowColode(queue);
            
        }
    }

    class Player
    { 
        private List<Card> _playerHand;

        public void GetCards(Queue<Card> colode)
        {
            bool gettingCard = true;

            while (gettingCard)
            {
                string userInput;
                Console.Clear();
                Console.WriteLine("Что бы вытянуть карту, нажмите Enter или введите количество карт.");
                Console.WriteLine("Что бы выйти, нажмите Esc");
                Console.WriteLine($"На данный момент в руке игрока {_playerHand.Count} карт");

                userInput = Console.ReadLine();

                if (Int32.TryParse(userInput, out int userChoise) && userChoise <= colode.Count)
                {
                    for(int i = 0; i < userChoise; i++)
                    {
                        _playerHand.Add(colode.Dequeue());
                    }
                }
                else
                {
                    
                }
            }

            
        }

        public void ShowPlayersHand()
        {
            foreach (Card card in _playerHand)
            {
                card.ShowCard();
            }
        }
    }

    class Colode
    {
        private List<Card> _colode = new List<Card>();
        string[] suits = { "Diamonds", "Hearts", "Clubs", "Spades" };
        string[] nominals = { "Ace", "Jack", "Queen", "King", "10", "9", "8", "7", "6", "5", "4", "3", "2", "1" };

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
        public void ShowColode(Queue<Card> colode)
        {
            foreach (Card card in colode)
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
            string[] suits = { "Diamonds", "Hearts", "Clubs", "Spades", };
            if (suits.Contains(suit))
            {
                _suit = suit;
            }
        }

        private void SetNominal(string nominal)
        {
            string[] nominals = { "Ace", "Jack", "Queen", "King", "10", "9", "8", "7", "6", "5", "4", "3", "2", "1"};
            if (nominals.Contains(nominal))
            {
                _nominal = nominal;
            }
        }
    }
}
