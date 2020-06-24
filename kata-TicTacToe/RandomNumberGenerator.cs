using System;

namespace kata_TicTacToe
{
    public class RandomNumberGenerator: NumberGenerator
    {
        public int GetNumber(int minimum, int maximum)
        {
            var random = new Random();
            var randomCoordinate = random.Next(minimum, maximum);
            return randomCoordinate;
        }
    }
}