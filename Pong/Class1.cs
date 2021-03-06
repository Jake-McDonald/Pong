﻿using System;
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

        public Ball(int locationX, int locationY)
        {
            Console.WriteLine("New ball created");
            this.currentLocation = new Point(locationX, locationY);
            this.randomNumGenerator = new Random();
        }
        public void MoveBall(int xMove, int yMove)
        {
            Point newPoint = new Point(currentLocation.X, currentLocation.Y);
            newPoint.Offset(xMove, yMove);
            currentLocation = newPoint;
        }

        public Point bounce()
        {
            int randomX = randomNumGenerator.Next(0, 2);
            int randomY = randomNumGenerator.Next(0, 2);
            Point randomOffset = new Point(randomX, randomY);
            return randomOffset;
        }
    }
}
