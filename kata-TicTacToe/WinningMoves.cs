using System.Linq;

namespace kata_TicTacToe
{
    public class WinningMoves
    {
        
        private readonly Board _board;

        public WinningMoves(Board board)
        {
            _board = board;
        }


        public bool HasWonHorizontallyCheckCoordinates(Symbol symbol, int xCoordinate)
        {
            for (var y = 1; y <= _board.Size; y++)
            {
                var getSymbol = _board.GetSymbolAtCoordinates(xCoordinate, y) != symbol;
                if(_board.GetSymbolAtCoordinates(xCoordinate, y) != symbol )
                    return false;
            }
            return true;
        }
        
        public bool HasWonVerticallyCheckCoordinates(Symbol symbol, int yCoordinate)
        {
            for (var x = 1; x <= _board.Size; x++)
            {
                if (_board.GetSymbolAtCoordinates(x, yCoordinate) != symbol)
                    return false;
            }
            return true;
        }
        
        public bool HasWonDiagonallyLeftToRightCheckCoordinates(Symbol symbol)
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                var diagonal = _board.FindCoordinatesWhereXCoordinateEqualsYCoordinate();
                if (diagonal.All(square => square.Symbol == symbol))
                    return true;
            }
            return false;
        }
        
        public bool HasWonDiagonallyRightToLeftCheckCoordinates(Symbol symbol)
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                var diagonal = _board.FindSumXCoordinateYCoordinateEqualSizePlusOne();
                if (diagonal.All(square => square.Symbol == symbol))
                    return true;
            }
            return false;
        }
    }
}