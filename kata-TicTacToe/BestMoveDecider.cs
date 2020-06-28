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
            

            int xCoordinate = 2;
            int yCoordinate = 2;
            var move = new Move(xCoordinate, yCoordinate);
            
            //return startingMove;
            if (_board.IsSquareBlank(move))
            {
                return move;
            }
            
            if (_board.CheckOpponentWinHorizontally(Symbol.Naught))
            {
                move = new Move(_board.GetHorizontalEmptySpot().XCoordinate, _board.GetHorizontalEmptySpot().YCoordinate);
            }
            else if (_board.CheckOpponentWinVertically(Symbol.Naught))
            {
                move = new Move(_board.GetVerticalEmptySpot().XCoordinate, _board.GetVerticalEmptySpot().YCoordinate);
            }
            else if (_board.HasTwoOpponentSymbolIinDiagonalRTL(Symbol.Naught))
            {
                move = new Move(_board.GetDiagonalEmptySpotRTL().XCoordinate, _board.GetDiagonalEmptySpotRTL()
                .YCoordinate);
            }
            else if (_board.HasOpponentSymbolInDiagonalLTR(Symbol.Naught))
            {
                if (_board.CheckEmptySpotDiagonalRTL())
                {
                    move = new Move(_board.GetDiagonalEmptySpotRTL().XCoordinate, _board.GetDiagonalEmptySpotRTL().YCoordinate);
                }
               
            }
            else if (_board.HasEmptyCorner())
            {
                move = new Move(_board.FindEmptyCorner().XCoordinate, _board.FindEmptyCorner().YCoordinate);
            }
            else 
            {
                //(_board.HasMoreThanOneBlankSquare())
               move = new Move(_board.FindEmptySpot().XCoordinate, _board.FindEmptySpot().YCoordinate);
               return move;
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