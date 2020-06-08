using System;
using System.Collections.Generic;

namespace kata_TicTacToe
{
    public static class MoveValidator
    {
        public static bool IsValidMove(Move move, Board board)
        {
            return board.IsSquareBlank(move) && IsNumberPositive(move.XCoordinate, move.YCoordinate);

            //coordinates is taken
            //y coordinates outside board
            //x coordinate outside board
            //trying to make move when board full
            //what we know: board, move. given these coordinates - are these taken. maybe method to board about if squares taken.
            //
        }
        
        
        //check boundaries
        private static bool IsNumberPositive(int xCoordinate, int yCoordinate)
        {
            return xCoordinate >= 0 && yCoordinate >= 0;
        }

    
    }
}