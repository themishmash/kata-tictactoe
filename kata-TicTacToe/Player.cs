using System;

namespace kata_TicTacToe
{
    public class Player
    {
        private readonly IInputOutput _iio;

        public Symbol Symbol { get; private set; }
        private string Name { get; }

        public Player(IInputOutput iio, Symbol symbol, string name)
        {
            _iio = iio;
            Name = name;
            Symbol = symbol;
          
        }

        public Move PlayTurn()
        {
            var(x,y) = _iio.AskQuestion($"{Name} please enter a coordinate x,y to place your {Symbol} or enter control c to give up");
            var move = new Move(x, y);
            return move;
        }
        
        
    }
}