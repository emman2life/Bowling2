using System.Collections.Generic;
using BowlingAPI.Model;

namespace BowlingAPI
{
  

    public class BowlingGame : IBowlingGame
    {
       
        private int _index = 0;
        private int _frameIndex = 0;
        private int[] _scores;
        private int _pinsLeft = 10;
        private Frame[] _frames = new Frame[10];

        public BowlingGame()
        {
            _scores = new int[21]; 
            
        }

        public BowlingScore Roll(int pins)
        {
            _scores[_index] = pins;
            ScoreFrame(pins);

            if (_index % 2 == 0 & pins == 10 & _index < 18) _index++;
            if (_index % 2 == 1)
            {
                _pinsLeft = 10;
                _frameIndex++;
            }
            else
            {
                _pinsLeft = _pinsLeft - pins;
            }

            _index++;
            if (_scores[18] != 10 & _index == 20) _pinsLeft = 0;



            return GetScore();
        }

        private void ScoreFrame(int pins)
        {
            Frame frame;
            if (_index % 2 == 0)
            {
                frame = new Frame();
                if(pins==10 & _index<18){
                    frame.SecondShotScore = "X";  
                }else{
                    frame.FirstShotScore = pins.ToString();
                }
                
                _frames[_frameIndex]= frame;
            }
            else if (_index == 20)
            {
                _frames[10].ThirdShotScore = pins.ToString();
            }
            else
            {
                if(_pinsLeft==pins){
                    _frames[_frameIndex].SecondShotScore = "/";
                }else{
                    _frames[_frameIndex].SecondShotScore = pins.ToString();
                }
                
            }
        }

        public BowlingScore GetScore()
        {
            int frameIndex = 0;
            int[] frameScores = new int[10];
            int[] cummulativeScores = new int[10];

            

            for (int i = 0; i < _index; i++)
            {
                if (i > 17)
                {
                    
                     frameScores[frameIndex] = LastFrameScore(i);
                    
                }
                else
                {
                    if(i%2==0){

                    
                    if (IsStrike(i))
                    {
                        frameScores[frameIndex] = StrikeScore(i);
                    }
                    else if (IsSpare(i))
                    {
                        frameScores[frameIndex] = SpareScore(i);
                    }
                    else
                    {
                        frameScores[frameIndex] = OpenScore(i);
                    }
                    frameIndex++;
                    }
                    
                }
            }
            int cummulativeScore = 0;
            
                for (int i = 0; i < _index/2; i++)
                {
                    
                   cummulativeScore += frameScores[i];
                    cummulativeScores[i] = cummulativeScore;
                   

                }


            BowlingScore bowlingScore = new BowlingScore(){
                FrameScores = frameScores,
                RollScores = _scores,
                PinsLeft = _pinsLeft,
                CummulativeScores = cummulativeScores,
                TotalScore = cummulativeScore,
                Frames = _frames
            };
            return bowlingScore;
        }

        private bool IsSpare(int index)
        {
            return _scores[index] + _scores[index + 1] == 10;
        }
        private bool IsStrike(int index)
        {
            return _scores[index] == 10;
        }
        private int SpareScore(int index)
        {
            return _scores[index] + _scores[index + 1] + _scores[index + 2];
        }
        private int StrikeScore(int index)
        {
            if (_scores[index + 2] == 10)
            {
                return _scores[index] + _scores[index + 2] + _scores[index +4];
            }
            else
            {
                return _scores[index] + _scores[index + 2] + _scores[index +3];
            }
        }
        private int OpenScore(int index)
        {
            return _scores[index] + _scores[index + 1];
        }

        private int LastFrameScore(int index){
            return _scores[18] + _scores[19]+_scores[20];
        }
    }
}