using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSP
{
    public class GraphColoringProblemSolver
    {
        private int?[,] Board { get; set; }
        private int N { get; set; }
        private List<int> _availbleValues;
        private Dictionary<int, HashSet<int>> _usedColors;
        private static bool Log = false;

        public GraphColoringProblemSolver(int n) {
            N = n;
            SetVariables();
            Board = new int?[N, N];
            _usedColors = new Dictionary<int, HashSet<int>>();
        }

        public string PrintedBoard()
        {
            return PrintedBoard(Board);
        }

        public void Run()
        {
            var result = Backtracking(Board);
            Console.WriteLine(result ? PrintedBoard() : "Brak rozwiazania");
        }

        public bool CheckBoard()
        {
            var check = Board != null;
            for (var i = 0; i < N && check; i++)
            {
                check = Board.GetRow(i).Count(x => x == null) == 0;
                for (var j = 0; j < N && check; j++)
                    check = CheckConstraints(null, i, j);
            }
            return check;
        }

        public bool CheckConstraints(HashSet<int> neighbors, int row, int col)
        {
            neighbors.Clear();
            CheckAndAddNearbear(neighbors, row + 1, col);
            CheckAndAddNearbear(neighbors, row - 1, col);
            CheckAndAddNearbear(neighbors, row, col + 1);
            CheckAndAddNearbear(neighbors, row, col - 1);
            
            var color = Board[row, col].Value;
            var check1 = !neighbors.Contains(color);
            //var check2 = !_usedColors[color].Any(x => !neighbors.Contains(x.Key) && x.Value.Any(y => neighbors.Contains(y)));
            var check2 = !_usedColors.ContainsKey(color) || !_usedColors[color].Any(neighbors.Contains);
            var check = check1 && check2;
            if (check)
                AddColorPair(row, col, neighbors);
            return check;
        }

        private void CheckAndAddNearbear(HashSet<int> set, int row, int col) {
            if (row >= 0 && row < N && col >= 0 && col < N && Board[row, col].HasValue)
                set.Add(Board[row, col].Value);
        }

        private string PrintedBoard(int?[,] board)
        {
            if (board == null) return "Brak rozwiazania...";

            var builder = new StringBuilder();
            var length = board.GetLength(1);
            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    builder.Append(board[i, j] == null ? "-" : board[i, j].ToString());
                    builder.Append("\t");
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        private void SetVariables() {
            int variablesCount = N % 2 == 0 ? 2 * N : 2 * N + 1;
            _availbleValues = Enumerable.Range(1, variablesCount).ToList();
        }

        private static bool ContainsNull(int?[] tab)
        {
            return tab.Any(x => x == null);
        }

        private bool Backtracking(int?[,] board)
        {
            var row = -1;
            var col = -1;

            if (!GetNextUnassigned(board, ref row, ref col))
                return true;

            HashSet<int> neighbors = new HashSet<int>();
            foreach (var value in _availbleValues)
            {
                board[row, col] = value;
                if (CheckConstraints(neighbors, row, col) && Backtracking(board))
                {
                    return true;
                }
            }
            RemoveColorPair(row, col, neighbors);
            board[row, col] = null;
            return false;
        }

        private void AddColorPair(int row, int col, HashSet<int> neighbors)
        {
            var color = Board[row, col];
            if (!_usedColors.ContainsKey(color.Value))
            {
                _usedColors.Add(color.Value, new HashSet<int>());
            }

            foreach (var neighbor in neighbors)
            {
                if (!_usedColors.ContainsKey(neighbor))
                {
                    _usedColors.Add(neighbor, new HashSet<int>());
                }

                _usedColors[color.Value].Add(neighbor);
                _usedColors[neighbor].Add(color.Value);
            }
        }

        private void RemoveColorPair(int row, int col, HashSet<int> neighbors)
        {
            var color = (int) Board[row, col];
            foreach (var neighbor in neighbors)
            {
                _usedColors[color].Remove(neighbor);
                _usedColors[neighbor].Remove(color);
            }
        }

        private bool GetNextUnassigned(int?[,] board, ref int row, ref int col)
        {
            var length = board.GetLength(1);
            for (var i = 0; i < length; i++)
                for (var j = 0; j < length; j++)
                    if (board[i, j] == null)
                    {
                        row = i;
                        col = j;
                        return true;
                    }
            return false;
        }
    }
}