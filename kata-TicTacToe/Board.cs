using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe
{
    public class Board
    {
       private readonly List<Square> _boardSquares = new List<Square>();
       private readonly List<Square> _wins = new List<Square>();
       private readonly int _size;
       
        public Board(int size)
        {
            _size = size;
            GenerateBoard(size, size);
        }

        public int BoardSquaresCount()
        {
            return _size;
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
        

        public Symbol GetSymbolAtCoordinates(int xCoordinate, int yCoordinate)
        {
            return _boardSquares[(xCoordinate-1) * _size + (yCoordinate-1)].Symbol;
        }

        //Using coordinates to check wins
        public bool HasWonHorizontallyCheckCoordinates(Symbol symbol, int xCoordinate)
        {
            for (var y = 1; y <= _size; y++)
            {
                var getSymbol = GetSymbolAtCoordinates(xCoordinate, y) != symbol;
              if(GetSymbolAtCoordinates(xCoordinate, y) != symbol )
                    return false;
            }
            return true;
        }
        
        public bool HasWonVerticallyCheckCoordinates(Symbol symbol)
        {

            for (var i = 1; i <= _size; i++)
            {
                var column = _boardSquares.Where(r => r.YCoordinate == i);
                if (column.All(square => square.Symbol == symbol))
                    return true;
            }
            return false;
        }
        
        public bool HasWonDiagonallyLeftToRightCheckCoordinates(Symbol symbol)
        {

            for (var i = 1; i <= _size; i++)
            {
                var diagonal = _boardSquares.Where(r => r.XCoordinate == r.YCoordinate);
                if (diagonal.All(square => square.Symbol == symbol))
                    return true;
            }
            return false;
        }
        
        public bool HasWonDiagonallyRightToLeftCheckCoordinates(Symbol symbol)
        {

            for (var i = 1; i <= _size; i++)
            {
                var diagonal = _boardSquares.Where(r => r.XCoordinate + r.YCoordinate == (_size +1));
                if (diagonal.All(square => square.Symbol == symbol))
                    return true;
            }
            return false;
        }
        
        
        
        //Draw
        public bool HasDraw()
        {
            if (_boardSquares.TrueForAll(x => x.SquareStatus == SquareStatus.Filled))
                return true;
            return false;
        }

       
    }
}