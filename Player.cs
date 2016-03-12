using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bubble
{
    class Player
    {
        public int triesLeft;
        TextBlock board;
        List<PlayerObserver> observers = new List<PlayerObserver>();
        GameStage stage;
        public Player(ref TextBlock lifeboard, ref GameStage stage)
        {
            this.board = lifeboard;
            this.stage = stage;
            resetTriesLeft();
        }



        public void reset()
        {
            resetTriesLeft();
        }

        public void addObserver(PlayerObserver obser)
        {
            this.observers.Add(obser);
        }

        public void resetTriesLeft()
        {
            switch (stage.Level)
            {
                case 1:
                    triesLeft = 5;
                    break;
                case 2:
                    triesLeft = 4;
                    break;

                case 3:
                    triesLeft = 3;
                    break;

            }

            update();
            
        }

        public void down()
        {
            triesLeft -= 1;
           
            if (triesLeft < 0)
            {
                notifyLost();
            }
            update();
        }

        private void update()
        {
            this.board.Text = triesLeft + "";
        }

        public void notifyLost()
        {
            foreach(PlayerObserver p in observers){
                p.lost();
            }
        }
    }
}
