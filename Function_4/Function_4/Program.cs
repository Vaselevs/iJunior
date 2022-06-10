using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PaintMap();
        }

        static void PaintMap()
        {
            char[,] map;
            int mapSize;
            int playerPositionX = 1;
            int playerPositionY = 1;
            bool isPlaying = true;
            bool painting = false;

            Console.Clear();
            Console.Write("Введите размер карты: ");

            mapSize = Convert.ToInt32(Console.ReadLine());
            mapSize += 2;

            map = new char[mapSize, mapSize];

            MapInitialization(map);
            map[playerPositionX, playerPositionY] = '@';

            Console.CursorVisible = false;

            while (isPlaying)
            {
                int playerDirectionX = 0;
                int playerDirectionY = 0;

                Console.Clear();
                Console.WriteLine($"Размер карты: {mapSize - 2}");
                Console.WriteLine("Чтобы начать или закончить рисовать карту, нажмите пробел. \nПробел так же стирает уже существующие участки карты");

                if (painting)
                    Console.WriteLine("РЕЖИМ РИСОВАНИЯ");
                else
                    Console.WriteLine("РЕЖИМ ПЕРЕДВИЖЕНИЯ");

                Console.WriteLine("Чтобы выйти из режима программы, нажмите Esc");

                ShowMap(map);

                ConsoleKeyInfo key;

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Spacebar:

                        if (painting == false)
                            painting = true;
                        else
                            painting = false;

                        break;
                    case ConsoleKey.Escape:

                        isPlaying = false;

                        break;
                }

                PLayerChoiseDirection(map, key, playerPositionX, playerPositionY, ref playerDirectionX, ref playerDirectionY);

                if (painting)
                    PlayerMoveWithPainting(map, ref playerPositionX, ref playerPositionY, playerDirectionX, playerDirectionY);
                else
                    PlayerMove(map, ref playerPositionX, ref playerPositionY, playerDirectionX, playerDirectionY);
                
            }
        }

        static void ShowMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void MapInitialization(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (i == 0 || i == map.GetLength(0) - 1)
                    {
                        map[i, j] = '#';
                    }
                    else
                    {
                        if (j == 0 || j == map.GetLength(0) - 1)
                        {
                            map[i, j] = '#';
                        }
                        else
                        {
                            map[i, j] = ' ';
                        }
                    }
                }
            }
        }

        static void PLayerChoiseDirection(char[,] map, ConsoleKeyInfo key, int playerPositionX, int playerPositionY, ref int playerDirectionX, ref int playerDirectionY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:

                    if (playerPositionX - 1 > 0)
                    {
                        playerDirectionX = -1;
                    }

                    break;
                case ConsoleKey.DownArrow:

                    if (playerPositionX + 1 < map.GetLength(0)-1)
                    {
                        playerDirectionX = 1;
                    }

                    break;
                case ConsoleKey.LeftArrow:

                    if (playerPositionY - 1 > 0)
                    {
                        playerDirectionY = -1;
                    }

                    break;
                case ConsoleKey.RightArrow:

                    if (playerPositionY + 1 < map.GetLength(0)-1)
                    {
                        playerDirectionY = 1;
                    }

                    break;
            }
        }

        static void PlayerMove(char[,] map, ref int playerPositionX, ref int playerPositionY, int playerDirectionX, int playerDirectionY)
        {
            if (map[playerPositionX+playerDirectionX,playerPositionY+playerDirectionY] == ' ')
            {
                map[playerPositionX, playerPositionY] = ' ';
                playerPositionX += playerDirectionX;
                playerPositionY += playerDirectionY;
                map[playerPositionX, playerPositionY] = '@';
            }
                
        }

        static void PlayerMoveWithPainting(char[,] map, ref int playerPositionX, ref int playerPositionY, int playerDirectionX, int playerDirectionY)
        {
            if (map[playerPositionX + playerDirectionX, playerPositionY + playerDirectionY] == ' ')
            {
                map[playerPositionX, playerPositionY] = '#';
                playerPositionX += playerDirectionX;
                playerPositionY += playerDirectionY;
                map[playerPositionX, playerPositionY] = '@';
            } else
            {
                map[playerPositionX, playerPositionY] = ' ';
                playerPositionX += playerDirectionX;
                playerPositionY += playerDirectionY;
                map[playerPositionX, playerPositionY] = '@';
            }
        }
    }
}