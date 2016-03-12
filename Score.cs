using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bubble
{
    class Score
    {

        private TextBlock ScoreBoard;
        private TextBlock LevelBoard;

        private List<ScoreObserver> observers = new List<ScoreObserver>();
        private GameStage stage;
        int score;

        public int Score_No {
            get { return this.score; } 
            set { this.score = value; } 
        }


        public Score(ref TextBlock board, ref TextBlock level, ref GameStage stge)
        {
            this.ScoreBoard = board;
            this.LevelBoard = level;
            this.stage = stge;
        }


        public void addObserver(ScoreObserver obser)
        {
            this.observers.Add(obser);
        }


        private void notifyNewLevel(){
            foreach(ScoreObserver s in observers){

                s.levelChanged();
            }
        }

        public void up()
        {
            if(score>=stage.levelHighestScore){
                notifyNewLevel();
            }
            switch (stage.Level)
            {
                case 1:

                    score += 5;
                    break;
                case 2:
                    score += 10;
                    break;
                case 3:
                    score += 15;
                    break;

                default:
                    score += 10;
                    break;
                 
            }
            update();
        }

        public void reset()
        {
            this.score = 0;
            update();
        }
        private void update(){
            Console.WriteLine("Should update " + score);
            ScoreBoard.Text = ""+score;
            LevelBoard.Text = ""+stage.Level;
        }

        }
       
    
}
