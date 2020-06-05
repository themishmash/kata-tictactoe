namespace kata_TicTacToe
{
    public class Move
    {
        private readonly SquareStatus _squareStatus;
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }

        public SquareStatus SquareStatus;
        //public Symbol Symbol;
        public Move(int xCoordinate, int yCoordinate)
        {
           
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            SquareStatus = SquareStatus.Filled;
            //Symbol = Symbol.None;
        }


     
        
    }
}