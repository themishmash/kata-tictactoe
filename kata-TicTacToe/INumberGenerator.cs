namespace kata_TicTacToe
{
    public interface INumberGenerator
    {
        int GetXCoordinate(int minimum, int maximum);
        int GetYCoordinate(int minimum, int maximum);
        
    }
}