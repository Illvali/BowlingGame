using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling
{
    public class BowlingGame
    {

        private int _score = 0;
        private int _ballsThisFrame = 0;
        private int _firstBallScore = 0;
        private int _secondBallScore = 0;
        private int _BonusBallsLeft = 0;

        public void Roll(int pins)
        {
            SetBallThisFrame();
            SetBallScore(pins);
            _score += pins;
            CheckIfBonusPoints(pins);
            CheckIfStrike();
            CheckIfSpare();
        }

        public void SetBallThisFrame()
        {
            if (_ballsThisFrame == 2)
            {
                _ballsThisFrame = 0;
            }
            _ballsThisFrame += 1;
        }

        public void SetBallScore(int pins)
        {
            if(_ballsThisFrame == 1)
            {
                _firstBallScore = pins;
            }
            else
            {
                _secondBallScore = pins;
            }
        }

        public void CheckIfStrike()
        {
            if(_ballsThisFrame == 1 && _firstBallScore == 10)
            {
                _BonusBallsLeft += 2;
            }

        }

        public void CheckIfSpare()
        {
            if (_ballsThisFrame == 2 && _firstBallScore + _secondBallScore == 10 && _firstBallScore != 10)
            {
                _BonusBallsLeft += 1;
            }
        }

        public void CheckIfBonusPoints(int pins)
        {
            if(_BonusBallsLeft > 0)
            {
                _BonusBallsLeft -= 1;
                _score += pins;
            }
        }

        public int Score()
        {
            return _score;
        }
    }
}
