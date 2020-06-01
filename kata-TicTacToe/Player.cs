using System.Collections.Generic;

namespace kata_TicTacToe
{
    public class Player
    {
        private readonly Board _board;
        public Symbol Symbol { get; set; }


        public Player(Board board)
        {
            _board = board;
        }

        public void MakeMove(int xCoordinate, int yCoordinate)
        {
            // var move = new Move(xCoordinate, yCoordinate);
            // _board.IsValidMove(move, Symbol);
        }
    }
}