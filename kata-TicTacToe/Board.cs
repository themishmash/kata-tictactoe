using System;
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

        public bool HasMoreThanOneBlankSquare()
        {
            var emptySquares = _boardSquares.Where(x => x.Symbol == Symbol.None);
            var numberOfEmptySquares = emptySquares.Count();
            if (numberOfEmptySquares > 1)
            {
                return true;
            }
            return false;
        }

        public Square FindEmptySpot()
        {
            var emptySquares = _boardSquares.Where(x => x.Symbol == Symbol.None);
            return emptySquares.FirstOrDefault();
        }

        public bool HasEmptyCorner()
        {
            var cornerSpot = _boardSquares.Where(s => s.XCoordinate == s.YCoordinate && s.Symbol == Symbol.None || s
                    .XCoordinate
                + s
                    .YCoordinate
                == (Size + 1) && s.Symbol == Symbol.None);
            var emptySpot = cornerSpot.Count(x => x.Symbol == Symbol.None);
            if (emptySpot > 1)
            {
                return true;
            }

            return false;
        }
        
         public Square FindEmptyCorner()
        {
            var cornerSpot = _boardSquares.Where(s => s.XCoordinate == s.YCoordinate && s.Symbol == Symbol.None || s
            .XCoordinate
             + s
            .YCoordinate
                == (Size + 1) && s.Symbol == Symbol.None);
            // PlaceSymbolToCoordinates(Symbol.Cross, new Move(cornerSpot.XCoordinate, cornerSpot.YCoordinate));
            return cornerSpot.FirstOrDefault();
        }

        public bool CheckOpponentWinHorizontally(Symbol symbol)
        {
            for (var i = 1; i <= Size; i++)
            {
                var row = _boardSquares.Where(r => r.XCoordinate == i);
                var numberRow = row.Count(x => x.Symbol == symbol);
                var emptySpot = row.Count(x => x.Symbol == Symbol.None);
                if (numberRow == 2 && emptySpot == 1 )
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
                    var emptySpot = row.Where(x => x.Symbol != Symbol.Naught);
                    return emptySpot.FirstOrDefault();
                }
            }
            
            return null;
        }
        
        public bool CheckOpponentWinVertically(Symbol symbol)
        {
            for (var i = 1; i <= Size; i++)
            {
                var column = _boardSquares.Where(r => r.YCoordinate == i);
                var emptySpot = column.Count(x => x.Symbol == Symbol.None);
                var numberColumn = column.Count(x => x.Symbol == symbol);
                if (numberColumn == 2 && emptySpot ==1)
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
                    var emptySpot = row.Where(x => x.Symbol != Symbol.Naught);
                    return emptySpot.FirstOrDefault();
                }
            }
            
            return null;
        }

        public bool HasOpponentSymbolInDiagonalRTL(Symbol symbol)
        {
            var diagonal = _boardSquares.Where(s => s.XCoordinate + s.YCoordinate == (Size + 1));
            var numberDiagonal = diagonal.Count(x => x.Symbol == symbol);
            if (numberDiagonal == 1)
            {
                return true;
            }
            return false;
        }
        
        public bool HasOpponentSymbolInDiagonalLTR(Symbol symbol)
        {
            var diagonal = _boardSquares.Where(s => s.XCoordinate == s.YCoordinate);
            var numberDiagonal = diagonal.Count(x => x.Symbol == symbol);
            var emptySpot = diagonal.Count(x => x.Symbol == Symbol.None);
            if (numberDiagonal == 1 && emptySpot == 1)
            {
                return true;
            }
            return false;
        }
        
        public Square GetDiagonalEmptySpotLTR()
        {
            
                var diagonal = _boardSquares.Where(s => s.XCoordinate == s.YCoordinate);
                var emptySpot = diagonal.Where(x => x.Symbol == Symbol.None);
                return emptySpot.FirstOrDefault();
        }
        
        public bool HasTwoOpponentSymbolIinDiagonalLTR(Symbol symbol)
        {
            for (var i = 1; i <= Size; i++)
            {
                var diagonal = _boardSquares.Where(s => s.XCoordinate == s.YCoordinate);
                var numberDiagonal = diagonal.Count(x => x.Symbol == symbol);
                if (numberDiagonal == 2)
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool HasTwoOpponentSymbolIinDiagonalRTL(Symbol symbol)
        {
            var diagonal = _boardSquares.Where(s => s.XCoordinate + s.YCoordinate == (Size + 1));
            var numberDiagonal = diagonal.Count(x => x.Symbol == symbol);
            var emptySpot = diagonal.Count(x => x.Symbol == Symbol.None);
            if (numberDiagonal == 2 && emptySpot == 1)
            {
                return true;
            }
            return false;
        }
        
        public bool HasSingleOpponentSymbolIinDiagonalLTR(Symbol symbol)
        {
            for (var i = 1; i <= Size; i++)
            {
                var diagonal = _boardSquares.Where(s => s.XCoordinate == s.YCoordinate);
                var numberDiagonal = diagonal.Count(x => x.Symbol == symbol);
                if (numberDiagonal == 1)
                {
                    return true;
                }
            }
            return false;
        }
        
        
        public Square GetDiagonalEmptySpotRTL()
        {
            var diagonal = _boardSquares.Where(s => s.XCoordinate + s.YCoordinate == (Size + 1));
            var emptySpot = diagonal.Where(x => x.Symbol == Symbol.None);
            return emptySpot.FirstOrDefault();
        }

        public bool CheckEmptySpotDiagonalRTL()
        {
            var diagonal = _boardSquares.Where(s => s.XCoordinate + s.YCoordinate == (Size + 1));
            var emptySpot = diagonal.Count(x => x.Symbol == Symbol.None);
            if (emptySpot > 0)
            {
                return true;
            }

            return false;
        }
       
    }
}