using System;

namespace pz_12
{
	class Program
	{
		public static void Hypotenuse(double a, double b, out double result)
		{
			result = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
		}
		
		public static void Square(double a, double b, double c, out double result)
		{
			double p = (a + b + c) / 2; // находим полупериметр
			result = Math.Sqrt(p * (p-a) * (p-b) * (p-c));
		}
		
		public static void Radius(double a, double b, double c, out double result)
		{
			result = (a + b - c) / 2;
		}
		
		public static void Main(string[] args)
		{
			Console.Write("Enter the first cathetus: ");
			double cat1 = Convert.ToDouble(Console.ReadLine());
			
			Console.Write("Enter the second cathetus: ");
			double cat2 = Convert.ToDouble(Console.ReadLine());
			
			double hypot;
			Hypotenuse(cat1, cat2, out hypot);
			Console.WriteLine("The hypotenuse equals: " + hypot);
			
			double sqr;
			Square(cat1, cat2, hypot, out sqr);
			Console.WriteLine("The square equals: " + sqr);
			
			double rad;
			Radius(cat1, cat2, hypot, out rad);
			Console.WriteLine("The radius equals: " + rad);
		}
	}
}