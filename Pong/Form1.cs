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
        private Paddle paddle2;
        private int xVelocity = 3;
        private int yVelocity = 3;
        private Rectangle topSide;
        private Rectangle bottomSide;
        private Rectangle leftSide;
        private Rectangle rightSide;
        private const int BOTTOM_SIDE_OFFSET = 42;
        private const int WALL_THICKNESS = 3;
        private const int OFFSET_FROM_WALL = 10;
        private ScoreKeeper scoreKeeper;
        private const int PADDLE_SPEED = 3;

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
            if(ball.boundingBox.IntersectsWith(paddle1.boundingBox))
            {
                Point offset = ball.Bounce();
                xVelocity = xVelocity * -1;
                ball.MoveBall(4 * xVelocity + offset.X, 4 * yVelocity + offset.Y);
            }
            else if (ball.boundingBox.IntersectsWith(paddle2.boundingBox))
            {
                Point offset = ball.Bounce();
                xVelocity = xVelocity * -1;
                ball.MoveBall(4 * xVelocity + offset.X, 4 * yVelocity + offset.Y);
            }
            else if (ball.boundingBox.IntersectsWith(rightSide))
            {
                if (xVelocity > 0)
                {
                    Point offset = ball.Bounce();
                    xVelocity = xVelocity * -1;
                    ball.MoveBall(4 * xVelocity + offset.X, 4 * yVelocity + offset.Y);
                    scoreKeeper.Player1Goal();

                    Player1Score.Text = scoreKeeper.player1Score.ToString();
                    if (scoreKeeper.player1Score == 15)
                    {
                        resetGame();
                    }
                    else ball.Reset();
                }
            }
            else if (ball.boundingBox.IntersectsWith(leftSide))
            {
                if (xVelocity < 0)
                {
                    Point offset = ball.Bounce();
                    xVelocity = xVelocity * -1;
                    ball.MoveBall(4 * xVelocity + offset.X, 4 * yVelocity + offset.Y);
                    scoreKeeper.Player2Goal();
                    Player2Score.Text = scoreKeeper.player2Score.ToString();
                    if (scoreKeeper.player2Score == 15)
                    {
                        resetGame();
                    }
                    else ball.Reset();
                }
            }
            else if (ball.boundingBox.IntersectsWith(bottomSide))
            {
                if (yVelocity > 0)
                {
                    Point offset = ball.Bounce();
                    yVelocity = yVelocity * -1;
                    ball.MoveBall(4 * xVelocity + offset.X, 4 * yVelocity + offset.Y);
                }
            }
            else if (ball.boundingBox.IntersectsWith(topSide))
            {
                if (yVelocity < 0)
                {
                    Point offset = ball.Bounce();
                    yVelocity = yVelocity * -1;
                    ball.MoveBall(4 * xVelocity + offset.X, 4 * yVelocity + offset.Y);
                }
            }
            if (paddle2.boundingBox.Y < ball.currentLocation.Y)
            {
                if (!paddle2.boundingBox.IntersectsWith(bottomSide))
                {
                    paddle2.MovePaddleDown(PADDLE_SPEED);
                }
            }
            else if(paddle2.boundingBox.Y > ball.currentLocation.Y)
            {
                if (!paddle2.boundingBox.IntersectsWith(topSide))
                { 
                    paddle2.MovePaddleUp(PADDLE_SPEED);
                }
            }
            ball.MoveBall(2 * xVelocity, 1  * yVelocity);
            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ball = new Ball(this.Width /2, this.Height / 2, 32, 32);
            paddle1 = new Paddle(this.Height / 4, 10, OFFSET_FROM_WALL, this.Height / 2);
            paddle2 = new Paddle(this.Height / 4, 10, this.Width - 40, this.Height / 2);
            topSide = new Rectangle(0, 0, this.Width, WALL_THICKNESS);
            bottomSide = new Rectangle(0, this.Height - BOTTOM_SIDE_OFFSET, this.Width, WALL_THICKNESS);
            leftSide = new Rectangle(0, 0, WALL_THICKNESS, this.Height);
            rightSide = new Rectangle(this.Width - 20, 0, WALL_THICKNESS, this.Height);
            scoreKeeper = new ScoreKeeper();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(Brushes.Red, ball.boundingBox);
            e.Graphics.FillRectangle(Brushes.Gray, paddle1.boundingBox);
            e.Graphics.FillRectangle(Brushes.Gray, paddle2.boundingBox);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                if (!paddle1.boundingBox.IntersectsWith(bottomSide))
                {
                    paddle1.MovePaddleDown(PADDLE_SPEED);
                }
            }
            else if(e.KeyCode == Keys.Q)
            {
                if (!paddle1.boundingBox.IntersectsWith(topSide))
                {
                    paddle1.MovePaddleUp(PADDLE_SPEED);
                }
            }
        }

        private void resetGame()
        {
            timer1.Enabled = false;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.game_over);
            player.Play();
            DialogResult dialogResult = MessageBox.Show("Play again?", "Pong", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                scoreKeeper.Reset();
                ball.Reset();
                Player1Score.Text = "0";
                Player2Score.Text = "0";
                timer1.Enabled = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                Application.Exit();
            }
        }
    }
}
