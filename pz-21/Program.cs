namespace pz_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the sign: ");
            string sign = Console.ReadLine();

            Console.Write("Enter the dividend: ");
            string dividend = Console.ReadLine();

            Console.Write("Enter the divider: ");
            string divider = Console.ReadLine();

            FractionalNumber a = new FractionalNumber();
            FractionalNumber b = new FractionalNumber(sign);
            FractionalNumber c = new FractionalNumber (sign, divider);
            FractionalNumber d = new FractionalNumber(sign, dividend, divider);

            if (sign == "" & dividend == "" & divider == "")
            {
                Console.WriteLine(a.GetNumber);
            }

            else if (dividend == "" & divider == "")
            {
                Console.WriteLine(b.GetNumber);
            }

            else if (dividend == "")
            {
                Console.WriteLine(c.GetNumber);
            }

            else
            {
                Console.WriteLine(d.GetNumber);
            }
           
        }
    }
}