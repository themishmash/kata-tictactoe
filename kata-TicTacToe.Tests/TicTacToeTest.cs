using System;
using System.Collections.Generic;
using Xunit;

namespace kata_TicTacToe.Tests
{
    public class TicTacToeTest
    {

      
        //TODO this test still fails. Need to fix testresponder
        
        [Fact]
        public void PlayerWinsHorizontally()
        {
            //arrange
            var board = new Board(3,3);
            var testInputX = new PlayerInput((1,1),(1,2),(1,3));
            var playerX = new Player(testInputX, Symbol.Cross);
            var testInputO = new PlayerInput((2,1),(3,1),(2,2));
            var playerO = new Player(testInputO, Symbol.Naught);
           
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
            //act
            ticTacToe.PlayGame();

            Assert.Equal(" X  X  X \n O  O  . \n O  .  . ",board.DisplayBoard());
            Assert.True(ticTacToe.HasPlayerWon(playerX));
            Assert.False(ticTacToe.HasPlayerWon(playerO));
            Assert.Equal(PlayerStatus.Won, playerX.PlayerStatus);
            //Assert.Equal(PlayerStatus.Won, playerO.PlayerStatus);
        }
        
        [Fact]
        public void PlayerWinsVertically()
        {
            //arrange
            var board = new Board(3,3);
            var testInputX = new PlayerInput((1,1),(2,1),(3,1));
            var playerX = new Player(testInputX, Symbol.Cross);
            var testInputO = new PlayerInput((2,2),(3,2),(1,2));
            var playerO = new Player(testInputO, Symbol.Naught);
           
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
            //act
            ticTacToe.PlayGame();
            
            Assert.True(ticTacToe.HasPlayerWon(playerX));
            Assert.False(ticTacToe.HasPlayerWon(playerO));
            Assert.Equal(PlayerStatus.Won, playerX.PlayerStatus);
            //Assert.Equal(PlayerStatus.Won, playerO.PlayerStatus);
        }
        
        [Fact]
        public void PlayerWinsDiagonally()
        {
            //arrange
            var board = new Board(3,3);
            var testInputX = new PlayerInput((1,1),(2,2),(3,3));
            var playerX = new Player(testInputX, Symbol.Cross);
            var testInputO = new PlayerInput((2,1),(3,2),(1,2));
            var playerO = new Player(testInputO, Symbol.Naught);
           
            var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
            //act
            ticTacToe.PlayGame();
            
            Assert.True(ticTacToe.HasPlayerWon(playerX));
            Assert.False(ticTacToe.HasPlayerWon(playerO));
            Assert.Equal(PlayerStatus.Won, playerX.PlayerStatus);
            //Assert.Equal(PlayerStatus.Won, playerO.PlayerStatus);
        }

       
        
        
        
       
    }
}