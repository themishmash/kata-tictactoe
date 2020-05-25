using Xunit;

namespace kata_TicTacToe.Tests
{
    public class Player1Should
    {
        [Fact]
        public void BeTheX()
        {
            var sut = new Player1();
            Assert.Equal(PlayerCounter.Crosses, sut.PlayerCounter);
        }

        // [Fact]
        // public void MarkCrossAsCoordinate()
        // {
        //     var board = new Board(3, 3);
        //     var sut = new Player1();
        //     sut.MarkCross(1, 1);
        //     
        //     //Assert.Equ, );
        //     
        // }
    }
}