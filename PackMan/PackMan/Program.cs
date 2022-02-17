using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PacMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool isPlaying = true;
            int pacmanX, pacmanY;
            int pacmanDX = 0, pacmanDY = 0;
            int allDots = 0;
            int collectDots = 0;
            int ghostX, ghostY;
            int ghostDX = 0, ghostDY = 1;
            Random rand = new Random();

            char[,] map = ReadMap("map1", out pacmanX, out pacmanY, out ghostX, out ghostY, ref allDots);

            
            DrawMap(map);

            while (isPlaying)
            {
                Console.SetCursorPosition(map.GetLength(1) + 1, 0);
                Console.Write($"Собрано: {collectDots}/{allDots}");
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangeDirection(key, ref pacmanDX, ref pacmanDY);
                }

                if (map[pacmanX + pacmanDX, pacmanY + pacmanDY] != '#')
                {
                    Move(map,'@',ref pacmanX,ref pacmanY,pacmanDX,pacmanDY);
                    CollectDots(map, pacmanX, pacmanY, ref collectDots);


                }

                if (map[ghostX + ghostDX, ghostY + ghostDY] != '#')
                {
                    Move(map,'$', ref ghostX, ref ghostY, ghostDX, ghostDY);
                }
                else
                {
                    ChangeDirection(rand, ref ghostDX, ref ghostDY);
                }

                System.Threading.Thread.Sleep(20);

                if ((collectDots == allDots) || (ghostX == pacmanX && ghostY == pacmanY))
                {
                    isPlaying = false;
                }
            }
            Console.SetCursorPosition(map.GetLength(1) + 1, 1);
            if(collectDots == allDots)
            {
                Console.WriteLine("Вы победили!");
            }
            else
            {
                Console.WriteLine("Вы умерли!");
            }


        }

        static void Move(char[,] map, char symbol, ref int X, ref int Y, int DX, int DY)
        {
            Console.SetCursorPosition(Y, X);
            Console.Write(map[X,Y]);

            X += DX;
            Y += DY;

            Console.SetCursorPosition(Y, X);
            Console.Write(symbol);
        }

        static void CollectDots(char[,] map, int X, int Y, ref int collectDots)
        {
            if (map[X, Y] == '.')
            {
                collectDots++;
                map[X, Y] = ' ';
            }
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int DX, ref int DY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    DX = -1; DY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    DX = 1; DY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    DX = 0; DY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    DX = 0; DY = 1;
                    break;
            }
        }

        static void ChangeDirection(Random rand, ref int DX, ref int DY)
        {
            int ghostDir = rand.Next(1, 5);

            switch (ghostDir)
            {
                case 1:
                    DX = -1; DY = 0;
                    break;
                case 2:
                    DX = 1; DY = 0;
                    break;
                case 3:
                    DX = 0; DY = -1;
                    break;
                case 4:
                    DX = 0; DY = 1;
                    break;
            }
        }

        static void DrawMap(char[,] map)
        {
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]); 
                }
                Console.WriteLine();
            }
        }

        static char[,] ReadMap(string mapName, out int pacmanX, out int pacmanY, out int ghostX, out int ghostY, ref int allDots)
        {
            pacmanX = 0;
            pacmanY = 0;
            ghostX = 0;
            ghostY = 0;

            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i,j] = newFile[i][j];

                    if(map[i,j] == '@')
                    {
                        pacmanX = i;
                        pacmanY = j;
                        map[i, j] = '.';
                    }
                    else if (map[i,j] == '$')
                    {
                        ghostX = i;
                        ghostY = j;
                        map[i, j] = '.';
                    }
                    else if (map[i,j] == ' ')
                    {
                        map[i, j] = '.';
                        allDots++;
                    }
                }
            }

            return map; 
        }
    }
}
