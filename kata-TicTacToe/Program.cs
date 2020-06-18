using System;

namespace kata_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        { 
            var board = new Board(3);
            var consoleInputOutput = new ConsoleInputOutput(); 
            //ask question of name here
            Console.WriteLine("Player 1: what is your name?");
            var name = Console.ReadLine();
            var player1 = new Player(consoleInputOutput, Symbol.Cross, name);  
            Console.WriteLine("Player 2: what is your name?");
            var name2 = Console.ReadLine();
            var player2 = new Player(consoleInputOutput, Symbol.Naught, name2);
            var ticTacToe = new TicTacToe(board, player1, player2, consoleInputOutput);
           
            ticTacToe.PlayGame();
            
//delegation
        }
    }
}