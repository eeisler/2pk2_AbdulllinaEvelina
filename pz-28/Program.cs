namespace pz_28
{
    delegate void Delegate(int n);
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter c = new Counter();

            Wait wait200 = new Wait(200, "It's 200");
            Wait wait800 = new Wait(800, "It's 800");

            c.WaitEvent += wait200.waited;
            c.WaitEvent += wait800.waited;
            
            c.Count();
        }
    }
}