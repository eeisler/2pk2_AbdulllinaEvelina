using System.Security.Cryptography;

namespace pz_27
{
    internal class Program
    {
        /*
            Описать структуру с именем PRICE, содержащую следующие поля:
                • TOVAR — название товара;
                • MAG — название магазина, в котором продается товар;
                • STOIM — стоимость товара в руб.

            2. Написать программу, выполняющую следующие действия:
                • ввод с клавиатуры данных в массив SPISOK, состоящий из восьми элементов типа
                PRICE; записи должны быть размещены в алфавитном порядке по названиям товаров;
                • вывод на экран информации о товаре, название которого введено с клавиатуры;
                • если таких товаров нет, выдать на дисплей соответствующее сообщение.
        */

        public struct Price
        {
            internal string tovar;
            internal string mag;
            internal int stoim;

            public Price(string t, string m, int s)
            {
                this.tovar = t;
                this.mag = m;
                this.stoim = s;
            }

        }
        static void Main(string[] args)
        {
            Price[] prices = new Price[8];

            for(int i = 0; i < prices.Length; ++i)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter the product name: ");
                string a = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter the shop name: ");
                string b = Console.ReadLine();
                Console.Write("Enter the price: ");
                int c = Convert.ToInt32(Console.ReadLine());
                prices[i] = new Price(a, b, c);
            }

            Console.Write("Enter the product name you want to know about: ");
            string findTov = Console.ReadLine();
            bool flag = false;
            Price foundTovar = new Price("", "", 0);
            Console.WriteLine(findTov);

            foreach(Price thing in prices)
            {
                Console.WriteLine(thing.tovar);
                if (thing.tovar == findTov)
                {
                    flag = true;
                    foundTovar = new Price(thing.tovar, thing.mag, thing.stoim);
                    break;
                }
                else
                {
                    flag = false;
                }
            }

            if (flag)
            {
                Console.WriteLine($"The name of product: {foundTovar.tovar}");
                Console.WriteLine($"The shop: {foundTovar.mag}");
                Console.WriteLine($"the price: {foundTovar.stoim}");
            }
            else
            {
                Console.WriteLine("Incorrect name. Try again");
                Console.Write("Enter the product name you want to know about: ");
                findTov = Console.ReadLine();
            }
        }
    }
}