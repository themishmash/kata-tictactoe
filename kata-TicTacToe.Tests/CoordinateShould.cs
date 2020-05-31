using Xunit;

namespace kata_TicTacToe.Tests
{
    public class CoordinateShould
    {
        [Fact]
        public void HaveXAndYCoordinates()
        {
            var coordinate = new Square(1,1);
            Assert.Equal(1, coordinate.XCoordinate);
            Assert.Equal(1, coordinate.YCoordinate);
        }

        
       
        
    }
}