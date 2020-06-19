using Xunit;

namespace kata_TicTacToe.Tests
{
    public class TicTacToeTest
    {
    
        [Fact]
        public void PlayerWinsHorizontallyFirstRow()
        {
            //arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((1,1),(1,2),(1,3));
            var playerX = new Player(testInputX, Symbol.Cross, "player x");
           
            var testInputO = new PlayerInput((2,1),(3,1),(2,2));
            var playerO = new Player(testInputO, Symbol.Naught, "player o");
            
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
            //act
            ticTacToe.PlayGame();
            //Assert
            Assert.Equal(" X  X  X \n O  .  . \n O  .  . ",board.DisplayBoard());
            // Assert.Equal(GameStatus.Won, playerX.GameStatus);
            Assert.Equal(GameStatus.Won, ticTacToe.GameStatus);
        }
        
        [Fact]
        public void PlayerWinsHorizontallySecondRow()
        {
            //arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((2,1),(2,2),(2,3));
            var playerX = new Player(testInputX, Symbol.Cross, "player x");
           
            var testInputO = new PlayerInput((1,1),(3,1),(3,2));
            var playerO = new Player(testInputO, Symbol.Naught, "player o");
            
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
            //act
            ticTacToe.PlayGame();
            //Assert
            Assert.Equal(GameStatus.Won, ticTacToe.GameStatus);
        }
        
        [Fact]
        public void PlayerWinsVertically()
        {
            //arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((1,1),(2,1),(3,1));
            var playerX = new Player(testInputX, Symbol.Cross, "player x");
            var testInputO = new PlayerInput((2,2),(3,2),(1,2));
            var playerO = new Player(testInputO, Symbol.Naught, "player o");
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
            //act
            ticTacToe.PlayGame();
            Assert.Equal(GameStatus.Won, ticTacToe.GameStatus);
        }
        
        [Fact]
        public void PlayerWinsDiagonallyLeftToRight()
        {
            //arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((1,1),(2,2),(3,3));
            var playerX = new Player(testInputX, Symbol.Cross, "player x");
            var testInputO = new PlayerInput((2,1),(3,2),(1,2));
            var playerO = new Player(testInputO, Symbol.Naught, "player o");
            //act
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
            ticTacToe.PlayGame();
            Assert.Equal(GameStatus.Won, ticTacToe.GameStatus);
        }
        
        [Fact]
        public void PlayerWinsDiagonallyRightToLeft()
        {
            //arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((1,3),(2,2),(3,1));
            var playerX = new Player(testInputX, Symbol.Cross, "player x");
            var testInputO = new PlayerInput((2,1),(3,2),(1,2));
            var playerO = new Player(testInputO, Symbol.Naught, "player o");
           
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
            //act
            ticTacToe.PlayGame();
            Assert.Equal(GameStatus.Won, ticTacToe.GameStatus);
        }
        
        [Fact]
        public void GameEndsWithDraw()
        {
            //Arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((1,1),(1,3),(2,1),(3,2), (3,3));
            var playerX = new Player(testInputX, Symbol.Cross, "player x");
            var testInputO = new PlayerInput((1,2), (2,3),(3,1),(2,2));
            var playerO = new Player(testInputO, Symbol.Naught, "player o");
            var ticTacToe = new TicTacToe(board, playerX, playerO, iio: new NullInputOutput());
            ticTacToe.PlayGame();
            Assert.Equal(GameStatus.Drew, ticTacToe.GameStatus);
        }
        
        [Fact]
        public void PlayerWinsAtEndOfGame()
        {
            //Arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((1,1),(1,3),(2,1),(2,2), (3,3));
            var playerX = new Player(testInputX, Symbol.Cross, "player x");
            var testInputO = new PlayerInput((1,2), (2,3),(3,1),(3,2));
            var playerO = new Player(testInputO, Symbol.Naught, "player o");
            var ticTacToe = new TicTacToe(board, playerX, playerO, new NullInputOutput());
            //Act
            ticTacToe.PlayGame();
            //Assert
            Assert.Equal(GameStatus.Won, ticTacToe.GameStatus);
        }
        
    }
}