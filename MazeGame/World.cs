using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    class World
    {
        // this will store our grid
        private string[,] Grid;
        //this will store the rows of our grid
        private int Rows;
        //this will store the cols of our grid
        private int Cols;


        public World(string[,] grid)
        {

            Grid = grid;
            Rows = grid.GetLength(0);
            Cols = grid.GetLength(1);
        }

        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    //Rows come before the colums in our Grid[,]
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);

                    if (element == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    Console.Write(element);
                }
            }
        }
        // Tracking if there are items in the location
        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }

        public bool isPositionWalkable(int x, int y)
        {
            // We are checking bounds here
            if (x < 0 || y < 0 || x >= Cols || y>= Rows)
            {
                return false;
            }
            //We are checking if the grid is walkable with spaces (" ")
            return Grid[y, x] == " " || Grid[y, x] == "X";
        }
    }
}
