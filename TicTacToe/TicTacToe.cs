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
            CheckIfGameEnded(currentPlayer);
            Console.WriteLine("Move accepted, here's the current board:\n" + Board.DisplayCurrentBoard());
        }

        private void AddPlayerInputToBoard(Player currentPlayer)
        {
            var validPosition = false;
            while (!validPosition)
            {
                var position = currentPlayer.GetPlayerCoord();
                validPosition = Board.PositionOnBoardIsEmpty(position);
                if (validPosition)
                {
                    Board.ChangeCurrentBoard(position, currentPlayer.PlayerSymbol);
                }
                else
                {
                    Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                }
            }
        }
        public void CheckIfGameEnded(Player currentPlayer)
        {
            CheckEndGame = new EndGame(Board.CurrentGameBoard, currentPlayer.PlayerSymbol);
            _gameOver = CheckEndGame.HasWinner();

            if (_gameOver) DisplayGameResult();
        }

        public void DisplayGameResult()
        {
            if (!CheckEndGame.HasWinner())
            {
                    //checkfor draw
            }
            else
            {
                Console.WriteLine("Move accepted, well done you've won the game!");
            }
            Console.WriteLine(Board.DisplayCurrentBoard());
            Console.ReadLine();
            Environment.Exit(0);
        }
    }


}


}