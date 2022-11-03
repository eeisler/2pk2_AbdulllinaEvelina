using System;

namespace pz_10
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Enter the string A: "); // "some text some"
			string a = Console.ReadLine();
			
			Console.Write("Enter the string B: "); // "text"
			string b = Console.ReadLine();
			
			if(a.Contains(b))
			{
				string reversed_b = "";
				
				for(int i = b.Length-1; i >= 0; i--)
				{
					reversed_b += b[i];
				}
				
				Console.WriteLine(a.Replace(b, reversed_b));
			}
			
			Console.ReadKey();
		}
	}
}