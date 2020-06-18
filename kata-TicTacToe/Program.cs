namespace kata_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        { 
            var board = new Board(3);
            var consoleInputOutput = new ConsoleInputOutput(); 
            //ask question of name here
            var player1 = new Player(consoleInputOutput, Symbol.Cross); //answer to question as part of constructor
            var player2 = new Player(consoleInputOutput, Symbol.Naught);
            var ticTacToe = new TicTacToe(board, player1, player2, consoleInputOutput);
           
            ticTacToe.PlayGame();
            
//delegation
        }
    }
}