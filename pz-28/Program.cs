using System;

namespace pz_28
{
    delegate void Delegate1(int n);
    delegate void Delegate2(int c);
    internal class Program
    {
        public static event Delegate2 ControllVisitor;
        public static void RaiseControllEvent(int c) => ControllVisitor?.Invoke(c);
        static void Main(string[] args)
        {       
            Console.Write("Enter the number of the task(1/5): ");
            int answer = Convert.ToInt32(Console.ReadLine());
            
            switch (answer)
            {
                case 1:
                    Counter c = new Counter();

                    Wait wait200 = new Wait(200, "It's 200");
                    Wait wait800 = new Wait(800, "It's 800");

                    c.WaitEvent += wait200.waited;
                    c.WaitEvent += wait800.waited;

                    c.Count();
                    break;

                case 5:
                    Controller controller = new Controller();
                    while (Visitor.counter < 3)
                    {
                        Console.Write("Enter the name: ");
                        string name = Console.ReadLine();
                        Visitor v = new Visitor(name);
                        Visitor.counter++;
                    }
                    ControllVisitor += controller.Controll;
                    RaiseControllEvent(Visitor.counter);
                    break;
            }

        }
    }
}