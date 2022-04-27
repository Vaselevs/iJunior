using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variable_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String firstName = "Иван";
            String lastName = "Абрамов";
            Console.WriteLine(firstName + " " + lastName);
            firstName = "Антон";
            lastName = "Огурцов";
            Console.WriteLine(firstName + " " + lastName);

        }
    }
}
