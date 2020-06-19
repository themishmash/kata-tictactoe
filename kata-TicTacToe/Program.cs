using System;

namespace kata_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Player player1;
            Player player2;
            var board = new Board(3);
            var consoleInputOutput = new ConsoleInputOutput();
            Console.WriteLine("Player 1: what is your name?");
            var name = Console.ReadLine();
            Console.WriteLine("Player 2: what is your name?");
            var name2 = Console.ReadLine();
            Console.WriteLine("Who would like to go first?");
            var firstPlayer = Console.ReadLine();
            if (firstPlayer == name)
            {
                player1 = new Player(consoleInputOutput, Symbol.Cross, name);
                player2 = new Player(consoleInputOutput, Symbol.Naught, name2);
            }
            else
            {
                player1 = new Player(consoleInputOutput, Symbol.Naught, name2);
                player2 = new Player(consoleInputOutput, Symbol.Cross, name);
            }
            
            var ticTacToe = new TicTacToe(board, player1, player2, consoleInputOutput);
            ticTacToe.PlayGame();
            
//delegation
        }
    }
}