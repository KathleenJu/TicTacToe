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
    public class ConsoleGame
    {
        private static void Main(string[] args)
        {
            var game = new TicTacToeGame();
            game.StartGame();
        }
    }
}
