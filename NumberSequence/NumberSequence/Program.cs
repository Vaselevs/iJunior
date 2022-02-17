using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startPoint = 7;
            int endPoint = 100;
            int pointStep = 7;



            for (int i = startPoint; i < endPoint; i += pointStep)
            {
                Console.Write(i + " ");
            }
        }
    }
}
