using System;

namespace kata_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Player player1 = null;
            Player player2 = null;
            var board = new Board(3);
            var consoleInputOutput = new ConsoleInputOutput();
            var bestMoveDecider = new BestMoveDecider(board);
            var randomNumberGenerator = new RandomNumberGenerator();
            var computerSmart = new ComputerNeverLose(Symbol.Cross, "computer", bestMoveDecider);
            //player1 = new RandomPlayer(randomNumberGenerator, Symbol.Naught, "random player");
            player2 = new Human(consoleInputOutput, Symbol.Naught, "human");
            // Console.WriteLine("Player 1: what is your name?");
            // var name = Console.ReadLine();
            // Console.WriteLine("Player 2: what is your name?");
            // var name2 = Console.ReadLine();
            // Console.WriteLine("Who would like to go first?");
            // var firstPlayer = Console.ReadLine();
            // if (firstPlayer == name && firstPlayer != "computer")
            // {
            //     player1 = new Human(consoleInputOutput, Symbol.Cross, name);
            //     player2 = new Human(consoleInputOutput, Symbol.Naught, name2);
            // }
            //
            // else if (firstPlayer == name2)
            // {
            //     player1 = new Human(consoleInputOutput, Symbol.Naught, name2);
            //     player2 = new Human(consoleInputOutput, Symbol.Cross, name);
            // }
            //
            // else if (firstPlayer == "computer")
            // {
            //     player1 = new Computer(Symbol.Naught,new ComputerInputOutput(board), "computer");
            //     player2 = new Human(consoleInputOutput, Symbol.Cross, name2);
            // }
            //
            var ticTacToe = new TicTacToe(board, player2, computerSmart, consoleInputOutput);
            ticTacToe.PlayGame();
            
//delegation
        }
    }
}