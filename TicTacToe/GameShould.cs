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
        Game game = new Game();
        string currentBoard = "..." +
                              "\n..." +
                              "\n...";
        [TestCase(
            "X.." +
            "\n..." +
            "\n...",
            'X',
            1, 1
            ),
        TestCase(
            "..." +
            "\n.X." +
            "\n...",
            'X',
            2, 2
            ),
         TestCase(
             "..." +
             "\n..." +
             "\n..X",
             'X',
             3, 3
         ),
         TestCase(
             ".O." +
             "\n..." +
             "\n...",
             'O',
             1, 2
         ), TestCase(
             "..." +
             "\n..O" +
             "\n...",
             'O',
             2, 3
         )]
        public void ReturnTheCorrectPositionOfInputIfMoveIsValid(string expectedBoard, char letter, int row, int column)
        {
            var actualBoard = game.ChangeCurrentBoard(currentBoard, letter, row - 1, column - 1);
            Assert.AreEqual(actualBoard, expectedBoard);
        }

        [TestCase(
            "X0." +
            "\nXXX" +
            "\n.00",
            'X',
             true
            ),
        TestCase(
            "XOO" +
            "\nOX." +
            "\nOX.",
            'X',
            false
            ),
         TestCase(
             "XO." +
             "\nXO." +
             "\nXOX",
             'X',
             true
         ),
         TestCase(
             "XOX\n" +
             ".O.\n" +
             ".OX",
             'O',
             true
         ), TestCase(
             "OXX" +
             "\nXOO" +
             "\nX.O",
             'O',
             true
         )]
        public void ReturnAwinnerOrDrawGame(string currentBoard, char letter, bool expectedResult)
        {
            var game = new EndGame();
            var actualResult = game.HasWinner(currentBoard, letter);
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
