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
             var turn = 0;
             _iio.Output(_board.DisplayBoard());
             while (true)
             {
                 turn++;
                 var currentPlayer = turn % 2 == 0 ? _player2 : _player1;
                 var move = currentPlayer.PlayTurn();
                 
                 while(!MoveValidator.IsValidMove(move, _board))
                 {
                     move = currentPlayer.PlayTurn();
                     
                 }
                 _board.PlaceSymbolToCoordinates(currentPlayer.Symbol, move);
                 _iio.Output(_board.DisplayBoard());

                 if (HasPlayerWon(currentPlayer, move))
                 {
                     ChangePlayerStatus(currentPlayer);
                     _iio.Output(_board.DisplayBoard());
                     break;
                 }

                 if (!_board.HasDraw()) continue;
                 _player1.PlayerStatus = PlayerStatus.Drew;
                 _player2.PlayerStatus = PlayerStatus.Drew;
                 break;
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

        private bool HasPlayerWon(Player player, Move move)
        {
            return _winningMove.HasWonHorizontallyCheckCoordinates(player.Symbol, move.XCoordinate) || _winningMove
            .HasWonVerticallyCheckCoordinates(player.Symbol, move.YCoordinate)
             || _winningMove.HasWonDiagonalLtr(player.Symbol) || _winningMove.HasWonDiagonalRtl(player.Symbol);
        }
    }
    
}
