using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Bubble
{
    class Bubblem : Canvas
    {
        /*
         * 
         * A bubble is a canvas  in a canvas (Game Screen). it has an expansion limit, has height, width, an imageBitmap. All these are genarated randomly */
        Canvas parent; 

        //position on the screen
        double xPos;
        double yPos;


        //dimensions
        int height = 100;
        int width = 100;
         
        //image representing this
        BitmapImage image;


        Rect rect;
        private String name;

        //the Game screen (and more objects in the future perhaps) are monitoring this bubble
        List<BubbleListener> Observers = new List<BubbleListener>();

        //How far does this bubble expand
        int expansion = 2;
        public static int maxWidth = 200;
        public static int maxHeight = 200;

        public int id { get; set; }

        public int bWidth
        {
            get { return width; }
            set { width = value; }

        }


        public int bHeight
        {
            get { return height; }
            set { width = value; }
        }


        public int Expansion
        {
            get { return expansion; }
            set { expansion = value; }
        }


        public double xPosition
        {
            get { return xPos; }
            set { xPos = value; }
        }


        public double yPosition
        {
            get { return yPos; }
            set { yPos = value; }
        }

        public String Color
        {
            set
            {
                this.name = value;
                image = new BitmapImage(new Uri("pack://application:,,/Resources/" + name, UriKind.Absolute));
            }
            get
            {
                return name;
            }

        }


        public Bubblem(int width, int height, Points p, BubbleListener observer, int scale)
        {
            this.width = width;
            this.height = height;
            this.xPos = p.X;
            this.yPos = p.Y;

            this.Observers.Add(observer); 

            maxWidth = width + (expansion );
            maxHeight = height + (expansion );


            rect = new Rect(xPos, yPos, height, width);
            this.MouseDown += burst;
            
            //set cursor

        }



        public void notifyBursted()
        {
            foreach (BubbleListener obs in Observers)
            {
                obs.bursted(id);
            }
        }


        public void notifyAdded()
        {

            foreach (BubbleListener obs in Observers)
            {
                obs.added();
            }
        }


        DispatcherTimer timer;
        Boolean bursted = false;
        public void burst(object sender, EventArgs e)
        {  notifyBursted();
           /* bursted = true;
            this.image = new BitmapImage(new Uri("pack://application:,,/Resources/" + "bursted.png", UriKind.Absolute));

            using (SoundPlayer mp = new SoundPlayer(Properties.Resources.pop))
            {
                mp.Play();
               
            }
             */
             
        }


        public void puncture()
        {
            bursted = true;
        }

        protected override void OnRender(System.Windows.Media.DrawingContext dc)
        {
            //if bubble is not destroyed, expand it forward and backward, to give the illusion that it is breathing.
            if (!bursted)
            {
                if (rect.Width > maxWidth || rect.Width < width)
                {
                    expansion *= -1;
                }

                try
                {
                    rect.Width += (expansion / 2) * +1;
                    rect.Height += (expansion / 2) * +1;
                    rect.X -= (expansion / 2);
                    rect.Y -= (expansion / 2);
                }
                catch (ArgumentException es)
                {
                   
                }

            }
            else
            {
                //else move it down the screen.
                rect.Y += 20;

            }
            dc.DrawImage(image, rect);
        }


        public void alert(String message)
        {

            MessageBox.Show(message);
        }
    }
}
