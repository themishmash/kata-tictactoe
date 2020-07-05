namespace kata_TicTacToe
{
    public class Human : Player
    {
        private readonly IInputOutput _iio;

        public Human(IInputOutput iio, Symbol symbol, string name) : base(symbol, name)
        {
            _iio = iio;
        }

        public override Move PlayTurn()
        {
            var(x,y) = _iio.AskQuestion($"{Name} please enter a coordinate x,y to place your {Symbol} or enter control c to give up");
            var move = new Move(x, y);
            return move;
        }
    }
}