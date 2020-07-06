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

            if (CheckSingleFilledSpot())
            {
                return GetCornerSpot();
            }

            //does this have to be hardcoded?
            move = CheckWin(Symbol.Cross);
            if (move != null) return move;
            
            move = GetBestMove(); 
            if (move != null) return move;
            
            move = GetCornerSpot();
            if (move != null) return move;
            
           return FindEmptySpot().FirstOrDefault();

        }

        private Move CheckWin(Symbol symbol)
        {
            if (HasWonHorizontally(symbol))
            {
                var move = CheckRow();
                if (move != null) return move;
            }
            if (HasWonVertically(symbol))
            {
                var move = CheckColumn();
                if (move != null) return move;
            }
           
            return null;
        }

        private Move GetCentreMove()
        {
            return new Move((_board.Size + 1) / 2,(_board.Size + 1) / 2);
        }

        private Move GetBestMove()
        {
            var move = CheckRow();
            if (move != null) return move;

            move = CheckColumn();
            if (move != null) return move;

            move = CheckDiagonalLtr();
            if (move != null) return move;

            move = CheckDiagonalRtl();
            if (move != null) return move;

            move = HasOpponentSymbolDiagonalRtl();
            if (move != null) return move;
            
            move = HasOpponentSymbolDiagonalLtr();
            if (move != null) return move;

            return null;
        }
        
        private bool CheckSingleFilledSpot()
        {
            return FindEmptySpot().Count() == 8;
        }
        
        private Move CheckRow()
        {
            for (var i = 1; i <= _board.Size; i++)
            { 
                var numberOfCross = GetRowSpotsTest(i, Symbol.Cross);
                var numberOfNaught = GetRowSpotsTest(i, Symbol.Naught);
                var emptySpot = GetRowSpotsTest(i, Symbol.None);
                if ((numberOfCross.Count() == _board.Size - 1 || numberOfNaught.Count() == _board.Size-1) && 
                emptySpot!=null)
                {
                    return GetRowSpotsTest(i, Symbol.None).FirstOrDefault();
                }
            }
            return null;
        }
        

        // private int GetRowSpots(int rowNumber, Symbol symbol)
        // {
        //     var symbolList = new List<Symbol>();
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         symbolList.Add(_board.GetSymbolAtCoordinates(rowNumber, i));
        //     }
        //     return symbolList.Count(x => x == symbol);
        // }
        
        private IEnumerable<Move> GetRowSpotsTest(int rowNumber, Symbol symbol)
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(rowNumber, i) == symbol)
                {
                    moveList.Add(new Move(rowNumber, i));
                };
            }
            return moveList;
        }

        // private IEnumerable<Move> GetEmptySpotsRow(int rowNumber)
        // {
        //     var moveList = new List<Move>();
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         if (_board.GetSymbolAtCoordinates(rowNumber, i) == Symbol.None)
        //         {
        //             moveList.Add(new Move(rowNumber, i));
        //         }
        //     }
        //     return moveList;
        // }

        private Move CheckColumn()
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                var numberOfCross = GetColumnSpotsTest(i, Symbol.Cross);
                var numberofNaught = GetColumnSpotsTest(i, Symbol.Naught);
                var emptySpot = GetColumnSpotsTest(i, Symbol.None);
                if ((numberOfCross.Count() == _board.Size-1 || numberofNaught.Count() == _board.Size-1) && emptySpot !=null)
                {
                    return GetColumnSpotsTest(i,Symbol.None).FirstOrDefault();
                }
            }
            return null;
        }

        // private int GetColumnSpots(int columnNumber, Symbol symbol)
        // {
        //     var symbolList = new List<Symbol>();
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         symbolList.Add(_board.GetSymbolAtCoordinates(i, columnNumber));
        //     }
        //
        //     return symbolList.Count(x => x == symbol);
        // }
        
        private IEnumerable<Move> GetColumnSpotsTest(int colNumber, Symbol symbol)
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(i, colNumber) == symbol)
                {
                    moveList.Add(new Move(i, colNumber));
                };
            }
            return moveList;
        }

        // private IEnumerable<Move> GetEmptySpotsColumn(int columnNumber)
        // {
        //     var moveList = new List<Move>();
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         if (_board.GetSymbolAtCoordinates(i, columnNumber) == Symbol.None)
        //         {
        //             moveList.Add(new Move(i, columnNumber));
        //         }
        //     }
        //     return moveList;
        // }
        
        private Move HasOpponentSymbolDiagonalLtr()
        {
            //find way to refactor this method too
            // var diagonal = new[]
            // {
            //     _board.GetSymbolAtCoordinates(1, 1), //1, +1
            //     _board.GetSymbolAtCoordinates(2, 2),//2
            //     _board.GetSymbolAtCoordinates(3, 3) //3
            // };
            var numberOfCross = GetDiagonalSpotsTestLtr(Symbol.Cross);
            var numberOfNaught = GetDiagonalSpotsTestLtr(Symbol.Naught);
           var emptySpot = GetDiagonalSpotsTestLtr(Symbol.None);
           if ((numberOfCross.Count() == 1 || numberOfNaught.Count() == 1) && emptySpot.Count() == 1 && 
           CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent())
           {
               return GetDiagonalSpotsTestRtl(Symbol.None).FirstOrDefault();
           }
           return null;
        }
        private bool CheckEmptySpotDiagonalLtrWhenRtlFilledByOpponent()
        {
            return GetDiagonalSpotsTestLtr(Symbol.None).Count() == _board.Size - 1;
        }
        
        private Move HasOpponentSymbolDiagonalRtl()
        {
            var numberOfCross = GetDiagonalSpotsTestRtl(Symbol.Cross);
            var numberOfNaught = GetDiagonalSpotsTestRtl(Symbol.Naught);
            var emptySpot = GetDiagonalSpotsTestRtl(Symbol.None);
            if ((numberOfCross.Count() == 1 || numberOfNaught.Count() == 1) && emptySpot.Count() == 1 && 
            CheckEmptySpotDiagonalLtrWhenRtlFilledByOpponent())
            {
                // return GetEmptySpotsDiagonalLtr().FirstOrDefault;
                return GetDiagonalSpotsTestLtr(Symbol.None).FirstOrDefault();
                
            }
            return null;
        }
        private bool CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent()
        {
            //return GetEmptySpotsDiagonalRtl().Count() == _board.Size - 1;
            return GetDiagonalSpotsTestRtl(Symbol.None).Count() == _board.Size - 1;
        }
        
        private Move CheckDiagonalLtr()
        {
            var numberOfCross = GetDiagonalSpotsTestLtr(Symbol.Cross);
            var numberOfNaught = GetDiagonalSpotsTestLtr(Symbol.Naught);
            var emptySpot = GetDiagonalSpotsTestLtr(Symbol.None);
            if ((numberOfCross.Count() == _board.Size - 1 || numberOfNaught.Count() == _board.Size -1) && emptySpot !=null)
            {
                return GetDiagonalSpotsTestLtr(Symbol.None).FirstOrDefault();
            }
            return null;
        }

        private IEnumerable<Move> GetDiagonalSpotsTestLtr(Symbol symbol)
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

        // private int GetDiagonalSpotsLtr(Symbol symbol)
        // {
        //     var symbolList = new List<Symbol>();
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //          symbolList.Add(_board.GetSymbolAtCoordinates(i, i));
        //     }
        //     return symbolList.Count(x => x == symbol);
        // }
        
        private IEnumerable<Move> GetEmptySpotsDiagonalLtr()
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(i, i) == Symbol.None)
                {
                    moveList.Add(new Move(i, i));
                }
            }
            return moveList;
        }
        
        private Move CheckDiagonalRtl()
        {
            var numberOfCross = GetDiagonalSpotsTestRtl(Symbol.Cross);
            var numberOfNaught = GetDiagonalSpotsTestRtl(Symbol.Naught);
            var emptySpot = GetDiagonalSpotsTestRtl(Symbol.None);
            if (numberOfCross.Count() == _board.Size - 1 && emptySpot.Count() == 1 || numberOfNaught.Count() == _board.Size
             - 1 && 
            emptySpot.Count() == 1)
            {
                return GetDiagonalSpotsTestRtl(Symbol.None).FirstOrDefault();
            }
            return null;
        }
        
        // private int GetDiagonalSpotsRtl(Symbol symbol)
        // {
        //     var symbolList = new List<Symbol>();
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         symbolList.Add(_board.GetSymbolAtCoordinates(i, (_board.Size+1)-i));
        //     }
        //     return symbolList.Count(x => x == symbol);
        // }

        private IEnumerable<Move> GetDiagonalSpotsTestRtl(Symbol symbol)
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

        // private IEnumerable<Move> GetEmptySpotsDiagonalRtl()
        // {
        //     var moveList = new List<Move>();
        //     for (var i = 1; i <= _board.Size; i++)
        //     {
        //         if (_board.GetSymbolAtCoordinates(i, (_board.Size+1)-i) == Symbol.None)
        //         {
        //             moveList.Add(new Move(i, (_board.Size+1)-i));
        //         }
        //     }
        //     return moveList;
        // }

        private Move GetCornerSpot()
        {
            var moveList = new List<Move>();
            for (var i = 1; i < _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(1, 1) == Symbol.None)
                {
                    moveList.Add(new Move(1, 1)); //change to return the single move
                }
                if (_board.GetSymbolAtCoordinates(1, _board.Size) == Symbol.None)
                {
                    moveList.Add(new Move(1, _board.Size));
                }

                if (_board.GetSymbolAtCoordinates(_board.Size, 1) == Symbol.None)
                {
                    moveList.Add(new Move(_board.Size, 1));
                }

                if (_board.GetSymbolAtCoordinates(_board.Size, _board.Size) == Symbol.None)
                {
                    moveList.Add(new Move(_board.Size, _board.Size));
                }
                
            }
            return moveList.FirstOrDefault();
        }

        private IEnumerable<Move> FindEmptySpot()
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                for (var j = 1; j <= _board.Size; j++)
                {
                    if (_board.GetSymbolAtCoordinates(j, i) == Symbol.None)
                    {
                        moveList.Add(new Move(j, i));
                    }
                }
            }
            return moveList;
        }
        
        
        
        private bool HasWonHorizontally(Symbol symbol)
        {
            for (var y = 1; y <= _board.Size; y++)
            {
                if(GetRowSpotsTest(y, symbol).Count() != 1)
                    return false;
            }
            return true;
        }

        private bool HasWonVertically(Symbol symbol)
        {
            for (var x = 1; x <= _board.Size; x++)
            {
                if (GetColumnSpotsTest(x, symbol).Count()!=1)
                    return false;
            }
            return true;
        }
    }
}