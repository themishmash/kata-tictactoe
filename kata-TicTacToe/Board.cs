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
        
        // public Symbol SymbolStatus(Move move)
        // {
        //     foreach (var square in _boardSquares)
        //     {
        //         if (square.XCoordinate == move.XCoordinate && square.YCoordinate == move.YCoordinate && square.Symbol == Symbol.None)
        //             return square.Symbol;
        //         if (square.XCoordinate == move.XCoordinate && square.YCoordinate == move.YCoordinate &&
        //             square.Symbol == Symbol.Cross)
        //             return square.Symbol;
        //         if (square.XCoordinate == move.XCoordinate && square.YCoordinate == move.YCoordinate &&
        //             square.Symbol == Symbol.Naught)
        //             return square.Symbol;
        //     }
        //
        //     return Symbol.None;
        // }

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


        public bool HasWonHorizontally(Symbol symbol)
        {

            if (_boardSquares[0].Symbol == symbol && _boardSquares[1].Symbol == symbol &&
                _boardSquares[2].Symbol == symbol)
            {
                return true;
            }
            if (_boardSquares[3].Symbol == symbol && _boardSquares[4].Symbol == symbol &&
                _boardSquares[5].Symbol == symbol)
            {
                return true;
            }
            return _boardSquares[6].Symbol == symbol && _boardSquares[7].Symbol == symbol &&
                   _boardSquares[8].Symbol == symbol;
        }

        public bool HasWonHorizontallyAll(Symbol symbol)
        {
            var squareRoot = Math.Sqrt(BoardSquaresCount());
            var intSquare = Convert.ToInt32(squareRoot);
            
                var row1 = _boardSquares.Where((square, index) => index < (intSquare - 1));
                if (row1.All(x => x.Symbol == symbol))
                    return true;
                
                var row2 = _boardSquares.Where((square, index) => index > (intSquare - 1) && index < ((2*intSquare)));
                if (row2.All(x => x.Symbol == symbol))
                     return true;
                
                return false;
        }

        public bool HasWonHorizontallyCheckCoordinates(Symbol symbol)
        {
            var squareRoot = Math.Sqrt(BoardSquaresCount());
            var intSquare = Convert.ToInt32(squareRoot);

            for (var i = 1; i <= intSquare; i++)
            {
                var row = _boardSquares.Where(r => r.XCoordinate == i);
                if (row.All(square => square.Symbol == symbol))
                    return true;
            }
            return false;
        }
        
        public bool HasWonVerticallyCheckCoordinates(Symbol symbol)
        {
            var squareRoot = Math.Sqrt(BoardSquaresCount());
            var intSquare = Convert.ToInt32(squareRoot);

            for (var i = 1; i <= intSquare; i++)
            {
                var column = _boardSquares.Where(r => r.YCoordinate == i);
                if (column.All(square => square.Symbol == symbol))
                    return true;
            }
            return false;
        }
        
        public bool HasWonDiagonallyLeftToRightCheckCoordinates(Symbol symbol)
        {
            var squareRoot = Math.Sqrt(BoardSquaresCount());
            var intSquare = Convert.ToInt32(squareRoot);

            for (var i = 1; i <= intSquare; i++)
            {
                var diagonal = _boardSquares.Where(r => r.XCoordinate == r.YCoordinate);
                if (diagonal.All(square => square.Symbol == symbol))
                    return true;
            }
            return false;
        }
        
        public bool HasWonDiagonallyRightToLeftCheckCoordinates(Symbol symbol)
        {
            var squareRoot = Math.Sqrt(BoardSquaresCount());
            var intSquare = Convert.ToInt32(squareRoot);

            for (var i = 1; i <= intSquare; i++)
            {
                var diagonal = _boardSquares.Where(r => r.XCoordinate + r.YCoordinate == (intSquare +1));
                if (diagonal.All(square => square.Symbol == symbol))
                    return true;
            }
            return false;
        }
        

        // public bool HasWonHorizontallyAll(Symbol symbol)
        // {
            // var squareRoot = Math.Sqrt(BoardSquaresCount());
            // var intSquare = Convert.ToInt32(squareRoot);
            //
            // for (var index = 0; index < 3; index++)
            // {
            //     if (_boardSquares[index].Symbol == symbol)
            //     {
            //         _wins.Add(_boardSquares[index]);
            //     }
            //     
            // }

            // for (var i = 0; i < _boardSquares.Count; i++)
            // {
            //     if (_boardSquares[i].Symbol == symbol)
            //     {
            //         _wins.Add(_boardSquares[i]);
            //         if (_wins.Count >= 3 && symbol == Symbol.Cross || _wins.Count >= 3 && symbol == Symbol.Naught)
            //         {
            //             return true;
            //         }
            //
            //       if(_wins.Contains(_boardSquares[]))
            //     }
            // }


           // return false;
            // for (var index = 0; index <= squareRoot; index++)
            // {
            //   var item = _boardSquares[index].Symbol == symbol;
            // }
            //
            // return false;
            // var query = _boardSquares.Where((elements, index) => (index < intSquare - 1));
            // foreach (var b in query)
            // {
            //     if (b.Symbol == symbol)
            //         return true;
            //     return false;
            // }
            //
            // return false;





        //}
        
        public bool HasWonVertically(Symbol symbol)
        {
            if (_boardSquares[0].Symbol == symbol && _boardSquares[3].Symbol == symbol &&
                _boardSquares[6].Symbol == symbol)
            {
                return true;
            }
            if (_boardSquares[1].Symbol == symbol && _boardSquares[4].Symbol == symbol &&
                _boardSquares[7].Symbol == symbol)
            {
                return true;
            }
            return _boardSquares[2].Symbol == symbol && _boardSquares[5].Symbol == symbol &&
                   _boardSquares[8].Symbol == symbol;
        }
        
        public bool HasWonDiagonally(Symbol symbol)
        {
            if (_boardSquares[0].Symbol == symbol && _boardSquares[4].Symbol == symbol &&
                _boardSquares[8].Symbol == symbol)
            {
                return true;
            }
            return _boardSquares[2].Symbol == symbol && _boardSquares[4].Symbol == symbol &&
                   _boardSquares[6].Symbol == symbol;
        }

        public bool HasDraw()
        {
            if (_boardSquares.TrueForAll(x => x.SquareStatus == SquareStatus.Filled))
                return true;
            return false;
        }

       
    }
}