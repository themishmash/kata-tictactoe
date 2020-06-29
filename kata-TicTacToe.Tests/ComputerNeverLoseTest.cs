using Xunit;

namespace kata_TicTacToe.Tests
{
    public class ComputerNeverLoseTest
    {

        [Fact]
        public void MakeFirstMoveAsPlayer1()
        {
            //arrange
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            
            //Act
            var move = computer.PlayTurn();
            
            //Assert
           Assert.Equal(2, move.XCoordinate);
           Assert.Equal(2, move.YCoordinate);
           //Assert.Equal(" .  .  . \n .  X  . \n .  .  . ",board.DisplayBoard());
        }
        
        //make move 2
        //make move 3
        //make move 4
        //make move 5

        [Fact]
        public void MakeMove2AsPlayer1()
        {
            //Arrange
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            
            //Act
            var computerMove1 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove1);
            var move1 = new Move(3,1);
            board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
            var computerMove2 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(Symbol.Cross, computerMove2);
           // var computerMove2 = computer.PlayTurn();
            
            //Assert
            Assert.Equal(1, computerMove2.XCoordinate);
            Assert.Equal(1, computerMove2.YCoordinate);
        }

        [Fact]
        public void MakeMove3BlockHorizontalWinAsPlayer1()
        {
            //Arrange
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            
           
            var computerMove1 =  computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove1);
            var move1 = new Move(3,1);
            board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
            
            var computerMove2 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove2);
            
            var move2 = new Move(3,3);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move2);
            
            //Act
            var computerMove3 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove3);
            
            //Assert
            Assert.Equal(3, computerMove3.XCoordinate);
            Assert.Equal(2, computerMove3.YCoordinate);
        }
        
        [Fact]
        public void MakeMove3BlockVerticalWinAsPlayer1()
        {
            //Arrange
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            
           
            var computerMove1 =  computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove1);
           
            var move1 = new Move(1,1);
            board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
            
            var computerMove2 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove2);
            
            var move2 = new Move(3,1);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move2);
            
            //Act
            var computerMove3 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove3);
            
            //Assert
            Assert.Equal(2, computerMove3.XCoordinate);
            Assert.Equal(1, computerMove3.YCoordinate);
        }
        
        [Fact]
        public void MakeMove2BlockDiagonalWinRTLAsPlayer2()
        {
            //Arrange
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            
            var move1 = new Move(2,2);
            board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
            
            var computerMove1 =  computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove1);
            
            var move2 = new Move(1,3);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move2);
            
            //Act
            var computerMove2 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove2);

            //Assert
            Assert.Equal(3, computerMove2.XCoordinate);
            Assert.Equal(1, computerMove2.YCoordinate);
        }
        
        
        [Fact]
        public void MakeMove2BlockHorizontalWinAsPlayer2()
        {
            //Arrange
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            
            var move1 = new Move(1,1);
            board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
            
            var computerMove1 =  computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove1);
            
            var move2 = new Move(1,2);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move2);
            
            //Act
            var computerMove2 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove2);

            //Assert
            Assert.Equal(1, computerMove2.XCoordinate);
            Assert.Equal(3, computerMove2.YCoordinate);
        }
        
        [Fact]
        public void MakeMove2BlockVerticalWinAsPlayer2()
        {
            //Arrange
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            
            var move1 = new Move(3,1);
            board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
            
            var computerMove1 =  computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove1);
            
            var move2 = new Move(2,1);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move2);
            
            //Act
            var computerMove2 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove2);
        
            //Assert
            Assert.Equal(1, computerMove2.XCoordinate);
            Assert.Equal(1, computerMove2.YCoordinate);
        }

        [Fact]
        public void MakeMoveForTwoInRowDiagonalPlayer1()
        {
            //Arrange
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            var computerMove1 =  computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove1);
            
            var move1 = new Move(3,3);
            board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
            
            var computerMove2 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove2);

            //Assert 
            Assert.Equal(1, computerMove2.XCoordinate);
            Assert.Equal(3, computerMove2.YCoordinate);
        }

        [Fact]
        public void CanDrawPlayer1()
        {
            //Arrange
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            var computerMove1 =  computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove1);
            
            var move1 = new Move(3,3);
            board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
            
            var computerMove2 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove2);
            
            var move2 = new Move(3, 1);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move2);

            var computerMove3 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove3);
            
            var move3 = new Move(1, 2);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move3);

            var computerMove4 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove4);
            
            // var move4 = new Move(2,1);
            // board.PlaceSymbolToCoordinates(Symbol.Naught, move4);

            // var computerMove5 = computer.PlayTurn();
            // board.PlaceSymbolToCoordinates(computer.Symbol, computerMove5);
            
            Assert.Equal(1, computerMove4.XCoordinate);
            Assert.Equal(1, computerMove4.YCoordinate);
        }

        [Fact]
        public void CanWinDiagonalLTRPlayer1()
        {
            //Arrange
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            var computerMove1 =  computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove1);
            
            var move1 = new Move(1,2);
            board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
            
            var computerMove2 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove2);
            
            var move2 = new Move(2, 1);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move2);
            
            //Act
            var computerMove3 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove3);
            
            Assert.Equal(3, computerMove3.XCoordinate);
            Assert.Equal(3, computerMove3.YCoordinate);
        }
        
        [Fact]
        public void CanWinDiagonalRTLPlayer1()
        {
            //Arrange
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            var computerMove1 =  computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove1);
            
            var move1 = new Move(1,2);
            board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
            
            var computerMove2 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove2);
            
            var move2 = new Move(3, 3);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move2);
            
            var computerMove3 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove3);
            
            var move3 = new Move(2, 3);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move3);
            
            //Act
            var computerMove4 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove4);
            
            //Assert
            Assert.Equal(3, computerMove4.XCoordinate);
            Assert.Equal(1, computerMove4.YCoordinate);
        }
        //o_x
        //xxx
        //o__
        [Fact]
        public void CanWinHorizontalPlayer1()
        {
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            var computerMove1 =  computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove1);
            
            var move1 = new Move(1,1);
            board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
            
            var computerMove2 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove2);
            
            var move2 = new Move(3, 1);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move2);
            
            var computerMove3 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove3);
            
            var move3 = new Move(3, 2);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move3);
            
            //Act
            var computerMove4 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove4);
            
            //Assert
            Assert.Equal(2, computerMove4.XCoordinate);
            Assert.Equal(3, computerMove4.YCoordinate);
        }
        
        //x_o
        //_x_
        //oxo
        [Fact]
        public void CanWinVerticalPlayer1()
        {
            var board = new Board(3);
            var bestMoveDecider = new BestMoveDecider(board);
            var computer = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            var computerMove1 =  computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove1);
            
            var move1 = new Move(3,1);
            board.PlaceSymbolToCoordinates(Symbol.Naught,move1);
            
            var computerMove2 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove2);
            
            var move2 = new Move(3, 3);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move2);
            
            var computerMove3 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove3);
            
            var move3 = new Move(1, 3);
            board.PlaceSymbolToCoordinates(Symbol.Naught, move3);
            
            //Act
            var computerMove4 = computer.PlayTurn();
            board.PlaceSymbolToCoordinates(computer.Symbol, computerMove4);
            
            //Assert
            Assert.Equal(1, computerMove4.XCoordinate);
            Assert.Equal(2, computerMove4.YCoordinate);
        }
        
        
        
    }
}