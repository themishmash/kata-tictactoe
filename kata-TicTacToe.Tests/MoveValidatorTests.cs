using Xunit;

namespace kata_TicTacToe.Tests
{
    public class MoveValidatorTests
    {
        //up to here
        [Fact]
        public void NotPlaceSymbolOnOccupiedSquare()
        {
            var board = new Board(3, 3);
            var move = new Move(1, 1);
            Assert.Equal(SquareStatus.Filled, move.SquareStatus);
        }
    }
}