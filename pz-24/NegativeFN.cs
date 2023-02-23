using pz_22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pz_23
{
    internal class NegativeFN : FractionalNumbers
    {
        int capacity;

        public int Capacity { get; set; }

        public NegativeFN(int dividend, int divider, int capacity) : base("-", dividend, divider)
        { 
            Capacity = capacity;  
        }

        override public string GetNumber { get { return $"Result: {sign}({this.dividend.ToString($"D{capacity}")}/{this.divider.ToString($"D{capacity}")})"; } }

        public object Clone()
        {
            return new NegativeFN(dividend, divider, capacity);
        }
    }
}
