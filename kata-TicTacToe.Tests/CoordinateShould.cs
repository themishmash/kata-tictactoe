using System;
using Xunit;

namespace kata_TicTacToe.Tests
{
    public class CoordinateShould
    {
        [Fact]
        public void HaveXYCoordinates()
        {
            var coordinate = new Coordinate(1,1);
            Assert.Equal(1, coordinate.XCoordinate);
            Assert.Equal(1, coordinate.YCoordinate);
        }

        // [Fact]
        // public void BeEmptyToBeginWith()
        // {
        //     var sut = new Coordinate(1,1);
        //     Assert.Equal(CoordinateStatus.Blank, sut.CoordinateStatus);
        // }
       
        
    }
}