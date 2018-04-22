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

            return newBoard.TrimEnd('\n');
        }


        public string ReturnCurrentBoard(string currentBoard, char letter)
        {
            var checkEndOfGame = new EndGame();
            var hasAWinner = checkEndOfGame.HasWinner(currentBoard, letter);
            if (currentBoard.Contains('.'))
            {
                return hasAWinner ? "Move accepted, well done you've won the game!\n" + currentBoard : currentBoard;
            }

            return "\nGame was a draw." + currentBoard;
        }
        public bool GameEnded(string currentBoard, char letter)
        {
            var checkEndOfGame = new EndGame();
            var hasAWinner = checkEndOfGame.HasWinner(currentBoard, letter);
            if (currentBoard.Contains('.'))
            {
                return hasAWinner;
            }
            return true;
        }

        public bool foo(string currentBoard)
        {
            if (!currentBoard.Contains('.'))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}