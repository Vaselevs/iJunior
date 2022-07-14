using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Game
    {

    }

    public class Player
    {

    }

    public class Train
    {
        private List<PassengerCarriage> Carriages { get; set; }

        public Train()
        {
            Carriages = new List<PassengerCarriage>();
        }

        public int AddNewCarriage()
        {
            Console.WriteLine("Введите количество мест в пассажирском вагоне: ");
            if(Int32.TryParse(Console.ReadLine(), out int numberOfSeats))
            {
                Carriages.Add(new PassengerCarriage(numberOfSeats));
                return numberOfSeats;
            }
            else
            {
                Console.WriteLine("Не верный формат ввода!");
                return 0;
            }
        }
    }

    public class PassengerCarriage
    {
        private int NumberOfSeats { get; set; }

        public PassengerCarriage(int numberOfSeats)
        {
            NumberOfSeats = numberOfSeats;
        }
    }
}
