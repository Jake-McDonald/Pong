using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;

namespace Pong
{
    public class Ball
    {
        Point currentLocation;

        public Ball(int locationX, int locationY)
        {
            Console.WriteLine("New ball created");
            this.currentLocation = new Point(locationX, locationY)
        }
        public void MoveBall(int xMove, int yMove)
        {
       
            this.currentLocation.X += xMove;
            this.currentLocation.Y += yMove;
        }
    }
}
