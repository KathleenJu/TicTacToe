using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeBoard
    {
        public List<List<Symbol>> GameBoard { get; set; }
        private int BoardHeight { get; }
        private int BoardWidth { get; }
        private Symbol Symbol { get; }

        public TicTacToeBoard(int boardHeight, int boardWidth, Symbol symbol)
        {
            GameBoard = new List<List<Symbol>>();
            BoardHeight = boardHeight;
            BoardWidth = boardWidth;
            Symbol = symbol;

            SetGameBoard();
        }

        public void SetGameBoard()
        {
            for (var i = 0; i < BoardHeight; i++)
            {
                List<Symbol> row = new List<Symbol>();
                for (var j = 0; j < BoardWidth; j++)
                {
                    row.Add(Symbol);
                }
                GameBoard.Add(row);
            }
        }
    }
}
