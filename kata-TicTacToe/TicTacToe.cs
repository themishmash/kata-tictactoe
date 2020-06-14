using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_TicTacToe
{
    public class TicTacToe
    {
        //private readonly List<Player> _players;
        private readonly IInputOutput _iio;
        private readonly WinningMoves _winningMoves;
        private readonly Board _board;
        private readonly Player _player1;
        private readonly Player _player2;


        public TicTacToe(Board board, Player player1, Player player2, IInputOutput iio)
        {
            _iio = iio;
            _board = board;
            _winningMoves = new WinningMoves(board);
            _player1 = player1;
            _player2 = player2;
            PlayGame();
        }

       
        public void PlayGame()
        {
            while (_player1.PlayerStatus == PlayerStatus.Playing && _player2.PlayerStatus == PlayerStatus.Playing)
            {
                _iio.Output(_board.DisplayBoard());
                
                
                    var move = _player1.PlayTurn();
                    if(MoveValidator.IsValidMove(move, _board));
                        //need to have move validator
                        {
                            _board.PlaceSymbolToCoordinates(_player1.Symbol, move);
                            _iio.Output("valid move");
                        }
                        
                
                    
                    _iio.Output(_board.DisplayBoard());
                    
                    //can also pass in player's move. 
                    //move win check logic into own class. 
                    if (HasPlayerWon(_player1, move))
                    {
                        _player1.PlayerStatus = PlayerStatus.Won;
                        _player2.PlayerStatus = PlayerStatus.Lost;
                        _board.DisplayBoard();
                       break;
                    }
                    
                    var move2 = _player2.PlayTurn();
                    _board.PlaceSymbolToCoordinates(_player2.Symbol, move2);
                    _iio.Output(_board.DisplayBoard());
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


        public bool HasPlayerWon(Player player, Move move)
        {
            return _winningMoves.HasWonHorizontallyCheckCoordinates(player.Symbol, move.XCoordinate) || _winningMoves
            .HasWonVerticallyCheckCoordinates(player.Symbol, move.YCoordinate)
             || _winningMoves
            .HasWonDiagonallyLeftToRightCheckCoordinates(player.Symbol) || _winningMoves.HasWonDiagonallyRightToLeftCheckCoordinates(player.Symbol);
        }
    }
    
}