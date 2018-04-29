namespace TicTacToe
{
    public class InvalidMoveException : System.Exception
    {
        public InvalidMoveException(string message): base(message){ }
    }

    public class InvalidInputFormatException : System.Exception
    {
        public InvalidInputFormatException(string message): base(message){ }
    }

    public class EndOfGameException : System.Exception
    {
        public EndOfGameException(string message): base(message){ }
    }
}