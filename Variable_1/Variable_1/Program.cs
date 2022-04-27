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
            String firstName = "Абрамов";
            String lastName = "Иван";
            Console.WriteLine(firstName + " " + lastName);
            String tempName = firstName;
            firstName = lastName;
            lastName = tempName;
            Console.WriteLine(firstName + " " + lastName);

        }
    }
}