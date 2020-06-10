using Xunit;

namespace kata_TicTacToe.Tests
{
    public class PlayerTests
    {
        
        [Fact]
         public void PlaceSymbolWithXYCoordinates()
         {
             var input = new AutomatedPlayer((1,1));
             var playerX = new Player(input, Symbol.Cross);
             var move = playerX.PlayTurn();
             Assert.Equal(1, move.XCoordinate);
             Assert.Equal(1, move.YCoordinate);
         }
        
        
         
        [Fact]
        public void PlayerHasCorrectXSymbol()
        {
            var input = new AutomatedPlayer((1,1));
            var playerX = new Player(input, Symbol.Cross);
            Assert.Equal(Symbol.Cross, playerX.Symbol);
        }
        
    }
}