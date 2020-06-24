namespace kata_TicTacToe
{
    public class RandomPlayer : Player
    {
        private readonly NumberGenerator _iNumberGenerator;
        

        public RandomPlayer(NumberGenerator iNumberGenerator, Symbol symbol, string name) : base(symbol, name)
        {
            _iNumberGenerator = iNumberGenerator;
           
        }

        public override Move PlayTurn()
        {
            var xCoordinate = _iNumberGenerator.GetNumber(0, 4);
            var yCoordinate = _iNumberGenerator.GetNumber(0, 4);
            var move = new Move(xCoordinate, yCoordinate);
            return move;
        }
    }

    
}