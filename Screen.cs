using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Bubble
{
    class Screen
    {
        //this class blacks out the screen everytime the user selects the right bubble, or when the user quits, or wins the game
        //the fade object which is a canvas, is layered directly over the game screen. So all we actually have to do is make it visible,
        //and make its background color black.
        //very basic right? I know.
        Canvas fader = null;
<<<<<<< HEAD
        Brush bgColor = new SolidColorBrush(Colors.White);
        Brush txtColor = new SolidColorBrush(Colors.Black);
=======

>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5
        //Text to be displayed during pause 
        TextBlock pauseText = new TextBlock();


        List<fadeObserver> observers = new List<fadeObserver>();
        public Screen(Canvas c)
        {
            this.fader = c;
        }


        public void AddObserver(fadeObserver f)
        {
            this.observers.Add(f);
        }

        public Boolean fading = false;

        //fade out. No message
        public void fadeInOut()
        {
            fader.Visibility = Visibility.Visible;
<<<<<<< HEAD
            fader.Background = bgColor;
=======
            fader.Background = new SolidColorBrush(Colors.Black);
>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5
            DispatcherTimer fadeTimer = new DispatcherTimer();
            fadeTimer.Interval = new TimeSpan(0,0,0,0,200);
            int counter = 0;
            fadeTimer.Tick += (object sender, EventArgs s) =>
            {
               

                if (counter == 0)
                {
                   
                }
                else if (counter == 1)
                {
                    notifyFadeMiddle(); 
                }
                else if(counter > 2)
                {
                    fadeTimer.Stop();
                    fadeTimer = null;
                    GC.Collect();
                    counter = 0;
                    fading = false;
                    fader.Visibility = Visibility.Collapsed;
                }
                counter++;
            };
            fadeTimer.Start();
            fading = true;

        }


        //fadeOut with message
        public void fadeInOut(String title, int seconds, String message = "")
        {

            fader.Visibility = Visibility.Visible;
<<<<<<< HEAD
            fader.Background = bgColor;
=======
            fader.Background = new SolidColorBrush(Colors.Black);
>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5
            DispatcherTimer fadeTimer = new DispatcherTimer();
            fadeTimer.Interval = new TimeSpan(0, 0, 0, seconds, 0);


            TextBlock block = new TextBlock();
            TextBlock body = new TextBlock();
            block.Text = title;
            body.Text = message;

            block.FontSize = 60;
            body.FontSize = 20;

<<<<<<< HEAD
            block.Foreground = txtColor;
            body.Foreground = txtColor;
=======
            block.Foreground = new SolidColorBrush(Colors.White);
            body.Foreground = new SolidColorBrush(Colors.White);
>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5

            block.FontFamily = new FontFamily("Arial");
            body.FontFamily = new FontFamily("Arial");

            block.HorizontalAlignment = HorizontalAlignment.Center;
            body.HorizontalAlignment = HorizontalAlignment.Center;

            block.VerticalAlignment = VerticalAlignment.Center;
            body.VerticalAlignment = VerticalAlignment.Center;


            StackPanel p = new StackPanel();
            p.Children.Add(block);
            p.Children.Add(body); 

            Canvas.SetLeft(p, 550);
            Canvas.SetTop(p, 350);
            fader.Children.Add(p);

            fader.InvalidateVisual();
            

            fadeTimer.Tick += (object sender, EventArgs e) =>
            {
                block.Text = "";
                fader.Visibility = Visibility.Collapsed;
            };
            fadeTimer.Start();
            fading = true;

        }


        //Pause
        public void Pause()
        {

            fader.Visibility = Visibility.Visible;
<<<<<<< HEAD
            fader.Background = bgColor;
=======
            fader.Background = new SolidColorBrush(Colors.Black); 
>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5

            pauseText = new TextBlock();
            pauseText.Text = "PAUSED";
            pauseText.FontSize = 60;
<<<<<<< HEAD
            pauseText.Foreground = txtColor;
=======
            pauseText.Foreground = new SolidColorBrush(Colors.White);
>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5
            pauseText.FontFamily = new FontFamily("Arial");
            pauseText.HorizontalAlignment = HorizontalAlignment.Center;
            pauseText.VerticalAlignment = VerticalAlignment.Center;
            Canvas.SetLeft(pauseText, 550);
            Canvas.SetTop(pauseText, 350);
            fader.Children.Add(pauseText);
            fader.InvalidateVisual();
            
            fading = true;

        }



        //Continue Game
        public void Continue()
        {
             
            fader.Visibility = Visibility.Collapsed;
            fader.Children.Remove(pauseText);
            fading = false;

        }



        int counter = 0;
        private void showMessage(object sender, EventArgs e)
        {
            counter += 1;
            if (counter < 10)
            {

            }
            else
            {
              
            }

        }

        //redundant method. 
        int fadeOpacity = 254;
        private void changeOpacity(Object sender, EventArgs e)
        {
            string opacity = fadeOpacity.ToString("X"); //fadeOpacity.ToString().PadLeft(2,'0'); 
            String color = "#" + opacity+"000000";
            log(color);
            try
            {
                fader.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
            }
            catch (Exception es)
            {
            
                log(es.Message);
            }
           // log("#"+opacity+"0000" );
            fadeOpacity += 10;
            if (fadeOpacity > 255)
            {
               DispatcherTimer d = (DispatcherTimer)sender;
               d.Stop();
                fadeOpacity = 0;
                fading = false;    
                notifyFadeMiddle();
                fader.Background = new SolidColorBrush(Colors.Transparent);
                fader.Visibility = Visibility.Collapsed;
            }
        }

        //redundant method. 
        private void message(String message)
        {
            TextBlock block = new TextBlock();
            block.Text = message;
            block.FontSize = 30;
            block.Foreground = new SolidColorBrush(Colors.White);
            block.FontFamily = new FontFamily("Arial");
            block.HorizontalAlignment = HorizontalAlignment.Center;
            block.VerticalAlignment = VerticalAlignment.Center;
            fader.Children.Add(block);
        }

        //half into the blackout, tell the game to add a new bubble. The player can't see jack right now.
        private void notifyFadeMiddle()
        {
            foreach(fadeObserver i in observers){
                i.fadeMiddle();
            }

        }

        private void log(String message)
        {
            Console.WriteLine(message);
        }

         
    }
}
