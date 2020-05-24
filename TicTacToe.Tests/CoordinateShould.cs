using System;
using kata_TicTacToe;
using Xunit;

namespace TicTacToe.Tests
{
    public class CoordinateShould
    {
        [Fact]
        public void HaveXAndYCoordinates()
        {
            var sut = new Coordinate(0, 0);
            
            Assert.Equal(0, sut.XCoordinate);
            Assert.Equal(0, sut.YCoordinate);
        }
    }
}