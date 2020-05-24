namespace kata_TicTacToe
{
    public class Coordinate
    {
        public Coordinate(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
    }
}