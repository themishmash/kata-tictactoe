namespace kata_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        { 
            var board = new Board(3);
            var winningMoves = new WinningMove(board);
            var consoleInputOutput = new ConsoleInputOutput(); 
            var player1 = new Player(consoleInputOutput, Symbol.Cross, winningMoves);
            var player2 = new Player(consoleInputOutput, Symbol.Naught, winningMoves);
          
           var ticTacToe = new TicTacToe(board, player1, player2, consoleInputOutput);
           ticTacToe.PlayGame();
          // Console.WriteLine(board.DisplayBoard());

//delegation
        }
    }
}