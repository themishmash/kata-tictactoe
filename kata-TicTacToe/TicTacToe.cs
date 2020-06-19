using System;

namespace kata_TicTacToe
{
    public class TicTacToe
    {
        private readonly IInputOutput _iio;
        private readonly WinningMove _winningMove;
        private readonly Board _board;
        private readonly Player _player1;
        private readonly Player _player2;
        public GameStatus GameStatus { get; private set; }


        public TicTacToe(Board board, Player player1, Player player2, IInputOutput iio)
        {
            _board = board??throw new ArgumentException(nameof(board));
            _player1 = player1??throw new ArgumentException(nameof(player1));
            _player2 = player2??throw new ArgumentException(nameof(player2));
            _iio = iio??throw new ArgumentException(nameof(iio));
            _winningMove = new WinningMove(board);
            GameStatus = GameStatus.Playing;
        }
        

        public void PlayGame()
        {
            Player currentPlayer = null;
            _iio.Output("Here's the current board:");
             _iio.Output(_board.DisplayBoard());
             while (true)
             {
                 currentPlayer = currentPlayer != _player1 ? _player1 : _player2;
                 var move = currentPlayer.PlayTurn();
                 
                 while(!MoveValidator.IsValidMove(move, _board))
                 {
                     _iio.Output("Oh no, a piece is already at this place! Try again...");
                     move = currentPlayer.PlayTurn();
                 }
                 _board.PlaceSymbolToCoordinates(currentPlayer.Symbol, move);
                 _iio.Output("Move accepted, here's the current board:");
                 _iio.Output(_board.DisplayBoard());

                 if (HasPlayerWon(currentPlayer, move))
                 {
                     GameStatus = GameStatus.Won;
                     _iio.Output("Move accepted, well done you've won the game!");
                     _iio.Output(_board.DisplayBoard());
                     return;
                 }

                 if (_board.IsFull())
                 {
                     _iio.Output("No winner today, there is a draw!");
                     GameStatus = GameStatus.Drew;
                     return;
                 }
             }
        }
        

        private bool HasPlayerWon(Player player, Move move)
        {
            return _winningMove.HasWonHorizontallyCheckCoordinates(player.Symbol, move.XCoordinate) || _winningMove.HasWonVerticallyCheckCoordinates(player.Symbol, move.YCoordinate) || _winningMove.HasWonDiagonalLtr(player.Symbol) || _winningMove.HasWonDiagonalRtl(player.Symbol);
        }
    }
    
}
