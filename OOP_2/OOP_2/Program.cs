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
        public int X { get; private set; }
        public int Y { get; private set; }
        public char PlayerSymbol { get; private set; }

        public Player(int x, int y, char playerSymbol)
        {
            X = x;
            Y = y;
            PlayerSymbol = playerSymbol;
        }
    }

    class Renderer
    {
        public void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(player.X, player.Y);
            Console.WriteLine(player.PlayerSymbol);
        }
    }
}
