using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe
{
    public class TicTacToe
    {
        private readonly IInputOutput _iio;
        private readonly WinningMove _winningMove;
        private readonly Board _board;
        private readonly Player _player1;
        private readonly Player _player2;


        public TicTacToe(Board board, Player player1, Player player2, IInputOutput iio)
        {
            _board = board;
            _player1 = player1;
            _player2 = player2;
            _iio = iio;
            _winningMove = new WinningMove(board);
        }

       
        public void PlayGame()
        {
            while (_player1.PlayerStatus == PlayerStatus.Playing && _player2.PlayerStatus == PlayerStatus.Playing)
            {
                _iio.Output(_board.DisplayBoard());
                
                var move = _player1.PlayTurn();
                if(MoveValidator.IsValidMove(move, _board))
                {
                    _board.PlaceSymbolToCoordinates(_player1.Symbol, move);
                    _iio.Output(_board.DisplayBoard());
                }
                
                if (HasPlayerWon(_player1, move))
                {
                    _player1.PlayerStatus = PlayerStatus.Won;
                    _player2.PlayerStatus = PlayerStatus.Lost;
                    _board.DisplayBoard();
                    break;
                }
                CheckDraw();
                    
                //check if player 1 won or lose or draw (if not then execute the line below)

                if (_player1.PlayerStatus != PlayerStatus.Playing) continue;
                
                var move2 = _player2.PlayTurn();

                if (MoveValidator.IsValidMove(move2, _board))
                {
                    _board.PlaceSymbolToCoordinates(_player2.Symbol, move2);
                    _iio.Output(_board.DisplayBoard());
                }

                if (HasPlayerWon(_player2, move))
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
        
        private bool HasPlayerWon(Player player, Move move)
        {
            return _winningMove.HasWonHorizontallyCheckCoordinates(player.Symbol, move.XCoordinate) || _winningMove
            .HasWonVerticallyCheckCoordinates(player.Symbol, move.YCoordinate)
             || _winningMove
            .HasWonDiagonallyLeftToRightCheckCoordinates(player.Symbol) || _winningMove.HasWonDiagonallyRightToLeftCheckCoordinates(player.Symbol);
        }
    }
    
    //checkdrawreturn player status - switch?
    //check won - return playerstatus - switch?
}