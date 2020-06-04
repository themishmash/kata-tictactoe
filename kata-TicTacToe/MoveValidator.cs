using System;
using System.Collections.Generic;

namespace kata_TicTacToe
{
    public static class MoveValidator
    {
       // private readonly Board _board;
       // private readonly List<Square> _boardSquares = new List<Square>();

        // public MoveValidator(Board board)
        // {
        //     _board = board;
        //     _boardSquares = new List<Square>();
        // }
        public static bool IsValidMove(Move move, List<Square> board)
        {
            foreach (var square in board)
            {
                if (square.XCoordinate == move.XCoordinate && square.YCoordinate == move.YCoordinate && square.SquareStatus == SquareStatus.Blank && square.Symbol == Symbol.None)
                    return true;
            }
            return false;
        }

    
    }
}