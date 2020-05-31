namespace kata_TicTacToe
{
    public class Move
    {
        //public readonly int _xCoordinate;
        //public readonly int _yCoordinate;
        //public readonly Square Square;
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Move(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }


     
        
    }
}