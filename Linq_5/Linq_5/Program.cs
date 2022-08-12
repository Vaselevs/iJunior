using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_5
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Stotage
    {
        private CanOfStew _caOfStews;

    }

    public class CanOfStew
    {
        public string Name { get; private set; }
        public DateTime DateOfManufacture { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public CanOfStew(string name, DateTime dateOfManufacture, DateTime expirationDate)
        {
            Name = name;
            DateOfManufacture = dateOfManufacture;
            ExpirationDate = expirationDate;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {DateOfManufacture.Year} - {ExpirationDate.Year}");
        }
    }
}
