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

        public PlayerInput((int x, int y) turn, (int x, int y)turn2)
        {
            _turn = (1, 1);
            _turn2 = (1, 2);
        }
        
        public (int x, int y) AskQuestion(string question)
        {
            _counter++;
            switch (_counter)
            {
                case 1:
                    return _turn;
                case 2:
                    return _turn2;
                case 3:
                    return _turn3;
                case 4:
                    return _turn4;
                case 5:
                    return _turn5;
                default:
                    return (1, 1);
            }
        }

        public void Output(string message)
        {
            throw new NotImplementedException();
        }
        
    }
}