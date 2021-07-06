using BowlingAPI.Model;

namespace BowlingAPI
{
    public interface IBowlingGame
    {
        public BowlingScore GetScore();
        public BowlingScore Roll(int pins);
    }
}