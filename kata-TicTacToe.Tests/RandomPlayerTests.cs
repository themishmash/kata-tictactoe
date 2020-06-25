using Xunit;

namespace kata_TicTacToe.Tests
{
    public class RandomPlayerTests
    {
        [Fact]
        public void PlaceSymbolWithXAndYCoordinates()
        {
            //should be same as player essentially
            //arrange
            var input = new RandomPlayerInput(2); //this is done twice 
            var randomPlayer = new RandomPlayer(input, Symbol.Naught, "randomPlayer");
            //act
            var move = randomPlayer.PlayTurn();
            
            //assert
            Assert.Equal(2, move.XCoordinate);
            Assert.Equal(2, move.YCoordinate);
        }
    }
}