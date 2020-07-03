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
        public Move NextMove() //change interface to allow symbol to be passed in
        {
            var xCoordinate = initialMove(); 
            var yCoordinate = initialMove();
            var move = new Move(xCoordinate, yCoordinate);
            
            if (_board.IsSquareBlank(move) && _board.Size%2 == 1)
            {
                return move;
            }
            
            move = getBestMove(Symbol.Cross); //pass in nothing as don't need it
            if (move != null) return move;

            move = getBestMove(Symbol.Naught);
            if (move != null) return move;
            
            // move = _board.HasEmptyCorner();
            // if (move != null) return move;

            move = getCornerSpots().FirstOrDefault();
            if (move != null) return move;
            
           return findEmptySpot();
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


           // if (HasOpponentSymbolDiagonalLtr(Symbol.Naught) && CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent())
           // {
           //     return new Move(GetDiagonalEmptySpotRtl().XCoordinate, GetDiagonalEmptySpotRtl()
           //         .YCoordinate);
           // }
           // move = HasOpponentSymbolDiagonalLtr(Symbol.Naught);
           // if (move!=null) return move
           // if (HasOpponentSymbolDiagonalLtr(Symbol.Naught) && CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent())
           // {
           //     return new Move(GetDiagonalEmptySpotRtl().XCoordinate, GetDiagonalEmptySpotRtl()
           //     .YCoordinate);
           // }

           // if (_board.HasEmptyCorner())
           // {
           //     return new Move(_board.GetEmptyCorner().XCoordinate, _board.GetEmptyCorner().YCoordinate);
           // }

        }

        private int initialMove()
        {
            return (_board.Size + 1) / 2;
        }

        private Move getBestMove(Symbol symbol)
        {
            
            var move = checkRow(symbol);
            if (move != null) return move;

            move = CheckColumn(symbol);
            if (move != null) return move;

            move = checkDiagonalLtr(symbol);
            if (move != null) return move;

            move = checkDiagonalRtl(symbol);
            if (move != null) return move;

            move = HasOpponentSymbolDiagonalLtr(symbol);
            if (move != null) return move;

            return null;

        }
        
        private Move checkRow(Symbol symbol)
        {
            for (var i = 1; i <= _board.Size; i++)
            { 
                var numberOfSymbols = GetRowSpots(i).Count(x => x == symbol);
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

        private IEnumerable<Move> GetEmptySpotsRow(int rowNumber)
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(rowNumber, i) == Symbol.None)
                {
                    moveList.Add(new Move(rowNumber, i));
                }
            }
            return moveList;
        }
        
        private Move CheckColumn(Symbol symbol)
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                var numberOfSymbols = GetColumnSpots(i).Count(x => x == symbol);
                if (numberOfSymbols == _board.Size-1 && GetEmptySpotsColumn(i).Count() ==1)
                {
                    return new Move(GetEmptySpotsColumn(i).FirstOrDefault().XCoordinate, GetEmptySpotsColumn(i).FirstOrDefault().YCoordinate);
                }
            }
            return null;
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

        private IEnumerable<Move> GetEmptySpotsColumn(int columnNumber)
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(i, columnNumber) == Symbol.None)
                {
                    moveList.Add(new Move(i, columnNumber));
                }
            }
            return moveList;
        }

        //TODO CHECK HERE
        private Move HasOpponentSymbolDiagonalLtr(Symbol symbol)
        {
            //find way to refactor this method too
            // var diagonal = new[]
            // {
            //     _board.GetSymbolAtCoordinates(1, 1), //1, +1
            //     _board.GetSymbolAtCoordinates(2, 2),//2
            //     _board.GetSymbolAtCoordinates(3, 3) //3
            // };
            var numberOfSymbols = getDiagonalSpotsLtr().Count(x => x == symbol);
           var emptySpot = getDiagonalSpotsLtr().Count(x => x == Symbol.None);
           if (numberOfSymbols == 1 && emptySpot == 1 && CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent())
           {
               return new Move(getEmptySpotsDiagonalRtl().FirstOrDefault().XCoordinate, getEmptySpotsDiagonalRtl()
               .FirstOrDefault().YCoordinate);
           }
           return null;
        }
        private bool CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent()
        {
            return getEmptySpotsDiagonalRtl().Count() == _board.Size - 1;
        }

        private IEnumerable<Symbol> getDiagonalSpotsLtr()
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                 symbolList.Add(_board.GetSymbolAtCoordinates(i, i));
            }
            return symbolList;
        }
        
        private Move checkDiagonalLtr(Symbol symbol)
        {
            var filledSpots = getDiagonalSpotsLtr().Count(x => x == symbol);
            var emptySpot = getEmptySpotsDiagonalLtr().Count();
            if (filledSpots == _board.Size - 1 && emptySpot == 1)
            {
                return new Move(getEmptySpotsDiagonalLtr().FirstOrDefault().XCoordinate, getEmptySpotsDiagonalLtr()
                .FirstOrDefault().YCoordinate);
            }
            return null;
        }

        private IEnumerable<Move> getEmptySpotsDiagonalLtr()
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(i, i) == Symbol.None)
                {
                    moveList.Add(new Move(i, i));
                }
            }
            return moveList;
        }
        
        private Move checkDiagonalRtl(Symbol symbol)
        {
            var filledSpots = getDiagonalSpotsRtl().Count(x => x == symbol);
            var emptySpot = getEmptySpotsDiagonalRtl().Count();
            if (filledSpots == _board.Size - 1 && emptySpot == 1)
            {
                return new Move(getEmptySpotsDiagonalRtl().FirstOrDefault().XCoordinate, getEmptySpotsDiagonalRtl().FirstOrDefault().YCoordinate);
            }
            return null;
        }
        
        private IEnumerable<Symbol> getDiagonalSpotsRtl()
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                symbolList.Add(_board.GetSymbolAtCoordinates(i, (_board.Size+1)-i));
            }
            return symbolList;
        }

        private IEnumerable<Move> getEmptySpotsDiagonalRtl()
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(i, (_board.Size+1)-i) == Symbol.None)
                {
                    moveList.Add(new Move(i, (_board.Size+1)-i));
                }
            }
            return moveList;
        }

        private IEnumerable<Move> getCornerSpots()
        {
            var moveList = new List<Move>();
            for (var i = 1; i < _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(1, 1) == Symbol.None 
                    || _board.GetSymbolAtCoordinates(1, _board.Size)
                    == Symbol.None 
                    || _board.GetSymbolAtCoordinates(_board.Size, 1) == Symbol.None 
                    || _board.GetSymbolAtCoordinates(_board.Size, _board.Size) == Symbol.None)
                {
                    moveList.Add(new Move(1, 1));
                    moveList.Add(new Move(1, _board.Size));
                    moveList.Add(new Move(_board.Size, 1));
                    moveList.Add(new Move(_board.Size, _board.Size));
                }
            }
            return moveList;
        }

        private Move findEmptySpot()
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(i, _board.Size -i) == Symbol.None ||
                    _board.GetSymbolAtCoordinates(_board.Size-i, i) == Symbol.None)
                {
                    moveList.Add(new Move(i, _board.Size -i));
                    moveList.Add(new Move(_board.Size-i, i));
                }
            }
            return moveList.FirstOrDefault();
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