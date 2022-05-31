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


            



        }

        static void PaintMap()
        {
            bool isPainting = true;
            string newMapName;
            string[] map;
            int mapHeight, mapWidth;

            Directory.CreateDirectory("Maps");
            Console.Write("Введите название новой карты: ");
            newMapName = Console.ReadLine();
            Console.Write("Введите высоту карты: ");
            mapHeight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ширину карты: ");
            mapWidth = Convert.ToInt32(Console.ReadLine());
            
            map = new string[mapHeight];
            

            for(int i = 0; i < mapHeight; i++)
            {
                if (i == 0 || i == mapHeight - 1)
                {
                    for (int j = 0; j < mapWidth; j++)
                        map[i][j] = '#';
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

            File.CreateText($"Maps/{newMapName}");


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

        static void PlayerGameplay()
        {

        }
    }
}
