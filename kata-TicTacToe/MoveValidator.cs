using System;
using System.Collections.Generic;

namespace kata_TicTacToe
{
    public static class MoveValidator
    {
        public static bool IsValidMove(Move move, Board board)
        {
            return board.IsSquareBlank(move) && IsNumberPositive(move.XCoordinate, move.YCoordinate);
        }
        
        //check boundaries
        private static bool IsNumberPositive(int xCoordinate, int yCoordinate)
        {
            return xCoordinate >= 0 && yCoordinate >= 0;
        }

        public static bool HasQuit(string input)
        {
            return input == "q";
        }
    
    }
}