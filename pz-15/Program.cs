namespace pz_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\work\new.txt";

            Console.Write("Enter the string that needed to be found: ");
            string wantedSubstr = Console.ReadLine();

            string[] allStrFromFile = File.ReadAllLines(filePath);

            // обход по каждой строке файлов
            for (int i = 0; i < allStrFromFile.Length; i++) 
            {
                if (allStrFromFile[i].Contains(wantedSubstr)) // если строка содержит подстроку
                {
                    Console.WriteLine(allStrFromFile[i]);
                }
            }

        }
    }
}