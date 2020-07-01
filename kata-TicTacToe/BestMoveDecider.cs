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
            var xCoordinate = InitialMove(); //make this into a method
            var yCoordinate = InitialMove();
            var move = new Move(xCoordinate, yCoordinate);
            
            if (_board.IsSquareBlank(move))
            {
                return move;
            }
            
            move = GetBestMove(Symbol.Cross);
            if (move != null) return move;

            move = GetBestMove(Symbol.Naught);
            if (move != null) return move;

            if (HasOpponentSymbolDiagonalLtr(Symbol.Naught) && CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent())
            {
                return new Move(GetDiagonalEmptySpotRtl().XCoordinate, GetDiagonalEmptySpotRtl()
                .YCoordinate);
            }
            
            if (_board.HasEmptyCorner())
            {
                return new Move(_board.GetEmptyCorner().XCoordinate, _board.GetEmptyCorner().YCoordinate);
            }
            
            return new Move(_board.FindEmptySpot().XCoordinate, _board.FindEmptySpot().YCoordinate);
        }

        private int InitialMove()
        {
            return (_board.Size + 1) / 2;
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

            if (CheckDiagonalLtr(symbol))
            {
                return new Move(GetDiagonalEmptySpotLtr().XCoordinate, GetDiagonalEmptySpotLtr()
                        .YCoordinate);
            }

            if (CheckDiagonalRtl(symbol))
            {
                return new Move(GetDiagonalEmptySpotRtl().XCoordinate,
                        GetDiagonalEmptySpotRtl().YCoordinate);
            }

            return null;
        }
        
        
        private bool CheckRow(Symbol symbol)
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                //var row = _board.GetRowSpots(i);
                var numberOfSymbols = _board.GetRowSpots(i).Count(x => x.Symbol == symbol);
                //var emptySpot = GetEmptySpotsRow(i);
                if (numberOfSymbols == 2 && GetEmptySpotsRow(i).Count() == 1 )
                {
                    return true;
                }
            }
            return false;
        }
        
        //done
        private Square GetRowEmptySpot(Symbol symbol)
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                //var row = _board.GetRowSpots(i);
                var numberOfSymbols = _board.GetRowSpots(i).Count(x => x.Symbol == symbol);
                if (numberOfSymbols != 2) continue;
                {
                    //var emptySpot = row.Where(x => x.Symbol != symbol);
                    return GetEmptySpotsRow(i).FirstOrDefault();
                }
            }
            return null;
        }
        
        private IEnumerable<Square> GetEmptySpotsRow(int rowNumber)
        {
            return _board.GetRowSpots(rowNumber).Where(x => x.Symbol == Symbol.None);
        }
        
        // private Square GetRowEmptySpot(Symbol symbol)
        // {
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         var row = _board.GetRowSpots(i).Where(r => r.XCoordinate == i);
        //         var numberRow = row.Count(x => x.Symbol == symbol);
        //         if (numberRow != 2) continue;
        //         {
        //             var emptySpot = row.Where(x => x.Symbol != symbol);
        //             return emptySpot.FirstOrDefault();
        //         }
        //     }
        //     return null;
        // }

        private bool CheckColumn(Symbol symbol)
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                var numberOfSymbols = _board.GetColumnSpots(i).Count(x => x.Symbol == symbol);
                if (numberOfSymbols == 2 && GetEmptySpotsColumn(i).Count() ==1)
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
                var numberOfSymbols = _board.GetColumnSpots(i).Count(x => x.Symbol == symbol);
                if (numberOfSymbols != 2) continue;
                {
                    return GetEmptySpotsColumn(i).FirstOrDefault();
                }
            }
            return null;
        }
        
        private IEnumerable<Square> GetEmptySpotsColumn(int columnNumber)
        {
            return _board.GetColumnSpots(columnNumber).Where(x => x.Symbol == Symbol.None);
        }
        
        private bool HasOpponentSymbolDiagonalLtr(Symbol symbol)
        {
            //find way to refactor this method too
            // var diagonal = new[]
            // {
            //     _board.GetSymbolAtCoordinates(1, 1),
            //     _board.GetSymbolAtCoordinates(2, 2),
            //     _board.GetSymbolAtCoordinates(3, 3)
            // };
            //var diagonal = _board.GetDiagonalSpotsLtr();
            var numberOfSymbols = _board.GetDiagonalSpotsLtr().Count(s => s.Symbol == symbol);
           // var emptySpot = _board.GetDiagonalSpotsLtr().Count(s => s.Symbol == Symbol.None);
           var emptySpot = GetEmptySpotsDiagonalLtr().Count();
            return numberOfSymbols == 1 && emptySpot == 1;
        }
        
        
        //works
        private Square GetDiagonalEmptySpotLtr()
        {
            return GetEmptySpotsDiagonalLtr().FirstOrDefault();
        }

        private bool CheckDiagonalLtr(Symbol symbol)
        {
            var filledSpots = _board.GetDiagonalSpotsLtr().Count(x => x.Symbol == symbol);
            var emptySpot = GetEmptySpotsDiagonalLtr().Count();
            return filledSpots == 2 && emptySpot == 1;
        }

        private IEnumerable<Square> GetEmptySpotsDiagonalLtr()
        {
            return _board.GetDiagonalSpotsLtr().Where(x => x.Symbol == Symbol.None);
        }
        
        private Square GetDiagonalEmptySpotRtl()
        {
           // var diagonal = _board.GetDiagonalSpotsRtl();
            //var emptySpot = diagonal.Where(x => x.Symbol == Symbol.None);
            return GetEmptySpotsDiagonalRtl().FirstOrDefault();
        }
        
        private bool CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent()
        {
            return GetEmptySpotsDiagonalRtl().Any();
        }

        private bool CheckDiagonalRtl(Symbol symbol)
        {
            var filledSpots = _board.GetDiagonalSpotsRtl().Count(x => x.Symbol == symbol);
            var emptySpot = GetEmptySpotsDiagonalRtl().Count();
            return filledSpots == 2 && emptySpot == 1;
        }
        
        private IEnumerable<Square> GetEmptySpotsDiagonalRtl()
        {
            return _board.GetDiagonalSpotsRtl().Where(x => x.Symbol == Symbol.None);
        }
        
    }
    
    
}