using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_20_2d_semestr
{
    internal class Program
    {
        static string ChangeRegistr(string str)
        {
            char[] letters = str.ToCharArray();
            string result = "";

            for (int i = 0; i < str.Length; ++i)
            {
                if (Char.IsUpper(letters[i]))
                {
                    result += Char.ToLower(letters[i]);
                }

                else if (Char.IsLower(letters[i]))
                {
                    result += Char.ToUpper(letters[i]);
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter the word: ");
            string word = Console.ReadLine();

            Console.WriteLine(ChangeRegistr(word));
            Console.ReadKey();
        }
    }
}
