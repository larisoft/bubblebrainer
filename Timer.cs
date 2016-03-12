using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Bubble
{   
    //this is what ticks when the user is cracking his head, trying to figure out which bubble to pick.
    class Timer
    {   
        TextBlock board;
        DispatcherTimer t;
        int seconds;
        int timeLimit;
        List<TimerWatcher> observers = new List<TimerWatcher>();
        public Timer(ref TextBlock board, int timeLimit= 10)
        { 
            this.board = board;
            this.timeLimit = timeLimit;
            t = new DispatcherTimer();
            t.Interval = new TimeSpan(0, 0, 1);
            t.Tick += (object sender, EventArgs e) =>
            {
                time_tick();
            };
        }


         
        public void time_tick()
        {
            seconds++;

            if (seconds > timeLimit)
            {
                notifyTimeExceeded();
                reset();
                t.Stop(); 
            }
            else
            {

                notifyTick();
            }
           update_view();
        }

        public void start()

        {
            t.Start();
        }

        public void update_view()
        { 
            this.board.Text = "" + (timeLimit - seconds);
        }

        public void reset()
        {
            seconds = 0;
            t.Stop();
        }

        public void notifyTick()
        {
            foreach (TimerWatcher t in observers)
            {
                t.TimeTick();
            }
        }
        public void addObserver(TimerWatcher obser)
        {
            this.observers.Add(obser);
        }

        public void pause()
        {
            t.Stop();
        }

        public void play(){
        t.Start();
        }




        public void notifyTimeExceeded()
        {
            foreach (TimerWatcher t in observers)
            {
                t.TimeExceeded();
            }
        }


        public int TimeLimit
        {
            get { return timeLimit; }
            set { timeLimit = value; }
        }

    }
}
