using System;

namespace kata_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(3, 3);
            board.GenerateBoard();
            Console.WriteLine(board.DisplayBoard());

        }
    }
}