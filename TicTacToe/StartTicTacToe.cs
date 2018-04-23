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
        public static char Player = '1';
        public static char Letter = 'X';

        public static string CurrentBoard = "...\n" +
                           "...\n" +
                           "...";


        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe! \nHere's the current board:\n" + DisplayCurrentBoard(CurrentBoard));

            Game game = new Game();

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
            while (!game.GameEnded(CurrentBoard, Letter));

            Console.ReadLine();
        }

        public static void GetPlayerCoord(string input)
        {
            do
            {
                if (!InputAValidCoord(input))
                {
                    Console.WriteLine("Please enter a valid coordination. Row and Column must be both between 1 to 3.");
                    continue;
                }
                var coord = input.Split(',');
                var rowInput = int.Parse(coord[0]) - 1;
                var columnInput = int.Parse(coord[1]) - 1;

                PlayCurrentTurn(rowInput, columnInput);
            } while (false);
        }

        private static void PlayCurrentTurn(int rowInput, int columnInput)
        {
            Game game = new Game();
            do
            {
                if (!game.InputAValidMove(CurrentBoard, rowInput, columnInput))
                {
                    Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                    continue;
                }
                CurrentBoard = game.ChangeCurrentBoard(CurrentBoard, Letter, rowInput, columnInput);
                ReturnCurrentBoard();
            } while (false);
        }

        private static void ReturnCurrentBoard()
        {
            Game game = new Game();
            if (game.GameEnded(CurrentBoard, Letter))
            {
                Console.WriteLine("{0}", GameResult(CurrentBoard));
                Console.WriteLine(DisplayCurrentBoard(CurrentBoard));
                goto done;
            }
            Console.WriteLine("Move accepted, here's the current board: ");
            Console.WriteLine(DisplayCurrentBoard(CurrentBoard));
            GetNextPlayer(ref Player, ref Letter);
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

        public static string GameResult(string currentBoard)
        {
            if (!currentBoard.Contains('.'))
            {
                return "Game was a draw";
            }
            return "Move accepted, well done you've won the game!";
        }

    }
}
