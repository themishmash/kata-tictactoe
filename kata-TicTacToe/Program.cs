using System;
using System.Collections.Generic;

namespace kata_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(3, 3);

            // Console.WriteLine( board.DisplayBoard());
          // var consoleInput = new ConsoleInputOutput();
          
            // var playerX = new Player(board, consoleInput){Symbol = Symbol.Cross};
            // playerX.PlayTurn(Symbol.Cross);
            
            //playerX.PlayTurn(1, 1, Symbol.Cross);
           Console.WriteLine(board.DisplayBoard());
           var consoleInputOutput = new ConsoleInputOutput();
           var players = new List<Player>()
           {
               new Player(consoleInputOutput, Symbol.Cross),
               new Player(consoleInputOutput, Symbol.Naught),
           };
          
           // playerX.PlayTurn();
           // board.PlaceSymbolToCoordinates(Symbol.Cross, playerX.PlayTurn());
           var ticTacToe = new TicTacToe(players, consoleInputOutput, board);
           ticTacToe.StartGame();
           Console.WriteLine(board.DisplayBoard());


        }
    }
}