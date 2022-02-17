using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            

            while (true)
            {
                int i = rand.Next(0, 21);
                Console.WriteLine(i);
                Console.ReadKey();
            }


        }
    }
}
