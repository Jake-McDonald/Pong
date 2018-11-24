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
        private int xVelocity = 2;
        private int yVelocity = 2;
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
                    Point offset = ball.bounce();
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
                    Point offset = ball.bounce();
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
                    Point offset = ball.bounce();
                    yVelocity = yVelocity * -1;
                    ball.MoveBall(4 * xVelocity + offset.X, 4 * yVelocity + offset.Y);
                }

            }
            else if(ball.currentLocation.Y < -20)
            {
                if (yVelocity < 0)
                {
                    Point offset = ball.bounce();
                    yVelocity = yVelocity * -1;
                    ball.MoveBall(4 * xVelocity + offset.X, 4 * yVelocity + offset.Y);
                }
            }
            ball.MoveBall(2 * xVelocity, 1  * yVelocity);
            //pictureBox1.Location = ball.currentLocation;
            Debug.WriteLine(ball.currentLocation);

            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ball = new Ball(this.Width /2, this.Height / 2);
            //pictureBox1.Location = ball.currentLocation;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle(ball.currentLocation.X, ball.currentLocation.Y, 32, 32));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }


}
