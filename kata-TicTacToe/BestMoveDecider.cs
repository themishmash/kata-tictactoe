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
            var move = CheckCentreMove();
            
            if (_board.IsSquareBlank(move) && _board.Size % 2 == 1) //use the board.getsymbolatcoordiantes
            {
                return move;
            }

            if (CheckSingleFilledSpot())
            {
                return GetCornerSpot();
            }

            //does this have to be hardcoded?
            move = CheckWin();
            if (move != null) return move;
            
            move = GetBestMove(); 
            if (move != null) return move;
            

            move = GetCornerSpot();
            if (move != null) return move;
            
           return FindEmptySpot();

        }

        private Move CheckWin()
        {
            if (HasWonHorizontally())
            {
                var move = CheckRow();
                if (move != null) return move;
            }
            if (HasWonVertically())
            {
                var move = CheckColumn();
                if (move != null) return move;
            }
           
            return null;
        }

        private Move CheckCentreMove() //change the name
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
            var getemptyCount = 0;
            for (var i = 1; i <= _board.Size; i++)
            {
                getemptyCount += GetEmptySpots(i).Count();
            }
            if (getemptyCount == 8)
            {
                return true;
            }
            return false;
        }
        
        //this was not working for bestmove decider test win before block
        private Move CheckRow()
        {
            for (var i = 1; i <= _board.Size; i++)
            { 
                var numberOfXSymbols = GetRowSpots(i, Symbol.Cross);
                var numberOfOSymbols = GetRowSpots(i, Symbol.Naught);
                var emptySpotsRow = GetEmptySpotsRow(i); //that should same as above with symbol.none
                if ((numberOfXSymbols == _board.Size - 1 || numberOfOSymbols == _board.Size-1) && emptySpotsRow != null) //make 1 instead //This is checking to see if there are 2 filled in spots with the same symbol and 1 empty spot
                {
                    return emptySpotsRow.FirstOrDefault();
                }
            }
            return null;
        }
        

        private int GetRowSpots(int rowNumber, Symbol symbol)
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                symbolList.Add(_board.GetSymbolAtCoordinates(rowNumber, i));
            }
            return symbolList.Count(x => x == symbol);
        }

        private IEnumerable<Move> GetEmptySpotsRow(int rowNumber)
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(rowNumber, i) == Symbol.None)
                {
                    moveList.Add(new Move(rowNumber, i));
                }
            }
            return moveList;
        }
        
        private IEnumerable<Move> GetEmptySpots(int rowNumber)
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(rowNumber, i) == Symbol.None)
                {
                    moveList.Add(new Move(rowNumber, i));
                }
            }
            return moveList;
        }
        
        private Move CheckColumn()
        {
            for (var i = 1; i <= _board.Size; i++)
            {
                var numberOfXSymbols = GetColumnSpots(i, Symbol.Cross);
                var numberOfOSymbols = GetColumnSpots(i, Symbol.Naught);
                var emptySpotsColumn = GetEmptySpotsColumn(i);
                if ((numberOfXSymbols == _board.Size-1 || numberOfOSymbols == _board.Size-1) && emptySpotsColumn !=null)
                {
                    return emptySpotsColumn.FirstOrDefault();
                }
            }
            return null;
        }

        private int GetColumnSpots(int columnNumber, Symbol symbol)
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                symbolList.Add(_board.GetSymbolAtCoordinates(i, columnNumber));
            }

            return symbolList.Count(x => x == symbol);
        }

        private IEnumerable<Move> GetEmptySpotsColumn(int columnNumber)
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(i, columnNumber) == Symbol.None)
                {
                    moveList.Add(new Move(i, columnNumber));
                }
            }
            return moveList;
        }
        
        private Move HasOpponentSymbolDiagonalLtr()
        {
            //find way to refactor this method too
            // var diagonal = new[]
            // {
            //     _board.GetSymbolAtCoordinates(1, 1), //1, +1
            //     _board.GetSymbolAtCoordinates(2, 2),//2
            //     _board.GetSymbolAtCoordinates(3, 3) //3
            // };
            var numberOfXSymbols = GetDiagonalSpotsLtr(Symbol.Cross);
            var numberOfOSymbols = GetDiagonalSpotsLtr(Symbol.Naught);
           var emptySpot = GetDiagonalSpotsLtr(Symbol.None);
           if ((numberOfXSymbols == 1 || numberOfOSymbols == 1) && emptySpot == 1 && CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent())
           {
               return GetEmptySpotsDiagonalRtl().FirstOrDefault();
           }
           return null;
        }
        private bool CheckEmptySpotDiagonalLtrWhenRtlFilledByOpponent()
        {
            return GetEmptySpotsDiagonalLtr().Count() == _board.Size - 1;
        }
        
        private Move HasOpponentSymbolDiagonalRtl()
        {
            var numberOfXSymbols = GetDiagonalSpotsRtl(Symbol.Cross);
            var numberOfOSymbols = GetDiagonalSpotsRtl(Symbol.Naught);
            var emptySpot = GetDiagonalSpotsRtl(Symbol.None);
            if ((numberOfXSymbols == 1 || numberOfOSymbols == 1) && emptySpot == 1 && 
            CheckEmptySpotDiagonalLtrWhenRtlFilledByOpponent())
            {
                // return GetEmptySpotsDiagonalLtr().FirstOrDefault;
                return GetEmptySpotsDiagonalLtr().FirstOrDefault();
            }
            return null;
        }
        private bool CheckEmptySpotDiagonalRtlWhenLtrFilledByOpponent()
        {
            return GetEmptySpotsDiagonalRtl().Count() == _board.Size - 1;
        }
        
        private Move CheckDiagonalLtr()
        {
            var numberOfXSymbols = GetDiagonalSpotsLtr(Symbol.Cross);
            var numberOfOSymbols = GetDiagonalSpotsLtr(Symbol.Naught);
            var emptySpot = GetEmptySpotsDiagonalLtr();
            if ((numberOfXSymbols == _board.Size - 1 || numberOfOSymbols == _board.Size -1) && emptySpot !=null)
            {
                return GetEmptySpotsDiagonalLtr().FirstOrDefault();
            }
            return null;
        }

        private int GetDiagonalSpotsLtr(Symbol symbol)
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                 symbolList.Add(_board.GetSymbolAtCoordinates(i, i));
            }
            return symbolList.Count(x => x == symbol);
        }
        
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
            var filledXSpots = GetDiagonalSpotsRtl(Symbol.Cross);
            var filledOSpots = GetDiagonalSpotsRtl(Symbol.Naught);
            var emptySpot = GetEmptySpotsDiagonalRtl().Count();
            if (filledXSpots == _board.Size - 1 && emptySpot == 1 || filledOSpots == _board.Size - 1 && emptySpot == 1)
            {
                return GetEmptySpotsDiagonalRtl().FirstOrDefault();
            }
            return null;
        }
        
        private int GetDiagonalSpotsRtl(Symbol symbol)
        {
            var symbolList = new List<Symbol>();
            for (var i = 1; i <= _board.Size; i++)
            {
                symbolList.Add(_board.GetSymbolAtCoordinates(i, (_board.Size+1)-i));
            }
            return symbolList.Count(x => x == symbol);
        }

        private IEnumerable<Move> GetEmptySpotsDiagonalRtl()
        {
            var moveList = new List<Move>();
            for (var i = 1; i <= _board.Size; i++)
            {
                if (_board.GetSymbolAtCoordinates(i, (_board.Size+1)-i) == Symbol.None)
                {
                    moveList.Add(new Move(i, (_board.Size+1)-i));
                }
            }
            return moveList;
        }

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

        private Move FindEmptySpot()
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
            return moveList.FirstOrDefault();
        }
        
        
        
        //2 in row winning move - check to be like WinningMove class
        public bool HasWonHorizontally()
        {
            for (var y = 1; y <= _board.Size; y++)
            {
                if(GetEmptySpotsRow(y).Count() != 1)
                    return false;
            }
            return true;
        }
        
        public bool HasWonVertically()
        {
            for (var x = 1; x <= _board.Size; x++)
            {
                if (GetEmptySpotsColumn(x).Count()!=1)
                    return false;
            }
            return true;
        }
    }
}