using System;

namespace pz_11
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Enter the text: "); //example: sentence1.sentence2.sentence3.sentense4
			string text = Console.ReadLine();
			
			string[] sentence_arr = text.Split('.');
			
			string first = sentence_arr[0];
			string last = sentence_arr[sentence_arr.Length - 1];
			
			sentence_arr[0] = last;
			sentence_arr[sentence_arr.Length - 1] = first;
			
			string new_text = string.Join(".", sentence_arr);
			
			Console.Write("\nResult: ");
			Console.WriteLine(new_text);
		}
	}
}