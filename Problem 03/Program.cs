using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_03
{
    class Program
    {
        private static int _remainingCoals;
        private static int _collectedCoals;
        private static KeyValuePair<int, int> _startingPosition;
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var mine = new String[size, size];
            _remainingCoals = 0;
            _collectedCoals = 0;


            for (int i = 0; i < size; i++)
            {
                var currentRow = Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries).ToList();
                for (int j = 0; j < size; j++)
                {
                    mine[i, j] = currentRow[j];
                    if (currentRow[j].Equals("c"))
                    {
                        _remainingCoals++;
                    }

                    if (currentRow[j].Equals("s"))
                    {
                        _startingPosition = new KeyValuePair<int, int>(i, j);
                    }
                }
            }
            while (_remainingCoals > 0 && commands.Any())
            {
                var currentCommand = commands[0];
                commands.RemoveAt(0);
                switch (currentCommand)
                {
                    case "up": MoveUp(mine); break;
                    case "down": MoveDown(mine); break;
                    case "left": MoveLeft(mine); break;
                    case "right": MoveRight(mine); break;
                }
            }

            Console.WriteLine(_remainingCoals == 0
                ? $"You collected all coals! ({_startingPosition.Key}, {_startingPosition.Value})"
                : $"{_remainingCoals} coals left. ({_startingPosition.Key}, {_startingPosition.Value})");
        }

        private static void MoveUp(string[,] mine)
        {
            var row = _startingPosition.Key;
            var col = _startingPosition.Value;
            try
            {
                var current = mine[row - 1, col];
                mine[row, col] = "*";
                mine[row - 1, col] = "s";
                _startingPosition = new KeyValuePair<int, int>(row - 1, col);
                if (current.Equals("e"))
                {
                    GameOver();
                }
                if (!current.Equals("c")) return;
                _remainingCoals--;
                _collectedCoals++;

            }
            catch (Exception)
            {
                //ignored;
            }
        }

        private static void MoveDown(string[,] mine)
        {
            var row = _startingPosition.Key;
            var col = _startingPosition.Value;
            try
            {
                var current = mine[row + 1, col];
                mine[row, col] = "*";
                mine[row + 1, col] = "s";
                _startingPosition = new KeyValuePair<int, int>(row + 1, col);
                if (current.Equals("e"))
                {
                    GameOver();
                }
                if (!current.Equals("c")) return;
                _remainingCoals--;
                _collectedCoals++;

            }
            catch (Exception)
            {
                //ignored;
            }
        }

        private static void MoveLeft(string[,] mine)
        {
            var row = _startingPosition.Key;
            var col = _startingPosition.Value;
            try
            {
                var current = mine[row, col - 1];
                mine[row, col] = "*";
                mine[row, col - 1] = "s";
                _startingPosition = new KeyValuePair<int, int>(row, col - 1);
                if (current.Equals("e"))
                {
                    GameOver();
                }
                if (!current.Equals("c")) return;
                _remainingCoals--;
                _collectedCoals++;

            }
            catch (Exception)
            {
                //ignored;
            }
        }

        private static void MoveRight(string[,] mine)
        {
            var row = _startingPosition.Key;
            var col = _startingPosition.Value;
            try
            {
                var current = mine[row, col + 1];
                mine[row, col] = "*";
                mine[row, col + 1] = "s";
                _startingPosition = new KeyValuePair<int, int>(row, col + 1);
                if (current.Equals("e"))
                {
                    GameOver();
                }
                if (!current.Equals("c")) return;
                _remainingCoals--;
                _collectedCoals++;

            }
            catch (Exception)
            {
                //ignored;
            }
        }

        private static void GameOver()
        {
            Console.WriteLine($"Game over! ({_startingPosition.Key}, {_startingPosition.Value})");
            Environment.Exit(0);
        }
    }
}
