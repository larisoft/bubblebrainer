using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubble
{
    class GameStage
    {
        //this class decides how many bubbles there will be on the screen when its started initially, the number of  grids that should be assigned 
        //These decisions are made based on the user selected level of difficulty
        int level = 1;


        public GameStage(int difficulty)
        {
            this.level = difficulty;
        }


        //Maximum score user is allwed to reach
        public int levelHighestScore{
            get
            {
                switch (level)
                {
                    case 1:
                        return 100;
                             

                    case 2:
                            return 150;
                             
                    case 3:
                            return 200;
                            
                }

                return 200;
            }
        }


        public int time_limit
        {
            get
            {
                switch (level)
                {
                    case 1:
                        return 10;
                        
                    case 2:
<<<<<<< HEAD
                        return 16;
                     

                    case 3:
                        return 21;
=======
                        return 12;
                     

                    case 3:
                        return 15;
>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5
                    
                }

                return 10;
            }
        }

        public void reset()
        {
            level = 1;

        }



        public int Level { get{return level;} set{level = value;} }


        //How many cells should be created for each level?
        public int[] getCells(){


                switch(level){
                    case 1:

                        return new int[] { 5, 4 }; 

                    case 2:
                        return new int[] { 15, 8 };


                    case 3:
                        return new int[] { 20, 12 };
                    }

                return new int[] { 10, 5 };
            
            
        }


        
        //How many cells should we fill before the user fills the rest?
        public int GetPrefilledCells(){

            switch (level)
            {
                case 1:
                    return 5;

                case 2:
                    return 20;

                case 3:
                    return 30;

                case 4:
                    return 50;


            }
            return -1;
        }

        public void notifyMaster()
        { 

        }


        //Increase the level. Unfortunately, this will never get called as the game does not progress based on user performance. But on user choice
        public void up()
        {
            this.level += 1;

            if (level == 4 && level > levelHighestScore)
            {
                notifyMaster();
            }
        }
    }
}
