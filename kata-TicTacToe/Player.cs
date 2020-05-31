using System.Collections.Generic;

namespace kata_TicTacToe
{
    public class Player
    {
        public string PlayerSymbol;
        private readonly Board _board;
        public Symbol Symbol { get; set; }


        public Player(Board board)
        {
            //PlayerSymbol = playerSymbol;
            _board = board;
        }

        
        
        
        //need to have place their counter
        //return where they put it


        // public void PlaceCounter(int xCoordinate, int yCoordinate)
        // {
        //     if (_board.IsValidMove(xCoordinate, yCoordinate))
        //     {
        //         _board.ChangeStatusOfSquareForValidMove(xCoordinate, yCoordinate);
        //     }
        //
        //     _board.DisplayBoard();
        // }
        public void MakeMove(int xCoordinate, int yCoordinate)
        {
            var move = new Move(xCoordinate, yCoordinate);
            _board.IsValidMove(move, Symbol);
        }
    }
}