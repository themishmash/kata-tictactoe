using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe
{
    public class Board
    {
       private readonly List<Square> _boardSquares = new List<Square>();


        public Board(int width, int length)
        {
            GenerateBoard(width, length);
        }

        public int BoardSquaresCount()
        {
            return _boardSquares.Count;
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
        
        public Symbol SymbolStatus(Move move)
        {
            foreach (var square in _boardSquares)
            {
                if (square.XCoordinate == move.XCoordinate && square.YCoordinate == move.YCoordinate && square.Symbol == Symbol.None)
                    return square.Symbol;
                if (square.XCoordinate == move.XCoordinate && square.YCoordinate == move.YCoordinate &&
                    square.Symbol == Symbol.Cross)
                    return square.Symbol;
                if (square.XCoordinate == move.XCoordinate && square.YCoordinate == move.YCoordinate &&
                    square.Symbol == Symbol.Naught)
                    return square.Symbol;
            }

            return Symbol.None;
        }

        public bool PlaceSymbolToCoordinates(Symbol symbol, Move move)
        {
            if (!IsSquareBlank(move)) return false;
            var newValidMove = new Square(move.XCoordinate, move.YCoordinate) {Symbol = symbol, SquareStatus = 
            SquareStatus.Filled};
            var foundNewMoveCoordinate = _boardSquares.First(i => i.XCoordinate == move.XCoordinate && i.YCoordinate ==
                move.YCoordinate);
            var index = _boardSquares.IndexOf(foundNewMoveCoordinate);
            if (index != -1)
                _boardSquares[index] = newValidMove;

            return true;
        }




    }
}