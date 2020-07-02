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

        public IEnumerable<Square> GetSquareAtCoordinates(int xCoordinate, int yCoordinate)
        {
            return _boardSquares.Where(x => x.XCoordinate == xCoordinate && x.YCoordinate == yCoordinate);
        }
     

        public bool IsFull()
        {
            return _boardSquares.TrueForAll(square => square.Symbol != Symbol.None);
        }
        
        //TODO USE THIS?
        //use this to return empty spots?
        public IEnumerable<Square> GetSpots()
        {
            return _boardSquares.FindAll(s => s.XCoordinate <= Size);
        }
        public IEnumerable<Square> GetDiagonalSpotsLtr()
        {
            return _boardSquares.Where(s =>
                s.XCoordinate == s.YCoordinate);
        }
        public IEnumerable<Square> GetDiagonalSpotsRtl()
        {
            return _boardSquares.Where(s => s.XCoordinate + s.YCoordinate == (Size + 1));
        }
        
        public IEnumerable<Square> GetRowSpots(int rowNumber)
        {
            return _boardSquares.Where(x => x.XCoordinate == rowNumber);
        }
        
        public IEnumerable<Square> GetColumnSpots(int columnNumber)
        {
            return _boardSquares.Where(x => x.YCoordinate == columnNumber);
        }

        public Square FindEmptySpot()
        {
            var emptySquares = _boardSquares.Where(x => x.Symbol == Symbol.None);
            return emptySquares.FirstOrDefault();
        }

        public bool HasEmptyCorner()
        {
            var emptySpot = GetCornerSpots().Count(x => x.Symbol == Symbol.None);
            return emptySpot > 1;
        }
        
         public Square GetEmptyCorner()
         {
             return GetCornerSpots().FirstOrDefault(s => s.Symbol == Symbol.None);
         }

         private IEnumerable<Square> GetCornerSpots()
         {
             var cornerSpot = _boardSquares.Where(s =>
                 s.XCoordinate == 1 && s.YCoordinate == 1 || s.XCoordinate == 1 && s.YCoordinate == Size ||
                 s.XCoordinate == Size && s.YCoordinate == 1 || s.XCoordinate == Size && s.YCoordinate == Size);
             return cornerSpot;
         }
         
        
    }
}