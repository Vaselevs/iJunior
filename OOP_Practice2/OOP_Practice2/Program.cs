using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerClub computerClub = new ComputerClub(7);

            computerClub.Work();


        }
    }

    class ComputerClub
    {

        private int _money = 0;
        private List<Computer> _computers = new List<Computer>();
        private Queue<Schoolboy> _schoolboys = new Queue<Schoolboy>();

        public ComputerClub(int computerCount)
        {
            Random random = new Random();

            for(int i = 0; i < computerCount; i++)
            {
                _computers.Add(new Computer(random.Next(2, 20)));
            }

            CreateNewSchoolboys(50);
        }

        private void CreateNewSchoolboys(int count)
        {
            Random random = new Random();

            for(int i = 0; i < count; i++)
            {
                _schoolboys.Enqueue(new Schoolboy(random.Next(100, 250), random));
            }
        }

        public void Work()
        {
            while (_schoolboys.Count > 0)
            {
                Console.Clear();
                Console.WriteLine($"У компьютерного клуба сейчас {_money} рублей, ждём нового клиента");

                Schoolboy schoolboy = _schoolboys.Dequeue();
                Console.WriteLine($"В очереде школьник, он хочет купить {schoolboy.DesiredMinutes} минут");
                Console.WriteLine("\nСписок компьютеров:");
                ShowAllComputers();

                Console.Write("\nВыберите какой компьютер ему дать: ");
                int computerCount = int.Parse(Console.ReadLine()) - 1;

                if(computerCount >= 0 && computerCount < _computers.Count)
                {
                    if (_computers[computerCount].IsBusy)
                    {
                        Console.WriteLine("Вы предложили занятый компьютер, клиент ушел");
                    }
                    else
                    {
                        if (schoolboy.CheckSolvensy(_computers[computerCount]))
                        {
                            Console.WriteLine("Денег хватает, школьник занял компьютер");
                            _money += schoolboy.ToPay();
                            _computers[computerCount].TakeThePlace(schoolboy);
                        } else
                        {
                            Console.WriteLine("Денег у него нет, он уходит");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Вы не смогли выбрать компьютер, клиент ушел...");
                }

                Console.WriteLine("Что бы пригласить нового клиента, нажмите любую клавишу");
                Console.ReadLine();
                SkipMinute();
            }
        }

        private void SkipMinute()
        {
            foreach(var computer in _computers)
            {
                computer.SkipMinute();
            }
        }

        private void ShowAllComputers()
        {
            for(int i = 0; i < _computers.Count; i++)
            {
                Console.Write($"{i+1}. ");
                _computers[i].ShowInfo();
            }
        }
    }

    class Computer
    {
        private Schoolboy _schoolboy;
        private int _minutesleft;

        public int PriceForMinutes { get; private set; }
        public bool IsBusy
        {
            get 
            { 
                return _minutesleft > 0; 
            }
        }

        public Computer(int priceForMinutes)
        {
            PriceForMinutes = priceForMinutes;
        }

        public void TakeThePlace(Schoolboy schoolboy)
        {
            _schoolboy = schoolboy;
            _minutesleft = _schoolboy.DesiredMinutes;
        }

        public void FreeThePlace()
        {
            _schoolboy = null;
        }

        public void SkipMinute()
        {
            _minutesleft--;
        }

        public void ShowInfo()
        {
            if (IsBusy)
                Console.WriteLine($"Компьютер занят. Осталось минут - {_minutesleft}");
            else
                Console.WriteLine($"Компьютер свободен. Цена за минут - {PriceForMinutes}");
        }
    }

    class Schoolboy
    {
        private int _money;
        int _moneyToPay;
        
        public int DesiredMinutes { get; private set; }

        public Schoolboy(int money, Random random)
        {
            DesiredMinutes = random.Next(10, 30);
            _money = money;
            
        }

        public bool CheckSolvensy(Computer computer)
        {
            _moneyToPay = computer.PriceForMinutes * DesiredMinutes;
            if(_money >= _moneyToPay)
            {
                return true;
            }
            else
            {
                _moneyToPay = 0;
                return false;
            }
        }

        public int ToPay()
        {
            _money -= _moneyToPay;
            return _moneyToPay;
        }
    }
}
