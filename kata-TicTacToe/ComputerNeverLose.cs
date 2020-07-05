namespace kata_TicTacToe
{
    public class ComputerNeverLose : Player
    {
        private readonly IMoveDecider _moveDecider;

        public ComputerNeverLose(Symbol symbol, string name, IMoveDecider moveDecider) : base(symbol, name)
        {
            _moveDecider = moveDecider;
        }
        
        public override Move PlayTurn()
        {
            return _moveDecider.NextMove();
        }
        
    }
}