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


            Directory.CreateDirectory("Maps");



        }

        static void WriteMap()
        {


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
