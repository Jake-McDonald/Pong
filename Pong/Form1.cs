using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ball.currentLocation.X > this.Width -40)
            {
                    xVelocity = xVelocity * -1;
                    //ball.currentLocation = new Point(this.Width -200, this.Height / 2);
                    Debug.WriteLine("Changed velocity - Left");
            }
            else if (ball.currentLocation.X < 10)
            {
                xVelocity = xVelocity * -1;
                //ball.currentLocation = new Point(10, this.Height / 2);
                Debug.WriteLine("Changed velocity - Right");
            }
            else if(ball.currentLocation.Y > this.Height - 75)
            {
                yVelocity = yVelocity * -1;

            }
            else if(ball.currentLocation.Y < 0)
            {
                yVelocity = yVelocity * -1;
            }
            ball.MoveBall(4 * xVelocity, 2  * yVelocity);
            pictureBox1.Location = ball.currentLocation;
            Debug.WriteLine(pictureBox1.Location);
            Debug.WriteLine(ball.currentLocation);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ball = new Ball(this.Width /2, this.Height / 2);
            pictureBox1.Location = ball.currentLocation;
        }
    }


}
