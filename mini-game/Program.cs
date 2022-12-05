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
        static int[] playerPosition = new int[2] {12, 12};
        static char[,] map = new char[mapSize, mapSize]; 
        static int enemiesCount = 10;
        static int healingsCount = 5;
        static int buffsCount = 3;
        static bool gameFlag = true;
        
        public static char[,] GenerateMap()
        {
            //нужно запомнить координаты объектов, чтобы обновлять карту.CreateCoords(); - i don't know this 
            //каждый раз выводится разное количество объектов 
            for (int row = 0; row < mapSize; ++row)
            {
                for (int column = 0; column < mapSize; ++column)
                {
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

                while (map[enemyX, enemyY] != ' ')
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

                while (map[healX, healY] != ' ')
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

                while (map[buffX, buffY] != ' ')
                {
                    buffX = rnd.Next(mapSize);
                    buffY = rnd.Next(mapSize);
                }
                map[buffX, buffY] = '♦';
            }
            return map;
        }
        
        public static void PrintMap(char[,] map)//done
        {
            /* 
            * p - '▲' - white
            * e - '■' - red
            * b - '♦' - yellow
            * h - '♥' - blue
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
                        if (map[row, column] == '▲') Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        if (map[row, column] == '■') Console.ForegroundColor = ConsoleColor.DarkRed;
                        if (map[row, column] == '♥') Console.ForegroundColor = ConsoleColor.DarkGreen;
                        if (map[row, column] == '♦') Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(map[row, column] + " ");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("|");
                }
            }
        }
        public static void UpdateMap()//to do
        {
            /*
             * Чтобы после проигрыша закрывалось поле и выводилось сообщение о проигрыше
             * В начале игры выводилось приветственное сообщение, а поле не выводилось пока нет команды start
             */
            Console.Clear();

        }
        static void Move()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    map[playerPosition[0], playerPosition[1]] = ' ';
                    map[playerPosition[0] + 1, playerPosition[1]] = '▲';
                    break;
                case ConsoleKey.DownArrow:
                    map[playerPosition[0], playerPosition[1]] = ' ';
                    map[playerPosition[0] - 1, playerPosition[1]] = '▼';
                    break;
                case ConsoleKey.LeftArrow:
                    map[playerPosition[0], playerPosition[1]] = ' ';
                    map[playerPosition[0], playerPosition[1] - 1] = '◀';
                    break;
                case ConsoleKey.RightArrow:
                    map[playerPosition[0], playerPosition[1]] = ' ';
                    map[playerPosition[0], playerPosition[1] + 1] = '▶';
                    break;
            }
        }
        public static void Buffs()//in process
        {
            if (map[playerPosition[0], playerPosition[1]] == '♦')
            {
                buffFlag = true;
                playersPower = 10;
            }
        }

        public static void Fight()//in process
        {
            if (map[playerPosition[0], playerPosition[1]] == '■')
            {
                 while (enemysHP > 0)
                 {
                     enemysHP -= playersPower;
                     playersHP -= enemiesPower;
                 }
                 if (playersHP <= 0)
                 {
                     gameFlag = false;
                 }
                 else 
                 {
                     enemiesCount--;
                 }
            }
        }

        static int triesCounter = 1;
        public static string Hello(string s)//i was just bored :)
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
                        Console.WriteLine("GET F*CKING OUT!");
                        break;
                }   
            }
            return s;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to the {game's name}! If you're ready to start enter {start}"); //name of the game

            string startWord = Console.ReadLine();
            Hello(startWord);
            
            Move();
            UpdateMap();
            Console.ReadKey();
        }
    }
}