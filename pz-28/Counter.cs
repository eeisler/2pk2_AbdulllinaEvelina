using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_28
{
    class Counter
    {
        public event Delegate WaitEvent;
        public void RaiseWaitEvent(int n) => WaitEvent?.Invoke(n);
        public void Count()
        {
            for (int i = 1; i < 1000; ++i)
            {
                RaiseWaitEvent(i);
            }
        }
    }
}
