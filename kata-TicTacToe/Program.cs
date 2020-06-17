namespace kata_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        { 
            var board = new Board(3);
            var consoleInputOutput = new ConsoleInputOutput(); 
            var player1 = new Player(consoleInputOutput, Symbol.Cross);
            var player2 = new Player(consoleInputOutput, Symbol.Naught);
          
            var ticTacToe = new TicTacToe(board, player1, player2, consoleInputOutput);
           ticTacToe.PlayGame();
          // Console.WriteLine(board.DisplayBoard());

//delegation
        }
    }
}