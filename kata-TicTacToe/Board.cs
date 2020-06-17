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
           //if (!IsSquareBlank(move)) return;
            var newValidMove = new Square(move.XCoordinate, move.YCoordinate) {Symbol = symbol, SquareStatus = 
            SquareStatus.Filled};
            var foundNewMoveCoordinateInList = _boardSquares.First(square => square.XCoordinate == move.XCoordinate && square
            .YCoordinate ==
                move.YCoordinate);
            var index = _boardSquares.IndexOf(foundNewMoveCoordinateInList);
            if (index != -1)
                _boardSquares[index] = newValidMove;
        }
        
        public Symbol GetSymbolAtCoordinates(int xCoordinate, int yCoordinate)
        {
            return _boardSquares[(xCoordinate-1) * Size + (yCoordinate-1)].Symbol;
        }
        
        public IEnumerable<Square> FindSumXCoordinateYCoordinateEqualSizePlusOne()
        {
            var diagonal = _boardSquares.Where(square => square.XCoordinate + square.YCoordinate == (Size + 1));
            return diagonal;
        }
        
        public IEnumerable<Square> FindCoordinatesWhereXCoordinateEqualsYCoordinate()
        {
            var diagonal = _boardSquares.Where(square => square.XCoordinate == square.YCoordinate);
            return diagonal;
        }

        //Draw
        public bool HasDraw()
        {
            return _boardSquares.TrueForAll(square => square.SquareStatus == SquareStatus.Filled);
        }
        
        // public bool HasWonVerticallyCheckCoordinates(Symbol symbol)
        // {
        //
        //     for (var i = 1; i <= _size; i++)
        //     {
        //         var column = _boardSquares.Where(r => r.YCoordinate == i);
        //         if (column.All(square => square.Symbol == symbol))
        //             return true;
        //     }
        //     return false;
        // }
        
        // public bool HasWonVerticallyCheckCoordinates(Symbol symbol, int yCoordinate)
        // {
        //
        //     for (var x = 1; x <= Size; x++)
        //     {
        //         if (GetSymbolAtCoordinates(x, yCoordinate) != symbol)
        //             return false;
        //     }
        //     return true;
        // }
        // public bool HasWonDiagonallyLeftToRightCheckCoordinates(Symbol symbol)
        // {
        //
        //     for (var i = 1; i <= Size; i++)
        //     {
        //         var diagonal = FindCoordinatesWhereXCoordinateEqualsYCoordinate();
        //         if (diagonal.All(square => square.Symbol == symbol))
        //             return true;
        //     }
        //     return false;
        // }

        
        
        // public bool HasWonDiagonallyRightToLeftCheckCoordinates(Symbol symbol)
        // {
        //
        //     for (var i = 1; i <= Size; i++)
        //     {
        //         var diagonal = FindSumXCoordinateYCoordinateEqualSizePlusOne();
        //         if (diagonal.All(square => square.Symbol == symbol))
        //             return true;
        //     }
        //     return false;
        // }

        

       
    }
}