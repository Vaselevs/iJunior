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
            int playerPositionY = 6;
            int mapTopBorder = 5;
            bool isPlaying = true;
            bool painting = false;

            Console.Clear();
            Console.Write("Введите размер карты: ");

            mapSize = Convert.ToInt32(Console.ReadLine());
            mapSize += 2;

            map = new char[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for(int j = 0; j < mapSize; j++)
                {
                    if (i == 0 || i == mapSize - 1)
                    {
                        map[i, j] = '#';
                    }
                    else
                    {
                        if(j == 0 || j == mapSize - 1)
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

            Console.CursorVisible = false;

            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine($"Размер карты: {mapSize - 2}");
                Console.WriteLine("Чтобы начать или закончить рисовать карту, нажмите пробел. \nПробел так же стирает уже существующие участки карты");

                if (painting)
                    Console.WriteLine("РЕЖИМ РИСОВАНИЯ");
                else
                    Console.WriteLine("РЕЖИМ ПЕРЕДВИЖЕНИЯ");

                Console.WriteLine("Чтобы выйти из режима программы, нажмите Esc");

                ShowMap(map);

                Console.SetCursorPosition(playerPositionX, playerPositionY);
                Console.Write("@");

                ConsoleKeyInfo key;

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:

                        if(playerPositionY - 1 > mapTopBorder)
                        {
                            if (painting)
                            {
                                ChangeSimbol(map, playerPositionY - mapTopBorder - 1, playerPositionX);
                                playerPositionY -= 1;
                            }
                            else
                            {
                                if (map[playerPositionY - mapTopBorder - 1, playerPositionX] == ' ')
                                {
                                    playerPositionY -= 1;
                                }
                            }
                        }

                        break;
                    case ConsoleKey.DownArrow:

                        if (playerPositionY + 1 < mapTopBorder + mapSize)
                        {
                            if (painting)
                            {
                                ChangeSimbol(map, playerPositionY - mapTopBorder + 1, playerPositionX);
                                playerPositionY += 1;
                            }
                            else
                            {
                                if (map[playerPositionY - mapTopBorder + 1, playerPositionX] == ' ')
                                {
                                    playerPositionY += 1;
                                }
                            }
                        }

                        break;
                    case ConsoleKey.LeftArrow:

                        if(playerPositionX - 1 > 0)
                        {
                            if (painting)
                            {
                                ChangeSimbol(map, playerPositionY - mapTopBorder, playerPositionX - 1);
                                playerPositionX -= 1;
                            }
                            else
                            {
                                if (map[playerPositionY - mapTopBorder, playerPositionX - 1] == ' ')
                                {
                                    playerPositionX -= 1;
                                }
                            }
                        }

                        break;
                    case ConsoleKey.RightArrow:

                        if (playerPositionX + 1 < mapSize - 1)
                        {
                            if (painting)
                            {
                                ChangeSimbol(map, playerPositionY - mapTopBorder, playerPositionX + 1);
                                playerPositionX += 1;
                            }
                            else
                            {
                                if (map[playerPositionY - mapTopBorder, playerPositionX + 1] == ' ')
                                {
                                    playerPositionX += 1;
                                }
                            }
                        }

                        break;
                    case ConsoleKey.Spacebar:

                        if (painting == false)
                        {
                            painting = true;
                            ChangeSimbol(map, playerPositionY - mapTopBorder, playerPositionX);
                        }
                        else
                        {
                            painting = false;
                        }

                        break;
                    case ConsoleKey.Escape:

                        isPlaying = false;

                        break;
                }
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

        static void ChangeSimbol(char[,] map, int X, int Y)
        {
            if (map[X, Y] == ' ')
            {
                map[X, Y] = '#';
            }
            else
            {
                map[X, Y] = ' ';
            }
        }
    }
}