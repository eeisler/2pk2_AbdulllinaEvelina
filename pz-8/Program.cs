using System;

namespace pz_8
{
	class Program
	{
		public static void Main(string[] args)
		{
			Random rnd = new Random();
			int row = 4, column = 5;
			int[,] mnyam = new int[row,column];
			for(int i = 0; i < row; i++)
			{
				for(int j = 0; j < column; j++)
				{
					mnyam[i,j] = rnd.Next(0, 99);
					Console.Write(mnyam[i,j] + "\t");
				}
				Console.WriteLine();
			}
			for(int i = 0; i < column; i++)
			{
				int[] nyam = new int[row];
				for(int j = 0; j < row; j++)
				{
					nyam[j] = mnyam[j,i];
				}
				
				int maxValue = 0;
				
				foreach(int elem in nyam)
				{
					if(elem > maxValue)
					{
						maxValue = elem;
					}
				}
				
				Console.WriteLine("Max value is: {0}", maxValue + "\t");
			}
			Console.ReadKey();
			
		}
	}
}