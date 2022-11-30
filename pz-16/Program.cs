namespace pz_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = @"D:\work\new\temp.txt";

            string[] allStrFromFile = File.ReadAllLines(file);

            Console.WriteLine($"Count of the lines: {allStrFromFile.Length}");

            int count_of_the_words = 0;
            for (int i = 0; i < allStrFromFile.Length; i++)
            {
                count_of_the_words += allStrFromFile[i].Split(' ').Length;
            }
            Console.WriteLine($"Count of the words: {count_of_the_words}");
        }
    }
}