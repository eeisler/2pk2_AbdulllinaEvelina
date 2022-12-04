using System;
using System.Data.Common;

namespace mini_game
{
    internal class Program
    {
        int playersHP = 30;
        int playersPower = 5;
        int enemiesPower = 5;
        static int mapSize = 25;
        static Random rnd = new Random();
        
        public static char[,] GenerateMap()
        {
            char[,] map = new char[mapSize, mapSize]; 

            int playerX = 12;
            int playerY = 12;

            int enemiesCount = 10;
            int healingsCount = 5;
            int buffsCount = 3;

            for (int row = 0; row < mapSize; ++row)
            {
                for (int column = 0; column < mapSize; ++column)
                {
                    if (row == playerX && column == playerY)
                    {
                        map[row, column] = 'p';
                    }
                    else
                    {
                        map[row, column] = ' ';
                    }
                }
            }

            for (int enemy = 0; enemy < enemiesCount; ++enemy)
            {
                int enemyX = rnd.Next(mapSize);
                int enemyY = rnd.Next(mapSize);

                while (map[enemyX, enemyY] != ' ')
                {
                    enemyX = rnd.Next(mapSize);
                    enemyY = rnd.Next(mapSize);
                }

                map[enemyX, enemyY] = 'e';
            }

            for (int heal = 0; heal < healingsCount; ++heal)
            {
                int healX = rnd.Next(mapSize);
                int healY = rnd.Next(mapSize);

                while (map[healX, healY] != ' ')
                {
                    healX = rnd.Next(mapSize);
                    healY = rnd.Next(mapSize);
                }

                map[healX, healY] = 'h';

            }

            for (int buff = 0; buff < buffsCount; ++buff)
            {
                int buffX = rnd.Next(mapSize);
                int buffY = rnd.Next(mapSize);

                while (map[buffX, buffY] != ' ')
                {
                    buffX = rnd.Next(mapSize);
                    buffY = rnd.Next(mapSize);
                }
                map[buffX, buffY] = 'b';
            }

            return map;
        }

        public static void PrintMap(char[,] map)
        {
            for (int row = 0; row < mapSize; ++row)
            {
                if (row == 0)
                {
                    Console.WriteLine(" __________________________________________________");
                } 

                else if (row == mapSize - 1)
                {
                    Console.WriteLine(" __________________________________________________");
                    //Console.WriteLine(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                }
                else
                {
                    Console.Write("|");

                    for (int column = 0; column < mapSize; ++column) 
                    {
                        
                        Console.Write(map[row, column] + " ");
                    }
                    Console.WriteLine("|");
                }
            }

            /* 
             * p - ☻ - white
             * e - ■ - red
             * b - ✦ - yellow
             * h - ♥ - blue
             */
            for(int row = 0; row < mapSize; ++row)
            {
                for(int column = 0; column < mapSize; ++column)
                {
                    switch(map[row, column])
                    {
                        case 'p':
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write('☻');
                            break;
                        case 'h':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write('♥');
                            break;
                        case 'e':
                            Console.ForegroundColor = ConsoleColor.Red;
                            map[row, column] = '■';
                            break;
                        case 'b':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write('✦');
                            break;
                    }
                }
            }
        }

        

        static void Main(string[] args)
        {
            char[,] mAp = GenerateMap();
            PrintMap(mAp);
            Console.ReadKey();
        }
    }
}