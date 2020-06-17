using Xunit;

namespace kata_TicTacToe.Tests
{
    public class BoardTests
    {

        [Fact]
        public void GenerateSquaresInBoardWithCorrectCoordinates()
        {
            var board = new Board(3);
            Assert.Equal(" .  .  . \n .  .  . \n .  .  . ",board.DisplayBoard());
        }
        
         [Fact]
         public void ChangeSquareToPlayerSymbolXForValidMove()
         {
             var board = new Board(3);
             var move = new Move(1,1);
             board.PlaceSymbolToCoordinates(Symbol.Cross, move);
             board.DisplayBoard();
             Assert.Equal(" X  .  . \n .  .  . \n .  .  . ",board.DisplayBoard());
         }
         
    }
}