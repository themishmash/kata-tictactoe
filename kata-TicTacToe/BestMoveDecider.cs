namespace kata_TicTacToe
{
    public class BestMoveDecider:IMoveDecider
    {
        private readonly Board _board;

        public BestMoveDecider(Board board)
        {
            _board = board;
            //first move = get firstmove
        }
        
        public Move NextMove() //pass in player? so can get symbol?
        {
            var xCoordinate = 2;
            var yCoordinate = 2;
            var move = new Move(xCoordinate, yCoordinate);
            
            //return startingMove;
            if (_board.IsSquareBlank(move))
            {
                return move;
            }
            
            move = GetOptimalMove(Symbol.Cross);
            if (move != null) return move;

            move = GetOptimalMove(Symbol.Naught);
            if (move != null) return move;
            
            if (_board.HasOpponentSymbolInDiagonalLTR(Symbol.Naught) && _board.CheckEmptySpotDiagonalRTL())
            {
                return new Move(_board.GetDiagonalEmptySpotRTL().XCoordinate, _board.GetDiagonalEmptySpotRTL()
                .YCoordinate);
            }
            
            if (_board.HasEmptyCorner())
            {
                return new Move(_board.GetEmptyCorner().XCoordinate, _board.GetEmptyCorner().YCoordinate);
            }
            
            return new Move(_board.FindEmptySpot().XCoordinate, _board.FindEmptySpot().YCoordinate);
        }

        private Move GetOptimalMove(Symbol symbol) //pass in symbol as parameter
        {
            if (_board.CheckRow(symbol))
            {
               return new Move(_board.GetRowEmptySpot(symbol).XCoordinate, _board
                        .GetRowEmptySpot(symbol)
                        .YCoordinate);
            }

            if (_board.CheckColumn(symbol))
            {
                return new Move(_board.GetColumnEmptySpot(symbol).XCoordinate,
                        _board.GetColumnEmptySpot(symbol).YCoordinate);
            }

            if (_board.CheckDiagonalLTR(symbol))
            {
                return new Move(_board.GetDiagonalEmptySpotLTR().XCoordinate, _board.GetDiagonalEmptySpotLTR()
                        .YCoordinate);
            }

            if (_board.CheckDiagonalRTL(symbol))
            {
                return new Move(_board.GetDiagonalEmptySpotRTL().XCoordinate,
                        _board.GetDiagonalEmptySpotRTL().YCoordinate);
            }

            return null;
        }
    }
}