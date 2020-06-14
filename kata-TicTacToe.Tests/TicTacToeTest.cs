using System;
using System.Collections.Generic;
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
            var playerX = new Player(testInputX, Symbol.Cross);
           
            var testInputO = new PlayerInput((2,1),(3,1),(2,2));
            var playerO = new Player(testInputO, Symbol.Naught);
            
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
            //act
           
            //Assert
            Assert.Equal(" X  X  X \n O  .  . \n O  .  . ",board.DisplayBoard());
            // Assert.True(ticTacToe.HasPlayerWon(playerX));
            // Assert.False(ticTacToe.HasPlayerWon(playerO));
            Assert.Equal(PlayerStatus.Won, playerX.PlayerStatus);
        }
        
        [Fact]
        public void PlayerWinsHorizontallySecondRow()
        {
            //arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((2,1),(2,2),(2,3));
            var playerX = new Player(testInputX, Symbol.Cross);
           
            var testInputO = new PlayerInput((1,1),(3,1),(3,2));
            var playerO = new Player(testInputO, Symbol.Naught);
            
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
            //act
           
        
            //Assert
            // Assert.Equal(" X  X  X \n O  .  . \n O  .  . ",board.DisplayBoard());
            // Assert.True(ticTacToe.HasPlayerWon(playerX));
            // Assert.False(ticTacToe.HasPlayerWon(playerO));
            Assert.Equal(PlayerStatus.Won, playerX.PlayerStatus);
        }
        
        [Fact]
        public void PlayerWinsVertically()
        {
            //arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((1,1),(2,1),(3,1));
            var playerX = new Player(testInputX, Symbol.Cross);
            var testInputO = new PlayerInput((2,2),(3,2),(1,2));
            var playerO = new Player(testInputO, Symbol.Naught);
           
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
            //act
            
            
            // Assert.True(ticTacToe.HasPlayerWon(playerX));
            // Assert.False(ticTacToe.HasPlayerWon(playerO));
            Assert.Equal(PlayerStatus.Won, playerX.PlayerStatus);
        }
        
        [Fact]
        public void PlayerWinsDiagonallyLeftToRight()
        {
            //arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((1,1),(2,2),(3,3));
            var playerX = new Player(testInputX, Symbol.Cross);
            var testInputO = new PlayerInput((2,1),(3,2),(1,2));
            var playerO = new Player(testInputO, Symbol.Naught);
            //act
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
          

            // Assert.True(ticTacToe.HasPlayerWon(playerX, move));
            // Assert.False(ticTacToe.HasPlayerWon(playerO));
            Assert.Equal(PlayerStatus.Won, playerX.PlayerStatus);
        }
        
        [Fact]
        public void PlayerWinsDiagonallyRightToLeft()
        {
            //arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((1,3),(2,2),(3,1));
            var playerX = new Player(testInputX, Symbol.Cross);
            var testInputO = new PlayerInput((2,1),(3,2),(1,2));
            var playerO = new Player(testInputO, Symbol.Naught);
           
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
            //act

            // Assert.True(ticTacToe.HasPlayerWon(playerX));
            // Assert.False(ticTacToe.HasPlayerWon(playerO));
            Assert.Equal(PlayerStatus.Won, playerX.PlayerStatus);
        }
        
        [Fact]
        public void GameEndsWithDraw()
        {
            //Arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((1,1),(1,3),(2,1),(3,2), (3,3));
            var playerX = new Player(testInputX, Symbol.Cross);
            var testInputO = new PlayerInput((1,2), (2,3),(3,1),(2,2));
            var playerO = new Player(testInputO, Symbol.Naught);
            var ticTactToe = new TicTacToe(board, playerX, playerO, iio: new NullInputOutput());
            
            //Assert.Equal(PlayerStatus.Drew, playerX.PlayerStatus);
            Assert.Equal(PlayerStatus.Drew, playerO.PlayerStatus);
            
        }
        
        [Fact]
        public void PlayerWinsAtEndOfGame()
        {
            //Arrange
            var board = new Board(3);
            var testInputX = new PlayerInput((1,1),(1,3),(2,1),(2,2), (3,3));
            var playerX = new Player(testInputX, Symbol.Cross);
            var testInputO = new PlayerInput((1,2), (2,3),(3,1),(3,2));
            var playerO = new Player(testInputO, Symbol.Naught);
            var ticTactToe = new TicTacToe(board, playerX, playerO, new NullInputOutput());
            
            Assert.Equal(PlayerStatus.Won, playerX.PlayerStatus);
            
        }
        
        
        
        
        
       
    }
}