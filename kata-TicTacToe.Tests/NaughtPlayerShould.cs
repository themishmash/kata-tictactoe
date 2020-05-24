using Xunit;

namespace kata_TicTacToe.Tests
{
    public class NaughtPlayerShould
    {
        [Fact]
        public void MarkNaughtOnBoardForEachTurn()
        {
            var board = new Board(3, 3);
            var sut = new NaughtPlayer();
            sut.MarkNaught();
           // Assert.Equal("O", board.GenerateBoard().Contains("0"));
        }
    }
}