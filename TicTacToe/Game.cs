using System;

namespace TicTacToe
{
    public class Game
    {
        public string ChangeCurrentBoard(string currentBoard, char letter, int rowInput, int columnInput)
        {
            var newBoard = string.Empty;
            var arrayBoard = currentBoard.Split('\n');
            for (var row = 0; row < arrayBoard.Length; row++)
            {
                for (var column = 0; column < arrayBoard.Length; column++)
                {
                    if (row == rowInput - 1 && column == columnInput - 1)
                    {
                        newBoard = AddInputToBoard(arrayBoard, newBoard, letter, row, column);
                    }
                    else
                    {
                        newBoard += arrayBoard[row][column];
                    }
                }
                newBoard += "\n";
            }
            return newBoard.TrimEnd('\n');
        }

        public string AddInputToBoard(string[] arrayBoard, string newBoard, char letter, int row, int column)
        {
            if (InputAValidMove(arrayBoard, row, column))
            {
                Console.WriteLine("Move accepted, here's the current board: ");
                newBoard += letter;
            }
            else
            {
                Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                newBoard += arrayBoard[row][column];
            }

            return newBoard;
        }

        public bool InputAValidMove(string[] arrayBoard, int row, int column)
        {
            return arrayBoard[row][column] == '.';
        }

    }
}