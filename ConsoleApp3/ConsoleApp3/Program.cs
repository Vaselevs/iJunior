using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class ComputerClub
    {
        private List<Computer> _computers = new List<Computer>();
        private Queue<Schoolboy> _schoolboys = new Queue<Schoolboy>();
    }

    class Computer
    {
        private Schoolboy _schoolboy;
        private int _minutesLeft;

        public int PriceForMinutes { get; private set; }

        public bool IsBusy
        {
            get
            {
                return _minutesLeft > 0;
            }
        }

        public Computer(int priceForMinutes)
        {
            PriceForMinutes = priceForMinutes;
        }

        public void TakeThePlace(Schoolboy schoolboy)
        {
            _schoolboy = schoolboy;
            _minutesLeft = _schoolboy.DesiredMinutes;
        }

        public void FreeThePlace()
        {
            _schoolboy = null;
        }

        public void SkipMinute()
        {
            _minutesLeft--;
        }

        public void ShowInfo()
        {
            if (IsBusy)
                Console.WriteLine($"Компьютер занят. Осталось минут - {_minutesLeft}");
            else
                Console.WriteLine($"Компьютер свободен. Цена за минуту - {PriceForMinutes}")
        }
    }

    class Schoolboy
    {
        private int _money;

        public int DesiredMinutes { get; private set; }

        public Schoolboy (int money)
        {
            Random rand = new Random();
            _money = money;
            DesiredMinutes = rand.Next(10, 30);
        }
    }


}
