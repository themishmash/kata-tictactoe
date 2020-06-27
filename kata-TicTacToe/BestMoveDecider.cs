using System;

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
            //check to see if can win - put down if can
            //method to block player if about to win - priority
        
            //check for 
            //method for diagonal win (centre if not taken)
            //method to check first for one counter and other squares blank
            //method to check for two counters and other one blank
        
            //list of moves made perhaps? 
            //throw new System.NotImplementedException();
            
            //check if board empty 
            var xCoordinate = 2;
            var yCoordinate = 2;
            var move = new Move(xCoordinate, yCoordinate);
            //return startingMove;
            if (_board.IsSquareBlank(move))
            {
                return move;
            }

            //CheckOpponentMoves();
        //_board.CheckOpponentWinHorizontally(Symbol.Naught);
            
            if (_board.CheckOpponentWinHorizontally(Symbol.Naught))
            {
                move = new Move(_board.GetEmptySpot().XCoordinate, _board.GetEmptySpot().YCoordinate);
            }
            else
            {
                move = new Move(_board.FindEmptyCorner().XCoordinate, _board.FindEmptyCorner().YCoordinate);
            }
            
           return move;
           // CheckOpponentMoves();



        }

       

        //need to look through list of boardsquares and find an empty corner. so check boardsquares and look at x and y coordinates - where they equal one another, where they equal size+1 together - AND they are empty
        // private void CheckCorners()
        // {
        //    
        //     int xCoordinate;
        //     int yCoordinate;
        //     var cornerMove = new Move(xCoordinate, yCoordinate);
        // }
    }
}