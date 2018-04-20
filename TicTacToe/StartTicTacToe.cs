using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class StartTicTacToe
    {
        public char Player;
        public char Letter;

        public StartTicTacToe(char player, char letter)
        {
            this.Player = player;
            this.Letter = letter;
        }

        public static void Main(string[] args)
        {
            var currentBoard = "...\n" +
                               "...\n" +
                               "...";
            Console.WriteLine("Welcome to Tic Tac Toe! \nHere's the current board:\n" + currentBoard);

            StartTicTacToe game = new StartTicTacToe('1', 'X');

            do
            {
                currentBoard = game.GetPlayerCoord(currentBoard);
                game.NextPlayer();

            } while (!game.GameWon());
        }

        private void NextPlayer()
        {
            if (Player == '1')
            {
                Player = '2';
                Letter = 'O';
            }
            else
            {
                Player = '1';
                Letter = 'X';

            }
        }

        public string GetPlayerCoord(string currentBoard)
        {
            Console.Write("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", Player, Letter);

            var coord = Console.ReadLine()?.Split(',');
            var rowInput = int.Parse(coord[0]);
            var columnInput = int.Parse(coord[1]);

            Game game = new Game();
            var foo = game.ChangeCurrentBoard(currentBoard, Letter, rowInput, columnInput);
            return foo;
        }

        public bool GameWon()
        {
            return false;
        }

    }
}
