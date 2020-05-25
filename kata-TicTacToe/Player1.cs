namespace kata_TicTacToe
{
    public class Player1 : Player
    {
    public PlayerCounter PlayerCounter { get; private set; }
    
        public Player1()
        {
            PlayerCounter = PlayerCounter.Crosses;
        }

        public void MarkCross()
        {
            throw new System.NotImplementedException();
        }
    }
}