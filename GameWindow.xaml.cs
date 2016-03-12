using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Bubble
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// The main login of the game is in this class.
    /// A timer runs continuously, updating and triggering all other events.
    /// 

    //the listeners this class implements helps it monitor the behavior of different objects in the game.
    public partial class GameWindow : Window, BubbleListener, fadeObserver, ScoreObserver, PlayerObserver, TimerWatcher
    {

        //flag for whether game is paused or playing
        Boolean paused = false;

        //this is a windows canvas object layered over the screen when it supposedly 'flickers' to create a fadeOut effect
        Screen screen;

        //this is the main clock of the game. Runs at specified milliseconds, updating and triggering everything else.
        DispatcherTimer timer;

        //This is the list of bubbles that appear on the screen.
        List<Bubblem> bubbles;


        //This is supposed to be the background of the game. Though, I later went for plain white and its kinda useless right now but feel free to make yours better.
        BitmapImage background;

        //This is a special class that divides the screen into grids, where bubbles will be placed. 
        GridMaker maker;

        //This keeps track of the stage/difficulty of the game
        GameStage stage;

        //This keeps track of the number of chances a player has before he loses.
        Player player;

        //This keeps track of player's score and increments it according to current stage
        Score score;


        //Game DJ sort of
        SoundPlayer sp;

        //Not to be confused with timer above, this class is what runs before a player selects a bubble. If it counts down to its limit before the player makes a choice, the game ends.
        Timer time;
       

        //This helps us fill the generated grids randomly
        Random ran = new Random();

        //Every bubble has an id with which we identify it. 
        int id = 0;

        //This is the stack of ids. When a user selects a bubble, we compare the chosen bubble against the last added bubble id. Kinda the big idea of the game.
        Stack<int> bubbleIds = new Stack<int>();

        public GameWindow(int difficulty)
        {
            //do windows stuff
            InitializeComponent();
            this.Closing += (object sender, CancelEventArgs es) =>
            {
                time.reset();
            };
            startNewGame(difficulty);


        }
          
         
        //just stop the timers. Nothing else needs stopping when the game is paused for now
        private void pauseGame()
        {
            timer.Stop();
            time.pause();
            paused = true;
            screen.Pause();
        }

        //continue the timers
        private void continueGame()
        {
            timer.Start();
            time.play();
            paused = false;
            screen.Continue();
        }


        //game ends but do not close immediately because a message is most likely on the screen. Hence, delay for a number of seconds.
        private void close_game(int delay)
        {
            timer.Stop();
            time.reset();
            DispatcherTimer t = new DispatcherTimer();
            t.Interval = new TimeSpan(0, 0, delay);
            t.Tick+= (object sender, EventArgs se) =>{
                t.Stop();
                this.Close();
            };
            t.Start();

        }

        //game ends, do clean up.
        private void close_game()
        {
           
                time.reset();  
                this.Close();
                 
            
             
        }



         

        private void startNewGame(int difficulty)
        { 
            //set up keyboard event listeners
            this.KeyDown+= (object sender, KeyEventArgs es) => {

                switch (es.Key)
                {
                    case Key.Space:
                        if (paused)
                        {
                            continueGame();
                        }
                        else
                        {
                            pauseGame();
                        }
                        break;

                    case Key.Q:
                        quit();
                        break;
                }
            };



<<<<<<< HEAD
            //other setups  
=======
            //other setups


>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5
            stage = new GameStage(difficulty);

            time = new Timer(ref time_board, stage.time_limit);
            time.addObserver(this);
            bubbles = new List<Bubblem>();
            sp = new SoundPlayer();
            screen = new Screen(fader);
            screen.AddObserver(this);
            timer = new DispatcherTimer();
            timer.Tick += drawStuff;
<<<<<<< HEAD
            int fps = 200;
=======
            int fps = 100;
>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5
            timer.Interval = new TimeSpan(0, 0, 0, 0, fps);

            maker = new GridMaker(1200, 700, 10, 5);
            
            score = new Score(ref score_board, ref level_board, ref stage);
            score.addObserver(this);

            player = new Player(ref life_board, ref stage);
            player.addObserver(this);

            timer.Start();


            preFill();

            time.start();
        }
         

        //the question timer ticks
        public void TimeTick()
        {
            using(SoundPlayer s = new SoundPlayer()){ 

           Assembly assembly = Assembly.GetExecutingAssembly(); 
           s.Stream = assembly.GetManifestResourceStream("Bubble.Resources.tick.wav"); 
           s.Play(); 
           }

        }




<<<<<<< HEAD
        //add initial bubbles randomly 
=======
        //add initial bubbles randomly
>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5
        private void preFill()
        {

            DispatcherTimer ti = new DispatcherTimer();
            ti.Tick += (object sender, EventArgs e) =>
            {
                if (bubbleIds.Count > stage.GetPrefilledCells())
                {
                    ti.Stop();
                }
                else
                {
                    addBubble();
                }
            };

<<<<<<< HEAD
            ti.Interval = new TimeSpan(0, 0, 0, 0, 400);
=======
            ti.Interval = new TimeSpan(0, 0, 0, 0, 300);
>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5
            ti.Start();


        }

        //question timer exceeded limit
        public void TimeExceeded()
        {

            lost();
        }


        //add a bubble to the screen... assign it an id...
        public void addBubble()
        {
            //color of bubble selected randomly
            ColorGenerator col = new ColorGenerator();
            
            //getting size of bubble. we get half the size first, and then get a number between 0 and half and add to it. This is to ensure that 
            //while the sizes are random, no bubble is too small (i.e. below half).
            int   half = Convert.ToInt32(maker.blockWidth) / 2;
            int size = ran.Next(half); 
            size += half;
            
                //get an empty grid
                Points p = maker.getEmptyGrid();

                if (p != null)
                {
                    Bubblem b = new Bubblem(size, size, p, this, 1);
                    b.id = id;
                    id += 1;
                    b.Expansion = ran.Next(3) + 1;
                    b.Color = col.GetColor(ran.Next(5));
                    bubbles.Add(b); 
                    bubbleIds.Push(b.id);
                    board.Children.Add(b);
                }
                board.InvalidateVisual();
            

        }


       
       public void lost()
       {
           screen.fadeInOut("Game Over!", 4, "Score: "+ score.Score_No); ;
           close_game(3);
           
            
       }



       public void quit()
       {
           time.reset();
           screen.fadeInOut("Dumb Quitter!", 4);
           close_game(3); 
       }
         
         
        //just for debugging
        private void log(String message)
        {
            Console.WriteLine(message);
        } 


        //The user has clicked on a bubble. 
        //@ToDo change the name of this method
        public void bursted(int id)
        {   
            //if the last bubble added to the screen is the same as the bubble clicked, score the user
            if (bubbleIds.Peek() == id)
            {
                fadeOut();
                score.up();
                player.resetTriesLeft();
                time.reset();
                time.start();
            }
            else
            {
                wrong();
            }
        }

        //The user pressed 'q'
        public void stopGame(object sender, RoutedEventArgs e)
        {
            screen.fadeInOut("Quitter", 3);
            close_game(3); 

        }


        //THe user has gotten to the highest level possible.
        //@ToDO change this method's name.
        public void levelChanged()
        {
            screen.fadeInOut("Brain Master!", 5); 
            level_board.Text = stage.Level + "";
            close_game(5);
        }

         
       private void  playFailSound(){ 
           Assembly assembly = Assembly.GetExecutingAssembly();

           Stream stre = assembly.GetManifestResourceStream("Bubble.Resources.wrong.wav"); 
           SoundPlayer p = new SoundPlayer(stre);
           p.Play();
        }


        //the user selected the wrong bubble
        public void wrong()
        {
            playFailSound();
            player.down();
            

        }



        //a new bubble is added.
        public void added()
        {

        } 


        //this refreshes the screen, showing the new positions of all objects on the canvas
        private void drawStuff(object sender, EventArgs e)
        {
            foreach(Canvas c in board.Children){

                c.InvalidateVisual();
            }
        }

         


        public void fadeStarted()
        {

        }

        //in the middle of the fade, we add a new bubble so the player doesnt see where it appears
        public void fadeMiddle()
        { 
             addBubble();
        }

        public void fadeCompleted()
        {
          
        }


        //start the fade.
        private void fadeOut()
        {
            if (!screen.fading)
            {
                screen.fadeInOut();
            } 
        }



         
    }
}
