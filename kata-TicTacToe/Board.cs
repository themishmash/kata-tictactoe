using System.Collections.Generic;

namespace kata_TicTacToe
{
    public class Board
    {
        private readonly int _width;
        private readonly int _length;
        public readonly IList<Coordinate> CoordinateList;
        public CoordinateStatus CoordinateStatus;
    
        
        public Board(int width, int length)
        {
            _width = width;
            _length = length;
           //CoordinateStatus = CoordinateStatus.Blank; //--> this seems to be set even without this? 
            CoordinateList = new List<Coordinate>();
        }

        public IList<Coordinate> GenerateBoard()
        {
            for (var row = 1; row <= _width; row++)
            {
                for (var column = 1; column <= _length; column++)
                {
                    var square = new Coordinate(row, column);
                    CoordinateList.Add(square);
                   //CoordinateStatus = CoordinateStatus.Blank; --> this is set without this? 
                }
            }

            return CoordinateList;
        }
        

        public string DisplayBoard()
        { 
            var board = "";
            var i = 1;
            while (i <= CoordinateList.Count)
            {
                board += " . ";
                if (i % _width == 0)
                {
                    board += System.Environment.NewLine;
                }
                i++;
            }
            return board;
        }


        public bool IsValidMove(int xCoordinate, int yCoordinate)
        {
            foreach (var spot in CoordinateList)
            {
                if (xCoordinate != spot.XCoordinate || yCoordinate != spot.YCoordinate) continue;
                if (spot.CoordinateStatus == CoordinateStatus.Blank)
                    
                    return true;
            }
            return false;
        }


        public void ChangeCoordinateStatus()
        {
            foreach (var item in CoordinateList)
            {
                if (IsValidMove(item.XCoordinate, item.YCoordinate))
                {
                    item.CoordinateStatus = CoordinateStatus.Filled;
                }
            }
        }
    }
}