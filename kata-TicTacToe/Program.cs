using System;

namespace kata_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(3, 3);

            Console.WriteLine( board.DisplayBoard());
            var playerX = new Player(board){Symbol = Symbol.Cross};
            playerX.MakeMove(1, 1);
            
            
            //var move = new Move(1, 1);

           //board.IsValidMove(1, 1, playerX.Symbol);
            //board.ChangeStatusOfSquareForValidMove(move, Symbol.Cross);

            //var move2 = new Move(1, 2);
            //board.IsValidMove(1, 2, playerX.Symbol);
            
            Console.WriteLine(board.DisplayBoard());
            //Console.WriteLine(board.DisplayBoard());
            // Console.WriteLine( playerX.PlaceCounter(1,1));


        }
    }
}