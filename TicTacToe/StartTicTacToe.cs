using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class StartTicTacToe
    {
        public static void Main(string[] args)
        {
            var player = '1';
            var letter = 'X';
            var currentBoard = "...\n" +
                               "...\n" +
                               "...";
            Console.WriteLine("Welcome to Tic Tac Toe! \nHere's the current board:\n" + DisplayCurrentBoard(currentBoard));

            Game game = new Game();

            do
            {
                Console.Write("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", player,
                       letter);
                var input = Console.ReadLine();
                if (input == "q")
                {
                    Console.WriteLine("Player " + player + " gave up. End of game");
                    break;
                }
                else
                {
                    do
                    {
                        if (InputAValidCoord(input))
                        {
                            var coord = input.Split(',');
                            var rowInput = int.Parse(coord[0]) - 1;
                            var columnInput = int.Parse(coord[1]) - 1;
                            do
                            {
                                //var currentPlayerCoord = GetPlayerCoord1(input, player, letter);
                                if (game.InputAValidMove(currentBoard, rowInput, columnInput))
                                {
                                    currentBoard = game.ChangeCurrentBoard(currentBoard, letter, rowInput, columnInput);
                                    var gameEnded = game.GameEnded(currentBoard, letter);
                                    if (!gameEnded)
                                    {
                                        Console.WriteLine("Move accepted, here's the current board: ");
                                        Console.WriteLine(DisplayCurrentBoard(currentBoard));
                                        GetNextPlayer(ref player, ref letter);
                                    }
                                    else
                                    {
                                        Console.WriteLine("{0}", GameResult(gameEnded, currentBoard));
                                        Console.WriteLine(DisplayCurrentBoard(currentBoard));
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                                }
                            } while (false);
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid coordination. Row and Column must be both between 1 to 3.");
                        }
                    } while (false);
                }
            }
            while (!game.GameEnded(currentBoard, letter));

            Console.ReadLine();
        }

        //public static string PlayTurn(string input, string currentBoard, char player, char letter)
        //{
        //    Game game = new Game();
        //    var inputAValidMove = false;
        //    do
        //    {
        //        var currentPlayerCoord = GetPlayerCoord1(input, player, letter);
        //        if (game.InputAValidMove(currentBoard, currentPlayerCoord[0], currentPlayerCoord[1]))
        //        {
        //            currentBoard = game.ChangeCurrentBoard(currentBoard, letter, currentPlayerCoord[0],
        //                currentPlayerCoord[1]);
        //            inputAValidMove = true;
        //            return currentBoard;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Oh no, a piece is already at this place! Try again...");
        //        }
        //    } while (!inputAValidMove);

        //    return null;
        //}

        public static bool InputAValidCoord(string input)
        {
            return input != null && Regex.IsMatch(input, "[1-3],[1-3]");
        }

        //public static int[] GetPlayerCoord(char player, char letter)
        //{
        //    do
        //    {
        //        Console.Write("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", player, letter);

        //        var input = Console.ReadLine();
        //        if (InputAValidCoord(input))
        //        {
        //            var coord = input.Split(',');
        //            var rowInput = int.Parse(coord[0]) - 1;
        //            var columnInput = int.Parse(coord[1]) - 1;
        //            return new int[] { rowInput, columnInput };
        //        }
        //        else
        //        {
        //            Console.WriteLine("Please enter a valid coordination. Row and Column must be both between 1 to 3.");
        //        }
        //    } while (true);

        //    return new int[] { 0, 0 };
        //}
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

        public static string GameResult(bool hasAwinner, string currentBoard)
        {
            if (!currentBoard.Contains('.'))
            {
                return "Game was a draw";
            }
            return "Move accepted, well done you've won the game!";
        }

    }
}
