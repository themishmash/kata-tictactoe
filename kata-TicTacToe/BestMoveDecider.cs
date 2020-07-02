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
            var xCoordinate = initialMove(); //make this into a method
            var yCoordinate = initialMove();
            var move = new Move(xCoordinate, yCoordinate);
            
            if (_board.IsSquareBlank(move) && _board.Size%2 == 1)
            {
                return move;
            }
            
            move = getBestMove(Symbol.Cross);
            if (move != null) return move;

            move = getBestMove(Symbol.Naught);
            if (move != null) return move;
            
            //Getnextbestmovetowin
            //has 2 or more spots and rest empty for row, column or diagonal - put one in empty spot
            // if (_board.Size > 3)
            // {
            //     if (CheckRowNextBest(Symbol.Cross))
            //     {
            //         return new Move(FindBestRow(Symbol.Cross).XCoordinate, FindBestRow(Symbol.Cross)
            //         .YCoordinate);
            //     }
            //
            //     if (CheckColumnNextBest(Symbol.Cross))
            //     {
            //         return new Move(GetColumnEmptySpotNextBest(Symbol.Cross).XCoordinate, GetColumnEmptySpotNextBest
            //             (Symbol.Cross).YCoordinate);
            //     }
            // }
            

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

        private int initialMove()
        {
            return (_board.Size + 1) / 2;
        }

        private Move getBestMove(Symbol symbol)
        {
            // var move = CheckRow();
            // if (move != null) return move;
            //
            // move = CheckColumn();
            //if (move != null) return move;
            var move = CheckRow(symbol);
            if (move != null) return move;
            // if (CheckRow(symbol))
            // {
            //    return new Move(GetRowEmptySpot(symbol).XCoordinate, GetRowEmptySpot(symbol)
            //             .YCoordinate);
            // }
            
            //call the method

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
        
        
        // private bool CheckRow(Symbol symbol)
        // {
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         //var row = _board.GetRowSpots(i);
        //         var numberOfSymbols = GetRowSpots(i).Count(x => x == symbol);
        //         //var emptySpot = GetEmptySpotsRow(i);
        //         if (numberOfSymbols == _board.Size-1 && GetEmptySpotsRow(i).Count() == _board.Size - numberOfSymbols )
        //         {
        //             return true; //return the coordinates for the move//
        //         }
        //     }
        //     return false;
        // }
        
        private Move CheckRow(Symbol symbol)
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                //var row = _board.GetRowSpots(i);
                var numberOfSymbols = GetRowSpots(i).Count(x => x == symbol);
                //var emptySpot = GetEmptySpotsRow(i);
                if (numberOfSymbols == _board.Size-1 && GetEmptySpotsRow(i).Count() == _board.Size - numberOfSymbols )
                {
                    return new Move(GetEmptySpotsRow(i).FirstOrDefault().XCoordinate, GetEmptySpotsRow(i).FirstOrDefault().YCoordinate);
                }
            }

            return null;
        }

        private IEnumerable<Symbol> GetRowSpots(int rowNumber)
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                symbolList.Add(_board.GetSymbolAtCoordinates(rowNumber, i));
            }

            return symbolList;
        }
        
        private IEnumerable<Square> GetEmptySpotsRow(int rowNumber)
        {
            //var test = _board.GetRowSpots(rowNumber).Where(x => x.Symbol == Symbol.None);
            return _board.GetRowSpots(rowNumber).Where(x => x.Symbol == Symbol.None);
        }
        
        //done
        // private Square GetRowEmptySpot(Symbol symbol)
        // {
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         //var row = _board.GetRowSpots(i);
        //         var numberOfSymbols = GetRowSpots(i).Count(x => x == symbol);
        //         if (numberOfSymbols != _board.Size-1) continue;
        //         {
        //             //var emptySpot = row.Where(x => x.Symbol != symbol);
        //             return GetEmptySpotsRow(i).FirstOrDefault();
        //         }
        //     }
        //     return null;
        // }
        
     
        
        
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
                var numberOfSymbols = GetColumnSpots(i).Count(x => x == symbol);
                if (numberOfSymbols == _board.Size-1 && GetEmptySpotsColumn(i).Count() ==1)
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
                var numberOfSymbols = GetColumnSpots(i).Count(x => x == symbol);
                if (numberOfSymbols != _board.Size-1) continue;
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
        
        private IEnumerable<Symbol> GetColumnSpots(int columnNumber)
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                symbolList.Add(_board.GetSymbolAtCoordinates(i, columnNumber));
            }

            return symbolList;
        }
        
        //TODO CHECK HERE
        private bool HasOpponentSymbolDiagonalLtr(Symbol symbol)
        {
            //find way to refactor this method too
            // var diagonal = new[]
            // {
            //     _board.GetSymbolAtCoordinates(1, 1), //1, +1
            //     _board.GetSymbolAtCoordinates(2, 2),//2
            //     _board.GetSymbolAtCoordinates(3, 3) //3
            // };
            var numberOfSymbols = GetDiagonalSpotsLtr().Count(x => x == symbol);
           var emptySpot = GetDiagonalSpotsLtr().Count(x => x == Symbol.None);
           return numberOfSymbols == 1 && emptySpot == 1;
        }

        private IEnumerable<Symbol> GetDiagonalSpotsLtr()
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                 symbolList.Add(_board.GetSymbolAtCoordinates(i, i));
            }
            return symbolList;
        }

        
        //works
        private Square GetDiagonalEmptySpotLtr()
        {
            return GetEmptySpotsDiagonalLtr().FirstOrDefault();
        }

        private bool CheckDiagonalLtr(Symbol symbol)
        {
            var filledSpots = GetDiagonalSpotsLtr().Count(x => x == symbol);
            var emptySpot = GetEmptySpotsDiagonalLtr().Count();
            return filledSpots == _board.Size-1 && emptySpot == 1;
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
            // return GetEmptySpotsDiagonalRtl().Any();
            return GetEmptySpotsDiagonalRtl().Count() == _board.Size - 1;
        }

        private bool CheckDiagonalRtl(Symbol symbol)
        {
            var filledSpots = _board.GetDiagonalSpotsRtl().Count(x => x.Symbol == symbol);
            var emptySpot = GetEmptySpotsDiagonalRtl().Count();
            return filledSpots == _board.Size-1 && emptySpot == 1;
        }
        
        private IEnumerable<Square> GetEmptySpotsDiagonalRtl()
        {
            return _board.GetDiagonalSpotsRtl().Where(x => x.Symbol == Symbol.None);
        }
        
        
        
        
        
        //LEAVE FOR NOW
        
        //TODO get next best move - need to research
        // private bool CheckRowNextBest(Symbol symbol)
        // {
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         //var row = _board.GetRowSpots(i);
        //         var numberOfSymbols = GetRowSpots(i).Count(x => x == symbol);
        //         //var emptySpot = GetEmptySpotsRow(i);
        //         if (numberOfSymbols == _board.Size-2 && GetEmptySpotsRow(i).Count() == _board.Size - numberOfSymbols ) //UP TO HERE
        //         {
        //             return true;
        //         }
        //     }
        //     return false;
        // }
        //
        // //done
        // private Square FindBestRow(Symbol symbol)
        // {
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         //var row = _board.GetRowSpots(i);
        //         var numberOfSymbols = GetRowSpots(i).Count(x => x == symbol);
        //         var emptySpot = GetEmptySpotsRow(i);
        //         if (numberOfSymbols == _board.Size-2 && emptySpot.Count() == _board.Size - numberOfSymbols ) //UP TO HERE
        //         {
        //             return emptySpot.FirstOrDefault();
        //         }
        //     }
        //
        //     return null;
        // }
        //
        // private bool CheckColumnNextBest(Symbol symbol)
        // {
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         //var row = _board.GetRowSpots(i);
        //         var numberOfSymbols = _board.GetColumnSpots(i).Count(x => x.Symbol == symbol);
        //         //var emptySpot = GetEmptySpotsRow(i);
        //         if (numberOfSymbols == _board.Size-2 && GetEmptySpotsColumn(i).Count() == _board.Size - 
        //         numberOfSymbols ) //UP TO HERE
        //         {
        //             return true;
        //         }
        //     }
        //     return false;
        // }
        //
        // //done
        // private Square GetColumnEmptySpotNextBest(Symbol symbol)
        // {
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         //var row = _board.GetRowSpots(i);
        //         var numberOfSymbols = GetColumnSpots(i).Count(x => x == symbol);
        //         var emptySpot = GetEmptySpotsColumn(i);
        //         if (numberOfSymbols == _board.Size-2 && emptySpot.Count() == _board.Size - numberOfSymbols ) //UP TO HERE
        //         {
        //             return emptySpot.FirstOrDefault();
        //         }
        //     }
        //
        //     return null;
        // }
        
    }
    
    
}