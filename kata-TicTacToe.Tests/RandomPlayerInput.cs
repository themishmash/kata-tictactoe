
namespace kata_TicTacToe.Tests
{
    public class RandomPlayerInput: INumberGenerator
    {
        private readonly int _xCoordinate;
        private readonly int _yCoordinate;


        public RandomPlayerInput(int xCoordinate, int yCoordinate)
        {
            _xCoordinate = xCoordinate;
            _yCoordinate = yCoordinate;
        }


        public int GetXCoordinate(int minimum, int maximum)
        {
            return _xCoordinate;
        }

        public int GetYCoordinate(int minimum, int maximum)
        {
            return _yCoordinate;
        }
    }
}