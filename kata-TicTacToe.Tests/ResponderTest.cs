using System;
using System.Linq;

namespace kata_TicTacToe.Tests
{
    public class ResponderTest : IInputOutput
    {
        private readonly string _input;
        public readonly int XCoordinate;
        public readonly int YCoordinate;
        // public ResponderTest(int xCoordinate, int yCoordinate)
        // {
        //     XCoordinate = xCoordinate;
        //     YCoordinate = yCoordinate;
        // }

        private string _testResponses;
        
        // public ResponderTest(string testResponses)
        // {
        //     _testResponses = testResponses;
        // }
        public (int x,int y) AskQuestion(string question)
        {

            return (1,1);
        }

      

        public int[] ParseStringCoordinatesToInt(string number)
        {
            var stringCoordinates = number.Split(",", StringSplitOptions.RemoveEmptyEntries);
            return stringCoordinates.Select(int.Parse).ToArray();
        }
    }
}