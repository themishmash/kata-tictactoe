using Xunit;

namespace kata_TicTacToe.Tests
{
    public class SquareTests
    {
        [Fact]
        public void HaveXAndYCoordinates()
        {
            var coordinate = new Square(1,1);
            Assert.Equal(1, coordinate.XCoordinate);
            Assert.Equal(1, coordinate.YCoordinate);
        }

        [Fact]
        public void GetCorrectStringFromSymbol()
        {
            var square = new Square(1,1){Symbol = Symbol.Cross};
            var str = square.ToString();
            Assert.Equal(" X ", str);
        }
        
       
        
    }
}