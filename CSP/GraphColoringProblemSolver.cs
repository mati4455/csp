using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSP
{
    public class GraphColoringProblemSolver
    {
        private int?[,] Board { get; set; }
        private int N { get; set; }
        private List<int> _availbleValues;
        private HashSet<Point> _usedColors;

        public GraphColoringProblemSolver(int n) {
            N = n;
            SetVariables();
            Board = new int?[N, N];
        }

        public string PrintedBoard()
        {
            return PrintedBoard(Board);
        }

        public void Run(bool backtracking)
        {
            var result = backtracking 
                ? Backtracking(Board) 
                : ForwardChecking(Board);
            Console.WriteLine(result ? PrintedBoard() : "Brak rozwiazania");
        }
        
        public bool CheckConstraints(HashSet<int> neighbors, int row, int col, int color)
        {
            neighbors.Clear();
            CheckAndAddNearbear(neighbors, row - 1, col);
            CheckAndAddNearbear(neighbors, row, col - 1);
            
            //var color = Board[row, col].Value;
            var neighbor = !neighbors.Contains(color);
            var harmony = !neighbors.Any(x => _usedColors.Contains(new Point(color, x)) || _usedColors.Contains(new Point(x, color)));
            var check = neighbor && harmony;

            /*if (check)
                AddColorPair(row, col, neighbors);*/
            return check;
        }

        private void CheckAndAddNearbear(HashSet<int> set, int row, int col) {
            if (row >= 0 && col >= 0 && Board[row, col].HasValue)
                set.Add(Board[row, col].Value);
        }
        
        private bool Backtracking(int?[,] board)
        {
            int row = -1,
                col = -1;

            if (!GetNextUnassigned(board, ref row, ref col))
                return true;

            var neighbors = new HashSet<int>();
            foreach (var value in _availbleValues)
            {
                if (CheckConstraints(neighbors, row, col, value))
                {
                    board[row, col] = value;
                    AddColorPair(row, col, neighbors);

                    if (Backtracking(board))
                        return true;

                    RemoveColorPair(row, col, neighbors);
                    board[row, col] = null;
                }
            }
            return false;
        }


        private bool ForwardChecking(int?[,] board)
        {
            var row = -1;
            var col = -1;

            if (!GetNextUnassigned(board, ref row, ref col))
                return true;

            var newDomain = new List<int>();
            var neighbors = new HashSet<int>();
            foreach (var value in _availbleValues)
            {
                if (CheckConstraints(neighbors, row, col, value))
                    newDomain.Add(value);
            }

            foreach (var value in newDomain)
            {
                if (CheckConstraints(neighbors, row, col, value)) { 
                    board[row, col] = value;
                    AddColorPair(row, col, neighbors);

                    if (ForwardChecking(board))
                        return true;

                    RemoveColorPair(row, col, neighbors);
                    board[row, col] = null;
                }
            }
            return false;
        }

        private void AddColorPair(int row, int col, HashSet<int> neighbors)
        {
            var color = Board[row, col].Value;
            foreach (var neighbor in neighbors)
                _usedColors.Add(new Point(color, neighbor));
        }

        private void RemoveColorPair(int row, int col, HashSet<int> neighbors)
        {
            var color = Board[row, col].Value;
            foreach (var neighbor in neighbors)
                _usedColors.Remove(new Point(color, neighbor));
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

        private void SetVariables()
        {
            int variablesCount = N % 2 == 0 ? 2 * N : 2 * N + 1;
            _availbleValues = Enumerable.Range(1, variablesCount).ToList();

            _usedColors = new HashSet<Point>();
        }

        private static bool ContainsNull(int?[] tab)
        {
            return tab.Any(x => x == null);
        }
    }
}