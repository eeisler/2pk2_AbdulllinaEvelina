using System;

namespace pz_9
{
	class Program
	{
		public static void Main(string[] args)
		{
			int[][] nums = new int[10][];
			Random rnd = new Random();
			
			for(int i = 0; i < 10; i++)
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
			
			int[] lasts = new int[10];
			
			for(int i = 0; i < 10; i++)
			{
				lasts[i] = nums[i][nums[i].Length-1];
			}
			
			Console.WriteLine();
			
			foreach(int i in lasts)
				{
					Console.Write(i + " ");
				}
				
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
			Console.WriteLine();
			foreach(int i in max)
				{
					Console.Write(i + " ");
				}
			
			Console.ReadKey();
		}
	}
}