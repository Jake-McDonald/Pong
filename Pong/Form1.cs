using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Form1 : Form

    {
        private Ball ball;
        private Paddle paddle1;
        private int xVelocity = 2;
        private int yVelocity = 2;
        private Rectangle topSide;
        private Rectangle bottomSide;
        private Rectangle leftSide;
        private Rectangle rightSide;
        private const int BOTTOM_SIDE_OFFSET = 42;
        private const int WALL_THICKNESS = 3;
        private const int OFFSET_FROM_WALL = 10;




        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            this.SetStyle(ControlStyles.Opaque, false);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ball.currentLocation.X > this.Width -40)
            {
                if (xVelocity > 0)
                {
                    Point offset = ball.Bounce();
                    xVelocity = xVelocity * -1;
                    ball.MoveBall(4 * xVelocity + offset.X, 4 * yVelocity + offset.Y);

                    //ball.currentLocation = new Point(this.Width -200, this.Height / 2);
                    Debug.WriteLine("Changed velocity - Left");
                }
            }
            else if (ball.currentLocation.X < 0)
            {
                if (xVelocity < 0)
                {
                    Point offset = ball.Bounce();
                    xVelocity = xVelocity * -1;
                    ball.MoveBall(4 * xVelocity + offset.X, 4 * yVelocity + offset.Y);

                    //ball.currentLocation = new Point(10, this.Height / 2);
                    Debug.WriteLine("Changed velocity - Right");
                }
            }
            else if(ball.currentLocation.Y > this.Height -80)
            {
                if (yVelocity > 0)
                {
                    Point offset = ball.Bounce();
                    yVelocity = yVelocity * -1;
                    ball.MoveBall(4 * xVelocity + offset.X, 4 * yVelocity + offset.Y);
                }

            }
            else if(ball.currentLocation.Y < -20)
            {
                if (yVelocity < 0)
                {
                    Point offset = ball.Bounce();
                    yVelocity = yVelocity * -1;
                    ball.MoveBall(4 * xVelocity + offset.X, 4 * yVelocity + offset.Y);
                }
            }
            ball.MoveBall(2 * xVelocity, 1  * yVelocity);
            Debug.WriteLine(ball.currentLocation);

            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ball = new Ball(this.Width /2, this.Height / 2);
            paddle1 = new Paddle(this.Height / 4, 10, OFFSET_FROM_WALL, this.Height / 2);
            topSide = new Rectangle(0, 0, this.Width, WALL_THICKNESS);
            bottomSide = new Rectangle(0, this.Height - BOTTOM_SIDE_OFFSET, this.Width, WALL_THICKNESS);
            leftSide = new Rectangle(0, 0, WALL_THICKNESS, this.Height);
            rightSide = new Rectangle(this.Width - 20, 0, WALL_THICKNESS, this.Height);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw ball
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle(ball.currentLocation.X, ball.currentLocation.Y, 32, 32));

            //draw paddle
            //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(paddle1.locationX, paddle1.locationY, paddle1.width, paddle1.height));
            e.Graphics.FillRectangle(Brushes.Gray, topSide);
            e.Graphics.FillRectangle(Brushes.Gray, bottomSide);
            e.Graphics.FillRectangle(Brushes.Gray, leftSide);
            e.Graphics.FillRectangle(Brushes.Gray, rightSide);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }


}
