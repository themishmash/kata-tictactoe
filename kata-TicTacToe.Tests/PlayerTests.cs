using Xunit;

namespace kata_TicTacToe.Tests
{
    public class PlayerTests
    {
        
        [Fact]
         public void PlaceSymbolWithXYCoordinates()
         {
             var input = new TestResponder();
             var playerX = new Player(input, Symbol.Cross);
             var move = playerX.PlayTurn();
             Assert.Equal(1, move.XCoordinate);
             Assert.Equal(1, move.YCoordinate);
         }

         [Fact]
         public void PlayerHasCorrectXSymbol()
         {
             var input = new TestResponder();
             var playerX = new Player(input, Symbol.Cross);
             Assert.Equal(Symbol.Cross, playerX.Symbol);
         }
        
        // [Fact]
        // public void PlaceDifferentSymbolsWithTwoPlayers()
        // {
        //     var board = new Board(3, 3);
        //     var playerXInput = new ResponderTest("1,1");
        //     var playerOInput = new ResponderTest("2,2");
        //     var playerX = new Player(board, playerXInput){Symbol = Symbol.Cross};
        //     var playerO = new Player(board, playerOInput){Symbol = Symbol.Naught};
        //     playerX.PlayTurn(Symbol.Cross);
        //     playerO.PlayTurn(Symbol.Naught);
        //     Assert.Equal(" X  .  . \n .  O  . \n .  .  . ",board.DisplayBoard());
        // }
        //
        // [Fact]
        // public void NotPlaceSymbolOnOccupiedSquare()
        // {
        //     var board = new Board(3, 3);
        //     var playerXInput = new ResponderTest("1, 1");
        //     var playerOInput = new ResponderTest("1, 1");
        //     var playerX = new Player(board, playerXInput){Symbol = Symbol.Cross};
        //     var playerO = new Player(board, playerOInput){Symbol = Symbol.Naught};
        //     playerX.PlayTurn(Symbol.Cross);
        //     playerO.PlayTurn(Symbol.Naught);
        //     Assert.Equal(" X  .  . \n .  .  . \n .  .  . ",board.DisplayBoard());
        // }
    }
}