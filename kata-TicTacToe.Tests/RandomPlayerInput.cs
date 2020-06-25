using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe.Tests
{
    public class RandomPlayerInput: NumberGenerator
    {
        private readonly int _coordinate;
        

        public RandomPlayerInput(int coordinate)
        {
            _coordinate = coordinate;
           
        }


        public int GetNumber(int minimum, int maximum)
        {
            return _coordinate;
        }
    }
}