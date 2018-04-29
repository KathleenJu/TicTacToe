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
        GameBoard board = new GameBoard();

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

        private static object[] _winningGameBoard1 =
        {
            new List<List<Symbol>>(){
                new List<Symbol>(){Symbol.Cross, Symbol.Empty, Symbol.Empty},
                new List<Symbol>(){Symbol.Cross, Symbol.Empty, Symbol.Empty},
                new List<Symbol>(){Symbol.Cross, Symbol.Empty, Symbol.Empty}
            },
            new List<List<Symbol>>(){
                new List<Symbol>(){Symbol.Cross, Symbol.Empty, Symbol.Empty},
                new List<Symbol>(){Symbol.Naught, Symbol.Cross, Symbol.Empty},
                new List<Symbol>(){Symbol.Naught, Symbol.Empty, Symbol.Cross}
            },
            new List<List<Symbol>>(){
                new List<Symbol>(){Symbol.Naught, Symbol.Naught, Symbol.Empty},
                new List<Symbol>(){Symbol.Cross, Symbol.Cross, Symbol.Cross},
                new List<Symbol>(){Symbol.Cross, Symbol.Empty, Symbol.Empty}
            }
        };


        [Test, TestCaseSource(nameof(_winningGameBoard1))]
        public void ReturnAWinnerForCross(List<List<Symbol>> currentBoard)
        {
            Symbol playerSymbol = Symbol.Cross;
            GameStatus game = new GameStatus(currentBoard, playerSymbol);
            var actualResult = game.HasWinner();
            Assert.IsTrue(actualResult);

        }

        private static object[] _winningGameBoard2 =
        {
            new List<List<Symbol>>(){
                new List<Symbol>(){Symbol.Cross, Symbol.Empty, Symbol.Naught},
                new List<Symbol>(){Symbol.Naught, Symbol.Naught, Symbol.Empty},
                new List<Symbol>(){Symbol.Naught, Symbol.Empty, Symbol.Empty}
            },
            new List<List<Symbol>>(){
                new List<Symbol>(){Symbol.Cross, Symbol.Empty, Symbol.Naught},
                new List<Symbol>(){Symbol.Naught, Symbol.Cross, Symbol.Naught},
                new List<Symbol>(){Symbol.Naught, Symbol.Empty, Symbol.Naught}
            },
            new List<List<Symbol>>(){
                new List<Symbol>(){Symbol.Naught, Symbol.Naught, Symbol.Empty},
                new List<Symbol>(){Symbol.Cross, Symbol.Empty, Symbol.Cross},
                new List<Symbol>(){Symbol.Naught, Symbol.Naught, Symbol.Naught}
            }
        };

        [Test, TestCaseSource(nameof(_winningGameBoard2))]
        public void ReturnAWinnerForNaught(List<List<Symbol>> currentBoard)
        {
            Symbol playerSymbol = Symbol.Naught;
            GameStatus game = new GameStatus(currentBoard, playerSymbol);
            var actualResult = game.HasWinner();
            Assert.IsTrue(actualResult);

        }

        private static object[] _losingGameBoard =
        {
            new List<List<Symbol>>(){
                new List<Symbol>(){Symbol.Cross, Symbol.Empty, Symbol.Naught},
                new List<Symbol>(){Symbol.Naught, Symbol.Cross, Symbol.Empty},
                new List<Symbol>(){Symbol.Naught, Symbol.Empty, Symbol.Empty}
            },
            new List<List<Symbol>>(){
                new List<Symbol>(){Symbol.Cross, Symbol.Empty, Symbol.Naught},
                new List<Symbol>(){Symbol.Naught, Symbol.Cross, Symbol.Empty},
                new List<Symbol>(){Symbol.Naught, Symbol.Empty, Symbol.Naught}
            },
            new List<List<Symbol>>(){
                new List<Symbol>(){Symbol.Naught, Symbol.Naught, Symbol.Empty},
                new List<Symbol>(){Symbol.Cross, Symbol.Empty, Symbol.Cross},
                new List<Symbol>(){Symbol.Naught, Symbol.Cross, Symbol.Naught}
            }
        };

        [Test, TestCaseSource(nameof(_losingGameBoard))]
        public void ReturnNoWinner(List<List<Symbol>> currentBoard)
        {
            Symbol playerSymbol = Symbol.Naught;
            GameStatus game = new GameStatus(currentBoard, playerSymbol);
            var actualResult = game.HasWinner();
            Assert.IsFalse(actualResult);

        }
        private static object[] _drawGameBoard =
        {
            new List<List<Symbol>>(){
                new List<Symbol>(){Symbol.Cross, Symbol.Naught, Symbol.Cross},
                new List<Symbol>(){Symbol.Naught, Symbol.Naught, Symbol.Cross},
                new List<Symbol>(){Symbol.Cross, Symbol.Cross, Symbol.Naught}
            },
            new List<List<Symbol>>(){
                new List<Symbol>(){Symbol.Cross, Symbol.Naught, Symbol.Naught},
                new List<Symbol>(){Symbol.Naught, Symbol.Cross, Symbol.Cross},
                new List<Symbol>(){Symbol.Naught, Symbol.Cross, Symbol.Naught}
            },
            new List<List<Symbol>>(){
                new List<Symbol>(){Symbol.Naught, Symbol.Naught, Symbol.Cross},
                new List<Symbol>(){Symbol.Cross, Symbol.Naught, Symbol.Cross},
                new List<Symbol>(){Symbol.Naught, Symbol.Cross, Symbol.Naught}
            }
        };


        [Test, TestCaseSource(nameof(_drawGameBoard))]
        public void ReturnADrawGame(List<List<Symbol>> currentBoard)
        {
            Symbol playerSymbol = Symbol.Cross;
            GameStatus game = new GameStatus(currentBoard, playerSymbol);
            var actualResult = game.IsADrawGame();
            Assert.IsTrue(actualResult);

        }
    }
}
