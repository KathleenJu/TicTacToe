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
        CurrentBoard game = new CurrentBoard();
        string currentBoard = "..." + "\n" +
                              "..." + "\n" +
                              "...";
        [TestCase(
            "X.." + "\n" +
            "..." + "\n" +
            "...",

            'X',

            1, 1
            ),
        TestCase(
            "..." + "\n" +
            ".X." + "\n" +
            "...",

            'X',

            2, 2
            ),
         TestCase(
             "..." + "\n" +
             "..." + "\n" +
             "..X",

             'X',

             3, 3
         ),
         TestCase(
             ".O." + "\n" +
             "..." + "\n" +
             "...",

             'O',

             1, 2
         ), TestCase(
             "..." + "\n" +
             "..O" + "\n" +
             "...",

             'O',

             2, 3
         )]
        public void ReturnTheCorrectPositionOfInputIfMoveIsValid(string expectedBoard, char playerSymbol, int row, int column)
        {
            var actualBoard = game.ChangeCurrentBoard(currentBoard, playerSymbol, row - 1, column - 1);
            Assert.AreEqual(actualBoard, expectedBoard);
        }

        [TestCase(
            "XO." + "\n" +
            "XXX" + "\n" +
            ".OO",

             'X',

             true
            ),
        TestCase(
            "XOO" + "\n" +
            "OX." + "\n" +
            "OX.",

            'X',

            false
            ),
         TestCase(
             "XO." + "\n" +
             "XO." + "\n" +
             "XOX",

             'X',

             true
         ),
         TestCase(
             "XOX" + "\n" +
             ".O." + "\n" +
             ".OX",

             'O',

             true
         ), TestCase(
             "OXX" + "\n" +
             "XOO" + "\n" +
             "X.O",

             'O',

             true
         )]
        public void ReturnAwinnerOrDrawGame(string currentBoard, char playerSymbol, bool expectedResult)
        {
            var game = new EndGame();
            var actualResult = game.HasWinner(currentBoard, playerSymbol);
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
