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

            move = GetBestMove(); 
            if (move != null) return move;
            
           return FindEmptySpot();
        }

        private Move GetCentreMove()
        {
            return new Move((_board.Size + 1) / 2,(_board.Size + 1) / 2);
        }

        private Move GetBestMove()
        {
            var move = FindWinningMove(Symbol.Cross);
            if (move != null) return move;

            move = FindWinningMove(Symbol.Naught);
            if (move != null) return move;

            move = FindDiagonalWithTwoEmptyCorners();
            if (move != null) return move;

            move = GetCornerSpot();
            if (move != null) return move;
            
            return null;
        }
        
        private Move FindWinningMove(Symbol symbol)
        {
            var move = FindAWinningRowMove(symbol);
            if (move != null) return move;

            move = FindAWinningColumnMove(symbol);
            if (move != null) return move;

            move = FindAWinningDiagonalMoveLtr(symbol);
            if (move != null) return move;
            
            move = FindAWinningDiagonalMoveRtl(symbol);
            if (move != null) return move;
            
            return move;
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
        
        private Move FindAWinningDiagonalMoveLtr(Symbol symbol)
        {
            var move = GetCentreMove();
            var center = _board.GetSymbolAtCoordinates(move.XCoordinate, move.YCoordinate);
            if (center != symbol)
            {
                return null;
            }
            
            var topLeft = _board.GetSymbolAtCoordinates(1, 1);
            var bottomRight = _board.GetSymbolAtCoordinates(_board.Size, _board.Size);
            
            if (topLeft == symbol && bottomRight == Symbol.None)
            {
                return new Move(_board.Size, _board.Size);
            }
        
            if (bottomRight == symbol && topLeft == Symbol.None)
            {
                return new Move(1,1);
            }
            
            return null;
        }
        
        private Move FindAWinningDiagonalMoveRtl(Symbol symbol)
        {
            var move = GetCentreMove();
            var center = _board.GetSymbolAtCoordinates(move.XCoordinate, move.YCoordinate);
            if (center != symbol)
            {
                return null;
            }

            var topRight = _board.GetSymbolAtCoordinates(1, _board.Size);
            var bottomLeft = _board.GetSymbolAtCoordinates(_board.Size, 1);
            
            if (topRight == symbol && bottomLeft == Symbol.None)
            {
                return new Move(_board.Size, 1);
            }
            
            if (bottomLeft == symbol && topRight == Symbol.None)
            {
                return new Move(1, _board.Size);
            }
            return null;
        }
        
        private Move FindDiagonalWithTwoEmptyCorners()
        {
            var topLeft = _board.GetSymbolAtCoordinates(1, 1);
            var bottomRight = _board.GetSymbolAtCoordinates(_board.Size, _board.Size);
            
            if (topLeft == Symbol.None && bottomRight == Symbol.None)
            {
                return new Move(1,1);
            }
            
            var topRight = _board.GetSymbolAtCoordinates(1, _board.Size);
            var bottomLeft = _board.GetSymbolAtCoordinates(_board.Size, 1);

            if (topRight == Symbol.None && bottomLeft == Symbol.None)
            {
                return new Move(1, _board.Size);
            }
            return null;
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