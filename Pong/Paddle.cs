using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Pong
{
    public class Paddle
    {
        public int height { get; set; }
        public int width { get; set; }
        public int locationX { get; set; }
        public int locationY { get; set; }
        public Rectangle boundingBox;

        public Paddle(int Height, int Width, int LocationX, int LocationY)
        {
            this.height = Height;
            this.width = Width;
            this.locationX = LocationX;
            this.locationY = LocationY;
        }
    }
}
