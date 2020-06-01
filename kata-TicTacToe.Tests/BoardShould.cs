using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Xunit;

namespace kata_TicTacToe.Tests
{
    public class BoardShould
    {
        [Fact]
        public void CreateBoardOf9Squares()
        {
            var board = new Board(3, 3);
            Assert.Equal(9, board.BoardSquaresCount());
        }
        
        [Fact]
        public void GenerateSquaresInBoardWithCorrectCoordinates()
        {
            var board = new Board(3, 3);
//loop to test for all correct coordinates 
//or 4 corners

            Assert.Equal(" .  .  . \n .  .  . \n .  .  . ",board.DisplayBoard());
        }
        

         [Fact]
         public void ChangeSquareToPlayerSymbolXForValidMove()
         {
             var board = new Board(3, 3);
             //var playerX = new Player(board){Symbol = Symbol.Cross};
             //playerX.MakeMove(1, 1);
             var move = new Move(1,1);
             board.PlaceSymbolToCoordinates(Symbol.Cross, move);
             board.DisplayBoard();
             Assert.Equal(" X  .  . \n .  .  . \n .  .  . ",board.DisplayBoard());
         }

         [Fact]
         public void NotChangeWhenPlayerMakesMoveOnOccupiedSquare()
         {
             var board = new Board(3, 3);
             var move = new Move(1,1 );
             board.PlaceSymbolToCoordinates(Symbol.Cross, move);
             var move2 = new Move(1,1);
             board.PlaceSymbolToCoordinates(Symbol.Naught, move2);
             board.DisplayBoard();
             Assert.Equal(" X  .  . \n .  .  . \n .  .  . ",board.DisplayBoard());
         }
    }
}