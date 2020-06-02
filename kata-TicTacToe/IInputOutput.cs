namespace kata_TicTacToe
{
    public interface IInputOutput
    {
        public string AskQuestion(string question);

        public int[] ParseStringCoordinatesToInt(string number);
    }
}