using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_28
{
    internal class Wait
    {       
        public int number;
        public string message;

        public int Number
        {
            get { return number; }
            set 
            {
                if (value > 1000)
                {
                    value = 1000;
                    number = value;
                }
                else 
                    number = value; 
            }
        }
        public Wait(int n, string m) //entering the number to wait
        {
            Number = n;
            message = m;
        }

        public void waited(int n)
        {
            if(n == number)
            {
                Console.WriteLine(message);
            }
        }
    }
}
