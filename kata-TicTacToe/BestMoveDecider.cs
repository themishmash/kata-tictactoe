using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe
{
    public class BestMoveDecider:IMoveDecider
    {
        private readonly Board _board;

        public BestMoveDecider(Board board)
        {
            _board = board;
        }
        
        public Move NextMove() //pass in player? so can get symbol?
        {
            var xCoordinate = (_board.Size + 1) / 2;
            var yCoordinate = (_board.Size + 1) / 2;
            var move = new Move(xCoordinate, yCoordinate);
            
            if (_board.IsSquareBlank(move))
            {
                return move;
            }
            
            move = GetBestMove(Symbol.Cross);
            if (move != null) return move;

            move = GetBestMove(Symbol.Naught);
            if (move != null) return move;
            
            if (HasOpponentSymbolInDiagonalLTR(Symbol.Naught) && _board.CheckEmptySpotDiagonalRTL())
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
        

        private Move GetBestMove(Symbol symbol) //pass in symbol as parameter
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

        private bool HasOpponentSymbolInDiagonalLTR(Symbol symbol)
            {
                //find way to refacotr this method too
                var diagonal = new[]
                {
                    _board.GetSymbolAtCoordinates(1, 1),
                    _board.GetSymbolAtCoordinates(2, 2),
                    _board.GetSymbolAtCoordinates(3, 3)
                };
                
                var numberDiagonal = diagonal.Count(s => s == symbol);
                var emptySpot = diagonal.Count(s => s == Symbol.None);
                return numberDiagonal == 1 && emptySpot == 1;
            }
    }
    
    
}