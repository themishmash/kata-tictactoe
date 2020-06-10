using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe.Tests
{
    public class PlayerInput : IInputOutput
    {
        private readonly (int x, int y) _turn;
        private readonly (int x, int y) _turn1;
        private readonly (int x, int y) _turn2;
        private readonly (int x, int y) _turn3;

        private int _counter = 0;
        
        // public AutomatedPlayer((int x,int y) turn1, (int x, int y) turn2)
        // {
        //     _turn1 = turn1;
        //     _turn2 = turn2;
        //    
        // }

        public PlayerInput((int x, int y) turn, (int x, int y) turn2, (int x, int y) turn3)
        {
            _turn = turn;
            _turn2 = turn2;
            _turn3 = turn3;
        }
        
        
        public PlayerInput((int x, int y) turn)
        {
            _turn = turn;
        
        }
        
        
        public (int x, int y) AskQuestion(string question)
        {
            _counter++;
            return _counter switch
            {
                1 => _turn,
                2 => _turn2,
                3 => _turn3,
                _ => (1, 1)
            };
        }

        public void Output(string message)
        {
            throw new NotImplementedException();
        }
    }
}