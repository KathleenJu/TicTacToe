using System;
using System.Globalization;
using System.Linq;

namespace TicTacToe
{
    public class CurrentBoard
    {
        public string ChangeCurrentBoard(string currentBoard, char playerSymbol, int row, int column)
        {
            const char newLine = '\n';
            const char emptySpot = '.';
            var currentBoardLines = currentBoard.Split(newLine);
            if (currentBoardLines[row][column] == emptySpot)
            {
                return AddInputToCurrentBoard(currentBoard, playerSymbol, row, column);
            }
            return currentBoard;
        }

        private static string AddInputToCurrentBoard(string currentBoard, char playerSymbol, int rowInput, int columnInput)
        {
            const char newLine = '\n';
            var newBoard = string.Empty;
            var currentBoardLines = currentBoard.Split(newLine);
            for (var row = 0; row < currentBoardLines.Length; row++)
            {
                for (var column = 0; column < currentBoardLines.Length; column++)
                {
                    if (row == rowInput && column == columnInput)
                    {
                        newBoard += playerSymbol;
                    }
                    else
                    {
                        newBoard += currentBoardLines[row][column];
                    }
                }
                newBoard += newLine;
            }
            return newBoard.TrimEnd(newLine);
        }
    }
}