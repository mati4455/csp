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
        private readonly List<bool> _avaibleValues = new List<bool>() {true, false};
        private bool Log = false;

        private const int MaxRepeat = 2;

        public void LoadBoard(bool?[,] board)
        {
            Board = board;
            N = board.GetLength(1);
        }

        public void GenerateBoard(int n, int m)
        {
            N = n;
            M = m;
            Board = new bool?[N, N];

            for (var i = 0; i < N; i++)
            for (var j = 0; j < N; j++)
                Board[i, j] = null;

            var rand = new Random();
            var added = 0;
            while (added < M)
            {
                var x = rand.Next(0, N);
                var y = rand.Next(0, N);

                if (Board[x, y] == null)
                {
                    Board[x, y] = rand.NextDouble() >= 0.5;
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

        public void Run()
        {
            var result = Backtracking(Board);
            Console.WriteLine(result ? PrintedBoard() : "Brak rozwiazania");
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

        public bool CheckConstraints(bool?[,] board, int row, int col)
        {
            var rowValue = board.GetRow(row);
            var colValue = board.GetCol(col);
            var n = rowValue.Length;
            var half = n / 2;
            var check = true;

            if (Log) Console.WriteLine("-----------------");

            if (Log) Console.WriteLine($"Uzupelniono pole ({row}, {col})");

            // liczba 0 i 1 w wierszu ma być taka sama
            var zerosRowCount = rowValue.Count(x => x == false);
            var onesRowCount = rowValue.Count(x => x == true);
            if (zerosRowCount > half || onesRowCount > half)
            {
                if (Log) Console.WriteLine($"Rozna liczba zer i jedynek w wierszu: {row}");
                check = false;
            }

            // liczba 0 i 1 w kolumnie ma być taka sama
            var zerosColCount = colValue.Count(x => x == false);
            var onesColCount = colValue.Count(x => x == true);
            if (zerosColCount > half || onesColCount > half)
            {
                if (Log) Console.WriteLine($"Rozna liczba zer i jedynek w kolumnie: {col}");
                check = false;
            }

            // symbol nie może powtarzać się dwa razy pod rząd
            var validRow = CheckRepeat(rowValue);
            if (!validRow) check = false;

            var validCol = CheckRepeat(colValue);
            if (!validCol) check = false;

            // sprawdzenie unikalności kolumn i wierwszy
            for (var i = 0; i < n; i++)
            {
                if (i != row && rowValue.Count(x => x == null) == 0 && rowValue.SequenceEqual(board.GetRow(i)))
                {
                    if (Log) Console.WriteLine($"Powtorzone wiersze: {row} - {i}");
                    check = false;
                }
                if (i != col && colValue.Count(x => x == null) == 0 && colValue.SequenceEqual(board.GetCol(i)))
                {
                    if (Log) Console.WriteLine($"Powtorzone kolumny: {col} - {i}");
                    check = false;
                }
            }

            //Console.WriteLine(PrintedBoard());

            //Console.ReadKey();

            if (Log) Console.WriteLine($"----------------- -> {check}\n\n");

            return check;
        }

        private bool CheckRepeat(bool?[] data)
        {
            var currentSign = data[0];
            var repeatCount = 0;
            for (var i = 1; i < data.Length; i++)
            {
                if (data[i] == currentSign && currentSign != null)
                {
                    repeatCount++;

                    if (repeatCount >= MaxRepeat)
                    {
                        if (Log) Console.WriteLine($"Liczba powtorzen pod rzad jest wieksza niz {MaxRepeat}.");
                        return false;
                    }
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

            if (!GetNextUnassigned(board, ref row, ref col))
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
        
        private bool GetNextUnassigned(bool?[,] board, ref int row, ref int col)
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