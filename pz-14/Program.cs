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
                Console.WriteLine(A);
                return AllNumsAtoB(A + 1, B);
            }
            else 
            {
                return 0;
            }
            
        }


        static void Main(string[] args)
        {
            Console.WriteLine(ArifmeticProgression(1, -5, 3));
            Console.WriteLine(Math.Round(GeometricProgression(1, 1, 3)));
            Console.WriteLine(AllNumsAtoB(1, 10));
        }
    }
}