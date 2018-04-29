using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class TicTacToe
    {
        private static bool _gameOver = false;

        public Board Board { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public EndGame CheckEndGame { get; set; }

        public TicTacToe()
        {
            Board = new Board();
            PlayerOne = new Player(Number.One, Symbol.Cross);
            PlayerTwo = new Player(Number.Two, Symbol.Naught);
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Tic Tac Toe! \nHere's the current board:\n" + Board.DisplayCurrentBoard());

            while (!_gameOver)
            {
                PlayTurn(PlayerOne);
                PlayTurn(PlayerTwo);
            }
            Console.ReadLine();
        }

        private void PlayTurn(Player currentPlayer)
        {
            AddPlayerInputToBoard(currentPlayer);
            Console.WriteLine("Move accepted, here's the current board:\n" + Board.DisplayCurrentBoard());
        }

        private void AddPlayerInputToBoard(Player currentPlayer)
        {
           
        }


    }


}