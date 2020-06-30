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
            return _boardSquares.Any(square => square.XCoordinate == move.XCoordinate && square.YCoordinate == move.YCoordinate && square.Symbol == Symbol.None);
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

        public bool IsFull()
        {
            return _boardSquares.TrueForAll(square => square.Symbol != Symbol.None);
        }

        public Square FindEmptySpot()
        {
            var emptySquares = _boardSquares.Where(x => x.Symbol == Symbol.None);
            return emptySquares.FirstOrDefault();
        }

        public bool HasEmptyCorner()
        {
            var cornerSpot = _boardSquares.Where(s => s.XCoordinate == s.YCoordinate || s
                    .XCoordinate
                + s
                    .YCoordinate
                == (Size + 1));
            var emptySpot = cornerSpot.Count(x => x.Symbol == Symbol.None);
            return emptySpot > 1;
        }
        
         public Square GetEmptyCorner()
        {
            var cornerSpot = _boardSquares.Where(s => s.XCoordinate == s.YCoordinate && s.Symbol == Symbol.None || s
            .XCoordinate
             + s
            .YCoordinate
                == (Size + 1) && s.Symbol == Symbol.None);
            return cornerSpot.FirstOrDefault();
        }

         public Square GetRowEmptySpot(Symbol symbol)
        {
            for (var i = 1; i <= Size; i++)
            {
                var row = _boardSquares.Where(r => r.XCoordinate == i);
                var numberRow = row.Count(x => x.Symbol == symbol);
                if (numberRow != 2) continue;
                {
                    var emptySpot = row.Where(x => x.Symbol != symbol);
                    return emptySpot.FirstOrDefault();
                }
            }
            return null;
        }

         public Square GetColumnEmptySpot(Symbol symbol)
        {
            for (var i = 1; i <= Size; i++)
            {
                var row = _boardSquares.Where(r => r.YCoordinate == i);
                var numberColumn = row.Count(x => x.Symbol == symbol);
                if (numberColumn != 2) continue;
                {
                    var emptySpot = row.Where(x => x.Symbol != symbol);
                    return emptySpot.FirstOrDefault();
                }
            }
            return null;
        }
         public IEnumerable<Square> GetDiagonalSpotsLtr()
         {
             return _boardSquares.Where(s =>
                 s.XCoordinate == s.YCoordinate);
         }

        // public bool HasOpponentSymbolInDiagonalLTR(Symbol symbol)
        // {
        //     var diagonal = new[]
        //     {
        //         GetSymbolAtCoordinates(1, 1),
        //         GetSymbolAtCoordinates(2, 2),
        //         GetSymbolAtCoordinates(3, 3)
        //     };
        //     
        //     var numberDiagonal = diagonal.Count(s => s == symbol);
        //     var emptySpot = diagonal.Count(s => s == Symbol.None);
        //     return numberDiagonal == 1 && emptySpot == 1;
        // }
        
        // public Square GetDiagonalEmptySpotLTR()
        // {
        //     var diagonal = _boardSquares.Where(s => s.XCoordinate == s.YCoordinate);
        //     var emptySpot = diagonal.Where(x => x.Symbol == Symbol.None);
        //     return emptySpot.FirstOrDefault();
        // }
        
        public IEnumerable<Square> GetDiagonalSpotsRtl()
        {
            return _boardSquares.Where(s =>
                s.XCoordinate + s.YCoordinate == (Size + 1));
        }
        
        // public Square GetDiagonalEmptySpotRTL()
        // {
        //     var diagonal = _boardSquares.Where(s => s.XCoordinate + s.YCoordinate == (Size + 1));
        //     var emptySpot = diagonal.Where(x => x.Symbol == Symbol.None);
        //     return emptySpot.FirstOrDefault();
        // }
        
        // public bool CheckEmptySpotDiagonalRTL()
        // {
        //     var diagonal = _boardSquares.Where(s => s.XCoordinate + s.YCoordinate == (Size + 1));
        //     var emptySpot = diagonal.Count(x => x.Symbol == Symbol.None);
        //     return emptySpot > 0;
        // }

        public bool CheckRow(Symbol symbol)
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
        
        // public IEnumerable<Square> GetRowSpots()
        // {
        //     IEnumerable<Square> squares;
        //     for (var i = 1; i <= Size; i++)
        //     {
        //        squares = _boardSquares.Where(r => r.XCoordinate == i);
        //     }
        //
        //     //return squares;
        // }
        
        
        
        public bool CheckColumn(Symbol symbol)
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
        
        // public bool CheckDiagonalLTR(Symbol symbol)
        // {
        //     var diagonal = _boardSquares.Where(s => s.XCoordinate == s.YCoordinate);
        //     var filledSpots = diagonal.Count(x => x.Symbol == symbol);
        //     var emptySpot = diagonal.Count(x => x.Symbol == Symbol.None);
        //     return filledSpots == 2 && emptySpot == 1;
        // }

        // public bool CheckDiagonalRTL(Symbol symbol)
        // {
        //     var diagonal = _boardSquares.Where(s => s.XCoordinate + s.YCoordinate == (Size +1));
        //     var filledSpots = diagonal.Count(x => x.Symbol == symbol);
        //     var emptySpot = diagonal.Count(x => x.Symbol == Symbol.None);
        //     return filledSpots == 2 && emptySpot == 1;
        // }
        
    }
}