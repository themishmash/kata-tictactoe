using System.Collections.Generic;
using System.Linq;

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
            var move = GetCentreMove();
            
            if (_board.IsSquareBlank(move) && _board.Size % 2 == 1) //use the board.getsymbolatcoordiantes
            {
                return move;
            }
            
            //does this have to be hardcoded?
            // move = CheckWin(Symbol.Cross);
            // if (move != null) return move;
            
            move = GetBestMove(); 
            if (move != null) return move;

            move = GetCornerSpot();
            if (move != null) return move;
            
           return FindEmptySpot();

        }

        private Move GetCentreMove()
        {
            return new Move((_board.Size + 1) / 2,(_board.Size + 1) / 2);
        }

        private Move GetBestMove()
        {
            var move = FindAWinningRowMove(Symbol.Cross);
            if (move != null) return move;

            move = FindAWinningColumnMove(Symbol.Cross);
            if (move != null) return move;

            move = FindAWinningDiagonalLtrMove(Symbol.Cross);
            if (move != null) return move;
            
            move = FindAWinningDiagonalRtlMove(Symbol.Cross);
            if (move != null) return move;

            // move = CheckDiagonalLtr();
            // if (move != null) return move;

            // move = CheckDiagonalRtl();
            // if (move != null) return move;

            move = HasOpponentSymbolDiagonalRtl();
            if (move != null) return move;
            
            move = HasOpponentSymbolDiagonalLtr();
            if (move != null) return move;

            move = FindAWinningRowMove(Symbol.Naught);
            if (move != null) return move;
            
            move = FindAWinningColumnMove(Symbol.Naught);
            if (move != null) return move;


            return null;
        }
        
        private Move FindAWinningRowMove(Symbol symbol)
        {
            Move nextMove = null;
            
            //Check all rows to see if there is a winning one
            for (var row = 1; row <= _board.Size; row++)
            {
                // check the rows columns
                for (var col = 1; col <= _board.Size; col++)
                {
                    var currentSymbol = _board.GetSymbolAtCoordinates(row, col);
                    // if there is a different symbol, the row can't win
                    if (currentSymbol != symbol && currentSymbol !=Symbol.None)
                    {
                        nextMove = null;
                        break;
                    }
                    // if we have found a possible move already, there id more than 1 empty, the row cant win 
                    if (currentSymbol == Symbol.None && nextMove != null)
                    {
                        nextMove = null;
                        break;
                    }
                    // if the spot is empty, remember it and keep checking
                    if (currentSymbol == Symbol.None)
                    {
                        nextMove = new Move(row, col);
                    } 
                }
                // if there was a empty spot found , no need to check any more rows
                if (nextMove != null) break;
            }
            // if we found a spot, this will be the next move
            return nextMove;
        }
        
        private Move FindAWinningColumnMove(Symbol symbol)
        {
            Move nextMove = null;
            for (var col = 1; col <= _board.Size; col++)
            {
                for (var row = 1; row <= _board.Size; row++)
                {
                    var currentSymbol = _board.GetSymbolAtCoordinates(row, col);
                    if (currentSymbol != symbol && currentSymbol !=Symbol.None)
                    {
                        nextMove = null;
                        break;
                    }
                    if (currentSymbol == Symbol.None && nextMove != null)
                    {
                        nextMove = null;
                        break;
                    }
                    if (currentSymbol == Symbol.None)
                    {
                        nextMove = new Move(row, col);
                    } 
                }
                if (nextMove != null) break;
            }
            return nextMove;
        }
        
        private Move FindAWinningDiagonalLtrMove(Symbol symbol)
        {
            Move nextMove = null;
            for (var i = 1; i <= _board.Size; i++)
            {
                var currentSymbol = _board.GetSymbolAtCoordinates(i, i);
                if (currentSymbol != symbol && currentSymbol !=Symbol.None)
                {
                    nextMove = null;
                    break;
                }
                if (currentSymbol == Symbol.None && nextMove != null)
                {
                    nextMove = null;
                    break;
                }
                if (currentSymbol == Symbol.None)
                {
                    nextMove = new Move(i, i);
                } 
            }
            return nextMove;
        }
        
        private Move FindAWinningDiagonalRtlMove(Symbol symbol)
        {
            Move nextMove = null;
            for (var i = 1; i <= _board.Size; i++)
            {
                var currentSymbol = _board.GetSymbolAtCoordinates(_board.Size +1 -i, i);
                if (currentSymbol != symbol && currentSymbol !=Symbol.None)
                {
                    nextMove = null;
                    break;
                }
                if (currentSymbol == Symbol.None && nextMove != null)
                {
                    nextMove = null;
                    break;
                }
                if (currentSymbol == Symbol.None)
                {
                    nextMove = new Move(_board.Size +1 -i, i);
                } 
            }
            return nextMove;
        }

        private Move HasOpponentSymbolDiagonalLtr()
        {
            var numberOfCross = GetDiagonalSpotsLtr(Symbol.Cross);
            var numberOfNaught = GetDiagonalSpotsLtr(Symbol.Naught);
           var emptySpot = GetDiagonalSpotsLtr(Symbol.None);
           if ((numberOfCross.Count() == 1 || numberOfNaught.Count() == 1) && emptySpot.Count() == 1 && 
           CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent())
           {
               return GetDiagonalSpotsRtl(Symbol.None).FirstOrDefault();
           }
           return null;
        }
        private bool CheckEmptySpotDiagonalLtrWhenRtlFilledByOpponent()
        {
            return GetDiagonalSpotsLtr(Symbol.None).Count() == _board.Size - 1;
        }
        
        private Move HasOpponentSymbolDiagonalRtl()
        {
            var numberOfCross = GetDiagonalSpotsRtl(Symbol.Cross);
            var numberOfNaught = GetDiagonalSpotsRtl(Symbol.Naught);
            var emptySpot = GetDiagonalSpotsRtl(Symbol.None);
            if ((numberOfCross.Count() == 1 || numberOfNaught.Count() == 1) && emptySpot.Count() == 1 && 
            CheckEmptySpotDiagonalLtrWhenRtlFilledByOpponent())
            {
                return GetDiagonalSpotsLtr(Symbol.None).FirstOrDefault();
            }
            return null;
        }
        private bool CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent()
        {
            return GetDiagonalSpotsRtl(Symbol.None).Count() == _board.Size - 1;
        }
        
        private IEnumerable<Move> GetDiagonalSpotsLtr(Symbol symbol)
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(i, i) == symbol)
                {
                    moveList.Add(new Move(i, i));
                }
            }
            return moveList;
        }
        
        private IEnumerable<Move> GetDiagonalSpotsRtl(Symbol symbol)
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(i, (_board.Size + 1) - i) == symbol)
                {
                    moveList.Add(new Move(i, (_board.Size + 1)-i));
                }
            }
            return moveList;
        }

        private Move GetCornerSpot()
        {
            if (_board.GetSymbolAtCoordinates(1, 1) == Symbol.None)
            {
               return new Move(1, 1); //change to return the single move
            }
            if (_board.GetSymbolAtCoordinates(1, _board.Size) == Symbol.None)
            {
                return new Move(1, _board.Size);
            }

            if (_board.GetSymbolAtCoordinates(_board.Size, 1) == Symbol.None)
            {
               return new Move(_board.Size, 1);
            }

            if (_board.GetSymbolAtCoordinates(_board.Size, _board.Size) == Symbol.None)
            {
                return new Move(_board.Size, _board.Size);
            }
            
            return null;
        }

        private Move FindEmptySpot()
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                for (var j = 1; j <= _board.Size; j++)
                {
                    if (_board.GetSymbolAtCoordinates(j, i) == Symbol.None)
                    {
                       return new Move(j, i);
                    }
                }
            }
            return null;
        }
        
    }
}