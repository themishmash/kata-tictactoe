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
    }
}