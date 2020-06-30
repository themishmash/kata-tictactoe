namespace kata_TicTacToe
{
    public abstract class Player
    {
        //protected readonly IInputOutput _iio;

        public Symbol Symbol { get; private set; }
        protected string Name { get; }

        protected Player(Symbol symbol, string name)
        {
            Name = name;
            Symbol = symbol;
          
        }

        // public virtual Move PlayTurn()
        // {
        //     var(x,y) = _iio.AskQuestion($"{Name} please enter a coordinate x,y to place your {Symbol} or enter control c to give up");
        //     var move = new Move(x, y);
        //     return move;
        // }

        public abstract Move PlayTurn();

    }
}