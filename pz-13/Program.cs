namespace pz_13
{
    internal class Program
    {
        static char FrequentlyUsedSymbol(char[] s)
        {
            int counter = 0;
            char symbol = s[0];

            for (int i = 0; i > s.Length; ++i)
            {
                int internalcounter = 0;

                for(int j = 0; j < s.Length; ++j)
                {
                    if (s[j] == s[i])
                    { 
                        internalcounter++;
                    }

                }

                if (internalcounter > counter)
                {
                    counter = internalcounter;
                    symbol = s[i];
                }
            }
            return symbol;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter some symbols: ");
            string[] strs = Console.ReadLine().Split();

            char[] symbols = new char[strs.Length];

            for (int i = 0; i < strs.Length; ++i)
            {
                symbols[i] = Convert.ToChar(strs[i]);
            }

            Console.WriteLine(FrequentlyUsedSymbol(symbols));
        }
    }
}