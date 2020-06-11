using System.Collections.Generic;

namespace kata_TicTacToe
{
    public class Player
    {
        private readonly IInputOutput _iio;
        public Symbol Symbol { get; set; }
        public PlayerStatus PlayerStatus { get; set; }


        public Player(IInputOutput iio, Symbol symbol)
        {
            _iio = iio;
            Symbol = symbol;
            PlayerStatus = PlayerStatus.Playing;
        }

        public virtual Move PlayTurn()
        {
            var(x,y) = _iio.AskQuestion("What Coordinate do you want?");
            var move = new Move(x, y);
            return move;
        }
        
      
    }
}