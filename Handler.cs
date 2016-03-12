using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Bubble
{
    //this class imitates the handler class in android which allows one to schedule tasks easily. 
    class Handler
    {
        public Handler(int seconds)
        {

            DispatcherTimer t = new DispatcherTimer();
            t.Tick += (object sender, EventArgs es) =>
            {
                
            };
            t.Interval = new TimeSpan(0, 0, seconds);
            t.Start();

        }


        public void run()
        {

        }
    }
}
