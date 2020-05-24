namespace TicTacToe.Tests
{
    public class BoardShould
    {
        [Fact]
        public void CreateBoardOf9Spots()
        {
            var sut = new Board(3, 3)

            Assert.Equal(9, sut.GenerateBoard.Count());
        }
    }
}