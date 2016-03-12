using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bubble
{
    //divide the screen into given rows and columns
    //get randomly available space each time
    class GridMaker
    {
      
        Points[,] Cells; 
        double Width;
        double Height;
        int columns;
        int rows;
           int no_of_cells;

       public double blockWidth { get; set; }

       public double blockHeight { get; set; }

       public double[] blockSize { get { return new double[] { blockWidth, blockHeight }; }  }

        public GridMaker(double ScreenWidth, double ScreenHeight, int columns, int rows)
        {
            this.Width = ScreenWidth;
            this.Height = ScreenHeight; 
            this.columns = columns;
            this.rows = rows;
            this.no_of_cells = (int) (columns * rows);
            CreateGrids();

        }


        //the concept here is; keep filling all the cells in each row. When you get to the end of the row, come back to (0, y). 
        public void CreateGrids()
        {
            //keep track of x as it increases;
            double filledWidth = 0;

            //keep track of y as it increases;
            double filledHeight= 0;
            Points p = null;
             blockWidth = Width / (double) columns;
            
             double margin = blockWidth/Double.Parse(""+2);
             blockHeight = Height / (double)rows;
            Cells = new Points[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                //position to start at exactly 0 when block width is added
                filledWidth=margin-blockWidth ;

                if(i>0)  filledHeight += blockHeight;
                for(int j = 0; j < columns; j++){
                p = new Points(); 
                p.X = (filledWidth + blockWidth);
                p.Y = (filledHeight);
                filledWidth = p.X;
                filledHeight = p.Y;
                Cells[i,j] = p;
                    
                }
                
            }

            int counter = 0;
            foreach(Points poi in Cells){
                 
                    log(counter+" . X Point: " + poi.X + "  Y Point: " + poi.Y);
                    counter++;
                 
            }



             
        }


        //mark all the cells as empty
        public void reset()
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j].Filled = false;
                }
            }
        }

        Random ran = new Random();

        //get a random grid that is empty. i.e. contains no bubble
        public Points getEmptyGrid()
        {
            try
            {
                List<int[]> points = getAvailableGrids();

                log("Left Grids " + points.Count);
                int count = points.Count;

                int select = ran.Next(count);
                int row = points[select][0];
                int column = points[select][1];


                Points selectedGrid = Cells[row, column];
                Cells[row, column].Filled = true;
                return selectedGrid;
            }
            catch (Exception e)
            {

            }

            return null;
        }


        private void alert(String message)
        {
            MessageBox.Show(message);
        }

        private List<int[]> getAvailableGrids()
        {
            List<int[]> result = new List<int[]>();



            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if (!Cells[i, j].Filled)
                        result.Add(new int[] { i, j });
                }
            }

            return result;

        }


        private void log(String message)
        {
            Console.WriteLine(message);
        }
    }
}
