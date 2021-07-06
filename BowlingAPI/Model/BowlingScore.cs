using System.Collections.Generic;

namespace BowlingAPI.Model
{
    public class BowlingScore
    {
        public int[] FrameScores { get; set; }
        public int[] RollScores { get; set; }
        public Frame[] Frames { get; set; }

        public int[] CummulativeScores { get; set; }
      
        public int TotalScore { get; set; }
        public int PinsLeft { get; set; }
    }
}