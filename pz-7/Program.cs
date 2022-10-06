namespace pz_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            int sum = 0;

            Console.Write("Enter 10 numbers: ");
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());

                if (array[i] == 0)
                {
                    break;
                }

                sum += array[i];
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}