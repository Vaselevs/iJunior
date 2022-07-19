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

        }
    }

    public abstract class Human
    {
        public int Health { get; private set; }
        public int Attack { get; private set; }
        public double Armor { get; private set; }

        public Human(int health, int attack, double armor)
        {
            Health = health;
            Attack = attack;
            Armor = CalculateArmor(armor);
        }

        public void TakeDamage(int damage)
        {
            if(damage > 0)
            {
                Health -= (int)(damage * Armor);
            }
        }

        public abstract int MakeAttack();

        private double CalculateArmor(double armor)
        {
            return 1 - armor / 100;
        }
    }

    public class Warrior : Human
    {
        private static int _attackNumber = 0;

        public Warrior(int health, int attack, double armor) : base(health, attack, armor)
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
                return Attack;
            }
        }

        private int ComboAttack()
        {
            return Attack * 2;
        }
    }

    public class Wizard : Human
    {
        private static int _attackNumber = 0;
        private int _magicPower;

        public Wizard(int health, int attack, double armor, int magicPower) : base(health, attack, armor)
        {
            _magicPower = magicPower;
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
                return Attack;
            }
        }

        private int MagicAtack()
        {
            return _magicPower;
        }
    }

    public class Peasant : Human
    {
        private int _cornfieldsWrath;

        public Peasant(int health, int attack, double armor, int cornfieldsWrath) : base(health, attack, armor)
        {
            _cornfieldsWrath = cornfieldsWrath;
        }

        public override int MakeAttack()
        {
            return Attack * _cornfieldsWrath;
        }


    }

    public class Knight : Human
    {
        private static int _attackNumber = 0;
        private double _baseArmor;
        private double _maxArmor = 100;
        public new double Armor { get; private set; }

        public Knight(int health, int attack, double armor) : base(health, attack, armor)
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
            return Attack;
        }
    }

    public class Zombie : Human
    {

    }

    public class CrazyWizrd : Wizard
    {

    }
}
