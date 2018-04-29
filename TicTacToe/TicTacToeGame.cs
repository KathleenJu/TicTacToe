using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private static bool _gameOver = false;

        public GameBoard Board { get; }
        public Player PlayerOne { get; }
        public Player PlayerTwo { get; }
        public GameStatus GameStatus;

        public TicTacToeGame()
        {
            Board = new GameBoard();
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
            CheckGameStatus(currentPlayer);
            Console.WriteLine("Move accepted, here's the current board:\n" + Board.DisplayCurrentBoard());
        }

        private void AddPlayerInputToBoard(Player currentPlayer)
        {
            var validPosition = false;
            while (!validPosition)
            {
                var position = currentPlayer.GetPlayerInput();
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

        private void CheckGameStatus(Player currentPlayer)
        {
            GameStatus = new GameStatus(Board.CurrentGameBoard, currentPlayer.PlayerSymbol);
            _gameOver = GameStatus.HasWinner();

            if (_gameOver) DisplayGameResult();
        }

        private void DisplayGameResult()
        {
            if (!GameStatus.HasWinner())
            {
                if (GameStatus.IsADrawGame())
                {
                    Console.WriteLine("It's a draw game.");
                }
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