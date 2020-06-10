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



        public TicTacToe(List<Player> players, IInputOutput iio, Board board)
        {
            _players = players;
            _iio = iio;
            _board = board;
        }

        public void StartGame()
        {

         
            _playerMoves = new List<Move>();
           
            for (var i = 0; i <3 ; i++)
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