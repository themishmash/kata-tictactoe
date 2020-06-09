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
            var testInputX = new AutomatedPlayer(new Move(1,1), null, null, null, null);
            var playerX = new Player(testInputX, Symbol.Cross);
            var console = new ConsoleInputOutput();
            var ticTacToe = new TicTacToe(new List<Player> {playerX}, console, board);
            ticTacToe.StartGame();

           // Assert.True(ticTacToe.IsHorizontalWinBoardSquares(playerX));
        }
        
        // [Fact]
        // public void EachPlayerPlaysTheirTurn()
        // {
        //     var board = new Board(3,3);
        //     var testInputX = new TestResponder();
        //     var playerX = new Player(testInputX, Symbol.Cross);
        //     var testInputO = new TestResponder();
        //     var playerO = new Player(testInputO, Symbol.Naught);
        //     var console = new ConsoleInputOutput();
        //     
        //     var ticTacToe = new TicTacToeTest(board, new Player[]{playerX, playerO}, console);
        //     ticTacToe.StartGame();
        //     
        // }
    }
}