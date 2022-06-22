using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player NewPlayer = new Player(15, 10, '$');
            Renderer NewRenderer = new Renderer();

            NewRenderer.DrawPlayer(NewPlayer);
        }
    }

    class Player
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public char Symbol { get; private set; }

        public Player(int positionX, int positionY, char symbol)
        {
            PositionX = positionX;
            PositionY = positionY;
            this.Symbol = symbol;
        }
    }

    class Renderer
    {
        public void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(player.PositionX, player.PositionY);
            Console.WriteLine(player.Symbol);
        }
    }
}
