using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Play();
        }
    }

    public class Game
    {
        private FigtherFabric _fighterFabric; 

        public Game()
        {
            _fighterFabric = new FigtherFabric();
        }

        public void Play()
        {
            bool isPlaying = true;
            Human fighterOne;
            Human fighterTwo;

            while (isPlaying)
            {
                fighterOne = ChooseFighter(1);

                if (fighterOne != null)
                {
                    fighterTwo = ChooseFighter(2);
                    if (fighterTwo != null)
                    {
                        if (fighterOne != fighterTwo)
                        {
                            Fight(fighterOne, fighterTwo);
                            PraiseWinner(fighterOne, fighterTwo);
                        }

                        Console.ReadLine();
                    }
                    else
                    {
                        isPlaying = false;
                    }
                } 
                else
                {
                    isPlaying = false;
                }
            }
        }

        private void Fight(Human fighter, Human enemy)
        {
            while(fighter.Health > 0 && enemy.Health > 0)
            {
                fighter.Attack(enemy);
                Console.WriteLine($"У {enemy.Name} осталось {enemy.Health}");
                enemy.Attack(fighter);
                Console.WriteLine($"У {fighter.Name} осталось {fighter.Health}");
            }
        }

        private Human ChooseFighter(int fighterPosition)
        {
            Human[] fighters = new Human[5] {_fighterFabric.CrateWarrior(4000, 350, 30, "Андрей"), _fighterFabric.CreateWizard(2500, 300, 20, 200, "Анатолий"), _fighterFabric.CreatePeasant(2000, 100, 15, 70, "Сашка"), _fighterFabric.CreateKnight(5000, 250, 40, "Коля"), _fighterFabric.CreateZombie(1000, 50, 5, "Шон")};

            Console.WriteLine($"Выберите бойца номер {fighterPosition}!");
            Console.WriteLine();

            int positionInArray = 0;

            foreach(Human fighter in fighters)
            {
                positionInArray++;
                Console.WriteLine($"{positionInArray}. {fighter.СlassName}");
            }

            Console.WriteLine();
            Console.WriteLine("6. Выход");

            if(Int32.TryParse(Console.ReadLine(), out int userInput))
            {
                if (userInput >= 1 && userInput <= fighters.Length)
                {
                    return fighters[userInput-1];
                }
            }

            return null;
        }

        private void PraiseWinner(Human fighter, Human enemy)
        {
            if (fighter.Health > enemy.Health)
            {
                Console.WriteLine($"{fighter.Name} выигрывает в битве, ура!");
            }
            else if (fighter.Health < enemy.Health)
            {
                Console.WriteLine($"{enemy.Name} выигрывает в битве, ура!");
            } 
            else
            {
                Console.WriteLine("Ничья!");
            }
        }
    }

    public class FigtherFabric
    {
        public FigtherFabric()
        {

        }

        public Warrior CrateWarrior(int health, int attack, double armor, string name)
        {
            return new Warrior(health, attack, armor, name);
        }

        public Wizard CreateWizard(int health, int attack, double armor, int magicPower, string name)
        {
            return new Wizard(health, attack, armor, magicPower, name);
        }

        public Peasant CreatePeasant(int health, int attack, double armor, int peasantCornfieldsWrath, string name)
        {
            return new Peasant(health, attack, armor, peasantCornfieldsWrath, name);
        }

        public Knight CreateKnight(int health, int attack, double armor, string name)
        {
            return new Knight(health, attack, armor, name);
        }

        public Zombie CreateZombie(int health, int attack, double armor, string name)
        {
            return new Zombie(health, attack, armor, name);
        }
    }

    public abstract class Human
    {
        protected int _attackNumber = 0;
        private Random _random;
        private int _minRandom = 1;
        private int _maxRandom = 10;
        
        public string СlassName { get; protected set; }
        public string Name { get; private set; }
        public int Health { get; protected set; }
        public int Damage { get; private set; }
        public double ArmorPercent { get; protected set; }

        public Human(int health, int attack, double armor, string name)
        {
            _random = new Random();
            Health = health + GenerateRandomGain();
            Damage = attack + GenerateRandomGain();
            ArmorPercent = CalculateArmor(armor + GenerateRandomGain());
            Name = name;
        }

        public virtual void TakeDamage(int damage)
        {
            if(damage > 0)
            {
                int damageBlockedArmor = (int)(damage * ArmorPercent);
                Console.WriteLine($"{ToString()} {Name} получил {damageBlockedArmor} урона!");
                Health -= damageBlockedArmor;
            }
        }

        public abstract void Attack(Human enemy);

        protected int GenerateRandomGain()
        {
            return _random.Next(_minRandom, _maxRandom);
        }

        private double CalculateArmor(double armor)
        {
            return 1 - armor / 100;
        }
    }

    public class Warrior : Human
    {
        private int _specialAttackFrequency = 2;
        private int _multiplierOfComboAttack = 2;

        public Warrior(int health, int attack, double armor, string name) : base(health, attack, armor, name)
        {
            СlassName = "Воин";
        }

        public override void Attack(Human enemy)
        {
            _attackNumber++;
            if (_attackNumber % _specialAttackFrequency == 0)
            {
                enemy.TakeDamage(DoComboAttack());
            }
            else
            {
                enemy.TakeDamage(Damage + GenerateRandomGain());
            }
        }

        private int DoComboAttack()
        {
            return Damage * _multiplierOfComboAttack + GenerateRandomGain();
        }
    }

    public class Wizard : Human
    {
        private int _magicPower;
        private int _specialAttackFrequency = 3;

        public Wizard(int health, int attack, double armor, int magicPower, string name) : base(health, attack, armor, name)
        {
            _magicPower = magicPower + GenerateRandomGain();
            СlassName = "Маг";
        }

        public override void Attack(Human enemy)
        {
            _attackNumber++;
            if (_attackNumber % _specialAttackFrequency == 0)
            {
                enemy.TakeDamage(DoMagicAttack());
            }
            else
            {
                enemy.TakeDamage(Damage + GenerateRandomGain());
            }
        }

        private int DoMagicAttack()
        {
            return _magicPower + GenerateRandomGain();
        }
    }

    public class Peasant : Human
    {
        private int _cornfieldsWrath;

        public Peasant(int health, int attack, double armor, int cornfieldsWrath, string name) : base(health, attack, armor, name)
        {
            _cornfieldsWrath = cornfieldsWrath;
            СlassName = "Крестьянин";
        }

        public override void Attack(Human enemy)
        {
            enemy.TakeDamage(Damage + _cornfieldsWrath + GenerateRandomGain());
        }
    }

    public class Knight : Human
    {
        private double _baseArmor;
        private double _maxArmor = 100;
        private int _specialAttackFrequency = 5;

        public Knight(int health, int attack, double armor, string name) : base(health, attack, armor, name)
        {
            _baseArmor = armor;
            СlassName = "Рыцарь";
        }

        public override void Attack(Human enemy)
        {
            _attackNumber++;
            if( _attackNumber % _specialAttackFrequency == 0)
            {
                ArmorPercent = _maxArmor;
            }
            else
            {
                ArmorPercent = _baseArmor;
            }

            enemy.TakeDamage(Damage + GenerateRandomGain());
        }
    }

    public class Zombie : Human
    {
        private static int _maxHealthRestored = 0;
        private double _healthRegenCoefficient = 0.05;
        private int _maxHealth;

        public Zombie(int health, int attack, double armor, string name) : base(health, attack, armor, name)
        {
            Health = health;
            _maxHealth = health;
            СlassName = "Зомби";
        }

        public override void Attack(Human enemy)
        {
            if (_maxHealth > Health && _maxHealthRestored < _maxHealth)
            {
                int currentHealth = Health;
                Health += (int)((_maxHealth - Health) * _healthRegenCoefficient);
                _maxHealthRestored = Health - currentHealth;
            }

            enemy.TakeDamage(Damage + GenerateRandomGain());
        }
    }
}
