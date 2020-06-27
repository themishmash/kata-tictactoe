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
            var xCoordinate = _iNumberGenerator.GetXCoordinate(1, 3);
            var yCoordinate = _iNumberGenerator.GetYCoordinate(1, 3);
            var move = new Move(xCoordinate, yCoordinate);
            return move;
        }
    }

    
}