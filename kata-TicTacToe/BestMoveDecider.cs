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
        public Move NextMove() 
        {
            var xCoordinate = InitialMove(); 
            var yCoordinate = InitialMove();
            var move = new Move(xCoordinate, yCoordinate);
            
            if (_board.IsSquareBlank(move) && _board.Size%2 == 1)
            {
                return move;
            }
            
            move = GetBestMove(); 
            if (move != null) return move;

            move = getCornerSpots();
            if (move != null) return move;
            
           return findEmptySpot();

        }

        private int InitialMove()
        {
            return (_board.Size + 1) / 2;
        }

        private Move GetBestMove()
        {
            var move = CheckRow();
            if (move != null) return move;

            move = CheckColumn();
            if (move != null) return move;

            move = checkDiagonalLtr();
            if (move != null) return move;

            move = checkDiagonalRtl();
            if (move != null) return move;

            move = hasOpponentSymbolDiagonalLtr();
            if (move != null) return move;

            return null;
        }
        
        private Move CheckRow()
        {
            for (var i = 1; i <= _board.Size; i++)
            { 
                var numberOfXSymbols = GetRowSpots(i, Symbol.Cross);
                var numberOfOSymbols = GetRowSpots(i, Symbol.Naught);
                var emptySpotsRow = GetEmptySpotsRow(i);
                if ((numberOfXSymbols == _board.Size - 1 || numberOfOSymbols == _board.Size-1) && emptySpotsRow != null) //This is checking to see if there are 2 filled in spots with the same symbol and 1 empty spot
                {
                    return emptySpotsRow;
                }
            }
            return null;
        }

        private int GetRowSpots(int rowNumber, Symbol symbol)
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                symbolList.Add(_board.GetSymbolAtCoordinates(rowNumber, i));
            }
            return symbolList.Count(x => x == symbol);
        }

        private Move GetEmptySpotsRow(int rowNumber)
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(rowNumber, i) == Symbol.None)
                {
                    moveList.Add(new Move(rowNumber, i));
                }
            }
            return moveList.FirstOrDefault();
        }
        
        private Move CheckColumn()
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                var numberOfXSymbols = GetColumnSpots(i).Count(x => x == Symbol.Cross);
                var numberOfOSymbols = GetColumnSpots(i).Count(x => x == Symbol.Naught);
                if (numberOfXSymbols == _board.Size-1 && GetEmptySpotsColumn(i).Count() ==1 || numberOfOSymbols == _board.Size-1 && GetEmptySpotsColumn(i).Count() ==1)
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
        
        private Move hasOpponentSymbolDiagonalLtr()
        {
            //find way to refactor this method too
            // var diagonal = new[]
            // {
            //     _board.GetSymbolAtCoordinates(1, 1), //1, +1
            //     _board.GetSymbolAtCoordinates(2, 2),//2
            //     _board.GetSymbolAtCoordinates(3, 3) //3
            // };
            var numberOfXSymbols = getDiagonalSpotsLtr().Count(x => x == Symbol.Cross);
            var numberOfOSymbols = getDiagonalSpotsLtr().Count(x => x == Symbol.Naught);
           var emptySpot = getDiagonalSpotsLtr().Count(x => x == Symbol.None);
           if (numberOfXSymbols == 1 && emptySpot == 1 && checkEmptySpotDiagonalRtlWhenLtrFilledByOpponent() || numberOfOSymbols == 1 && emptySpot == 1 && checkEmptySpotDiagonalRtlWhenLtrFilledByOpponent())
           {
               return new Move(getEmptySpotsDiagonalRtl().FirstOrDefault().XCoordinate, getEmptySpotsDiagonalRtl()
               .FirstOrDefault().YCoordinate);
           }
           return null;
        }
        private bool checkEmptySpotDiagonalRtlWhenLtrFilledByOpponent()
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
        
        private Move checkDiagonalLtr()
        {
            var filledXSpots = getDiagonalSpotsLtr().Count(x => x == Symbol.Cross);
            var filledOSpots = getDiagonalSpotsLtr().Count(x => x == Symbol.Naught);
            var emptySpot = getEmptySpotsDiagonalLtr().Count();
            if (filledXSpots == _board.Size - 1 && emptySpot == 1 || filledOSpots == _board.Size - 1 && emptySpot == 1)
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
        
        private Move checkDiagonalRtl()
        {
            var filledXSpots = getDiagonalSpotsRtl().Count(x => x == Symbol.Cross);
            var filledOSpots = getDiagonalSpotsRtl().Count(x => x == Symbol.Naught);
            var emptySpot = getEmptySpotsDiagonalRtl().Count();
            if (filledXSpots == _board.Size - 1 && emptySpot == 1 || filledOSpots == _board.Size - 1 && emptySpot == 1)
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

        private Move getCornerSpots()
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
            return moveList.FirstOrDefault();
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
    }
}