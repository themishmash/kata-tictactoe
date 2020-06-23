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
            //[1,2,3]
            //123
            //1+2+3
            //1
            //2
            //3
            //needed groupby because of 1D array i set up. taking each row, joining them with empty string
            //Then newline 
            //[[x,x,x],[ ,o, ],[o, , ]] //group by puts it like that
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
            //Windy way
            // var spot = _boardSquares.Find(s => s.XCoordinate == move.XCoordinate && s.YCoordinate == move.YCoordinate);
            // _boardSquares[_boardSquares.IndexOf(spot)].Symbol = symbol;
            
            
            // your list contains 9 square obj
            //     find the coordinate
            //         get the existing obj and change the property of the object
            
            //I was creating a new object, find the coordinate and then updating with new object
            

             var newValidMove = new Square(move.XCoordinate, move.YCoordinate) {Symbol = symbol};
             var foundNewMoveCoordinateInList = _boardSquares.First(square => square.XCoordinate == move.XCoordinate && square
             .YCoordinate ==
                 move.YCoordinate);
             var index = _boardSquares.IndexOf(foundNewMoveCoordinateInList);
             if (index != -1)
                 _boardSquares[index] = newValidMove;
            
             //_boardSquares = new List<Square>().AsReadOnly();
            
            //Sol showing his way
            // _boardSquares.Insert(_boardSquares.Find(s => s.XCoordinate != move.XCoordinate && s.YCoordinate != move
            //     .YCoordinate));
            // _boardSquares.Add(new Square(move.XCoordinate,move.YCoordinate, symbol));
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