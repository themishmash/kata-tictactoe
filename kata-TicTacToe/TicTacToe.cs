using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe
{
    public class TicTacToe
    {
        //private readonly List<Player> _players;
        private readonly IInputOutput _iio;
        private readonly Board _board;
        private readonly Player _player1;
        private readonly Player _player2;


        public TicTacToe(Board board, Player player1, Player player2, IInputOutput iio)
        {
            _iio = iio;
            _board = board;
            _player1 = player1;
            _player2 = player2;
            PlayGame();
        }

        // public void PlayGame()
        // {
        //     while (_player1.PlayerStatus == PlayerStatus.Playing || _player2.PlayerStatus == PlayerStatus.Playing)
        //     for (var i = 0; i <3 ; i++)
        //     {
        //         
        //         var move = _player1.PlayTurn();
        //         _board.PlaceSymbolToCoordinates(_player1.Symbol, move);
        //         var move2 = _player2.PlayTurn();
        //         _board.PlaceSymbolToCoordinates(_player2.Symbol, move2);
        //         
        //         _board.DisplayBoard();
        //         
        //         // if (HasPlayerWon(_players[0]) || HasPlayerWon(_players[1]))
        //         // {
        //         //     _iio.Output("winner");
        //         //     _board.DisplayBoard();
        //         // };
        //
        //         if (HasPlayerWon(_player1))
        //         {
        //             _player1.PlayerStatus = PlayerStatus.Won;
        //             _board.DisplayBoard();
        //         }
        //
        //     }
        //
        //
        //    // _board.DisplayBoard();
        // }
        
        public void PlayGame()
        {
            while (_player1.PlayerStatus == PlayerStatus.Playing && _player2.PlayerStatus == PlayerStatus.Playing)
            {
                _iio.Output(_board.DisplayBoard());
                    var move = _player1.PlayTurn();
                    _board.PlaceSymbolToCoordinates(_player1.Symbol, move);
                    _iio.Output(_board.DisplayBoard());
                    if (HasPlayerWon(_player1))
                    {
                        _player1.PlayerStatus = PlayerStatus.Won;
                        _player2.PlayerStatus = PlayerStatus.Lost;
                        _board.DisplayBoard();
                       break;
                    }
                    
                    var move2 = _player2.PlayTurn();
                    _board.PlaceSymbolToCoordinates(_player2.Symbol, move2);
                    _iio.Output(_board.DisplayBoard());
                    if (HasPlayerWon(_player2))
                    {
                        _player2.PlayerStatus = PlayerStatus.Won;
                        _player1.PlayerStatus = PlayerStatus.Lost;
                        _board.DisplayBoard();
                        break;
                    }
                    
                    CheckDraw();
                    
            }
        }

        private void CheckDraw()
        {
            if (!_board.HasDraw()) return;
            _player1.PlayerStatus = PlayerStatus.Drew;
            _player2.PlayerStatus = PlayerStatus.Drew;
        }


        public bool HasPlayerWon(Player player)
        {
            return _board.HasWonHorizontallyCheckCoordinates(player.Symbol) || _board.HasWonVerticallyCheckCoordinates(player.Symbol)
             || _board
            .HasWonDiagonallyLeftToRightCheckCoordinates(player.Symbol) || _board.HasWonDiagonallyRightToLeftCheckCoordinates(player.Symbol);
        }
    }
    
}