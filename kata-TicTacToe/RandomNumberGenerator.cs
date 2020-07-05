using System;

namespace kata_TicTacToe
{
    public class RandomNumberGenerator: INumberGenerator
    {
        public int GetXCoordinate(int minimum, int maximum)
        {
            var random = new Random();
            var randomCoordinate = random.Next(minimum, maximum);
            return randomCoordinate;
        }

        public int GetYCoordinate(int minimum, int maximum)
        {
            var random = new Random();
            var randomCoordinate = random.Next(minimum, maximum);
            return randomCoordinate;
        }
    }
}