namespace kata_TicTacToe
{
    public abstract class Player
    {
        private readonly Board _board;
        public GameStatus GameStatus { get; set; }
       
        protected Player()
        {
            GameStatus = GameStatus.Playing;
        }
        
        

        
    }
}