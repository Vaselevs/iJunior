using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Function_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            string currentMap = "НЕ ВЫБРАНА НИ ОДНА КАРТА";
            string[] mapsInDirectory;
            string pathToMaps = "Maps/";
            int userChoise;
            int userMapChoise;
            int cursorPositionForUserInputInMainMenu_Y = 2;
            int cursorPositionForUserInputInMainMenu_X = 20;

            while (isWorking)
            {

                Console.Clear();
                Console.WriteLine("Приветствую вас в редакторе карт");
                Console.WriteLine($"Ваша текущая карта: {currentMap}");
                Console.WriteLine("Выберите пункт меню: ");
                Console.WriteLine();
                Console.WriteLine("1.Выбрать уже существующую карту");
                Console.WriteLine("2.Нарисовать новую карту");
                Console.WriteLine("3.Играть в выбранную карту");
                Console.WriteLine("4.Выход из программы");

                Console.SetCursorPosition(cursorPositionForUserInputInMainMenu_X, cursorPositionForUserInputInMainMenu_Y);
                userChoise = System.Convert.ToInt32(Console.ReadLine());


                switch (userChoise)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Выберите номер карты из списка: ");
                        mapsInDirectory = Directory.GetFiles(pathToMaps);
                        
                        for(int i = 0; i < mapsInDirectory.Length; i++)
                        {
                            Console.WriteLine($"{i+1}.{mapsInDirectory[i]}");
                        }

                        Console.ReadLine();
                        break;
                    case 2:

                        PaintMap();

                        break;
                    case 3:

                        break;
                    case 4:
                        isWorking = false;
                        break;
                    default:

                        break;
                }
            }
        }

        static void PaintMap()
        {
            bool isPainting = true;
            string newMapName;
            char[,] map;
            int mapHeight, mapWidth;

            Console.Clear();
            Directory.CreateDirectory("Maps");
            Console.Write("Введите название новой карты: ");
            newMapName = Console.ReadLine();
            Console.Write("Введите высоту карты: ");
            mapHeight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ширину карты: ");
            mapWidth = Convert.ToInt32(Console.ReadLine());
            
            map = new char[mapHeight,mapWidth];
            

            for(int i = 0; i < mapHeight; i++)
            {
                if (i == 0 || i == mapHeight - 1)
                {
                    for (int j = 0; j < mapWidth; j++)
                        map[i,j] = '#';
                } else
                {
                    map[i, 0] = '#';
                    map[i, mapWidth - 1] = '#';
                }
            }

            /*
            Console.Clear();

            while (isPainting)
            {
                Console.WriteLine("Вы вошли в режим рисования карты.\nНе выходите из этого режима пока не закончите рисовать.");

            }

            */

            File.WriteAllText($"Maps/{newMapName}",Convert.ToString(map), Encoding.UTF8);


        }

        static char[,] ReadMap(string mapName)
        {
            string[] newFile = File.ReadAllLines($"Maps/{mapName}");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for(int i = 0; i < newFile.Length; i++)
            {
                for(int j = 0; j < newFile[i].Length; j++)
                {
                    map[i, j] = newFile[i][j];
                }
            }
            return map;
        }

        static void PlayerGameplay(char[,] map)
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
