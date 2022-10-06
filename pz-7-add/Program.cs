namespace pz_7_add
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] array = new int[100];

            for (int i = 0; i < array.Length; i++)
            { 
                array[i] = rnd.Next(0, 20);
                Console.Write(array[i] + " ");
            }

            Array.Sort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] != array[i + 1])
                {
                    if (array[i + 1] != array[i + 2])
                    {
                        Console.WriteLine($"\n{array[i + 1]} is unique");
                    }
                }  
            }
        }
    }
}