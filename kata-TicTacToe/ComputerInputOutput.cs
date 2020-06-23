using System;

namespace kata_TicTacToe
{
    public class ComputerInputOutput : IInputOutput
    {
        private readonly Board _board;

        public ComputerInputOutput(Board board)
        {
            _board = board;
        }
        public (int x, int y) AskQuestion(string answer)
        {
            var random = new Random();
            var randomXCoordinate = random.Next(1, 3);
            var randomYCoordinate = random.Next(1, 3);
            return (randomXCoordinate, randomYCoordinate);
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}