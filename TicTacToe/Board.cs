using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TicTacToe
{
    public class Board
    {
        public TicTacToeBoard TicTacToeBoard;
        public List<List<Symbol>> CurrentGameBoard;

        public Board()
        {
            TicTacToeBoard = new TicTacToeBoard(3, 3, Symbol.Empty);
            CurrentGameBoard = TicTacToeBoard.GameBoard;
        }

        public bool PositionOnBoardIsEmpty(Coordinates coordinates)
        {
            return CurrentGameBoard[coordinates.Row][coordinates.Column] == Symbol.Empty;
        }

        public void ChangeCurrentBoard(Coordinates coordinates, Symbol playerSymbol)
        {
                CurrentGameBoard[coordinates.Row][coordinates.Column] = playerSymbol;
        }

        public string DisplayCurrentBoard()
        {
            var displayBoard = String.Empty;
            foreach (var row in CurrentGameBoard)
            {
                foreach (var value in row)
                {
                    displayBoard += " " + (char)value + " ";
                }
                displayBoard += Environment.NewLine;
            }
            return displayBoard;
        }
        
    }
}