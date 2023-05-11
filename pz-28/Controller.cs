using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_28
{    
    internal class Controller
    {
        public static bool flag = true;
        public void Controll(int c)
        {
            if(c >= 3)
            {
                Console.WriteLine("It's full");
                flag = false;
            }
        }
    }
}
