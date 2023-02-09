namespace pz_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "/continue";

            while(word != "/stop")
            {
                Console.Write("Enter the sign: ");
                string sign = Console.ReadLine();

                EnterDividend:
                    Console.Write("Enter the dividend: ");
                    int dividend = 1;
                    try
                    {
                        dividend = Convert.ToInt32(Console.ReadLine());
                    } 
                    catch 
                    {
                        Console.WriteLine("Error: wrong dividend");
                        goto EnterDividend;
                    }

                EnterDivider:
                    Console.Write("Enter the divider: ");
                    int divider = 1;
                    try
                    {
                        divider = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Error: wrong divider");
                        goto EnterDivider;
                    }

                FractionalNumbers d = new FractionalNumbers(sign, dividend, divider);

                Console.WriteLine(d.GetNumber);

                Console.Write("Enter the command(/continue or /stop): ");
                word = Console.ReadLine();
            }

            Console.WriteLine($"Positive numbers count: {FractionalNumbers.positiveCounter}");
            Console.WriteLine($"Negative numbers count: {FractionalNumbers.negativeCounter}");
        }
    }
}