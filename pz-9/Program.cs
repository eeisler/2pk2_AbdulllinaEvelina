using System;
using System.Collections.Generic;

namespace pz_9
{
	class Program
	{
		public static void Main(string[] args)
		{
			int[][] nums = new int[10][];
			Random rnd = new Random();

            Console.WriteLine("Task 1-2: ");

            for (int i = 0; i < 10; i++)
			{
				int length = rnd.Next(3, 10);
				int[] mun = new int[length];

				for(int j = 0; j < length; j++)
				{
					mun[j] = rnd.Next(3, 10);
				}
				
				nums[i] = mun;
			}
			
			foreach(int[] i in nums)
			{
				foreach(int j in i)
				{
					Console.Write(j + " ");
				}
				Console.WriteLine();
			}

            Console.WriteLine("\nTask 3: ");

            int[] lasts = new int[10];
			
			for(int i = 0; i < 10; i++)
			{
				lasts[i] = nums[i][nums[i].Length-1];
			}
			
			foreach(int i in lasts)
				{
					Console.Write(i + " ");
                    Console.WriteLine();
                }

            Console.WriteLine("\nTask 4: ");

            int[] max = new int[10];
			
			for(int i = 0; i < 10; i++)
			{
				int maxValue = 0;
				
				foreach(int elem in nums[i])
				{
					if(elem > maxValue)
					{
						maxValue = elem;
					}
				}
				max[i] = maxValue;
            }

			foreach(int i in max)
				{
					Console.Write(i + " ");
                    Console.WriteLine();
                }

            Console.WriteLine("\nTask 5: ");

			for (int i = 0; i < 10; i++)
			{
				int MAX = max[i];
				int first = nums[i][0];
				for (int j = 0; j < nums[i].Length; j++)
				{
					if (nums[i][j] == MAX)
					{
						nums[i][0] = MAX;
						nums[i][j] = first;
					}
				}
			}
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < nums[i].Length; j++)
                {
					Console.Write(nums[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nTask 6");

            int val = 0;
            for (int a = 0; a < 10; a++)
            {
                for (int i = 0, j = nums[a].Length - 1; i < j; i++, j--)
                {
                    val = nums[a][i];
                    nums[a][i] = nums[a][j];
                    nums[a][j] = val;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < nums[i].Length; j++)
                {
                    Console.Write(nums[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nTask 7");

			int[] average = new int[10];

			for (int i = 0; i < 10; i++) 
			{
                int sum = 0;
                for (int j = 0; j < nums[i].Length; j++) 
				{
                    sum += nums[i][j];
                }
				average[i] = sum / nums[i].Length;
				Console.WriteLine(average[i]);
            }
            Console.ReadKey();
		}
	}
}