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
        public int PlayerPositionX { get; private set; }
        public int PlayerPositionY { get; private set; }
        public char PlayerSymbol { get; private set; }

        public Player(int x, int y, char playerSymbol)
        {
            PlayerPositionX = x;
            PlayerPositionY = y;
            PlayerSymbol = playerSymbol;
        }
    }

    class Renderer
    {
        public void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(player.PlayerPositionX, player.PlayerPositionY);
            Console.WriteLine(player.PlayerSymbol);
        }
    }
}
