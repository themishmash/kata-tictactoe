namespace kata_TicTacToe
{
    public class Square
    {
        
        public int XCoordinate { get;}
        public int YCoordinate { get;}
        
        public Symbol Symbol { get; set; }

        public Square(int xCoordinate, int yCoordinate, Symbol symbol = Symbol.None)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Symbol = symbol;
        }

        public override string ToString()
        {
            switch(Symbol)
            {
                case(Symbol.Cross):
                    return " X ";
                case(Symbol.Naught):
                    return " O ";
                default:
                    return " . ";
            }
        }
    }
}