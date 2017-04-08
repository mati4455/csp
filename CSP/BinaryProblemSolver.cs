using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSP
{
    public class BinaryProblemSolver
    {
        private bool?[,] Board { get; set; }
        private int N { get; set; }
        private int M { get; set; }
        private bool _heurestic;
        private readonly List<bool> _avaibleValues = new List<bool> {true, false};
        private static bool Log = false;
        
        private const int MaxRepeat = 2;
        
        public void LoadBoard(bool?[,] board)
        {
            Board = (bool?[,]) board.Clone();
            N = board.GetLength(1);
        }

        public void GenerateBoard(int n, int m, bool useDefaultBoards)
        {
            N = n;
            M = Math.Min(m, N*N);

            if (useDefaultBoards)
            {
                LoadBoard(BinaryData.GetSet(n));
            }
            else
            {
                Board = new bool?[N, N];

                for (var i = 0; i < N; i++)
                for (var j = 0; j < N; j++)
                    Board[i, j] = null;

                Run(true, true);
            }

            var rand = new Random();
            var added = 0;
            var toRemove = N*N - M;
            while (added < toRemove)
            {
                var x = rand.Next(0, N);
                var y = rand.Next(0, N);

                if (Board[x, y] != null)
                {
                    Board[x, y] = null;
                    added++;
                }
            }
        }
        
        public string PrintedBoard()
        {
            return PrintedBoard(Board);
        }

        private string PrintedBoard(bool?[,] board)
        {
            if (board == null) return "Brak rozwiazania...";

            var builder = new StringBuilder();
            var length = board.GetLength(1);
            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    builder.Append(board[i, j] == null ? "-" : board[i, j] == true ? "1" : "0");
                    builder.Append(" ");
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        public bool CheckBoard()
        {
            return CheckBoard(Board);
        }
        
        public Statistic Run(bool backtracking, bool heurestic)
        {
            _heurestic = heurestic;

            var watch = System.Diagnostics.Stopwatch.StartNew();

            var result = backtracking 
                ? Backtracking(Board)
                : ForwardChecking(Board);
            Console.WriteLine(result ? PrintedBoard() : "Brak rozwiazania");

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Algorytm zakonczyl obliczenia w czasie: {elapsedMs}ms");

            return new Statistic
            {
                Duration = elapsedMs,
                ReturnCount = 0
            };
        }

        public bool?[,] GetCopyBoard()
        {
            return (bool?[,]) Board.Clone();
        }

        public bool CheckBoard(bool?[,] board)
        {
            var check = board != null;
            for (var i = 0; i < N && check; i++)
            {
                check = board.GetRow(i).Count(x => x == null) == 0;
                for (var j = 0; j < N && check; j++)
                    check = CheckConstraints(board, i, j);
            }
            return check;
        }

        public static bool CheckConstraints(bool?[,] board, int row, int col)
        {
            var rowValue = board.GetRow(row);
            var colValue = board.GetCol(col);
            var n = rowValue.Length;
            var half = n / 2;
            
            // liczba 0 i 1 w wierszu ma być taka sama
            var zerosRowCount = rowValue.Count(x => x == false);
            var onesRowCount = rowValue.Count(x => x == true);
            if (zerosRowCount > half || onesRowCount > half)
                return false;

            // liczba 0 i 1 w kolumnie ma być taka sama
            var zerosColCount = colValue.Count(x => x == false);
            var onesColCount = colValue.Count(x => x == true);
            if (zerosColCount > half || onesColCount > half)
                return false;

            // symbol nie może powtarzać się dwa razy pod rząd
            var validRow = CheckRepeat(rowValue);
            if (!validRow)
                return false;

            var validCol = CheckRepeat(colValue);
            if (!validCol)
                return false;

            var isNullInRow = ContainsNull(rowValue);
            var isNullInCol = ContainsNull(colValue);

            // sprawdzenie unikalności kolumn i wierwszy
            for (var i = 0; i < n; i++)
            {
                var currRow = board.GetRow(i);
                if (!isNullInRow && i != row && rowValue.SequenceEqual(currRow))
                    return false;

                var currCol = board.GetCol(i);
                if (!isNullInCol && i != col && !ContainsNull(currCol) && colValue.SequenceEqual(currCol))
                    return false;
            }
            
            return true;
        }

        private static bool ContainsNull(bool?[] tab)
        {
            return tab.Any(x => x == null);
        }

        private static bool CheckRepeat(bool?[] data)
        {
            var currentSign = data[0];
            var repeatCount = 0;
            for (var i = 1; i < data.Length; i++)
            {
                if (data[i] == currentSign && currentSign != null)
                {
                    repeatCount++;

                    if (repeatCount >= MaxRepeat)
                        return false;
                }
                else
                {
                    repeatCount = 0;
                    currentSign = data[i];
                }
            }
            return true;
        }

        private bool Backtracking(bool?[,] board)
        {
            var row = -1;
            var col = -1;

            if (_heurestic && !GetNextUnassignedHeurestic(board, ref row, ref col))
                return true;

            if (!_heurestic && !GetNextUnassignedBasic(board, ref row, ref col))
                return true;

            foreach (var value in _avaibleValues)
            {
                board[row, col] = value;
                if (CheckConstraints(board, row, col) && Backtracking(board))
                    return true;
            }
            board[row, col] = null;
            return false;
        }

        private bool ForwardChecking(bool?[,] board)
        {
            var row = -1;
            var col = -1;

            if (_heurestic && !GetNextUnassignedHeurestic(board, ref row, ref col))
                return true;

            if (!_heurestic && !GetNextUnassignedBasic(board, ref row, ref col))
                return true;

            var newDomain = new List<bool>();
            if (_heurestic)
            {
                foreach (var value in _avaibleValues)
                {
                    board[row, col] = value;
                    if (CheckConstraints(board, row, col))
                        newDomain.Add(value);
                }
            }
            else
            {
                newDomain.AddRange(_avaibleValues);
            }

            foreach (var value in newDomain)
            {
                board[row, col] = value;
                if (ForwardChecking(board))
                    return true;
            }

            board[row, col] = null;
            return false;
        }

        private bool GetNextUnassignedHeurestic(bool?[,] board, ref int row, ref int col)
        {
            var currRowIndex = 0;
            var bestRowIndex = -1;
            var min = 2*N;
            while (currRowIndex < N)
            {
                var currRow = board.GetRow(currRowIndex);
                var nullCount = currRow.Count(x => x == null);
                if (nullCount < min && nullCount != 0)
                {
                    min = nullCount;
                    bestRowIndex = currRowIndex;
                }
                currRowIndex++;
            }

            if (bestRowIndex == -1) return false;

            row = bestRowIndex;
            col = board.GetRow(bestRowIndex).ToList().IndexOf(null);
            return true;
        }

        private bool GetNextUnassignedBasic(bool?[,] board, ref int row, ref int col)
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
