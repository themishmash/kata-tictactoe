using Xunit;

namespace kata_TicTacToe.Tests
{
    public class PlayerShould
    {
        [Fact]
         public void PlaceSymbolWithXYCoordinates()
         {
             var board = new Board(3, 3);
             var input = new ResponderTest(1, 1);
             var playerX = new Player(board, input){Symbol = Symbol.Cross};
             playerX.PlayTurn(input.XCoordinate, input.YCoordinate, Symbol.Cross);
             Assert.Equal(" X  .  . \n .  .  . \n .  .  . ",board.DisplayBoard());
         }
         
         [Fact]
         public void PlaceDifferentSymbolsWithTwoPlayers()
         {
             var board = new Board(3, 3);
             var playerXInput = new ResponderTest(1, 1);
             var playerOInput = new ResponderTest(2, 2);
             var playerX = new Player(board, playerXInput){Symbol = Symbol.Cross};
             var playerO = new Player(board, playerOInput){Symbol = Symbol.Naught};
             playerX.PlayTurn(playerXInput.XCoordinate, playerXInput.YCoordinate, Symbol.Cross);
             playerO.PlayTurn(playerOInput.XCoordinate, playerOInput.YCoordinate, Symbol.Naught);
             Assert.Equal(" X  .  . \n .  O  . \n .  .  . ",board.DisplayBoard());
         }
         
         [Fact]
         public void NotPlaceSymbolOnOccupiedSquare()
         {
             var board = new Board(3, 3);
             var playerXInput = new ResponderTest(1, 1);
             var playerOInput = new ResponderTest(1, 1);
             var playerX = new Player(board, playerXInput){Symbol = Symbol.Cross};
             var playerO = new Player(board, playerOInput){Symbol = Symbol.Naught};
             playerX.PlayTurn(playerXInput.XCoordinate, playerXInput.YCoordinate, Symbol.Cross);
             playerO.PlayTurn(playerOInput.XCoordinate, playerOInput.YCoordinate, Symbol.Naught);
             Assert.Equal(" X  .  . \n .  .  . \n .  .  . ",board.DisplayBoard());
         }
    }
}