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
            char[,] map;

            map = PaintMap();
            ShowMap(map);

            Console.ReadLine();
        }


        static char[,] PaintMap()
        {
            char[,] map;
            int mapSize;
            int playerPositionX = 1;
            int playerPositionY = 6;
            int mapTopBorder = 5;
            int mapBottomBorder;
            int mapLeftBorder = 0;
            int mapRightBorder;
            bool isPlaying = true;
            bool painting = false;

            Console.Clear();
            Console.Write("Введите размер карты: ");

            mapSize = Convert.ToInt32(Console.ReadLine());
            mapBottomBorder = mapTopBorder + mapSize;
            mapRightBorder = mapLeftBorder + mapSize;
            mapSize += 2;

            map = new char[mapSize,mapSize];

            for(int i = 0; i < mapSize; i++)
            {
                if(i == 0 || i == mapSize - 1)
                {
                    for (int j = 0; j < mapSize; j++)
                        map[i, j] = '#';
                }
                else
                {
                    map[i, 0] = '#';
                    map[i, mapSize - 1] = '#';
                }
            }

            Console.CursorVisible = false;

            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    Console.Clear();
                    Console.WriteLine($"Размер карты: {mapSize - 2}");
                    Console.WriteLine("Чтобы начать или закончить рисовать карту, нажмите пробел. \nПробел так же стирает уже существующие участки карты");
                    if (painting)
                        Console.WriteLine("РЕЖИМ РИСОВАНИЯ");
                    else
                        Console.WriteLine("РЕЖИМ ПЕРЕДВИЖЕНИЯ");
                    Console.WriteLine("Чтобы выйти из режима рисования, нажмите Esc");

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    ShowMap(map);

                    Console.SetCursorPosition(playerPositionX,playerPositionY);
                    Console.Write("@");





                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (painting)
                            {
                                if (playerPositionY - 1 > mapTopBorder)
                                {
                                    map[playerPositionX, playerPositionY - mapTopBorder] = '#';
                                    playerPositionY -= 1;
                                }
                            } else
                            {
                                if (playerPositionY - 1 > mapTopBorder)
                                {
                                    map[playerPositionX, playerPositionY - mapTopBorder] = ' ';
                                    playerPositionY -= 1;
                                }
                            }
                            break;
                        case ConsoleKey.DownArrow:

                            if (painting)
                            {
                                if (playerPositionY + 1 < mapBottomBorder)
                                {
                                    map[playerPositionX, playerPositionY - mapTopBorder] = '#';
                                    playerPositionY += 1;
                                }
                            } else
                            {
                                if (playerPositionY + 1 < mapBottomBorder)
                                {
                                    map[playerPositionX, playerPositionY - mapTopBorder] = ' ';
                                    playerPositionY += 1;
                                }
                            }
                            break;
                        case ConsoleKey.LeftArrow:

                            if (painting)
                            {
                                if (playerPositionX - 1 > mapLeftBorder)
                                {
                                    map[playerPositionX, playerPositionY] = '#';
                                    playerPositionX -= 1;
                                }
                            } else
                            {
                                if (playerPositionX - 1 > mapLeftBorder)
                                {
                                    map[playerPositionX, playerPositionY] = ' ';
                                    playerPositionX -= 1;
                                }
                            }
                            break;
                        case ConsoleKey.RightArrow:

                            if (painting)
                            {
                                if (playerPositionX + 1 < mapRightBorder)
                                {
                                    map[playerPositionX, playerPositionY] = '#';
                                    playerPositionX += 1;
                                }
                            } else
                            {
                                if (playerPositionX + 1 < mapRightBorder)
                                {
                                    map[playerPositionX, playerPositionY] = ' ';
                                    playerPositionX += 1;
                                }
                            }
                            break;
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
                }
            }

            return map;
        }

        static void ShowMap(char[,] map)
        {
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
