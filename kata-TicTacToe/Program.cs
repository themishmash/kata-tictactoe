using System;

namespace kata_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(3, 3);

            // Console.WriteLine( board.DisplayBoard());
           var consoleInput = new ConsoleInputOutput();
           //  
           // consoleInput.AskQuestion("please choose a coordinate");
             //var coordinate = Console.ReadLine();
            
           var coordinate = "1,1";
            int[] coordinateNumbers = consoleInput.ParseStringCoordinatesToInt(coordinate);
            var playerX = new Player(board, consoleInput){Symbol = Symbol.Cross};
            playerX.PlayTurn(coordinateNumbers[0], coordinateNumbers[1], Symbol.Cross);
            
            //playerX.PlayTurn(1, 1, Symbol.Cross);
            Console.WriteLine(board.DisplayBoard());
            

        }
    }
}