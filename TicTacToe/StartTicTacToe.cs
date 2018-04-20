using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
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
            
            var newBoard = currentBoard;
            do
            {
                var currentPlayer = GetPlayerCoord(player, letter);
                currentBoard =
                        game.ChangeCurrentBoard(currentBoard, letter, currentPlayer[0], currentPlayer[1]);
                //separate this to a function (maybe in game class?)
                if (currentBoard != newBoard)
                {
                    Console.WriteLine("Move accepted, here's the current board: ");
                    Console.WriteLine(currentBoard);
                    GetNextPlayer(ref player, ref letter);
                }
                else
                {
                    Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                }
                newBoard = currentBoard;
            }
            while (!GameWon());
            //should check if won or ended or quit before going to next player
            
            Console.WriteLine("you won {0}", player);
            Console.ReadLine();
        }

        public static void GetNextPlayer(ref char player, ref char letter)
        {
            player = player == '1' ? player = '2' : player = '1';
            letter = letter == 'X' ? letter = 'O' : letter = 'X';
        }

        public static int[] GetPlayerCoord(char player, char letter)
        {
            Console.Write("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", player, letter);
            var coord = Console.ReadLine()?.Split(',');
            var rowInput = int.Parse(coord[0]);
            var columnInput = int.Parse(coord[1]);

            return new int[] { rowInput, columnInput };
        }

        public static bool GameWon()
        {
            return false;
        }

    }
}
