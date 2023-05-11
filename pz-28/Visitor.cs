using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_28
{
    internal class Visitor
    {
        public static int counter = 0;
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Visitor(string name) 
        { 
            Name = name;
            counter++;
        }
    }
}
