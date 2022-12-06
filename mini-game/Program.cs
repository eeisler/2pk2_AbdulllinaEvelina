using System;
using System.Data.Common;

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
        
        public static char[,] GenerateMap()
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
                map[buffX, buffY] = '♦';
            }
            return map;
        }
        
        public static void PrintMap(char[,] map)
        {
            /* 
                * p - '▲' - white
                * e - '■' - red
                * b - '♦' - yellow
                * h - '♥' - green
            */
            for (int row = 0; row < mapSize; ++row)
            {
                if (row == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" __________________________________________________");
                } 
                else if (row == mapSize - 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" __________________________________________________");
                } 
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                    for (int column = 0; column < mapSize; ++column) 
                    {
                        if (map[row, column] == '■') Console.ForegroundColor = ConsoleColor.DarkRed;
                        if (map[row, column] == '♥') Console.ForegroundColor = ConsoleColor.DarkGreen;
                        if (map[row, column] == '♦') Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(map[row, column] + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("|");
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
        }

        static void Move()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            char prevItem = ' ';
            
            if (buffFlag) 
            {
                buffsTime++;
            }
            
            if (buffsTime >= 5 && buffFlag)
            {
                buffsTime = 0;
                buffFlag = false;
                playersPower = 5;
            }
            
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
                    playerPosition[1] += 1;
                    break;
            }

            switch (prevItem)
            {
                case '■':
                    Fight();
                    break;
                case '♦':
                    buffFlag = true;
                    Buffs();
                    break; 
                case '♥':
                    Heal();
                    break;
            }
            UpdateMap();
        }

        public static void Heal()
        {
            playersHP = 30;
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

        static int triesCounter = 1;
        public static string Hello(string s)
        {
            if (s == "start")
            {
                Console.WriteLine("Wish you luck! Enjoy the game :)");
                char[,] mAp = GenerateMap();
                PrintMap(mAp);
            }
            else
            {
                switch (triesCounter)
                {
                    case 1:
                        triesCounter++;
                        Console.WriteLine("It's ok :) When you'll be ready, please, enter {start}");
                        Hello(Console.ReadLine());
                        break;
                    case 2:
                        triesCounter++;
                        Console.WriteLine("Just enter {start}, when you're ready.");
                        Hello(Console.ReadLine());
                        break;
                    case 3:
                        triesCounter++;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Enter {start} :)");
                        Hello(Console.ReadLine());
                        break;
                    case 4:
                        triesCounter++;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("JUST. ENTER. {START}.");
                        Hello(Console.ReadLine());
                        break;
                    case 5:
                        triesCounter++;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("GET OUT!");
                        break;
                }   
            }
            return s;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to the {DO NOT ENTER START} game! If you're ready to start enter {start}"); //name of the game

            string startWord = Console.ReadLine();
            Hello(startWord);
            
            Move();
            UpdateMap();
            Console.ReadKey();
        }
    }
}