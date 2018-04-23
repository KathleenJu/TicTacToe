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
        public static char Letter { get; set; }
        public static int Row { get; set; }
        public static int Column { get; set; }

        public static string CurrentBoard { get; set; }


        public static void Main(string[] args)
        {
            Player = '1';
            Letter = 'X';
            CurrentBoard = "...\n" +
                           "...\n" +
                           "...";

            Console.WriteLine("Welcome to Tic Tac Toe! \nHere's the current board:\n" + DisplayCurrentBoard(CurrentBoard));

            do
            {
                Console.Write("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", Player,
                       Letter);
                var input = Console.ReadLine();
                if (input == "q")
                {
                    Console.WriteLine("Player " + Player + " gave up. End of game");
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
            CurrentBoard board = new CurrentBoard();
            var newBoard = board.ChangeCurrentBoard(CurrentBoard, Letter, Row, Column);
            do
            {
                if (CurrentBoard != newBoard)
                {
                    CurrentBoard = newBoard;
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
                Console.WriteLine(DisplayCurrentBoard(CurrentBoard));
                GetNextPlayer();
                goto done;
            }
            Console.WriteLine("{0}", GameResult());
            Console.WriteLine(DisplayCurrentBoard(CurrentBoard));
            done:;
        }


        public static bool InputAValidCoord(string input)
        {
            return input != null && Regex.IsMatch(input, "^[1-3],[1-3]$");
        }

        public static void GetNextPlayer()
        {
            Player = Player == '1' ? Player = '2' : Player = '1';
            Letter = Letter == 'X' ? Letter = 'O' : Letter = 'X';
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
            if (CurrentBoard.Contains('.'))
            {
                return checkEndOfGame.HasWinner(CurrentBoard, Letter);
            }
            return true;
        }

        public static string GameResult()
        {
            if (!CurrentBoard.Contains('.'))
            {
                return "Game was a draw";
            }
            return "Move accepted, well done you've won the game!";
        }

    }
}
