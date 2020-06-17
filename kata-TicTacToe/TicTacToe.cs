using System.Collections.Generic;

namespace kata_TicTacToe
{
    public class TicTacToe
    {
        private readonly IInputOutput _iio;
        // private readonly WinningMove _winningMove;
        private readonly Board _board;
        private readonly Player _player1;
        private readonly Player _player2;


        public TicTacToe(Board board, Player player1, Player player2, IInputOutput iio)
        {
            _board = board;
            _player1 = player1;
            _player2 = player2;
            _iio = iio;
           // _winningMove = new WinningMove(board);
        }

       
        // public void PlayGame()
        // {
        //     while (_player1.PlayerStatus == PlayerStatus.Playing && _player2.PlayerStatus == PlayerStatus.Playing)
        //     { 
        //         _iio.Output(_board.DisplayBoard());
        //         
        //         _iio.Output("Player 1");
        //         var move = _player1.PlayTurn();
        //         
        //         
        //         if(MoveValidator.IsValidMove(move, _board))
        //         {
        //             _board.PlaceSymbolToCoordinates(_player1.Symbol, move);
        //             _iio.Output(_board.DisplayBoard());
        //         }
        //         
        //         if (HasPlayerWon(_player1, move))
        //         {
        //             ChangePlayerStatus(_player1);
        //             _board.DisplayBoard();
        //             break;
        //         }
        //         CheckDraw();
        //             
        //         //check if player 1 won or lose or draw (if not then execute the line below)
        //
        //         if (_player1.PlayerStatus != PlayerStatus.Playing) continue;
        //         
        //         _iio.Output("Player 2");
        //         var move2 = _player2.PlayTurn();
        //
        //         if (MoveValidator.IsValidMove(move2, _board))
        //         {
        //             _board.PlaceSymbolToCoordinates(_player2.Symbol, move2);
        //             _iio.Output(_board.DisplayBoard());
        //         }
        //
        //         if (HasPlayerWon(_player2, move))
        //         {
        //             ChangePlayerStatus(_player2);
        //             _board.DisplayBoard();
        //             break;
        //         }
        //         CheckDraw();
        //
        //     }
        // }
        
        public void PlayGame()
        {

            var isGameOver = false;
            _iio.Output(_board.DisplayBoard());
            
            while (!isGameOver)
            {
                _player1.Play(_board);
                _iio.Output(_board.DisplayBoard());
                CheckDraw();
                if (_player1.PlayerStatus == PlayerStatus.Playing)
                {
                    _player2.Play(_board);
                    _iio.Output(_board.DisplayBoard());
                    CheckDraw();
                }
                
                isGameOver =_player1.PlayerStatus != PlayerStatus.Playing || _player2.PlayerStatus != PlayerStatus
                    .Playing;
                
            }

        }
        
        


        private void ChangePlayerStatus(Player player)
        {

            if (player == _player1)
            {
                _player1.PlayerStatus = PlayerStatus.Won;
                _player2.PlayerStatus = PlayerStatus.Lost;
            }
            else
            {
                _player2.PlayerStatus = PlayerStatus.Won;
                _player1.PlayerStatus = PlayerStatus.Lost;
            }
            
        }

        private void CheckDraw()
        {
            if (!_board.HasDraw()) return;
            _player1.PlayerStatus = PlayerStatus.Drew;
            _player2.PlayerStatus = PlayerStatus.Drew;
        }
        
        // private bool HasPlayerWon(Player player, Move move)
        // {
        //     return _winningMove.HasWonHorizontallyCheckCoordinates(player.Symbol, move.XCoordinate) || _winningMove
        //     .HasWonVerticallyCheckCoordinates(player.Symbol, move.YCoordinate)
        //      || _winningMove
        //     .HasWonDiagonallyLeftToRightCheckCoordinates(player.Symbol) || _winningMove.HasWonDiagonallyRightToLeftCheckCoordinates(player.Symbol);
        // }
    }
    
}