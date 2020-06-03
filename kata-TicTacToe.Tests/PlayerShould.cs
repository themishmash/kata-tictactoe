using Xunit;

namespace kata_TicTacToe.Tests
{
    public class PlayerShould
    {
        private const int XCoordinate = 1;
        private const int YCoordinate = 1;
        [Fact]
         public void PlaceSymbolWithXYCoordinates()
         {
             var input = new ResponderTest();
             var playerX = new Player(input, Symbol.Cross);
             var move = playerX.PlayTurn();
             Assert.Equal(XCoordinate, move.XCoordinate);
             Assert.Equal(YCoordinate, move.YCoordinate);
         }

         [Fact]
         public void PlayerHasCorrectSymbol()
         {
             var input = new ResponderTest();
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