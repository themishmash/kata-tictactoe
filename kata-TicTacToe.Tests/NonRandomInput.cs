using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe.Tests
{
    public class RandomInput: NumberGenerator
    {
        private readonly (int x, int y) _turn;

        public RandomInput((int x, int y) turn)
        {
            _turn = turn;
        }
        public int GetNumber(int minimum, int maximum)
        {
            var range = maximum - minimum;
            return range;
        }
    }
}