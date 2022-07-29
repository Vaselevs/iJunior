using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Play();
        }
    }

    class Game
    {
        private int _greenArmyCount = 10;
        private int _blueArmyCount = 10;
        private Platoon _greenArmy;
        private Platoon _blueArmy;
        private Random _random;

        public Game()
        {
            _greenArmy = new Platoon(_greenArmyCount);
            _blueArmy = new Platoon(_blueArmyCount);
            _random = new Random();
        }

        public void Play()
        {
            Console.WriteLine("Добро пожаловать на тестовый полигон!");
            Console.WriteLine("Состав армий:");
            Console.WriteLine("Армия зелёных:");

            _greenArmy.ShowPlatoonInfo();

            Console.WriteLine();
            Console.WriteLine("Армия синих:");

            _blueArmy.ShowPlatoonInfo();

            Battle(_greenArmy, _blueArmy);

            if(_greenArmy.GetNumberOfSoldiers() > 0)
            {
                Console.WriteLine("Первая армия победила!");
            }
            else if(_blueArmy.GetNumberOfSoldiers() > 0)
            {
                Console.WriteLine("Вторая армия победила!");
            } 
            else
            {
                Console.WriteLine("Обе армии пали в равном бою!");
            }
        }

        private void Battle(Platoon armyOne, Platoon armyTwo)
        {
            while(armyOne.GetNumberOfSoldiers() > 0 && armyTwo.GetNumberOfSoldiers() > 0)
            {
                int maxNumberOfSoldiers;

                if(armyOne.GetNumberOfSoldiers() >= armyTwo.GetNumberOfSoldiers())
                {
                    maxNumberOfSoldiers = armyOne.GetNumberOfSoldiers();
                } 
                else
                {
                    maxNumberOfSoldiers = armyTwo.GetNumberOfSoldiers();
                }

                for(int i = 0; i < maxNumberOfSoldiers; i++)
                {
                    if (i < armyOne.GetNumberOfSoldiers())
                    {
                        int damage = armyOne.GetSoldierAttackPower(i);

                        if (armyTwo.GetNumberOfSoldiers() > 0)
                        {
                            int randomEnemySoldier = _random.Next(armyTwo.GetNumberOfSoldiers());
                            armyTwo.SetDamageToSoldier(randomEnemySoldier, damage);
                            Console.WriteLine($"{armyOne.GetSoldierClassName(i)} из АРМИИ 1 нанёс {damage} урона {armyTwo.GetSoldierClassName(randomEnemySoldier)} из АРМИИ 2");
                            armyTwo.TryToKillSoldier(randomEnemySoldier);
                        }
                    }

                    if (i < armyTwo.GetNumberOfSoldiers())
                    {
                        int damage = armyTwo.GetSoldierAttackPower(i);

                        if(armyOne.GetNumberOfSoldiers() > 0)
                        {
                            int randomEnemySoldier = _random.Next(armyOne.GetNumberOfSoldiers());
                            armyOne.SetDamageToSoldier(randomEnemySoldier, damage);
                            Console.WriteLine($"{armyTwo.GetSoldierClassName(i)} из АРМИИ 2 нанёс {damage} урона {armyOne.GetSoldierClassName(randomEnemySoldier)} из АРМИИ 1");
                            armyOne.TryToKillSoldier(randomEnemySoldier);
                        }
                    }
                }
            }
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers;
        private Random _random;
        private int _minRandomNumber;
        private int _countOfSoldierClasses;

        public Platoon(int numberOfSoldiers)
        {
            _soldiers = new List<Soldier>();
            _minRandomNumber = 0;
            _countOfSoldierClasses = 3;
            _random = new Random();
            CreatePlatoon(numberOfSoldiers);
        }

        private void CreatePlatoon(int numberOfSoldiers)
        {
            for(int i = 0; i < numberOfSoldiers; i++)
            {
                switch(_random.Next(_minRandomNumber, _countOfSoldierClasses))
                {
                    case 0:
                        _soldiers.Add(new SoldierWithRevolver(200, 15));
                        break;
                    case 1:
                        _soldiers.Add(new SoldierWithAssaultRifle(300, 40));
                        break;
                    case 2:
                        _soldiers.Add(new SoldierWithMinigun(100, 5));
                        break;
                }

                System.Threading.Thread.Sleep(50);
            }
        }

        public int GetNumberOfSoldiers() => _soldiers.Count;

        public string GetSoldierClassName(int soldierId) => _soldiers[soldierId].GetSoldierClassName();

        public int GetSoldierAttackPower(int soldierId) => _soldiers[soldierId].Attack();

        public void SetDamageToSoldier(int soldierId, int damage) => _soldiers[soldierId].GetDamage(damage);

        public void ShowPlatoonInfo()
        {
            foreach(Soldier soldier in _soldiers)
            {
                soldier.ShowSoldierInfo();
            }
        }

        public void TryToKillSoldier(int soldierId)
        {
            if (_soldiers[soldierId].IsDead())
            {
                _soldiers.RemoveAt(soldierId);
            }
        }
    }

    abstract class Soldier
    {
        protected int _numberOfAttack;
        protected int _health;
        protected int _attack;
        protected int _ammoInMagazin;
        protected string _className;

        public Soldier(int health, int attack)
        {
            _health = health;
            _attack = attack;
            _numberOfAttack = 0;
        }

        abstract public int Attack();

        public void GetDamage(int damage) => _health -= damage;

        public string GetSoldierClassName() => _className;

        public bool IsDead()
        {
            if(_health <= 0)
                return true;
            else
                return false;
        }

        public void ShowSoldierInfo()
        {
            Console.WriteLine($"{_className} - {_health} HP - {_attack} ATK");
        }
    }

    class SoldierWithRevolver : Soldier
    {
        public SoldierWithRevolver(int health, int attack) : base(health, attack)
        {
            _ammoInMagazin = 6;
            _className = "Солдат с Револьвером";
        }
        
        override public int Attack()
        {
            if(_numberOfAttack < _ammoInMagazin)
            {
                _numberOfAttack++;
                return _attack;
            }
            else
            {
                _numberOfAttack = 0;
                return _attack - _attack;
            }
        }
    }

    class SoldierWithAssaultRifle : Soldier
    {
        public SoldierWithAssaultRifle(int health, int attack) : base(health, attack)
        {
            _ammoInMagazin = 1;
            _className = "Солдат с Винтовкой";
        }

        override public int Attack()
        {
            if (_numberOfAttack < _ammoInMagazin)
            {
                _numberOfAttack++;
                return _attack;
            }
            else
            {
                _numberOfAttack = 0;
                return _attack - _attack;
            }
        }
    }

    class SoldierWithMinigun : Soldier
    {
        private int _numberOfBulletByAttack = 5;

        public SoldierWithMinigun(int health, int attack) : base(health, attack)
        {
            _ammoInMagazin = 100;
            _className = "Солдат с Миниганом";
        }

        override public int Attack()
        {
            if (_numberOfAttack < _ammoInMagazin)
            {
                int totalAttack = 0;

                for(int i = 0; i < _numberOfBulletByAttack; i++)
                {
                    _numberOfAttack++;
                    totalAttack += _attack;
                }
                
                return totalAttack;
            }
            else
            {
                _numberOfAttack = 0;
                return _attack - _attack;
            }
        }
    }
}
