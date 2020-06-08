using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe.Tests
{
    public class TestResponder : IInputOutput
    {
        private readonly Queue <int>_testResponses = new Queue<int>();
        public (int x,int y) AskQuestion(string question)
        {
            return (1,1);
        }
        
       
        
        
        public void Output(string message)
        {
            
        }
    }
}