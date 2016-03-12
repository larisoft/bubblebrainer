using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubble
{/*
  * this class generates colors for bubbles randomly 
  * 
  */
    class ColorGenerator
    {
        Random ran;

        public ColorGenerator()
        {
            ran = new Random();
        }


        public String  GetColor(int randomColor)
        { 

            switch (randomColor)
            {
                case 0:
<<<<<<< HEAD
                    //return "black.png";
                    return "green.png";
                    break;

                case 1:
                    //return "blue.png";
                    return "white.png";
=======
                    return "black.png";
                    break;

                case 1:
                    return "blue.png";
>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5
                    break;

                case 2:
                    return  "green.png";
                    break;

                case 3:
                    return "white.png";
                    break;

                default:
<<<<<<< HEAD
                    return "green.png";
=======
                    return "yellow.png";
>>>>>>> 13d3f5e214eb2bcc5f1e40555ebe82011bdb04a5
                    break;

                    

            }

        }
    }
}
