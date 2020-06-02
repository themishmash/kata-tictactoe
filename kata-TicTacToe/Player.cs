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

        public void PlayTurn(int xCoordinate, int yCoordinate, Symbol symbol)
        //(int xCoordinate, int yCoordinate, Symbol symbol)
        {
            // var move = new Move(xCoordinate, yCoordinate);
            // _board.IsValidMove(move, Symbol);
            //_iio.AskQuestion("Please enter a coordinate") == _iio.ParseStringCoordinatesToInt();
            var move = new Move(xCoordinate, yCoordinate);
            _board.PlaceSymbolToCoordinates(symbol, move);
        }
    }
}