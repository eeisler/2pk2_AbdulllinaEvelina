namespace pz_14
{
    internal class Program
    {
        static double ArifmeticProgression(int number_of_element, double result, int n)
        {
            if (number_of_element == n) // base case
            {
                return result;
            }
            return ArifmeticProgression(number_of_element + 1, result - 0.5, n); //recursive case
        }

        static double GeometricProgression(int number_of_element, double result, int n) 
        {
            if (number_of_element == n) // base case
            {
                return result;
            }
            return GeometricProgression(number_of_element + 1, result * 0.4, n); //recursive case
        }

        static double AllNumsAtoB(int A, int B)
        {
            if (A == B)
            {
                return A;
            }
            if (A < B)
            {
                Console.WriteLine($"{A}"); 
                return AllNumsAtoB(A + 1, B);
            }
            if (A > B)
            {
                Console.WriteLine(A); 
                return AllNumsAtoB(A - 1, B);
            }
            else 
            {
                return 0;
            }
        }
        /* Задание 4. Описать рекурсивную функцию Palindrom(S) логического типа, возвращающую True, если
        строка S является палиндромом (то есть читается одинаково слева направо и справа налево),
        и False в противном случае. Оператор цикла в теле функции не использовать. Вывести
        значения функции Palindrom для пяти данных строк.*/

       
        static string Reverse(string str)
        {
            return str.Length < 2 ? str : Reverse(str.Substring(1)) + str[0];  
        }
    
        static bool Palindrom(string a)
        {
            if(Reverse(a) == a)
                return true;
           
            else
                return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Arithmetic progression: {ArifmeticProgression(1, -5, 3)}");
            Console.WriteLine($"Geometric progression: {Math.Round(GeometricProgression(1, 1, 3), 2)}");
            Console.WriteLine(AllNumsAtoB(1, 10));
            Console.WriteLine(AllNumsAtoB(10, 1));
            Console.Write("Enter the string: ");
            Console.WriteLine(Palindrom(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}