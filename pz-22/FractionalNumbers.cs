using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_22
{
    public class FractionalNumbers
    {
        public static int positiveCounter = 0;
        public static int negativeCounter = 0;

        protected string sign;
        protected int dividend;
        protected int divider = 1;

        public string Sign
        {
            get { return sign; }
            set
            {
                if (value == "+" || value == "-")
                {
                    sign = value;
                }
                else
                {
                    sign = "+";
                }
            }
        }

        public int Divider
        {
            set 
            {
                if (value != 0)
                {
                    divider = value;
                }
                else if (value == 0)
                {
                    Console.WriteLine($"Divider can't be 0\nDivider equals {this.divider}");
                }
            }
        }

        virtual public string GetNumber { get { return $"Result: {this.sign}({this.dividend}/{this.divider})"; } }

        public FractionalNumbers(string sign, int dividend, int divider)
        {
            this.Sign = sign;
            this.dividend = dividend;
            this.Divider = divider;
            if (this.sign == "+")
            {
                positiveCounter++;
            }
            else
            {
                negativeCounter++;
            }
        }           
    }
}
