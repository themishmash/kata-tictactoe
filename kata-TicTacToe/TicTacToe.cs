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
        private GameStatus GameStatus { get; set; }


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
           // _iio.Output("Here's the current board:");
           _iio.Output(Messages.BoardMessage);

           //printCaption();
            //_iio.Output(MyRsc.CurrentBoard)
            
             _iio.Output(_board.DisplayBoard());
             while (true)
             {
                 currentPlayer = currentPlayer != _player1 ? _player1 : _player2;
                 if (currentPlayer != null)
                 {
                     var move = currentPlayer.PlayTurn();
                 
                     while(!MoveValidator.IsValidMove(move, _board))
                     {
                         _iio.Output(Messages.BoardPieceTakenMessage);
                         move = currentPlayer.PlayTurn();
                     }

                     _board.PlaceSymbolToCoordinates(currentPlayer.Symbol, move);
                     _iio.Output(Messages.MoveAcceptedMessage);
                     _iio.Output(_board.DisplayBoard());

                     if (HasPlayerWon(currentPlayer, move))
                     {
                         GameStatus = GameStatus.Won;
                         _iio.Output(Messages.WinMessage);
                         _iio.Output(_board.DisplayBoard());
                         return;
                     }
                 }

                 if (_board.IsFull())
                 {
                     _iio.Output(Messages.DrawMessage);
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
