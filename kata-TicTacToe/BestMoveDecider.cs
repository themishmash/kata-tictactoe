using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

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

            if (HasOpponentSymbolInDiagonalLTR(Symbol.Naught) && CheckEmptySpotDiagonalRTL())
            {
                return new Move(GetDiagonalEmptySpotRTL().XCoordinate, GetDiagonalEmptySpotRTL()
                .YCoordinate);
            }
            
            if (HasEmptyCorner())
            {
                return new Move(GetEmptyCorner().XCoordinate, GetEmptyCorner().YCoordinate);
            }
            
            return new Move(FindEmptySpot().XCoordinate, FindEmptySpot().YCoordinate);
        }
        

        private Move GetBestMove(Symbol symbol) 
        {
            if (CheckRow(symbol))
            {
               return new Move(GetRowEmptySpot(symbol).XCoordinate, GetRowEmptySpot(symbol)
                        .YCoordinate);
            }

            if (CheckColumn(symbol))
            {
                return new Move(GetColumnEmptySpot(symbol).XCoordinate,
                        GetColumnEmptySpot(symbol).YCoordinate);
            }

            if (CheckDiagonalLTR(symbol))
            {
                return new Move(GetDiagonalEmptySpotLTR().XCoordinate, GetDiagonalEmptySpotLTR()
                        .YCoordinate);
            }

            if (CheckDiagonalRTL(symbol))
            {
                return new Move(GetDiagonalEmptySpotRTL().XCoordinate,
                        GetDiagonalEmptySpotRTL().YCoordinate);
            }

            return null;
        }


        private bool CheckRow(Symbol symbol)
        {
            
            for (var i = 1; i <= _board.Size; i++)
            {
                var row = _board.GetSpots().Where(r => r.XCoordinate == i);
                var numberOfSymbols = row.Count(x => x.Symbol == symbol);
                var emptySpot = row.Count(x => x.Symbol == Symbol.None);
                if (numberOfSymbols == 2 && emptySpot == 1 )
                {
                    return true;
                }
            }
            return false;
        }
        private Square GetRowEmptySpot(Symbol symbol)
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                var row = _board.GetSpots().Where(r => r.XCoordinate == i);
                var numberRow = row.Count(x => x.Symbol == symbol);
                if (numberRow != 2) continue;
                {
                    var emptySpot = row.Where(x => x.Symbol != symbol);
                    return emptySpot.FirstOrDefault();
                }
            }
            return null;
        }

        private bool CheckColumn(Symbol symbol)
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                var column = _board.GetSpots().Where(r => r.YCoordinate == i);
                var emptySpot = column.Count(x => x.Symbol == Symbol.None);
                var numberColumn = column.Count(x => x.Symbol == symbol);
                if (numberColumn == 2 && emptySpot ==1)
                {
                    return true;
                }
            }
            return false;
        }

        private Square GetColumnEmptySpot(Symbol symbol)
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                var row = _board.GetSpots().Where(r => r.YCoordinate == i);
                var numberColumn = row.Count(x => x.Symbol == symbol);
                if (numberColumn != 2) continue;
                {
                    var emptySpot = row.Where(x => x.Symbol != symbol);
                    return emptySpot.FirstOrDefault();
                }
            }
            return null;
        }
        private bool HasOpponentSymbolInDiagonalLTR(Symbol symbol)
        {
            //find way to refactor this method too
            // var diagonal = new[]
            // {
            //     _board.GetSymbolAtCoordinates(1, 1),
            //     _board.GetSymbolAtCoordinates(2, 2),
            //     _board.GetSymbolAtCoordinates(3, 3)
            // };
            var diagonal = _board.GetDiagonalSpotsLtr();
            var numberOfSymbols = diagonal.Count(s => s.Symbol == symbol);
            var emptySpot = diagonal.Count(s => s.Symbol == Symbol.None);
            return numberOfSymbols == 1 && emptySpot == 1;
        }

        private Square GetDiagonalEmptySpotLTR()
        {
            var diagonal = _board.GetDiagonalSpotsLtr();
            var emptySpot = diagonal.Where(x => x.Symbol == Symbol.None);
            return emptySpot.FirstOrDefault();
        }

        private bool CheckDiagonalLTR(Symbol symbol)
        {
            var diagonal = _board.GetDiagonalSpotsLtr();
            var filledSpots = diagonal.Count(x => x.Symbol == symbol);
            var emptySpot = diagonal.Count(x => x.Symbol == Symbol.None);
            return filledSpots == 2 && emptySpot == 1;
        }

        private Square GetDiagonalEmptySpotRTL()
        {
            var diagonal = _board.GetDiagonalSpotsRtl();
            var emptySpot = diagonal.Where(x => x.Symbol == Symbol.None);
            return emptySpot.FirstOrDefault();
        }

        private bool CheckEmptySpotDiagonalRTL()
        {
            var diagonal = _board.GetDiagonalSpotsRtl();
            var emptySpot = diagonal.Count(x => x.Symbol == Symbol.None);
            return emptySpot > 0;
        }

        private bool CheckDiagonalRTL(Symbol symbol)
        {
            var diagonal = _board.GetDiagonalSpotsRtl();
            var filledSpots = diagonal.Count(x => x.Symbol == symbol);
            var emptySpot = diagonal.Count(x => x.Symbol == Symbol.None);
            return filledSpots == 2 && emptySpot == 1;
        }

        private Square FindEmptySpot()
        {
            var emptySquares = _board.GetSpots().Where(x => x.Symbol == Symbol.None);
            return emptySquares.FirstOrDefault();
        }

        private bool HasEmptyCorner()
        {
            var cornerSpot = _board.GetSpots().Where(s => s.XCoordinate == s.YCoordinate || s
                    .XCoordinate
                + s
                    .YCoordinate
                == (_board.Size + 1));
            var emptySpot = cornerSpot.Count(x => x.Symbol == Symbol.None);
            return emptySpot > 1;
        }
        private Square GetEmptyCorner()
        {
            var cornerSpot = _board.GetSpots().Where(s => s.XCoordinate == s.YCoordinate && s.Symbol == Symbol.None || s
                    .XCoordinate
                + s
                    .YCoordinate
                == (_board.Size + 1) && s.Symbol == Symbol.None);
            return cornerSpot.FirstOrDefault();
        }
        
    }
    
    
}