using System;
using System.Linq;

namespace kata_TicTacToe.Tests
{
    public class TestResponder : IInputOutput
    {
        public (int x,int y) AskQuestion(string question)
        {
            return (1,1);
        }
        
    }
}