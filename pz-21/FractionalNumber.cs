using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_21
{
    internal class FractionalNumber
    {
        private string sign;
        private string dividend;
        private string divider;

        public FractionalNumber()
        {
            this.sign = " ";
            this.dividend = "0";
            this.divider = "0";
        }
        public FractionalNumber(string sign)
        {
            this.sign = sign;
            this.dividend = "0";
            this.divider = "0";
        }
        public FractionalNumber(string sign, string divider)
        {
            this.sign = sign;
            this.dividend = "0";
            this.divider = divider;
        }

        public FractionalNumber(string sign, string dividend, string divider)
        {
            this.sign = sign;
            this.dividend = dividend;   
            this.divider = divider;
        }
        public string GetNumber { get { return $"Result: {this.sign} {this.dividend}/{this.divider}"; } }
    }
}
