using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class StartTicTacToe
    {
        private static char _player = '1';
        private static char _letter = 'X';
        public static int Row { get; set; } = 0;
        public static int Column { get; set; } = 0;

        private static string _currentBoard = "...\n" +
                           "...\n" +
                           "...";


        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe! \nHere's the current board:\n" + DisplayCurrentBoard(_currentBoard));

            do
            {
                Console.Write("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", _player,
                       _letter);
                var input = Console.ReadLine();
                if (input == "q")
                {
                    Console.WriteLine("Player " + _player + " gave up. End of game");
                    break;
                }
                GetPlayerCoord(input);
            }
            while (!CheckIfGameEnded());

            Console.ReadLine();
        }

        public static void GetPlayerCoord(string input)
        {
            do
            {
                if (InputAValidCoord(input))
                {
                    var coord = input.Split(',');
                    Row = int.Parse(coord[0]) - 1;
                    Column = int.Parse(coord[1]) - 1;
                    PlayCurrentTurn();
                    continue;
                }
                Console.WriteLine("Please enter a valid coordination. Row and Column must be both between 1 to 3.");
            } while (false);
        }

        private static void PlayCurrentTurn()
        {
            Game game = new Game();
            var newBoard = game.ChangeCurrentBoard(_currentBoard, _letter, Row, Column);
            do
            {
                if (_currentBoard != newBoard)
                {
                    _currentBoard = newBoard;
                    ReturnCurrentBoard();
                    continue;
                }
                Console.WriteLine("Oh no, a piece is already at this place! Try again...");
            } while (false);
        }

        private static void ReturnCurrentBoard()
        {
            if (!CheckIfGameEnded())
            {
                Console.WriteLine("Move accepted, here's the current board: ");
                Console.WriteLine(DisplayCurrentBoard(_currentBoard));
                GetNextPlayer(ref _player, ref _letter);
                goto done;
            }
            Console.WriteLine("{0}", GameResult());
            Console.WriteLine(DisplayCurrentBoard(_currentBoard));
            done:;
        }


        public static bool InputAValidCoord(string input)
        {
            return input != null && Regex.IsMatch(input, "^[1-3],[1-3]$");
        }

        public static void GetNextPlayer(ref char player, ref char letter)
        {
            player = player == '1' ? player = '2' : player = '1';
            letter = letter == 'X' ? letter = 'O' : letter = 'X';
        }

        public static string DisplayCurrentBoard(string currentBoard)
        {
            var newBoard = string.Empty;
            var arrayOfCurrentBoard = currentBoard.Split('\n');
            for (var row = 0; row < arrayOfCurrentBoard.Length; row++)
            {
                for (var column = 0; column < arrayOfCurrentBoard.Length; column++)
                {
                    newBoard += " " + arrayOfCurrentBoard[row][column] + " ";
                }
                newBoard += "\n";
            }
            return newBoard;
        }
        public static bool CheckIfGameEnded()
        {
            var checkEndOfGame = new EndGame();
            if (_currentBoard.Contains('.'))
            {
                return checkEndOfGame.HasWinner(_currentBoard, _letter);
            }
            return true;
        }

        public static string GameResult()
        {
            if (!_currentBoard.Contains('.'))
            {
                return "Game was a draw";
            }
            return "Move accepted, well done you've won the game!";
        }

    }
}
