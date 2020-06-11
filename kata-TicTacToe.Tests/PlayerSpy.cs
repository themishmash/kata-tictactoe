namespace kata_TicTacToe.Tests
{
    public class PlayerSpy : Player
    {
        
        private readonly PlayerInput _playerInput;

        private PlayerSpy(IInputOutput iio, Symbol symbol) : base(iio, symbol)
        {

            _playerInput = (PlayerInput) iio;
        }

        // public override Move PlayTurn()
        // {
        //     
        // }

        public static PlayerSpy CreateWinningHorizontalPlayer()
        {
            return new PlayerSpy(new PlayerInput((1,1),(2,1),(3,1) ),Symbol.Cross);
        }
    }
}