using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeBoard
    {
        public List<List<Symbol>> GameBoard { get; set; }
        private int _boardHeight { get; }
        private int _boardWidth { get; }
        private Symbol _symbol { get; }

        public TicTacToeBoard(int boardHeight, int boardWidth, Symbol symbol)
        {
            GameBoard = new List<List<Symbol>>();
            _boardHeight = boardHeight;
            _boardWidth = boardWidth;
            _symbol = symbol;

        }

    }
}