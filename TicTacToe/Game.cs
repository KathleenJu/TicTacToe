﻿using System;

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
    }
}