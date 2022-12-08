using System;
using System.Data.Common;
using System.Diagnostics;

namespace mini_game
{
    internal class Program
    {
        // Default variables
        static int playersHP = 30;
        static int playersPower = 5;
        static int[] playerPosition = new int[2] {12, 12};
        
        static int enemysHP = 15;
        static int enemiesPower = 5;
        static int enemiesCount = 10;
        static int[] enemiesHealths =
        {
            enemysHP, enemysHP,
            enemysHP, enemysHP,
            enemysHP, enemysHP,
            enemysHP, enemysHP,
            enemysHP, enemysHP
        };
        static int enemiesKilled = 0;
        
        static int mapSize = 25;
        static char[,] map = new char[mapSize, mapSize]; 
        
        static Random rnd = new Random();
        
        static bool buffFlag = false;
        static int buffsCount = 3;
        static int buffsTime = 0;
        
        static int healingsCount = 5;
        
        static bool gameFlag = true;
        
        public static char[,] GenerateMap() // Generating the map
        {
            for (int row = 0; row < mapSize; ++row)
            {
                for (int column = 0; column < mapSize; ++column)
                {
                    // If cell is a player position then write a triangle
                    if (row == playerPosition[0] && column == playerPosition[1])
                    {
                        map[row, column] = '▲';
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

                while (map[enemyX, enemyY] != ' ') // If cell is not empty then generate new random values
                {
                    enemyX = rnd.Next(mapSize);
                    enemyY = rnd.Next(mapSize);
                }

                map[enemyX, enemyY] = '■';
            }

            for (int heal = 0; heal < healingsCount; ++heal)
            {
                int healX = rnd.Next(mapSize);
                int healY = rnd.Next(mapSize);

                while (map[healX, healY] != ' ') // If cell is not empty then generate new random values
                {
                    healX = rnd.Next(mapSize);
                    healY = rnd.Next(mapSize);
                }

                map[healX, healY] = '♥';
            }

            for (int buff = 0; buff < buffsCount; ++buff)
            {
                int buffX = rnd.Next(mapSize);
                int buffY = rnd.Next(mapSize);

                while (map[buffX, buffY] != ' ') // If cell is not empty then generate new random values
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
                    /*if (map[row, column] == 'p') Console.ForegroundColor = ConsoleColor.Blue;
                    if (map[row, column] == 'e') Console.ForegroundColor = ConsoleColor.Red;
                    if (map[row, column] == 'h') Console.ForegroundColor = ConsoleColor.Green;
                    if (map[row, column] == 'b') Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{map[row, column]} ");*/

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
                        Console.Write($"{map[row, column]} ");
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
                        Console.Write(map[row, column] + " ");//-----------------------------------------------!!!
                    }
                    writer.WriteLine("|");
                }
            }
            Console.WriteLine($"HP: {playersHP}\nEnemies: {enemiesCount}\nPower: {playersPower}\nBuff's Time: {buffsTime}");
        }

        public static void UpdateMap()
        {
            Console.Clear();
            
            if (gameFlag)
            {
                PrintMap(map);
                Move();
            }
            else
            {
                Console.WriteLine("You loose the game :)!");
            }
            writer.WriteLine($"HP: {playersHP}\nEnemies: {enemiesCount}\nPower: {playersPower}\nBuff's Time: {buffsTime}\nMove's count: {countMoves}");
            writer.Close();

            Console.Clear();
            Process.GetCurrentProcess().Kill();           
        }

        static void Move()
        {
            countMoves++;

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    prevItem = map[playerPosition[0] - 1, playerPosition[1]];
                    map[playerPosition[0], playerPosition[1]] = ' ';
                    map[playerPosition[0] - 1, playerPosition[1]] = '▲';
                    playerPosition[0] -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    prevItem = map[playerPosition[0] + 1, playerPosition[1]];
                    map[playerPosition[0], playerPosition[1]] = ' ';
                    map[playerPosition[0] + 1, playerPosition[1]] = '▼';
                    playerPosition[0] += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    prevItem = map[playerPosition[0], playerPosition[1] - 1];
                    map[playerPosition[0], playerPosition[1]] = ' ';
                    map[playerPosition[0], playerPosition[1] - 1] = '◀';
                    playerPosition[1] -= 1;
                    break;
                case ConsoleKey.RightArrow:
                    prevItem = map[playerPosition[0], playerPosition[1] + 1];
                    map[playerPosition[0], playerPosition[1]] = ' ';
                    map[playerPosition[0], playerPosition[1] + 1] = '▶';
                    break;
            }

            }
        }
        public static void Buffs()
        {
            buffFlag = true;
            playersPower = 10;
        }

        public static void Fight()
        {
             while (enemiesHealths[enemiesKilled] > 0)
             {
                 enemiesHealths[enemiesKilled] -= playersPower;
                 playersHP -= enemiesPower;
                 
                 if (playersHP <= 0)
                 {
                     gameFlag = false;
                     break;
                 }

                 if (enemiesHealths[enemiesKilled] <= 0) // Counting killed enemies 
                 {
                     enemiesKilled++;
                     enemiesCount--;
                     break;
                 }
             }
        }

        static void Main(string[] args)
        {
            char[,] mAp = GenerateMap();
            PrintMap(mAp);
            Move2();
            Console.ReadKey();
        }
    }
}