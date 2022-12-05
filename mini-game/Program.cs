using System;
using System.Data.Common;

namespace mini_game
{
    internal class Program
    {
        static int playersHP = 30;
        static int enemysHP = 15;
        static int playersPower = 5;
        static int enemiesPower = 5;
        static int mapSize = 25;
        static Random rnd = new Random();
        static bool buffFlag = false;
        static int[] playerPosition = new int[2] { 12, 12 };
        static char[,] map = new char[mapSize, mapSize]; 
        static int enemiesCount = 10;
        static int healingsCount = 5;
        static int buffsCount = 3;
        static bool gameFlag = true;
        
        public static char[,] GenerateMap()
        {

            for (int row = 0; row < mapSize; ++row)
            {
                for (int column = 0; column < mapSize; ++column)
                {
                    if (row == playerPosition[0] && column == playerPosition[1])
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

            /* 
             * p - ☻ - white
             * e - ■ - red
             * b - ✦ - yellow
             * h - ♥ - blue
             */
            for(int row = 0; row < mapSize; ++row) // colors don't work
            {
                for(int column = 0; column < mapSize; ++column)
                {
                    switch(map[row, column])
                    {
                        case 'p':
                            //Console.ForegroundColor = ConsoleColor.Green;
                            map[row, column] = ('▲');
                            break;
                        case 'h':
                            //Console.ForegroundColor = ConsoleColor.Blue;
                            map[row, column] = ('♥');
                            break;
                        case 'e':
                            //Console.ForegroundColor = ConsoleColor.Red;
                            map[row, column] = ('■');
                            break;
                        case 'b':
                            //Console.ForegroundColor = ConsoleColor.Yellow;
                            map[row, column] = ('♦');
                            break;
                    }
                }
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
        }

        public void Move(System.ConsoleKey direction) // ▶ ◀ ▼ ▲
        {
            switch (direction)
            {
                case ConsoleKey.UpArrow:
                    playerPosition[0] += 1;
                    map[playerPosition[0] + 1, playerPosition[1]] = ' ';
                    map[playerPosition[0], playerPosition[1]] = '▲';
                    break;
                case ConsoleKey.DownArrow:
                    map[playerPosition[0] - 1, playerPosition[1]] = ' ';
                    map[playerPosition[0], playerPosition[1]] = '▼';
                    break;
                case ConsoleKey.LeftArrow:
                    map[playerPosition[0], playerPosition[1] - 1] = ' ';
                    map[playerPosition[0], playerPosition[1]] = '◀';
                    break;
                case ConsoleKey.RightArrow:
                    map[playerPosition[0], playerPosition[1] + 1] = ' ';
                    map[playerPosition[0], playerPosition[1]] = '▶';
                    break;
            }
        }
        public static void Buffs()
        {
            if (map[playerPosition[0], playerPosition[1]] == 'b')
            {
                buffFlag = true;
                playersPower = 10;
            }
        }

        public static void Fight()
        {
            if (map[playerPosition[0], playerPosition[1]] == 'e')
            {
                 while (enemysHP > 0)
                 {
                     enemysHP -= playersPower;
                     playersHP -= enemiesPower;
                 }
                 if (playerHP <= 0)
                 {
                     gameFlag = false;
                 }
                 else 
                 {
                     enemiesCount--;
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