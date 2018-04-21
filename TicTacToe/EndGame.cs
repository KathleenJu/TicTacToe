namespace TicTacToe
{
    public class EndGame
    {
        public bool foo(string currentBoard, char letter)
        {
            string[] winningCombos =
            {
                letter + letter + letter + "......",
                "..." + letter + letter + letter + "...",
                "......" + letter + letter + letter,
                letter + ".." + letter + ".." + letter + "..",


            };
            return false;
        }

    }
}