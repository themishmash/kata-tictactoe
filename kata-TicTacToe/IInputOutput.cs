namespace kata_TicTacToe
{
    public interface IInputOutput
    {
        (int x, int y) AskQuestion(string answer);
        
        void Output(string message);

    }
}