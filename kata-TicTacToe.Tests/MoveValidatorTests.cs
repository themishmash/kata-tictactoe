using Xunit;

namespace kata_TicTacToe.Tests
{
    public class MoveValidatorTests
    {
        //up to here
        [Fact]
         public void PlaceSymbolOnVacantSpot()
         {
             var board = new Board(3, 3);
             var move = new Move(1, 1);
             //board.PlaceSymbolToCoordinates(Symbol.Cross, move);
             Assert.True(MoveValidator.IsValidMove(move, board));
         }
         
         [Fact]
         public void CannotPlaceSymbolOnFilledSpot()
         {
             var board = new Board(3, 3);
             var move = new Move(1, 1);
             var move2 = new Move(1, 1);
             board.PlaceSymbolToCoordinates(Symbol.Cross, move);
             //board.PlaceSymbolToCoordinates(Symbol.Naught, move2);
          
             //Assert.True(MoveValidator.IsValidMove(move, board));
             Assert.False(MoveValidator.IsValidMove(move2, board));
          
         }
    }
}