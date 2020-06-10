using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe.Tests
{
    public class AutomatedPlayer : IInputOutput
    {
        private readonly (int x, int y) _turn;
        private readonly (int x, int y) _turn1;
        private readonly (int x, int y) _turn2;
        private readonly (int x, int y) _turn3;

        private readonly List<Move> _playerMoves = new List<Move>();
        
        // public AutomatedPlayer((int x,int y) turn1, (int x, int y) turn2)
        // {
        //     _turn1 = turn1;
        //     _turn2 = turn2;
        //    
        // }

        public AutomatedPlayer((int x, int y) turn, (int x, int y) turn2, (int x, int y) turn3)
        {
            _turn = turn;
            _turn2 = turn2;
            _turn3 = turn3;
            var move = new Move(turn.x, turn.y);
            var move2 = new Move(turn2.x, turn2.y );
            var move3 = new Move(turn2.x, turn2.y);
            _playerMoves.Add(move);
            _playerMoves.Add(move2);
            _playerMoves.Add(move3);

        }
        
        

        public AutomatedPlayer((int x, int y) turn1)
        {
            _turn1 = turn1;
            var move = new Move(turn1.x, turn1.y);
            _playerMoves.Add(move);
        }
        
        // public (int x,int y) AskQuestion(string question)
        // {
        //     foreach (var move in _playerMoves)
        //     {
        //         return (move.XCoordinate, move.YCoordinate);
        //     } 
        //     return (0,0);
        // }
        
        // public (int x,int y) AskQuestion(string question)
        // {
        //     
        //     var newMove = _playerMoves.First();
        //     _playerMoves.RemoveAt(0);
        //     return (newMove.XCoordinate, newMove.YCoordinate);
        //     foreach (var move in _playerMoves)
        //     {
        //         return (move.XCoordinate, move.YCoordinate);
        //     } 
        //     return (0,0);
        // }
        
        public (int x, int y) AskQuestion(string question)
        {
            
            // var newMove = _playerMoves.First();
            // _playerMoves.RemoveAt(0);
            // return (newMove.XCoordinate, newMove.YCoordinate);
            Move newMove = null;
         
            for(var i = 0; i < _playerMoves.Count; i--)
            {
                newMove = _playerMoves.First();
                _playerMoves.RemoveAt(0);
                return (newMove.XCoordinate, newMove.YCoordinate);
            } 
            return (newMove.XCoordinate, newMove.YCoordinate);
        }
        
        
    }
}