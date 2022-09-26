namespace pz_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Выберите задание(1-5): ");
            int task = Convert.ToInt32(Console.ReadLine());

            switch (task)
            {
                case 1:
                    // ЗАДАНИЕ 1 
                    for (int i = 0; i <= 100; i += 2)
                    {
                        Console.WriteLine(i);
                    }
                    break;

                case 2:
                    // ЗАДАНИЕ 2
                    for (char i = 'a'; i < 'a' + 5; i++)
                    {
                        Console.Write(i);
                    }
                    break;

                case 3:
                    // ЗАДАНИЕ 3
                    for (int m = 0; m < 5; m++)
                    {
                        for (int n = 0; n < 3; n++)
                        {
                            Console.Write('#');
                        }
                        Console.Write('\n');
                    }
                    break;

                case 4:
                    // ЗАДАНИЕ 4
                    for (int i = 0; i <= 100; i++)
                    {
                        if (i % 3 == 0)
                        {
                            Console.WriteLine(i);
                        }
                    }
                    break;

                case 5:
                    // ЗАДАНИЕ 5
                    for (int i = 1, j = 40; j - i > 10; i++, j--)
                    {
                        Console.WriteLine($"i = {i},\tj = {j}");
                    }
                    break;
                default:
                    Console.WriteLine("Некорректное значение");
                    break;
            }
        }
    }
}