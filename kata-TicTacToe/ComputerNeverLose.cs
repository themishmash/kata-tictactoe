using System;

namespace kata_TicTacToe
{
    public class ComputerNeverLose : Player
    {
        private readonly IMoveDecider _moveDecider;
        private readonly Board _board;
        private readonly WinningMove _winningMove;

        public ComputerNeverLose(Symbol symbol, string name, IMoveDecider moveDecider) : base(symbol, name)
        {
            _moveDecider = moveDecider;
            //  _board = board;
            //_winningMove = new WinningMove(board);
        }




        public override Move PlayTurn()
        {
            var random = new Random();
            var randomXCoordinate = random.Next(0, _board.Size + 1);
            var randomYCoordinate = random.Next(0, _board.Size + 1);
            var move = new Move(randomXCoordinate, randomYCoordinate);
            return move;
        }

        //check to see if can win - put down if can
        //method to block player if about to win - priority
        
        //check for 
        //method for diagonal win (centre if not taken)
        //method to check first for one counter and other squares blank
        //method to check for two counters and other one blank
        
        //list of moves made perhaps? 
    }
}