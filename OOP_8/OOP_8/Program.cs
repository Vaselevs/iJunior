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
        private Warrior _warrior;
        private Wizard _wizard;
        private Peasant _peasant;
        private Knight _knight;
        private Zombie _zombie;

        private string _warriorName = "Андрей";
        private int _warriorHealth = 4000;
        private int _warriorAttack = 350;
        private double _warriorArmor = 30;

        private string _wizardName = "Анатолий";
        private int _wizardHealth = 2500;
        private int _wizardAttack = 300;
        private double _wizardArmor = 20;
        private int _wizardMagicPower = 200;

        private string _peasantName = "Сашка";
        private int _peasantHealth = 2000;
        private int _peasantAttack = 100;
        private double _peasantArmor = 15;
        private int _peasantCornfieldsWrath = 70;

        private string _knightName = "Коля";
        private int _knightHealth = 5000;
        private int _knightAttack = 250;
        private double _knightArmor = 40;

        private string _zombiename = "Шон";
        private int _zombieHealth = 1000;
        private int _zombieAttack = 50;
        private int _zombieArmor = 5;

        public Game()
        {
            _warrior = new Warrior(_warriorHealth, _warriorAttack, _warriorArmor, _warriorName);
            _wizard = new Wizard(_wizardHealth, _wizardAttack, _wizardArmor, _wizardMagicPower, _wizardName);
            _peasant = new Peasant(_peasantHealth, _peasantAttack, _peasantArmor, _peasantCornfieldsWrath, _peasantName);
            _knight = new Knight(_knightHealth, _knightAttack, _knightArmor, _knightName);
            _zombie = new Zombie(_zombieHealth, _zombieAttack, _zombieArmor, _zombiename);
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
                if (figter == null)
                {
                    break;
                }

                Console.WriteLine("Выберите второго бойца!");
                Console.WriteLine();

                enemy = ChooseFighter();
                if (enemy == null)
                {
                    break;
                }

                if (figter != enemy)
                {
                    Fight(figter, enemy);
                }

                Console.ReadLine();
            }

            

        }


        private Human Fight(Human fighter, Human enemy)
        {
            while(fighter.Health > 0 && enemy.Health > 0)
            {
                enemy.TakeDamage(fighter.MakeAttack());
                Console.WriteLine($"У {enemy.Name} осталось {enemy.Health}");
                fighter.TakeDamage(enemy.MakeAttack());
                Console.WriteLine($"У {fighter.Name} осталось {fighter.Health}");
            }
            if(fighter.Health > enemy.Health)
            {
                return fighter;
            }
            else
            {
                return enemy;
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
                    return _warrior;
                case "2":
                    return _wizard;
                case "3":
                    return _peasant;
                case "4":
                    return _knight;
                case "5":
                    return _zombie;
                default:
                    return null;
            }
        }
    }


    public abstract class Human
    {
        private Random _rand = new Random();
        private int _minRandom = 1;
        private int _maxRandom = 10;
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Attack { get; private set; }
        public double Armor { get; private set; }

        public Human(int health, int attack, double armor, string name)
        {
            Health = health + GenerateRandomGain();
            Attack = attack + GenerateRandomGain();
            Armor = CalculateArmor(armor + GenerateRandomGain());
            Name = name;
        }

        public void TakeDamage(int damage)
        {
            if(damage > 0)
            {
                int damageBlockedArmor = (int)(damage * Armor);
                Console.WriteLine($"{GetType()} {Name} получил {damageBlockedArmor} урона!");
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
            return _rand.Next(_minRandom, _maxRandom);
        }
    }

    public class Warrior : Human
    {
        private static int _attackNumber = 0;

        public Warrior(int health, int attack, double armor, string name) : base(health, attack, armor, name)
        {

        }

        public override int MakeAttack()
        {
            _attackNumber++;
            if (_attackNumber % 2 == 0)
            {
                return ComboAttack();
            }
            else
            {
                return Attack + GenerateRandomGain();
            }
        }

        private int ComboAttack()
        {
            return Attack * 2 + GenerateRandomGain();
        }
    }

    public class Wizard : Human
    {
        private static int _attackNumber = 0;
        private int _magicPower;

        public Wizard(int health, int attack, double armor, int magicPower, string name) : base(health, attack, armor, name)
        {
            _magicPower = magicPower + GenerateRandomGain();
        }

        public override int MakeAttack()
        {
            _attackNumber++;
            if (_attackNumber % 3 == 0)
            {
                return MagicAtack();
            }
            else
            {
                return Attack + GenerateRandomGain();
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
            return Attack + _cornfieldsWrath + GenerateRandomGain();
        }


    }

    public class Knight : Human
    {
        private static int _attackNumber = 0;
        private double _baseArmor;
        private double _maxArmor = 100;
        public new double Armor { get; private set; }

        public Knight(int health, int attack, double armor, string name) : base(health, attack, armor, name)
        {
            _baseArmor = armor;
        }

        public override int MakeAttack()
        {
            _attackNumber++;
            if( _attackNumber % 5 == 0)
            {
                Armor = _maxArmor;
            }
            else
            {
                Armor = _baseArmor;
            }

            return Attack + GenerateRandomGain();
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

            return Attack + GenerateRandomGain();
        }

    }
}
