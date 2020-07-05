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

            move = GetCornerSpots();
            if (move != null) return move;
            
           return FindEmptySpot();

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

            move = CheckDiagonalLtr();
            if (move != null) return move;

            move = CheckDiagonalRtl();
            if (move != null) return move;

            move = HasOpponentSymbolDiagonalLtr();
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
                var numberOfXSymbols = GetColumnSpots(i, Symbol.Cross);
                var numberOfOSymbols = GetColumnSpots(i, Symbol.Naught);
                var emptySpotsColumn = GetEmptySpotsColumn(i);
                if ((numberOfXSymbols == _board.Size-1 || numberOfOSymbols == _board.Size-1) && emptySpotsColumn !=null)
                {
                    return emptySpotsColumn;
                }
            }
            return null;
        }
        
        private int GetColumnSpots(int columnNumber, Symbol symbol)
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                symbolList.Add(_board.GetSymbolAtCoordinates(i, columnNumber));
            }

            return symbolList.Count(x => x == symbol);
        }

        private Move GetEmptySpotsColumn(int columnNumber)
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(i, columnNumber) == Symbol.None)
                {
                    moveList.Add(new Move(i, columnNumber));
                }
            }
            return moveList.FirstOrDefault();
        }
        
        private Move HasOpponentSymbolDiagonalLtr()
        {
            //find way to refactor this method too
            // var diagonal = new[]
            // {
            //     _board.GetSymbolAtCoordinates(1, 1), //1, +1
            //     _board.GetSymbolAtCoordinates(2, 2),//2
            //     _board.GetSymbolAtCoordinates(3, 3) //3
            // };
            var numberOfXSymbols = GetDiagonalSpotsLtr(Symbol.Cross);
            var numberOfOSymbols = GetDiagonalSpotsLtr(Symbol.Naught);
           var emptySpot = GetDiagonalSpotsLtr(Symbol.None);
           if ((numberOfXSymbols == 1 || numberOfOSymbols == 1) && emptySpot == 1 && CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent())
           {
               return GetEmptySpotsDiagonalRtl().FirstOrDefault();
           }
           return null;
        }
        private bool CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent()
        {
            return GetEmptySpotsDiagonalRtl().Count() == _board.Size - 1;
        }
        
        private Move CheckDiagonalLtr()
        {
            var numberOfXSymbols = GetDiagonalSpotsLtr(Symbol.Cross);
            var numberOfOSymbols = GetDiagonalSpotsLtr(Symbol.Naught);
            var emptySpot = GetEmptySpotsDiagonalLtr();
            if ((numberOfXSymbols == _board.Size - 1 || numberOfOSymbols == _board.Size -1) && emptySpot !=null)
            {
                return GetEmptySpotsDiagonalLtr();
            }
            return null;
        }

        private int GetDiagonalSpotsLtr(Symbol symbol)
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                 symbolList.Add(_board.GetSymbolAtCoordinates(i, i));
            }
            return symbolList.Count(x => x == symbol);
        }
        
        private Move GetEmptySpotsDiagonalLtr()
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(i, i) == Symbol.None)
                {
                    moveList.Add(new Move(i, i));
                }
            }
            return moveList.FirstOrDefault();
        }
        
        private Move CheckDiagonalRtl()
        {
            var filledXSpots = GetDiagonalSpotsRtl(Symbol.Cross);
            var filledOSpots = GetDiagonalSpotsRtl(Symbol.Naught);
            var emptySpot = GetEmptySpotsDiagonalRtl().Count();
            if (filledXSpots == _board.Size - 1 && emptySpot == 1 || filledOSpots == _board.Size - 1 && emptySpot == 1)
            {
                return GetEmptySpotsDiagonalRtl().FirstOrDefault();
            }
            return null;
        }
        
        private int GetDiagonalSpotsRtl(Symbol symbol)
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                symbolList.Add(_board.GetSymbolAtCoordinates(i, (_board.Size+1)-i));
            }
            return symbolList.Count(x => x == symbol);
        }

        private IEnumerable<Move> GetEmptySpotsDiagonalRtl()
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

        private Move GetCornerSpots()
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

        private Move FindEmptySpot()
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