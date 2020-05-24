using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

namespace kata_TicTacToe
{
    public class Board
    {
        private readonly int _width;
        private readonly int _length;
        private readonly IList<Coordinate> _board;
       
      
      

        public Board(int width, int length)
        {
            _width = width;
            _length = length;
            _board = new List<Coordinate>();
        }

        public IList<Coordinate> GenerateBoard()
        {
            

            for (var row = 1; row <= _width; row++)
            {
                for (var column = 1; column <= _length; column++)
                {
                    var square = new Coordinate(row, column);
                    _board.Add(square);
                }
            }

            return _board;
        }
        

        public string DisplayBoard()
        { 
            var board = "";
            var i = 1;
            while (i <= _board.Count)
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
    }
}