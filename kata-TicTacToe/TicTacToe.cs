using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe
{
    public class TicTacToe
    {
        private readonly List<Player> _players;
        private readonly IInputOutput _iio;
        private readonly Board _board;
        private List<Move> _playerMoves;
        //private Dictionary<Move, Symbol> _winningList; 
        
        

        public TicTacToe(List<Player> players, IInputOutput iio, Board board)
        {
            _players = players;
            _iio = iio;
            _board = board;
        }

        // public void StartGame()
        // {
        //     _winningMoves = new List<Move>();
        //    
        //         var move = _players[0].PlayTurn();
        //         _board.PlaceSymbolToCoordinates(_players[0].Symbol, move);
        //         var move2 = _players[1].PlayTurn();
        //         _board.PlaceSymbolToCoordinates(_players[1].Symbol, move2);
        //         
        //         _winningMoves.Add(move);
        //         _winningMoves.Add(move2);
        //
        //        
        //        
        //
        //
        //     // if (_winningMoves.FirstOrDefault(i => i.XCoordinate == 1 && i.YCoordinate == 1 && i.XCoordinate==1 && i
        //     // .YCoordinate == 2 && i.XCoordinate ==1 && i
        //     // .YCoordinate ==3) != 
        //     // null && _players[0]
        //     // .Symbol == Symbol.Cross)
        //     // {
        //     //     _iio.Output($"Player {_players[0].Symbol} has won!");
        //     // }
        //     // if (HasWon(_players[0]))
        //     // {
        //     //    _players[0].GameStatue = GameStatus.Won;
        //     //     _iio.Output($"Player{_players[0]} has won");
        //     // }
        // }

        public void StartGame()
        {

            _playerMoves = new List<Move>();
            for (var i = 0; i <=3 ; i++)
            {
                var move = _players[0].PlayTurn();
                _board.PlaceSymbolToCoordinates(_players[0].Symbol, move);
                // var move2 = _players[1].PlayTurn();
                // _board.PlaceSymbolToCoordinates(_players[1].Symbol, move2);
                _playerMoves.Add(move);

            }

           
            
        }

      
        
    }
    
}