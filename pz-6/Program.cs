namespace pz_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 15;
            int counter = 1;

            while (counter <= n) 
            {
                int result = Convert.ToInt32(Math.Pow(counter, 2));
                if (result < n)
                {
                    Console.WriteLine(result);
                    counter++;
                }
                else 
                {
                    break;
                }
                
            }
        }
    }
}