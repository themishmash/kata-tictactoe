namespace kata_TicTacToe
{
    public class Player
    {
        private readonly IInputOutput _iio;
        private readonly WinningMove _winningMove;
        public Symbol Symbol { get; private set; }
        public PlayerStatus PlayerStatus { get; set; }


        public Player(IInputOutput iio, Symbol symbol, WinningMove winningMove)
        {
            _iio = iio;
            _winningMove = winningMove;
            Symbol = symbol;
            PlayerStatus = PlayerStatus.Playing;
        }

        public Move GetCoordinates()
        {
            var(x,y) = _iio.AskQuestion("Please enter a coordinate x,y to place your symbol or enter 'q' to give up");
            var move = new Move(x, y);
            return move;
        }

        public void Play(Board board)
        {
            var move = GetCoordinates();
            if (MoveValidator.IsValidMove(move, board))
            {
                board.PlaceSymbolToCoordinates(Symbol, move);
                _iio.Output(board.DisplayBoard());
            }
            
            if (HasPlayerWon(move))
            { 
                PlayerStatus = PlayerStatus.Won;
               board.DisplayBoard();
            }

        }
        
        private bool HasPlayerWon(Move move)
        {
            return _winningMove.HasWonHorizontallyCheckCoordinates(Symbol, move.XCoordinate) || _winningMove
                                                                                                        .HasWonVerticallyCheckCoordinates(Symbol, move.YCoordinate)
                                                                                                    || _winningMove
                                                                                                        .HasWonDiagonallyLeftToRightCheckCoordinates(Symbol) || _winningMove.HasWonDiagonallyRightToLeftCheckCoordinates(Symbol);
        }
        
      
    }
}