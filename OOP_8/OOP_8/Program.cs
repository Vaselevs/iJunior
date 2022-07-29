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
            Human figter;
            Human enemy;

            while (isPlaying)
            {
                Console.WriteLine("Выберите первого бойца!");
                Console.WriteLine();

                figter = ChooseFighter();

                if (figter != null)
                {
                    Console.WriteLine("Выберите второго бойца!");
                    Console.WriteLine();

                    enemy = ChooseFighter();
                    if (enemy != null)
                    {
                        if (figter != enemy)
                        {
                            Fight(figter, enemy);
                            PraiseTheWinner(figter, enemy);
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
                enemy.TakeDamage(fighter.MakeAttack());
                Console.WriteLine($"У {enemy.Name} осталось {enemy.Health}");
                fighter.TakeDamage(enemy.MakeAttack());
                Console.WriteLine($"У {fighter.Name} осталось {fighter.Health}");
            }
        }

        private Human ChooseFighter()
        {
            Console.WriteLine("1. Воин");
            Console.WriteLine("2. Волшебник");
            Console.WriteLine("3. Крестьянин");
            Console.WriteLine("4. Рыцарь");
            Console.WriteLine("5. Зомби");
            Console.WriteLine();
            Console.WriteLine("6. Выход");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    return _fighterFabric.CrateWarrior(4000, 350, 30, "Андрей");
                case "2":
                    return _fighterFabric.CreateWizard(2500, 300, 20, 200, "Анатолий");
                case "3":
                    return _fighterFabric.CreatePeasant(2000, 100, 15, 70, "Сашка");
                case "4":
                    return _fighterFabric.CreateKnight(5000, 250, 40, "Коля");
                case "5":
                    return _fighterFabric.CreateZombie(1000, 50, 5, "Шон");
                default:
                    return null;
            }
        }

        private void PraiseTheWinner(Human fighter, Human enemy)
        {
            if (fighter.Health > enemy.Health)
            {
                Console.WriteLine($"{fighter.Name} выигрывает в битве, ура!");
            }
            else
            {
                Console.WriteLine($"{enemy.Name} выигрывает в битве, ура!");
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
        private Random _random = new Random();
        private int _minRandom = 1;
        private int _maxRandom = 10;
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }
        public double Armor { get; private set; }

        public Human(int health, int attack, double armor, string name)
        {
            Health = health + GenerateRandomGain();
            Damage = attack + GenerateRandomGain();
            Armor = CalculateArmor(armor + GenerateRandomGain());
            Name = name;
        }

        public void TakeDamage(int damage)
        {
            if(damage > 0)
            {
                int damageBlockedArmor = (int)(damage * Armor);
                Console.WriteLine($"{ToString()} {Name} получил {damageBlockedArmor} урона!");
                Health -= damageBlockedArmor;
            }
        }

        public abstract int MakeAttack();

        private double CalculateArmor(double armor)
        {
            return 1 - armor / 100;
        }

        protected int GenerateRandomGain()
        {
            return _random.Next(_minRandom, _maxRandom);
        }
    }

    public class Warrior : Human
    {
        private static int _attackNumber = 0;
        private int _specialAttackFrequency = 2;
        private int _multiplierOfComboAttack = 2;

        public Warrior(int health, int attack, double armor, string name) : base(health, attack, armor, name)
        {

        }

        public override int MakeAttack()
        {
            _attackNumber++;
            if (_attackNumber % _specialAttackFrequency == 0)
            {
                return ComboAttack();
            }
            else
            {
                return Damage + GenerateRandomGain();
            }
        }

        private int ComboAttack()
        {
            return Damage * _multiplierOfComboAttack + GenerateRandomGain();
        }
    }

    public class Wizard : Human
    {
        private static int _attackNumber = 0;
        private int _magicPower;
        private int _specialAttackFrequency = 3;

        public Wizard(int health, int attack, double armor, int magicPower, string name) : base(health, attack, armor, name)
        {
            _magicPower = magicPower + GenerateRandomGain();
        }

        public override int MakeAttack()
        {
            _attackNumber++;
            if (_attackNumber % _specialAttackFrequency == 0)
            {
                return MagicAtack();
            }
            else
            {
                return Damage + GenerateRandomGain();
            }
        }

        private int MagicAtack()
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
        }

        public override int MakeAttack()
        {
            return Damage + _cornfieldsWrath + GenerateRandomGain();
        }
    }

    public class Knight : Human
    {
        private static int _attackNumber = 0;
        private double _baseArmor;
        private double _maxArmor = 100;
        private int _specialAttackFrequency = 5;
        public new double Armor { get; private set; }

        public Knight(int health, int attack, double armor, string name) : base(health, attack, armor, name)
        {
            _baseArmor = armor;
        }

        public override int MakeAttack()
        {
            _attackNumber++;
            if( _attackNumber % _specialAttackFrequency == 0)
            {
                Armor = _maxArmor;
            }
            else
            {
                Armor = _baseArmor;
            }

            return Damage + GenerateRandomGain();
        }
    }

    public class Zombie : Human
    {
        private static int _maxHealthRestored = 0;
        private double _healthRegenCoefficient = 0.05;
        private int _maxHealth;
        
        public new int Health { get; private set; }

        public Zombie(int health, int attack, double armor, string name) : base(health, attack, armor, name)
        {
            Health = health;
            _maxHealth = health;
        }

        public override int MakeAttack()
        {
            if (_maxHealth > Health && _maxHealthRestored < _maxHealth)
            {
                int currentHealth = Health;
                Health += (int)((_maxHealth - Health) * _healthRegenCoefficient);
                _maxHealthRestored = Health - currentHealth;
            }

            return Damage + GenerateRandomGain();
        }
    }
}
