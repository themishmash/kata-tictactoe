using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe
{
    public class Board
    {
     
        public readonly List<Square> _boardSquares = new List<Square>();


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

        

        // private bool IsValidMove(Move move)
        // {
        //     foreach (var square in _boardSquares)
        //     {
        //         if (square.XCoordinate == move.XCoordinate && square.YCoordinate == move.YCoordinate && square.SquareStatus == SquareStatus.Blank && square.Symbol == Symbol.None)
        //             return true;
        //     }
        //     return false;
        // }

        public bool PlaceSymbolToCoordinates(Symbol symbol, Move move)
        {
            //var moveValidator = new MoveValidator();
            if (!MoveValidator.IsValidMove(move, _boardSquares)) return false;
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