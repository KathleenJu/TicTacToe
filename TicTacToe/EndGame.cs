using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToe
{
    public class EndGame
    {
        private readonly List<List<Symbol>> _gameBoard;
        private readonly Symbol _playerSymbol;

        public EndGame(List<List<Symbol>> currentBoard, Symbol playerSymbol)
        {
            _gameBoard = currentBoard;
            _playerSymbol = playerSymbol;
        }


        private List<List<Coordinates>> WinningCoords { get; } = new List<List<Coordinates>>
        {
            new List<Coordinates> {new Coordinates(0, 0), new Coordinates(0, 1), new Coordinates(0, 2)},
            new List<Coordinates> {new Coordinates(1, 0), new Coordinates(1, 1), new Coordinates(1, 2)},
            new List<Coordinates> {new Coordinates(2, 0), new Coordinates(2, 1), new Coordinates(2, 2)},
            new List<Coordinates> {new Coordinates(0, 0), new Coordinates(1, 0), new Coordinates(2, 0)},
            new List<Coordinates> {new Coordinates(0, 1), new Coordinates(1, 1), new Coordinates(2, 1)},
            new List<Coordinates> {new Coordinates(0, 2), new Coordinates(1, 2), new Coordinates(2, 2)},
            new List<Coordinates> {new Coordinates(0, 0), new Coordinates(1, 1), new Coordinates(2, 2)},
            new List<Coordinates> {new Coordinates(2, 0), new Coordinates(1, 1), new Coordinates(0, 2)}
        };

        public bool HasWinner()
        {
            foreach (var line in WinningCoords)
            {
                var isAWinningLine = line.All(coord => _gameBoard[coord.Row][coord.Column] == _playerSymbol);
                if (isAWinningLine)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsADrawGame()
        {
            if (!HasWinner())
            {
                foreach (var row in _gameBoard)
                {
                    var hasEmptyPosition = row.Contains(Symbol.Empty);
                    if (hasEmptyPosition) return false;
                }
                return true;
            }
            return false;
        }


    }
}