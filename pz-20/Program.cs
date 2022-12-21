namespace pz_20
{
    /* 
       Напишите программу, в которой объявляется переменная типа double. В область памяти, выделенную под 
       эту переменную, запишите такие значения: в первый байт запишите значение 1, в следующие два байта 
       запишите символ ‘A’, в следующие четыре байта запишите значение 2 и в оставшийся восьмой байт 
       запишите значение 3.
    */
    unsafe internal class Program
    {
        static void Main(string[] args)
        {
            double d;

            byte* pnt = (byte*)&d;

            byte* p = pnt;
            *p = 1;
            pnt++;

            char* ch = (char*)pnt;
            *ch = 'A';
            pnt += 2;

            int* num = (int*)pnt;
            *num = 2;
            pnt += 4;

            byte* b = pnt;
            *b = 3;

            Console.WriteLine(d);
            Console.WriteLine((uint)*p--);
            Console.WriteLine((uint)*ch--);
            Console.WriteLine((uint)*num--);
            Console.WriteLine((uint)*b--);
        }
    }
}