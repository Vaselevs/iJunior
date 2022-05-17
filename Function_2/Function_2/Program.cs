using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int paintProcent = 56;
            ConsoleColor color = ConsoleColor.Green;
            int consoleCoordinateX = 20;
            int consoleCoordinateY = 10;

            DrawBar(color, paintProcent, consoleCoordinateX, consoleCoordinateY);
            
            Console.ReadLine();

        }

        static void DrawBar(ConsoleColor color, int paintProcent, int barX, int barY)
        {
            int barLength = 10;
            int percentageDivisor = 10;
            Console.BackgroundColor = color;
            paintProcent = paintProcent/percentageDivisor;

            Console.SetCursorPosition(barX, barY);
            Console.Write("[");

            for(int i = 1; i < barLength+1; i++)
            {
                if(i <= paintProcent)
                {
                    Console.Write('#');
                } 
                else
                {
                    Console.Write('_');
                }
            }

            Console.Write("]");
        }
    }
}
