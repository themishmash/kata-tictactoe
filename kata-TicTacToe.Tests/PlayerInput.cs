using System;

namespace kata_TicTacToe.Tests
{
    public class PlayerInput : IInputOutput
    {
        private readonly (int x, int y) _turn;
        private readonly (int x, int y) _turn2;
        private readonly (int x, int y) _turn3;
        private readonly (int x, int y) _turn4;
        private readonly (int x, int y) _turn5;

        private int _counter;
        
        public PlayerInput((int x, int y) turn, (int x, int y) turn2, (int x, int y) turn3)
        {
            _turn = turn;
            _turn2 = turn2;
            _turn3 = turn3;
        }
        
        public PlayerInput((int x, int y) turn, (int x, int y) turn2, (int x, int y) turn3, (int x, int y) turn4)
        {
            _turn = turn;
            _turn2 = turn2;
            _turn3 = turn3;
            _turn4 = turn4;
        }
        
        public PlayerInput((int x, int y) turn, (int x, int y) turn2, (int x, int y) turn3, (int x, int y) turn4,(int
         x, int y) turn5)
        {
            _turn = turn;
            _turn2 = turn2;
            _turn3 = turn3;
            _turn4 = turn4;
            _turn5 = turn5;
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
                4 => _turn4,
                5 => _turn5,
                _ => (1, 1)
            };
        }

        public void Output(string message)
        {
            throw new NotImplementedException();
        }
        
    }
}