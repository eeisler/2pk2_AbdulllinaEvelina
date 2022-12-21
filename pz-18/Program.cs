namespace pz_18
{
    internal class Program
    {
        enum marks { отлично, хорошо, удовлетворительно, неудовлетворительно, ужасно };
        enum seasons { зима, весна, лето, осень };

        static string[] winter = { "07.01 Рождество Христово", "23.02 День защитника Отечества", };
        static string[] spring = { "08.03 Международный женский день", "01.05 Праздник Весны и Труда", "09.05 День Победы" };
        static string[] summer = { "12.06 День России" };
        static string[] autum = { "04.11 День народного единства" };
        static void Main(string[] args)
        {
            Console.Write("Введите номер задания(1, 2): ");
            int task = Convert.ToInt32(Console.ReadLine());

            switch (task)
            {
                case 1:
                    Console.Write("Введите оценку: ");
                    int mark = Convert.ToInt32(Console.ReadLine());

                    switch (mark)
                    {
                        case 1:
                            Console.WriteLine($"Характеристика отметки 1: {marks.ужасно}"); ;
                            break;
                        case 2:
                            Console.WriteLine($"Характеристика отметки 2: {marks.неудовлетворительно}"); ;
                            break;
                        case 3:
                            Console.WriteLine($"Характеристика отметки 3: {marks.удовлетворительно}"); ;
                            break;
                        case 4:
                            Console.WriteLine($"Характеристика отметки 4: {marks.хорошо}"); ;
                            break;
                        case 5:
                            Console.WriteLine($"Характеристика отметки 5: {marks.отлично}"); ;
                            break;
                    }
                    break;

                case 2:
                    Console.Write("Введите время года: ");
                    string season = Console.ReadLine();

                    switch (season)
                    {
                        case ("зима"):
                            Console.WriteLine($"Зимние праздники:");
                            foreach (string i in winter)
                            {
                                Console.WriteLine(i);
                            }
                            break;
                        case ("весна"):
                            Console.WriteLine($"Весенние праздники: ");
                            foreach (string i in spring)
                            {
                                Console.WriteLine(i);
                            }
                            break;
                        case ("лето"):
                            Console.WriteLine($"Летние праздники: ");
                            foreach (string i in summer)
                            {
                                Console.WriteLine(i);
                            }
                            break;
                        case ("осень"):
                            Console.WriteLine($"Осенние праздники: ");
                            foreach (string i in autum)
                            {
                                Console.WriteLine(i);
                            }
                            break;
                    }
                    break;
            }
        }
    }
}
