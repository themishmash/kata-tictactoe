// using Xunit;
//
// namespace kata_TicTacToe.Tests
// {
//     public class TicTacToeTest
//     {
//     
//         [Fact]
//         public void PlayerWinsHorizontallyFirstRow()
//         {
//             //arrange
//             var board = new Board(3);
//             var testInputX = new PlayerInput((1,1),(1,2),(1,3));
//             var playerX = new Human(testInputX, Symbol.Cross, "player x");
//            
//             var testInputO = new PlayerInput((2,1),(3,1),(2,2));
//             var playerO = new Human(testInputO, Symbol.Naught, "player o");
//             
//             var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
//             //act
//             ticTacToe.PlayGame();
//             //Assert
//             Assert.Equal(" X  X  X \n O  .  . \n O  .  . ",board.DisplayBoard());
//             // Assert.Equal(GameStatus.Won, playerX.GameStatus);
//             Assert.Equal(GameStatus.Won, ticTacToe.GameStatus);
//         }
//         
//         [Fact]
//         public void PlayerWinsHorizontallySecondRow()
//         {
//             //arrange
//             var board = new Board(3);
//             var testInputX = new PlayerInput((2,1),(2,2),(2,3));
//             var playerX = new Human(testInputX, Symbol.Cross, "player x");
//            
//             var testInputO = new PlayerInput((1,1),(3,1),(3,2));
//             var playerO = new Human(testInputO, Symbol.Naught, "player o");
//             
//             var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
//             //act
//             ticTacToe.PlayGame();
//             //Assert
//             Assert.Equal(GameStatus.Won, ticTacToe.GameStatus);
//         }
//         
//         [Fact]
//         public void PlayerWinsVertically()
//         {
//             //arrange
//             var board = new Board(3);
//             var testInputX = new PlayerInput((1,1),(2,1),(3,1));
//             var playerX = new Human(testInputX, Symbol.Cross, "player x");
//             var testInputO = new PlayerInput((2,2),(3,2),(1,2));
//             var playerO = new Human(testInputO, Symbol.Naught, "player o");
//             var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
//             //act
//             ticTacToe.PlayGame();
//             Assert.Equal(GameStatus.Won, ticTacToe.GameStatus);
//         }
//         
//         [Fact]
//         public void PlayerWinsDiagonallyLeftToRight()
//         {
//             //arrange
//             var board = new Board(3);
//             var testInputX = new PlayerInput((1,1),(2,2),(3,3));
//             var playerX = new Human(testInputX, Symbol.Cross, "player x");
//             var testInputO = new PlayerInput((2,1),(3,2),(1,2));
//             var playerO = new Human(testInputO, Symbol.Naught, "player o");
//             //act
//             var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
//             ticTacToe.PlayGame();
//             Assert.Equal(GameStatus.Won, ticTacToe.GameStatus);
//         }
//         
//         [Fact]
//         public void PlayerWinsDiagonallyRightToLeft()
//         {
//             //arrange
//             var board = new Board(3);
//             var testInputX = new PlayerInput((1,3),(2,2),(3,1));
//             var playerX = new Human(testInputX, Symbol.Cross, "player x");
//             var testInputO = new PlayerInput((2,1),(3,2),(1,2));
//             var playerO = new Human(testInputO, Symbol.Naught, "player o");
//            
//             var ticTacToe = new TicTacToe(board, playerX, playerO,new NullInputOutput());
//             //act
//             ticTacToe.PlayGame();
//             Assert.Equal(GameStatus.Won, ticTacToe.GameStatus);
//         }
//         
//         [Fact]
//         public void GameEndsWithDraw()
//         {
//             //Arrange
//             var board = new Board(3);
//             var testInputX = new PlayerInput((1,1),(1,3),(2,1),(3,2), (3,3));
//             var playerX = new Human(testInputX, Symbol.Cross, "player x");
//             var testInputO = new PlayerInput((1,2), (2,3),(3,1),(2,2));
//             var playerO = new Human(testInputO, Symbol.Naught, "player o");
//             var ticTacToe = new TicTacToe(board, playerX, playerO, iio: new NullInputOutput());
//             ticTacToe.PlayGame();
//             Assert.Equal(GameStatus.Drew, ticTacToe.GameStatus);
//         }
//         
//         [Fact]
//         public void PlayerWinsAtEndOfGame()
//         {
//             //Arrange
//             var board = new Board(3);
//             var testInputX = new PlayerInput((1,1),(1,3),(2,1),(2,2), (3,3));
//             var playerX = new Human(testInputX, Symbol.Cross, "player x");
//             var testInputO = new PlayerInput((1,2), (2,3),(3,1),(3,2));
//             var playerO = new Human(testInputO, Symbol.Naught, "player o");
//             var ticTacToe = new TicTacToe(board, playerX, playerO, new NullInputOutput());
//             //Act
//             ticTacToe.PlayGame();
//             //Assert
//             Assert.Equal(GameStatus.Won, ticTacToe.GameStatus);
//         }
//         
//         //create another test with best move computer player can play a game - don't necessarily need to win. 
//         [Fact]
//         public void CanDrawPlayer2()
//         {
//             //Arrange
//             var board = new Board(3);
//             var testInputO = new PlayerInput((1,1),(1,3),(3,2),(2,3),(3,1));
//             var playerO = new Human(testInputO, Symbol.Naught, "player o");
//             var computer = new ComputerNeverLose(Symbol.Cross, "computer", new BestMoveDecider(board));
//             var ticTacToe = new TicTacToe(board, playerO, computer, new NullInputOutput());
//             //Act
//             ticTacToe.PlayGame();
//             //Assert
//             Assert.Equal(GameStatus.Drew, ticTacToe.GameStatus);
//             //Arrange
//            // var board = new Board(3);
//             //board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,1));
//             //board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(2,2));
//             // board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(1,3));
//             // board.PlaceSymbolToCoordinates(Symbol.Cross, new Move(1,2));
//             // board.PlaceSymbolToCoordinates(Symbol.Naught, new Move(3,2));
//             
//             //Act
//            // var bestMove = new BestMoveDecider(board).NextMove();
//         
//             //Assert
//             // Assert.Equal(1, bestMove.XCoordinate);
//             // Assert.Equal(1, bestMove.YCoordinate);
//         }
//         
//         // [Fact]
//         // public void ComputerMakeMove2()
//         // {
//         //     //Arrange
//         //     var board = new Board(3);
//         //     var testInputO = new PlayerInput((3,1));
//         //     var playerO = new Human(testInputO, Symbol.Naught, "player o");
//         //     var bestMoveDecider = new BestMoveDecider(board);
//         //     var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
//         //     
//         //     var ticTacToe = new TicTacToe(board, computer, playerO, new NullInputOutput() );
//         //     
//         //     //Act
//         //     //computer.PlayTurn();
//         //    // var move1 = new Move(3,1);
//         //    // board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
//         //    // var computerMove1 = computer.PlayTurn();
//         //    ticTacToe.PlayGame();
//         //     
//         //     
//         //     //Assert
//         //     Assert.Equal(" X  .  . \n .  X  . \n O  .  . ",board.DisplayBoard());
//         //     // Assert.Equal(1, computerMove1.XCoordinate);
//         //     // Assert.Equal(1, computerMove1.YCoordinate);
//         // }
//     }
// }