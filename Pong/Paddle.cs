using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Pong
{
    public class Paddle
    {
        public Point currentLocation { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public Rectangle boundingBox { get; set; }

        public Paddle(int Height, int Width, int LocationX, int LocationY)
        {
            this.height = Height;
            this.width = Width;
            this.currentLocation = new Point(LocationX, LocationY);
            this.boundingBox = new Rectangle(LocationX, LocationY, Width, Height);
        }

        private void MovePaddle(int yMove)
        {
            Point newPoint = new Point(currentLocation.X, currentLocation.Y);
            newPoint.Offset(0, yMove);
            currentLocation = newPoint;
            updateBoundingBox();
        }

        public void MovePaddleUp(int yMove)
        {
            MovePaddle(-1 * yMove);
        }

        public void MovePaddleDown(int yMove)
        {
            MovePaddle(yMove);
        }

        private void updateBoundingBox()
        {
            boundingBox = new Rectangle(currentLocation.X, currentLocation.Y, width, height);
        }


    }
}
