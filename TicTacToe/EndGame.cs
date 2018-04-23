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
        public bool HasWinner(string currentBoard, char letter)
        {
            var arrayOfCurrentBoard = currentBoard.Split('\n');
            var winningLine = false;
            foreach (var line in _winningCoords)
            {
                winningLine = line.All(coord => letter == arrayOfCurrentBoard[coord.Row][coord.Column]);
                if (winningLine)
                {
                    break;
                }
            }
            return winningLine;
        }

        private readonly List<List<Coord>> _winningCoords = new List<List<Coord>>
        {
            new List<Coord>{ new Coord( 0, 0), new Coord( 0, 1), new Coord( 0, 2)},
            new List<Coord>{ new Coord( 1, 0), new Coord( 1, 1), new Coord( 1, 2)},
            new List<Coord>{ new Coord( 2, 0), new Coord( 2, 1), new Coord( 2, 2)},
            new List<Coord>{ new Coord( 0, 0), new Coord( 1, 0), new Coord( 2, 0)},
            new List<Coord>{ new Coord( 0, 1), new Coord( 1, 1), new Coord( 2, 1)},
            new List<Coord>{ new Coord( 0, 2), new Coord( 1, 2), new Coord( 2, 2)},
            new List<Coord>{ new Coord( 0, 0), new Coord( 1, 1), new Coord( 2, 2)},
            new List<Coord>{ new Coord( 2, 0), new Coord( 1, 1), new Coord( 0, 2)}
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