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
    public class Game
    {
        public static char Player { get; set; }
        public static char PlayerSymbol { get; set; }
        public static int Row { get; set; }
        public static int Column { get; set; }

        public static string CurrentBoard { get; set; }


        public static void Main(string[] args)
        {
            Player = '1';
            PlayerSymbol = 'X';
            CurrentBoard = "..." + "\n" +
                           "..." + "\n" +
                           "...";

            Console.WriteLine("Welcome to Tic Tac Toe! \nHere's the current board:\n" + DisplayCurrentBoard(CurrentBoard));

            do
            {
                const string quitGame = "q";
                Console.Write("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", Player,
                       PlayerSymbol);
                var input = Console.ReadLine();
                if (input == quitGame)
                {
                    Console.WriteLine("Player " + Player + " gave up. End of game");
                    break;
                }
                GetPlayerCoord(input);
            }
            while (!HasGameEnded());

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
                }
                else
                {
                    Console.WriteLine("Please enter a valid coordination. Row and Column must be both between 1 to 3.");
                }
            } while (false);
        }

        private static void PlayCurrentTurn()
        {
            CurrentBoard board = new CurrentBoard();
            var newBoard = board.ChangeCurrentBoard(CurrentBoard, PlayerSymbol, Row, Column);
            do
            {
                if (CurrentBoard != newBoard)
                {
                    CurrentBoard = newBoard;
                    ReturnCurrentBoard();
                }
                else
                {
                    Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                }
            } while (false);
        }

        private static void ReturnCurrentBoard()
        {
            if (!HasGameEnded())
            {
                Console.WriteLine("Move accepted, here's the current board: ");
                Console.WriteLine(DisplayCurrentBoard(CurrentBoard));
                GetNextPlayer();
            }
            else
            {
                Console.WriteLine("{0}", GameResult());
                Console.WriteLine(DisplayCurrentBoard(CurrentBoard));
            }
        }

        public static bool InputAValidCoord(string input)
        {
            return input != null && Regex.IsMatch(input, "^[1-3],[1-3]$");
        }

        public static void GetNextPlayer()
        {
            Player = Player == '1' ? Player = '2' : Player = '1';
            PlayerSymbol = PlayerSymbol == 'X' ? PlayerSymbol = 'O' : PlayerSymbol = 'X';
        }

        public static string DisplayCurrentBoard(string currentBoard)
        {
            const char newLine = '\n';
            var newBoard = string.Empty;
            var currentBoardLines = currentBoard.Split(newLine);
            for (var row = 0; row < currentBoardLines.Length; row++)
            {
                for (var column = 0; column < currentBoardLines.Length; column++)
                {
                    newBoard += " " + currentBoardLines[row][column] + " ";
                }
                newBoard += newLine;
            }
            return newBoard;
        }
        public static bool HasGameEnded()
        {
            const char emptySpot = '.';
            var checkEndOfGame = new EndGame();
            if (CurrentBoard.Contains(emptySpot))
            {
                return checkEndOfGame.HasWinner(CurrentBoard, PlayerSymbol);
            }
            return true;
        }

        public static string GameResult()
        {
            const char emptySpot = '.';
            if (!CurrentBoard.Contains(emptySpot))
            {
                return "Game was a draw";
            }
            return "Move accepted, well done you've won the game!";
        }

    }
}
