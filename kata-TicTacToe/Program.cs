using System;

namespace kata_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(3, 3);

            // Console.WriteLine( board.DisplayBoard());
            // var playerX = new Player(board){Symbol = Symbol.Cross};
            // playerX.MakeMove(1, 1);
            //
            // Console.WriteLine(board.DisplayBoard());
            //
            // var playerO = new Player(board){Symbol = Symbol.Naught};
            // playerO.MakeMove(1,1);
            
            var move = new Move(1,1);
            //board.PlaceSymbolToCoordinates(move);
            
            Console.WriteLine(board.DisplayBoard());
            

        }
    }
}