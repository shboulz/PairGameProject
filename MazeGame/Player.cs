using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarker;
        private ConsoleColor PlayerColor;


        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = "§";
            PlayerColor = ConsoleColor.Red;
        }

        public void Draw()
        {
            Console.ForegroundColor = PlayerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(PlayerMarker);
            Console.ResetColor();

        }
    }
}
