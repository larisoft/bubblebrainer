using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubble
{
    interface TimerWatcher
    {
        void TimeExceeded();


        void TimeTick();
    }
}
