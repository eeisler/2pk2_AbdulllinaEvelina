using System.Text.RegularExpressions;

namespace pz_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the task (1/2): ");
            int task = Convert.ToInt32(Console.ReadLine());

            switch (task)
            {
                case 1:
                    string filepath1 = @"D:\work\new\pz-19.txt";
                    StreamReader sr = new StreamReader(new FileStream(filepath1, FileMode.OpenOrCreate, FileAccess.Read));

                    string textFromFile1 = sr.ReadToEnd();

                    sr.Close();

                    string pattern1 = @"\d{1} ([А-Яа-я]+ [А-Яа-я]{0,} [А-Яа-я]{0,}) ?\+";

                    foreach (Match match in new Regex(pattern1).Matches(textFromFile1))
                    {
                        Console.WriteLine(match.Groups[1].Value);
                    }
                    break;
                case 2:
                    string filepath2 = @"D:\work\new\connects.log";
                    StreamReader srr = new StreamReader(new FileStream(filepath2, FileMode.OpenOrCreate, FileAccess.Read));

                    string textFromFile2 = srr.ReadToEnd();

                    srr.Close();

                    string pattern2 = @"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})[\s-]*\[(\d{1,2}\/\w{3}\/\d{4})";

                    foreach (Match match in new Regex(pattern2).Matches(textFromFile2))
                    {
                        Console.WriteLine($"{match.Groups[1].Value}\t{match.Groups[2].Value}");
                    }
                    break;
            }
        }
    }
}