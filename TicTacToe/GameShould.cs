using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    class GameShould
    {
        Board board = new Board();

        [TestCase(
             " X  .  . " + "\r\n" +
             " .  .  . " + "\r\n" +
             " .  .  . " + "\r\n",

             Symbol.Cross,

             1, 1
         ),
         TestCase(
             " X  .  . " + "\r\n" +
             " .  O  . " + "\r\n" +
             " .  .  . " + "\r\n",

             Symbol.Naught,

             2, 2
         ),
         TestCase(
             " X  .  . " + "\r\n" +
             " .  O  . " + "\r\n" +
             " .  .  X " + "\r\n",

             Symbol.Cross,

             3, 3
         ),
         TestCase(
             " X  O  . " + "\r\n" +
             " .  O  . " + "\r\n" +
             " .  .  X " + "\r\n",

             Symbol.Naught,

             1, 2
         ), TestCase(
             " X  O  . " + "\r\n" +
             " .  O  X " + "\r\n" +
             " .  .  X " + "\r\n",

             Symbol.Cross,

             2, 3
         )]
        public void ReturnTheCorrectPositionOfInputIfMoveIsValid(string expectedBoard, Symbol playerSymbol, int row,
            int column)
        {
            var coordinates = new Coordinates(row - 1, column - 1);
            board.ChangeCurrentBoard(coordinates, playerSymbol);
            var actualBoard = board.DisplayCurrentBoard();
            Assert.AreEqual(actualBoard, expectedBoard);
        }
    }
}
