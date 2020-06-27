using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe
{
    public class Board
    {
       private readonly List<Square> _boardSquares = new List<Square>();

       public int Size { get; }
       
        public Board(int size)
        {
            Size = size;
            GenerateBoard(size, size);
        }
        
        private void GenerateBoard(int width, int length) 
        {
            for (var row = 1; row <= width; row++)
            {
                for (var column = 1; column <= length; column++)
                {
                    var square = new Square(row, column);
                    _boardSquares.Add(square);
                }
            }
        }

        public string DisplayBoard()
        {
            var rows = new List<string>();
            
            foreach (var row in _boardSquares.GroupBy(s=> s.XCoordinate, s=> s))
            {
                rows.Add( string.Join("",row));
            }
            return string.Join(System.Environment.NewLine, rows);
          
        }
        
        public bool IsSquareBlank(Move move)
        {
            foreach (var square in _boardSquares)
            {
                if (square.XCoordinate == move.XCoordinate && square.YCoordinate == move.YCoordinate && square.Symbol == Symbol.None)
                    return true;
            }
            return false;
        }

        public Square FindEmptyCorner()
        {
            var cornerSpot = _boardSquares.FirstOrDefault(s => s.XCoordinate == s.YCoordinate || s.XCoordinate + s.YCoordinate
                == (Size + 1) && s.Symbol == Symbol.None);
           // PlaceSymbolToCoordinates(Symbol.Cross, new Move(cornerSpot.XCoordinate, cornerSpot.YCoordinate));
            return cornerSpot;
        }

        public bool CheckOpponentWinHorizontally(Symbol symbol)
        {
            for (var i = 1; i <= Size; i++)
            {
                var row = _boardSquares.Where(r => r.XCoordinate == i);
                var numberRow = row.Count(x => x.Symbol == symbol);
                if (numberRow == 2)
                {
                 
                    return true;
                }
            }
            return false;
        }

        public Square GetHorizontalEmptySpot()
        {
            for (var i = 1; i <= Size; i++)
            {
                var row = _boardSquares.Where(r => r.XCoordinate == i);
                var numberRow = row.Count(x => x.Symbol == Symbol.Naught);
                if (numberRow == 2)
                {
                    var emptySpot = row.Where(x => x.Symbol == Symbol.None);
                    foreach (var spot in emptySpot)
                    {
                        return spot;
                    }
                }
            }
            
            return null;
        }
        
        public bool CheckOpponentWinVertically(Symbol symbol)
        {
            for (var i = 1; i <= Size; i++)
            {
                var column = _boardSquares.Where(r => r.YCoordinate == i);
                var numberColumn = column.Count(x => x.Symbol == symbol);
                if (numberColumn == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public Square GetVerticalEmptySpot()
        {
            for (var i = 1; i <= Size; i++)
            {
                var row = _boardSquares.Where(r => r.YCoordinate == i);
                var numberColumn = row.Count(x => x.Symbol == Symbol.Naught);
                if (numberColumn == 2)
                {
                    var emptySpot = row.Where(x => x.Symbol == Symbol.None);
                    foreach (var spot in emptySpot)
                    {
                        return spot;
                    }
                }
            }
            
            return null;
        }

        
        
        public void PlaceSymbolToCoordinates(Symbol symbol, Move move)
        {
            
            var spot = _boardSquares.Find(s => s.XCoordinate == move.XCoordinate && s.YCoordinate == move.YCoordinate);
            _boardSquares[_boardSquares.IndexOf(spot)] = new Square(move.XCoordinate,move.YCoordinate, symbol);
        }
        
        public Symbol GetSymbolAtCoordinates(int xCoordinate, int yCoordinate)
        {
            return _boardSquares[(xCoordinate-1) * Size + (yCoordinate-1)].Symbol;
        }
        

        //Draw
        public bool IsFull()
        {
            return _boardSquares.TrueForAll(square => square.Symbol != Symbol.None);
        }
        
       
    }
}