using System.Collections.Generic;

namespace kata_TicTacToe
{
    public class Player
    {
        private readonly Board _board;
        private readonly IInputOutput _iio;
        public Symbol Symbol { get; set; }


        public Player(Board board, IInputOutput iio)
        {
            _board = board;
            _iio = iio;
        }

        public bool PlayTurn(int xCoordinate, int yCoordinate, Symbol symbol)
        {
            // var move = new Move(xCoordinate, yCoordinate);
            // _board.IsValidMove(move, Symbol);
            
            var move = new Move(xCoordinate, yCoordinate);
            if (_board.PlaceSymbolToCoordinates(symbol, move))
            {
                return true;
            }

            return false;
        }
    }
}