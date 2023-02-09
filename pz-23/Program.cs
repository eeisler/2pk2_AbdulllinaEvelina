namespace pz_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NegativeFN a = new NegativeFN(1, 3, 4);
            NegativeFN b = new NegativeFN(25, 18, 3);
            NegativeFN c = new NegativeFN(52, 8, 5);
            NegativeFN d = new NegativeFN(96, 7, 2);

            Console.WriteLine(a.GetNumber);
            Console.WriteLine(b.GetNumber);
            Console.WriteLine(c.GetNumber);
            Console.WriteLine(d.GetNumber);
        }
    }
}