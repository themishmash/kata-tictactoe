using System.Linq;
using Xunit;

namespace kata_TicTacToe.Tests
{
    public class BoardShould
    {
        [Fact]
        public void CreateBoardOf9Spots()
        {
            var sut = new Board(3, 3);

            Assert.Equal(9, sut.GenerateBoard().Count);
        }

        [Fact]
        public void ContainSpecificCoordinatesOf33()
        {
            var sut = new Board(3, 3);
            sut.GenerateBoard();
            Assert.Equal(1, sut.CoordinateList.Count(c => c.XCoordinate == 3 && c.YCoordinate == 3));
        }

        //this test passes even without explicitly setting the status?
        [Fact]
        public void HaveCoordinateStatusBlankAtStartOfGame()
        {
            var sut = new Board(3, 3);
            sut.GenerateBoard();
            Assert.Equal(CoordinateStatus.Blank, sut.CoordinateList[0].CoordinateStatus);
        }

        [Fact]
        public void CheckForValidMove()
        {
            var sut = new Board(3, 3);
            sut.GenerateBoard();
            Assert.True(sut.IsValidMove(1,1));
        }

        [Fact]
         public void ChangeCoordinateStatusToFilledWhenPlaceCounter()
         {
             var sut = new Board(3, 3);
             sut.GenerateBoard();
             sut.IsValidMove(1, 1);
             sut.ChangeCoordinateStatus();
             Assert.Equal(CoordinateStatus.Filled, sut.CoordinateList[0].CoordinateStatus); 
         }
    }
}