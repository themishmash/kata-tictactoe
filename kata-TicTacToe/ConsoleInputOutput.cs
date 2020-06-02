using System;
using System.Linq;

namespace kata_TicTacToe
{
    public class ConsoleInputOutput : IInputOutput
    {
        public string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public int[] ParseStringCoordinatesToInt(string number)
        {
            var stringCoordinates = number.Split(",", StringSplitOptions.RemoveEmptyEntries);
            return stringCoordinates.Select(int.Parse).ToArray();
        }
    }
}