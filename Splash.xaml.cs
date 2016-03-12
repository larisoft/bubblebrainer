using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bubble
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        public Splash()
        {
            InitializeComponent();
            create_shortcut();
        }


        


        //start game in easy mode
        public void gameStartEasy(object sender, RoutedEventArgs e)
        {
            new GameWindow(1).Show();
        }

        //medium
        public void gameStartMedium(object sender, RoutedEventArgs e)
        {
            new GameWindow(2).Show();
        }

        //hard
        public void gameStartHard(object sender, RoutedEventArgs e)
        {
            new GameWindow(3).Show();
        }
  

        //close game
        public void close(object sender, RoutedEventArgs se)
        {
            this.Close();
        }

        //create shortcut
        public void create_shortcut()
        {
            String location = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            String linkExePath = Assembly.GetEntryAssembly().Location;

            String title = "Bubble Brainer";
            String description = "Launch Bubble Brainer";

           new ShortCutMaker().add_desktop_shortcut(location, linkExePath, title, description);
        }
    }
}
