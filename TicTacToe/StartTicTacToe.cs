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
            Console.WriteLine("Welcome to Tic Tac Toe! \nHere's the current board:\n" + currentBoard);

            Game game = new Game();
            do
            {
                var currentPlayerCoord = GetPlayerCoord(player, letter);

                //separate this to a function (maybe in game class?)
                if (game.InputAValidMove(currentBoard, currentPlayerCoord[0], currentPlayerCoord[1]))
                {
                    currentBoard =
                        game.ChangeCurrentBoard(currentBoard, letter, currentPlayerCoord[0], currentPlayerCoord[1]);
                    Console.WriteLine("Move accepted, here's the current board: ");
                    Console.WriteLine(currentBoard);
                    GetNextPlayer(ref player, ref letter);
                }
                else
                {
                    Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                }

            }
            while (!GameWon());
            //should check if won or ended or quit before going to next player

            Console.WriteLine("you won {0}", player);
            Console.ReadLine();
        }

        public static bool InputAValidCoord(string input)
        {
            return input != null && Regex.IsMatch(input, "[1-3],[1-3]");
        }

        public static int[] GetPlayerCoord(char player, char letter)
        {
            int rowInput = 0;
            int columnInput = 0;
            var validCoord = false;
            do
            {
                Console.Write("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", player, letter);

                var input = Console.ReadLine();
                if (InputAValidCoord(input))
                {
                    var coord = input.Split(',');
                    rowInput = int.Parse(coord[0]) - 1;
                    columnInput = int.Parse(coord[1]) - 1;
                    validCoord = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid coordination. Row and Column must be both between 1 to 3.");

                }
            } while (!validCoord);

            return new int[] { rowInput, columnInput };
        }
        public static void GetNextPlayer(ref char player, ref char letter)
        {
            player = player == '1' ? player = '2' : player = '1';
            letter = letter == 'X' ? letter = 'O' : letter = 'X';
        }

        public static bool GameWon()
        {
            return false;
        }

    }
}
