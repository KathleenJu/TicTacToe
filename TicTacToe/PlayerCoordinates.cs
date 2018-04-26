using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
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
