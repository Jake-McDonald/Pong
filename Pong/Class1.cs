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
        public Point currentLocation { get; set; }

        public Ball(int locationX, int locationY)
        {
            Console.WriteLine("New ball created");
            this.currentLocation = new Point(locationX, locationY);
        }
        public void MoveBall(int xMove, int yMove)
        {
            Point newPoint = new Point(currentLocation.X, currentLocation.Y);
            newPoint.Offset(xMove, yMove);
            currentLocation = newPoint;
        }
    }
}
