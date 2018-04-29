using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TicTacToe
{
    public class GameBoard
    {
        private TicTacToeBoard _ticTacToeBoard;
        public List<List<Symbol>> CurrentGameBoard;

        public GameBoard()
        {
            _ticTacToeBoard = new TicTacToeBoard(3, 3, Symbol.Empty);
            CurrentGameBoard = _ticTacToeBoard.GameBoard;
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