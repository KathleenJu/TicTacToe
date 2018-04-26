using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToe
{
    public class EndGame
    {
        public bool HasWinner(string currentBoard, char playerSymbol)
        {
            const char newLine = '\n';
            var currentBoardLines = currentBoard.Split(newLine);
            foreach (var line in WinningCoords)
            {
                var isAWinningLine = line.All(coord => playerSymbol == currentBoardLines[coord.Row][coord.Column]);
                if (isAWinningLine)
                {
                    return true;
                }
            }
            return false;
        }

        public List<List<Coord>> WinningCoords { get; } = new List<List<Coord>>
        {
            new List<Coord> {new Coord(0, 0), new Coord(0, 1), new Coord(0, 2)},
            new List<Coord> {new Coord(1, 0), new Coord(1, 1), new Coord(1, 2)},
            new List<Coord> {new Coord(2, 0), new Coord(2, 1), new Coord(2, 2)},
            new List<Coord> {new Coord(0, 0), new Coord(1, 0), new Coord(2, 0)},
            new List<Coord> {new Coord(0, 1), new Coord(1, 1), new Coord(2, 1)},
            new List<Coord> {new Coord(0, 2), new Coord(1, 2), new Coord(2, 2)},
            new List<Coord> {new Coord(0, 0), new Coord(1, 1), new Coord(2, 2)},
            new List<Coord> {new Coord(2, 0), new Coord(1, 1), new Coord(0, 2)}
        };

        public class Coord
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public Coord(int row, int column)
            {
                Row = row;
                Column = column;
            }
        }
    }
}