using System;
using System.Collections.Generic;

namespace kata_TicTacToe
{
    public static class MoveValidator
    {
        public static bool IsValidMove(Move move, IEnumerable<Square> boardSquares)
        {
            foreach (var square in boardSquares)
            {
                if (square.XCoordinate == move.XCoordinate && square.YCoordinate == move.YCoordinate && square.SquareStatus == SquareStatus.Blank && square.Symbol == Symbol.None)
                    return true;
            }
            return false;
        }

    
    }
}