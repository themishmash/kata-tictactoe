namespace kata_TicTacToe
{
    public class BestMoveDecider:IMoveDecider
    {
        private readonly Board _board;

        public BestMoveDecider(Board board)
        {
            _board = board;
        }
        
        public Move NextMove()
        {
            throw new System.NotImplementedException();
        }
    }
}