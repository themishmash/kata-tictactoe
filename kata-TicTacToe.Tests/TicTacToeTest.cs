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
            var board = new Board(3,3);
            var testInputX = new AutomatedPlayer((1,1),(1,2),(1,3));
            var playerX = new Player(testInputX, Symbol.Cross);
            var ticTacToe = new TicTacToe(new List<Player> {playerX}, testInputX, board);
            ticTacToe.StartGame();

            Assert.Equal(" X  X  X \n .  .  . \n .  .  . ",board.DisplayBoard());
        }
        
       
    }
}