using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe.Tests
{
    public class AutomatedPlayer : IInputOutput
    {
        private readonly Move _move;
        private readonly Move _move2;
        private readonly Move _move3;
        private readonly Move _move4;
        private readonly Move _move5;

        public AutomatedPlayer(Move move, Move move2 = null, Move move3 = null, Move move4 = null, Move move5 = null)
        {
            _move = move;
            _move2 = move2;
            _move3 = move3;
            _move4 = move4;
            _move5 = move5;
        }

       
        

     
        public (int x,int y) AskQuestion(string question)
        {
            
          return (1,1);
          
          
        }
        
        
    }
}