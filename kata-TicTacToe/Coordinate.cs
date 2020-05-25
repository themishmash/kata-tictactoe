namespace kata_TicTacToe
{
    public class Coordinate
    {
        
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }

        public CoordinateStatus CoordinateStatus { get; set; }

        //public readonly CoordinateStatus CoordinateStatus;
        public Coordinate(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            CoordinateStatus = CoordinateStatus.Blank; //needs to be here for it to work
        }

       
    }
}