using Xunit;

namespace kata_TicTacToe.Tests
{
    public class BestMoveDeciderTests
    {

        [Fact]
        public void MakeFirstMoveAsPlayer1()
        {
            //arrange
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            
            //Act
            var move = computer.PlayTurn();
            
            //Assert
           Assert.Equal(2, move.XCoordinate);
           Assert.Equal(2, move.YCoordinate);
        }
        
        [Fact]
        public void MakeMove2AsPlayer1()
        {
            //Arrange
            var board = new Board(3);
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,1));
            
            //Act
            var bestMove = new BestMoveDecider(board).NextMove();

            //Assert
            Assert.Equal(1, bestMove.XCoordinate);
            Assert.Equal(1, bestMove.YCoordinate);
        }

        [Fact]
        public void MakeMove3BlockHorizontalWinAsPlayer1()
        {
            //Arrange
            var board = new Board(3);
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught,new Move(3,1));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(1,1));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,3));
            
            //Act
            var bestMove = new BestMoveDecider(board).NextMove();

            //Assert
            Assert.Equal(3, bestMove.XCoordinate);
            Assert.Equal(2, bestMove.YCoordinate);
        }
        
        [Fact]
        public void MakeMove3BlockVerticalWinAsPlayer1()
        {
            //Arrange
            var board = new Board(3);
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,1));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(1,3));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,1));

            //Act
            var bestMove = new BestMoveDecider(board).NextMove();
            
            //Assert
            Assert.Equal(2, bestMove.XCoordinate);
            Assert.Equal(1, bestMove.YCoordinate);
        }
        
        [Fact]
        public void MakeMoveTwoBlockDiagonalWinRtlAsPlayer2()
        {
            //Arrange
            var board = new Board(3);
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(2,2));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(1,1));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,3));
            
            //Act
            var bestMove = new BestMoveDecider(board).NextMove();

            //Assert
            Assert.Equal(3, bestMove.XCoordinate);
            Assert.Equal(1, bestMove.YCoordinate);
        }
        
        [Fact]
        public void MakeMoveTwoBlockHorizontalWinAsPlayer2()
        {
            //Arrange
            var board = new Board(3);
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,1));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1, 2));
            
            //Act
            var bestMove = new BestMoveDecider(board).NextMove();

            //Assert
            Assert.Equal(1, bestMove.XCoordinate);
            Assert.Equal(3, bestMove.YCoordinate);
        }
        
        [Fact]
        public void MakeMoveTwoBlockVerticalWinAsPlayer2()
        {
            //Arrange
            var board = new Board(3);
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,1));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(2,1));
            
            //Act
            var bestMove = new BestMoveDecider(board).NextMove();

            //Assert
            Assert.Equal(1, bestMove.XCoordinate);
            Assert.Equal(1, bestMove.YCoordinate);
        }

        [Fact]
        public void MakeMoveForTwoInRowDiagonalPlayer1()
        {
            //Arrange
            var board = new Board(3);
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,3));
            
            //Act
            var bestMove = new BestMoveDecider(board).NextMove();

            //Assert 
            Assert.Equal(1, bestMove.XCoordinate);
            Assert.Equal(3, bestMove.YCoordinate);
        }

        [Fact]
        public void CanDrawPlayer1()
        {
            //Arrange
            var board = new Board(3);
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,3));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(1,3));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,1));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(3,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,2));
            
            //Act
            var bestMove = new BestMoveDecider(board).NextMove();

            //Assert
            Assert.Equal(1, bestMove.XCoordinate);
            Assert.Equal(1, bestMove.YCoordinate);
        }

        [Fact]
        public void CanWinDiagonalLtrPlayer1()
        {
            //Arrange
            var board = new Board(3);
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,2));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(1,1));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(2,1));
            
            //Act
            var bestMove = new BestMoveDecider(board).NextMove();

            //Assert
            Assert.Equal(3, bestMove.XCoordinate);
            Assert.Equal(3, bestMove.YCoordinate);
        }
        
        [Fact]
        public void CanWinDiagonalRtlPlayer1()
        {
            //Arrange
            var board = new Board(3);
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,2));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(1,1));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,3));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(1,3));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(2,3));
            
            //Act
            var bestMove = new BestMoveDecider(board).NextMove();
            
            //Assert
            Assert.Equal(3, bestMove.XCoordinate);
            Assert.Equal(1, bestMove.YCoordinate);
        }
      
        [Fact]
        public void CanWinHorizontalPlayer1()
        {
            var board = new Board(3);
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,1));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(1,3));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,1));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,1));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,2));
            
            //Act
            var bestMove = new BestMoveDecider(board).NextMove();

            //Assert
            Assert.Equal(2, bestMove.XCoordinate);
            Assert.Equal(3, bestMove.YCoordinate);
        }
        
        [Fact]
        public void CanWinVerticalPlayer1()
        {
            //Arrange
            var board = new Board(3);
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,1));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(1,1));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,3));
            board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(3,2));
            board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,3));
            
            //Act
            var bestMove = new BestMoveDecider(board).NextMove();

            //Assert
            Assert.Equal(1, bestMove.XCoordinate);
            Assert.Equal(2, bestMove.YCoordinate);
        }
        
        //makes optimal move for 4 x 4
        // [Fact]
        // public void MakesBestMoveFor4X4Board()
        // {
        //     var board = new Board(4);
        //     board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,1));
        //     board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(1,4));
        //     board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,2));
        //     board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(4,1));
        //     board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(2,1));
        //     board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(1,3));
        //     board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(2,2));
        //     board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,3));
        //     board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,2));
        //     board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(4,2));
        //     board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,4));
        //     
        //     //Act
        //     var bestMove = new BestMoveDecider(board).NextMove();
        //
        //     //Assert
        //     Assert.Equal(4, bestMove.XCoordinate);
        //     Assert.Equal(3, bestMove.YCoordinate);
        // }
    }
}