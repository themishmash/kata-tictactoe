using System;

namespace kata_TicTacToe
{
    public class Player
    {
        private readonly IInputOutput _iio;

        public Symbol Symbol { get; private set; }
        public PlayerStatus PlayerStatus { get; set; }


        public Player(IInputOutput iio, Symbol symbol)
        {
            _iio = iio;
            Symbol = symbol;
            PlayerStatus = PlayerStatus.Playing;
        }

        public Move PlayTurn()
        {
            var(x,y) = _iio.AskQuestion($"Please enter a coordinate x,y to place your {Symbol} or enter control c to give up");
            var move = new Move(x, y);
            return move;
        }
        
    }
}