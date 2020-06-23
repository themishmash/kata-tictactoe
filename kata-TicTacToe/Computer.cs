using System;

namespace kata_TicTacToe
{
    public class Computer : Player
    {
        private readonly Board _board;
        private readonly ComputerInputOutput _cio;

        public Computer(Symbol symbol, ComputerInputOutput cio, string name) : base(symbol, name)
        {
            _cio = cio;
        }

        public override Move PlayTurn()
        {
            var(x,y) = _cio.AskQuestion($"Computer has made their move");
            var move = new Move(x, y);
            return move;
        }
    }
}