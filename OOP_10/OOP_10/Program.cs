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
        private Platoon _greenArmy;
        private Platoon _blueArmy;

        public Game()
        {
            int greenArmyCount = 10;
            int blueArmyCount = 10;

            _greenArmy = new Platoon(greenArmyCount, "РИМ");
            _blueArmy = new Platoon(blueArmyCount, "ЭФИОПИЯ");
        }

        public void Play()
        {
            Console.WriteLine("Добро пожаловать на тестовый полигон!");
            Console.WriteLine("Состав армий:");
            Console.WriteLine("Армия зелёных:");

            _greenArmy.ShowInfo();

            Console.WriteLine();
            Console.WriteLine("Армия синих:");

            _blueArmy.ShowInfo();

            Battle(_greenArmy, _blueArmy);

            AnnounceWinner(_greenArmy, _blueArmy);
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
                        DoAttack(armyOne, armyTwo, i);
                    }

                    if (i < armyTwo.GetNumberOfSoldiers())
                    {
                        DoAttack(armyTwo, armyOne, i);
                    }
                }
            }

            void DoAttack(Platoon attackingArmy, Platoon defendingArmy, int attackingSoldierId)
            {
                int damage = attackingArmy.GetSoldierAttackPower(attackingSoldierId);

                if (defendingArmy.GetNumberOfSoldiers() > 0)
                {
                    defendingArmy.TakeDamage(attackingArmy.GetSoldierAttackPower(attackingSoldierId));
                    Console.WriteLine($"{attackingArmy.GetSoldierClassName(attackingSoldierId)} из {attackingArmy.ArmyName} нанёс {damage} урона");
                }
            }
        }

        private void AnnounceWinner(Platoon armyOne, Platoon armyTwo)
        {
            if (armyOne.GetNumberOfSoldiers() > 0)
            {
                Console.WriteLine($"{armyOne.ArmyName} победил!");
            }
            else if (armyTwo.GetNumberOfSoldiers() > 0)
            {
                Console.WriteLine($"{armyTwo.ArmyName} победила!");
            }
            else
            {
                Console.WriteLine("Обе армии пали в равном бою!");
            }
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers;
        private Random _random;
        public string ArmyName { get; private set; }

        public Platoon(int numberOfSoldiers, string armyName)
        {
            _soldiers = new List<Soldier>();
            _random = new Random();
            CreatePlatoon(numberOfSoldiers);
            ArmyName = armyName;
        }

        public int GetNumberOfSoldiers() => _soldiers.Count;

        public int GetSoldierAttackPower(int soldierId) => _soldiers[soldierId].GetAttackPower();

        public string GetSoldierClassName(int soldierId) => _soldiers[soldierId].GetSoldierClassName();

        public void SetDamageToSoldier(int soldierId, int damage) => _soldiers[soldierId].GetDamage(damage);

        public void ShowInfo()
        {
            foreach(Soldier soldier in _soldiers)
            {
                soldier.ShowInfo();
            }
        }

        public void TakeDamage(int damage)
        {
            int randomSoldier = _random.Next(_soldiers.Count);
            _soldiers[randomSoldier].GetDamage(damage);
            TryToKillSoldier(randomSoldier);
        }

        private void TryToKillSoldier(int soldierId)
        {
            if (_soldiers[soldierId].IsDead())
            {
                _soldiers.RemoveAt(soldierId);
            }
        }

        private void CreatePlatoon(int numberOfSoldiers)
        {
            Soldier[] soldiers = new Soldier[] {new SoldierWithRevolver(200, 15), new SoldierWithAssaultRifle(300, 40), new SoldierWithMinigun(100, 5)};

            for (int i = 0; i < numberOfSoldiers; i++)
            {
                _soldiers.Add(soldiers[_random.Next(soldiers.Length)]);
                System.Threading.Thread.Sleep(50);
            }
        }
    }

    abstract class Soldier
    {
        protected int NumberOfAttack;
        protected int Health;
        protected int AttackPower;
        protected int AmmoInMagazin;
        protected string ClassName;

        public Soldier(int health, int attack)
        {
            Health = health;
            AttackPower = attack;
            NumberOfAttack = 0;
        }

        public abstract int GetAttackPower();

        public void GetDamage(int damage) => Health -= damage;

        public string GetSoldierClassName() => ClassName;

        public bool IsDead() => Health <= 0;

        public void ShowInfo()
        {
            Console.WriteLine($"{ClassName} - {Health} HP - {AttackPower} ATK");
        }
    }

    class SoldierWithRevolver : Soldier
    {
        public SoldierWithRevolver(int health, int attack) : base(health, attack)
        {
            AmmoInMagazin = 6;
            ClassName = "Солдат с Револьвером";
        }

        public override int GetAttackPower()
        {
            if(NumberOfAttack < AmmoInMagazin)
            {
                NumberOfAttack++;
                return AttackPower;
            }
            else
            {
                NumberOfAttack = 0;
                return AttackPower - AttackPower;
            }
        }
    }

    class SoldierWithAssaultRifle : Soldier
    {
        public SoldierWithAssaultRifle(int health, int attack) : base(health, attack)
        {
            AmmoInMagazin = 1;
            ClassName = "Солдат с Винтовкой";
        }

        public override int GetAttackPower()
        {
            if (NumberOfAttack < AmmoInMagazin)
            {
                NumberOfAttack++;
                return AttackPower;
            }
            else
            {
                NumberOfAttack = 0;
                return AttackPower - AttackPower;
            }
        }
    }

    class SoldierWithMinigun : Soldier
    {
        private int _numberOfBulletByAttack = 5;

        public SoldierWithMinigun(int health, int attack) : base(health, attack)
        {
            AmmoInMagazin = 100;
            ClassName = "Солдат с Миниганом";
        }

        public override int GetAttackPower()
        {
            if (NumberOfAttack < AmmoInMagazin)
            {
                int totalAttack = 0;

                for(int i = 0; i < _numberOfBulletByAttack; i++)
                {
                    NumberOfAttack++;
                    totalAttack += AttackPower;
                }
                
                return totalAttack;
            }
            else
            {
                NumberOfAttack = 0;
                return AttackPower - AttackPower;
            }
        }
    }
}
