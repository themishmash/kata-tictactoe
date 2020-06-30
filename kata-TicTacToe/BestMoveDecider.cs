using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace kata_TicTacToe
{
    public class BestMoveDecider:IMoveDecider
    {
        private readonly Board _board;
        private readonly List<Symbol> _diagSymbols = new List<Symbol>();
        private readonly Symbol[] ArraySymbolDiag;

        public BestMoveDecider(Board board)
        {
            _board = board;
            ArraySymbolDiag = new Symbol[_board.Size];
        }
        
        public Move NextMove() //pass in player? so can get symbol?
        {
            var xCoordinate = (_board.Size + 1) / 2;
            var yCoordinate = (_board.Size + 1) / 2;
            var move = new Move(xCoordinate, yCoordinate);
            
            if (_board.IsSquareBlank(move))
            {
                return move;
            }
            
            move = GetBestMove(Symbol.Cross);
            if (move != null) return move;

            move = GetBestMove(Symbol.Naught);
            if (move != null) return move;

            if (HasOpponentSymbolInDiagonalLTR(Symbol.Naught) && _board.CheckEmptySpotDiagonalRTL())
            {
                return new Move(_board.GetDiagonalEmptySpotRTL().XCoordinate, _board.GetDiagonalEmptySpotRTL()
                .YCoordinate);
            }
            
            if (_board.HasEmptyCorner())
            {
                return new Move(_board.GetEmptyCorner().XCoordinate, _board.GetEmptyCorner().YCoordinate);
            }
            
            return new Move(_board.FindEmptySpot().XCoordinate, _board.FindEmptySpot().YCoordinate);
        }
        

        private Move GetBestMove(Symbol symbol) 
        {
            if (_board.CheckRow(symbol))
            {
               return new Move(_board.GetRowEmptySpot(symbol).XCoordinate, _board.GetRowEmptySpot(symbol)
                        .YCoordinate);
            }

            if (_board.CheckColumn(symbol))
            {
                return new Move(_board.GetColumnEmptySpot(symbol).XCoordinate,
                        _board.GetColumnEmptySpot(symbol).YCoordinate);
            }

            if (_board.CheckDiagonalLTR(symbol))
            {
                return new Move(_board.GetDiagonalEmptySpotLTR().XCoordinate, _board.GetDiagonalEmptySpotLTR()
                        .YCoordinate);
            }

            if (_board.CheckDiagonalRTL(symbol))
            {
                return new Move(_board.GetDiagonalEmptySpotRTL().XCoordinate,
                        _board.GetDiagonalEmptySpotRTL().YCoordinate);
            }

            return null;
        }

      
        private bool HasOpponentSymbolInDiagonalLTR(Symbol symbol)
        {
            //find way to refactor this method too
            // var diagonal = new[]
            // {
            //     _board.GetSymbolAtCoordinates(1, 1),
            //     _board.GetSymbolAtCoordinates(2, 2),
            //     _board.GetSymbolAtCoordinates(3, 3)
            // };
            var diagonal = _board.GetDiagonalSpotsLtr();
            var numberOfSymbols = diagonal.Count(s => s.Symbol == symbol);
            var emptySpot = diagonal.Count(s => s.Symbol == Symbol.None);
            return numberOfSymbols == 1 && emptySpot == 1;
        }
   
        // public Square GetRowEmptySpot(Symbol symbol)
        // {
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         var row = _board.GetRowSpots();
        //         var numberRow = row.Count(x => x.Symbol == symbol);
        //         if (numberRow != 2) continue;
        //         {
        //             var emptySpot = row.Where(x => x.Symbol != symbol);
        //             return emptySpot.FirstOrDefault();
        //         }
        //     }
        //     return null;
        // }
        
    }
    
    
}