using Xunit;

namespace kata_TicTacToe.Tests
{
    public class PlayerTests
    {
        
        [Fact]
         public void PlaceSymbolWithXAndYCoordinates()
         {
             //arrange
             var input = new PlayerInput((1,1));
             var playerX = new Player(input, Symbol.Cross);
             //act
             var move = playerX.PlayTurn();
             //assert
             Assert.Equal(1, move.XCoordinate);
             Assert.Equal(1, move.YCoordinate);
         }
        
         
        [Fact]
        public void PlayerHasCorrectXSymbol()
        {
            var input = new PlayerInput((1,1));
            var playerX = new Player(input, Symbol.Cross);
            Assert.Equal(Symbol.Cross, playerX.Symbol);
        }
        
    }
}