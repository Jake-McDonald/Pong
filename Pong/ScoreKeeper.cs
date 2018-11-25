using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class ScoreKeeper
    {
        public int player1Score { get; set; }
        public int player2Score { get; set; }
        public const int MAX_SCORE = 15;
        enum Players { PLAYER1 = 1, PLAYER2};

        public ScoreKeeper()
        {
            this.player1Score = 0;
            this.player2Score = 0;
        }

        private void Goal(int scoringPlayer)
        {
            if(scoringPlayer == (int)Players.PLAYER1)
            {
                player1Score += 1;
            }
            else if(scoringPlayer == (int)Players.PLAYER2)
            {
                player2Score += 1;
            }
        }

        public void Player1Goal()
        {
            Goal(1);
        }
        public void Player2Goal()
        {
            Goal(2);
        }

        public void Reset()
        {
            player1Score = 0;
            player2Score = 0;
        }
    }
}
