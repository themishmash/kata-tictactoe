// using Xunit;
//
// namespace kata_TicTacToe.Tests
// {
//     public class ComputerPlayer
//     {
//         [Fact]
//         public void PlaceSymbolRandomlyInsteadOfBlock()
//         {
//             //arrange
//             var board = new Board(3);
//             //moves already on board
//             board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,1));
//             board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1, 2));
//
//             var testInputO = new PlayerInput((1,1),(1,2));
//             var human = new Human(testInputO, Symbol.Naught, "human");
//             var computer = new Computer(Symbol.Cross, "Computer", board);
//            computer.PlayTurn();
//            computer.PlayTurn();
//             //
//            // var ticTacToe = new TicTacToe(board, human, computer,new NullInputOutput());
//             //act
//            // ticTacToe.PlayGame();
//             //Assert
//            // Assert.Equal(" X  X  X \n O  .  . \n O  .  . ",board.DisplayBoard());
//             // Assert.Equal(GameStatus.Won, playerX.GameStatus);
//             Assert.Equal(" O  O  . \n .  .  . \n .  .  . ",board.DisplayBoard());
//         }
//     }
// }