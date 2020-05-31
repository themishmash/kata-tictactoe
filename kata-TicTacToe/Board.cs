using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe
{
    public class Board
    {
     
        private readonly List<Square> _boardSquares = new List<Square>();
        //private readonly Move _move;


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


        public void IsValidMove(Move move, Symbol playerSymbol)
        {
            //var move = new Move(xCoordinate, yCoordinate);
            foreach (var square in _boardSquares)
            {
                if (square.XCoordinate == move.XCoordinate && square.YCoordinate == move.YCoordinate && square
                        .SquareStatus ==
                    SquareStatus
                        .Blank)
                    square.Symbol = playerSymbol;
                
                // customListItem2 = customListItems.Where(i=> i.name == "Item 2").First();
                // var index = customListItems.IndexOf(customListItem2);
                //
                // if(index != -1)
                //     customListItems[index] = newCustomListItem;
               
                var newValidMove = new Square(move.XCoordinate, move.YCoordinate) {Symbol = playerSymbol};
                var newMoveCoordinate = _boardSquares.First(i => i.XCoordinate == move.XCoordinate && i.YCoordinate ==
                    move.YCoordinate);
                var index = _boardSquares.IndexOf(newMoveCoordinate);
                if (index != -1)
                    _boardSquares[index] = newValidMove;
                
             
                //_boardSquares.Add(new Square(1,1){Symbol = playerSymbol});
               // _boardSquares.Add(newMove);

                return;
            }
        }

        
        
        
    }
}