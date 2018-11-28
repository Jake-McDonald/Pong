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
        public Random randomNumGenerator;
        public Rectangle boundingBox { get; set; }
        public int height;
        public int width;
        public int initialX;
        public int initialY;

        public Ball(int locationX, int locationY, int Width, int Height)
        {
            Console.WriteLine("New ball created");
            this.currentLocation = new Point(locationX, locationY);
            this.randomNumGenerator = new Random();
            this.boundingBox = new Rectangle(locationX, locationY, Width, Height);
            this.height = Height;
            this.width = Width;
            this.initialX = locationX;
            this.initialY = locationY;
        }
        public void MoveBall(int xMove, int yMove)
        {
            Point newPoint = new Point(currentLocation.X, currentLocation.Y);
            newPoint.Offset(xMove, yMove);
            currentLocation = newPoint;
            updateBoundingBox(xMove, yMove);
        }

        private void updateBoundingBox(int xMove, int yMove)
        {
            boundingBox = new Rectangle(currentLocation.X, currentLocation.Y, width, height);
        }

        public Point Bounce()
        {
            int randomX = randomNumGenerator.Next(0, 3);
            int randomY = randomNumGenerator.Next(0, 3);
            Point randomOffset = new Point(randomX, randomY);
            return randomOffset;
        }

        public void Reset()
        {
            currentLocation = new Point(initialX, initialY);
        }
    }
}
