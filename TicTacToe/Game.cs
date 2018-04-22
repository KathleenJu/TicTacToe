using System;
using System.Globalization;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        public bool InputAValidMove(string currentBoard, int row, int column)
        {
            var arrayOfCurrentBoard = currentBoard.Split('\n');
            return arrayOfCurrentBoard[row][column] == '.';
        }

        public string ChangeCurrentBoard(string currentBoard, char letter, int rowInput, int columnInput)
        {
            var newBoard = string.Empty;
            var arrayOfCurrentBoard = currentBoard.Split('\n');
            for (var row = 0; row < arrayOfCurrentBoard.Length; row++)
            {
                for (var column = 0; column < arrayOfCurrentBoard.Length; column++)
                {
                    if (row == rowInput && column == columnInput)
                    {
                        newBoard += letter;
                    }
                    else
                    {
                        newBoard += arrayOfCurrentBoard[row][column];
                    }
                }
                newBoard += "\n";
            }

            return ReturnCurrentBoard(newBoard.TrimEnd('\n'), letter);
        }

        
        public string ReturnCurrentBoard(string currentBoard, char letter)
        {
            var checkEndOfGame = new EndGame();
            var hasAWinner = checkEndOfGame.HasWinner(currentBoard, letter);
            if (currentBoard.Contains('.'))
            {
                return hasAWinner ? "Move accepted, well done you've won the game!\n" + ResetBoard(): currentBoard;
            }
            return "\nGame was a draw." + ResetBoard();
        }
        public string ResetBoard()
        {
            var resetBoard = "...\n" +
                               "...\n" +
                               "...";

            return resetBoard;
        }
    }
}