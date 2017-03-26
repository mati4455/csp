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
        private List<bool> AvaibleValues = new List<bool>() {true, false};

        private const int MaxRepeat = 2;

        public void LoadBoard(bool?[,] board)
        {
            Board = board;
            N = board.GetLength(1) / 2;
        }

        public void GenerateBoard(int n)
        {
            N = n;
            Board = new bool?[2 * N, 2 * N];
        }

        public bool CheckBoard()
        {
            var check = true;
            for (var i = 0; i < 2 * N && check; i++)
            {
                check = Board.GetRow(i).Count(x => x == null) == 0;
                for (var j = 0; j < 2 * N && check; j++)
                    check = CheckConstraints(i, j);
            }
            return check;
        }

        public bool CheckConstraints(int row, int col)
        {
            var rowValue = Board.GetRow(row);
            var colValue = Board.GetCol(col);

            // liczba 0 i 1 w wierszu ma być taka sama
            var zerosRowCount = rowValue.Count(x => x == false);
            if (zerosRowCount > N)
            {
                Console.WriteLine($"Rozna liczba zer i jedynek w wierszu: {row}");
                return false;
            }

            // liczba 0 i 1 w kolumnie ma być taka sama
            var zerosColCount = colValue.Count(x => x == false);
            if (zerosColCount > N)
            {
                Console.WriteLine($"Rozna liczba zer i jedynek w kolumnie: {col}");
                return false;
            }

            // symbol nie może powtarzać się dwa razy pod rząd
            var validRow = CheckRepeat(rowValue);
            if (!validRow) return false;

            var validCol = CheckRepeat(colValue);
            if (!validCol) return false;

            // sprawdzenie unikalności kolumn i wierwszy
            for (var i = 0; i < 2 * N; i++)
            {
                if (i != row && rowValue.SequenceEqual(Board.GetRow(i)))
                {
                    Console.WriteLine($"Powtorzone wiersze: {row} - {i}");
                    return false;
                }
                if (i != col && colValue.SequenceEqual(Board.GetCol(i)))
                {
                    Console.WriteLine($"Powtorzone kolumny: {col} - {i}");
                    return false;
                }
            }

            return true;
        }

        public string PrintedBoard()
        {
            var builder = new StringBuilder();
            for (var i = 0; i < 2 * N; i++)
            {
                for (var j = 0; j < 2 * N; j++)
                {
                    builder.Append(Board[i, j] == null ? "-" : Board[i, j] == true ? "1" : "0");
                    builder.Append(" ");
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        private bool CheckRepeat(bool?[] data)
        {
            var currentSign = data[0];
            var repeatCount = 0;
            for (var i = 1; i < data.Length; i++)
            {
                if (data[i] == currentSign)
                {
                    repeatCount++;

                    if (repeatCount >= MaxRepeat)
                    {
                        Console.WriteLine($"Liczba powtorzen pod rzad jest wieksza niz {MaxRepeat}.");
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

        private void Backtracking(bool[,] boardArg)
        {
            var board = (bool?[,]) boardArg.Clone();

            var pairs = GetUnasignetPairs(board);
            if (pairs.Count == 0) return;

            foreach (var value in AvaibleValues)
            {
                foreach (var pair in pairs)
                {

                }
            }
        }

        private List<Tuple<int, int>> GetUnasignetPairs(bool?[,] board)
        {
            var length = board.GetLength(1);
            var pairs = new List<Tuple<int, int>>();
            for (var i = 0; i < length; i++)
                for (var j = 0; j < length; j++)
                    if (board[i, j] == null)
                        pairs.Add(new Tuple<int, int>(i, j));
            return pairs;
        }
    }
}