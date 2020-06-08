using System;
using System.Linq;

namespace kata_TicTacToe
{
    public class ConsoleInputOutput : IInputOutput
    {
        // public string AskQuestion(string question)
        // {
        //     Console.WriteLine(question);
        //     //return Console.ReadLine();
        // }

        public (int x,int y) AskQuestion(string question)
        {
            Console.WriteLine(question);
            var answer = Console.ReadLine();
            var coordinates = ParseStringCoordinatesToInt(answer);
            return (coordinates[0], coordinates[1]);
            // return Console.ReadLine();
            // if(Validator.AreNumbersValid(answer));
            // {
            //     coordinateNumbers = _iio.ParseStringCoordinatesToInt(answer);
            // }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }


        private int[] ParseStringCoordinatesToInt(string number)
        {
            var stringCoordinates = number.Split(",", StringSplitOptions.RemoveEmptyEntries);
            return stringCoordinates.Select(int.Parse).ToArray();
        }
    }
}