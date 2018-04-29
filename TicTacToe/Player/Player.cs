using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        private static Coordinates Coordinates { get; set; }
        private Number PlayerNumber { get; set; }

        public Symbol PlayerSymbol { get; set; }

        public Player(Number playerNumber, Symbol playerSymbol)
        {
            PlayerNumber = playerNumber;
            PlayerSymbol = playerSymbol;
        }

        public Coordinates GetPlayerInput()
        {
            do
            {
                Console.Write("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ",
                    (int)PlayerNumber,
                    (char)PlayerSymbol);
                const string quitGame = "q";
                var input = Console.ReadLine();

                if (input == quitGame)
                {
                    Console.WriteLine("Player " + (int)PlayerNumber + " gave up. End of game");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                SetPlayerCoordinates(input);
            } while (Coordinates == null);

            return Coordinates;
        }

        private static void SetPlayerCoordinates(string input)
        {
            if (InputAValidCoord(input))
            {
                var coord = input.Split(',');
                var row = int.Parse(coord[0]) - 1;
                var column = int.Parse(coord[1]) - 1;
                Coordinates = new Coordinates(row, column);
            }
            else
            {
                Console.WriteLine("Please enter a valid coordination. Row and Column must be both between 1 to 3.");
                Coordinates = null;
            }
        }

        private static bool InputAValidCoord(string input)
        {
            return input != null && Regex.IsMatch(input, "^[1-3],[1-3]$");
        }
    }
}
