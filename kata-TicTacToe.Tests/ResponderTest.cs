namespace kata_TicTacToe.Tests
{
    public class ResponderTest : IInputOutput
    {
        public int XCoordinate;
        public int YCoordinate;
        public ResponderTest(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
        public string AskQuestion(string question)
        {
            throw new System.NotImplementedException();
        }
    }
}