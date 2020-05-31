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
        

        // [Fact]
        // public void HaveBlankCoordinatesAtStartOfTheGame()
        // {
        //     var board = new Board(3, 3);
        //     var blankCoordinate = new Coordinate(2,2);
        //     board.
        //     //Assert.True(board.IsValidMove(board.BoardSquares[0]));
        //     
        //     Assert.Equal(SquareStatus.Blank, blankCoordinate.SquareStatus);
        // }

        // [Fact]
        //  public void ChangeCoordinateStatusToFilledIfValidMove()
        //  {
        //      var board = new Board(3, 3);
        //      Assert.Equal(SquareStatus.Filled, board.ChangeStatusOfSquareForValidMove(1,1));
        //  }
         //
         // [Fact]
         // public void CoordinateStatusStaysFilledEvenIfCalledAgain()
         // {
         //     var board = new Board(3,3);
         //     board.ChangeStatusOfSquareForValidMove(1, 1);
         //     Assert.Equal(SquareStatus.Filled, board.ChangeStatusOfSquareForValidMove(1,1));
         // }

         [Fact]
         public void ChangeSquareToPlayerSymbolForValidMovie()
         {
             var board = new Board(3, 3);
             var playerX = new Player(board){Symbol = Symbol.Cross};
             //var move = new Move(1, 1);
             playerX.MakeMove(1, 1);
             board.UpdateBoard();
             Assert.Equal(" X  .  . \n .  .  . \n .  .  . ",board.DisplayBoard());
         }
    }
}