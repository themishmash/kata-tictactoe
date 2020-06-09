using Xunit;

namespace kata_TicTacToe.Tests
{
    public class MoveValidatorTests
    {
        //up to here
        [Fact]
         public void MoveIsValidWhenCheckingToPlaceSymbolOnVacantSpot()
         {
             var board = new Board(3, 3);
             var move = new Move(1, 1);
           
             Assert.True(MoveValidator.IsValidMove(move, board));
         }

         [Fact] public void MoveIsInvalidWhenCheckingToPlaceSymbolOnFilledSpot()
         {
             var board = new Board(3, 3);
             var validMove = new Move(1, 1);
             var invalidMove = new Move(1, 1);
             board.PlaceSymbolToCoordinates(Symbol.Cross, validMove);
            
             Assert.False(MoveValidator.IsValidMove(invalidMove, board));
         }

         [Fact]
         public void MoveIsInvalidWhenCheckingToPlaceSymbolOnSpotOutsideOfBoundaries()
         {
             var board = new Board(3, 3);
             var move = new Move(4, 4);
             
             Assert.False(MoveValidator.IsValidMove(move, board));
         }

         [Fact]
         public void MoveIsInvalidWhenCheckingToPlaceSymbolOnSpotWithNegativeCoordinates()
         {
             var board = new Board(3,3);
             var move = new Move(-1, -2);
             Assert.False(MoveValidator.IsValidMove(move, board));
         }
    }
}