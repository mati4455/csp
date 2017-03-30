using System;
using System.Collections.Generic;
using System.Text;
using CSP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Runner
{
    public class AlgoRunner
    {
        private bool?[,] StartBoardTrue =
        {
            {true, false, null, false, null, null},
            {null, null, true, null, true, null},
            {null, null, null, null, false, null},
            {null, null, null, true, null, null},
            {null, null, true, null, null, null },
            {null, false, null, null, null, null }
        };

        public AlgoRunner(int n, int m)
        {/*
            var newBoard = StartBoardTrue;

            var solver = new BinaryProblemSolver();
            solver.LoadBoard(StartBoardTrue);
            Console.WriteLine(solver.PrintedBoard());
            solver.Run();
            Console.WriteLine(solver.PrintedBoard());
            */
            Console.WriteLine($"--------------- Poczatek testu {n}x{n} ---------------");
            var board = new bool?[n, n];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    board[i, j] = null;
                }
            }

            var rand = new Random();
            var added = 0;
            while (added < m)
            {
                var x = rand.Next(0, n);
                var y = rand.Next(0, n);

                if (board[x, y] == null)
                {
                    board[x, y] = rand.NextDouble() >= 0.5;
                    if (BinaryProblemSolver.CheckConstraints(board, x, y))
                        added++;
                    else
                        board[x, y] = null;
                }
            }

            var solver = new BinaryProblemSolver();
            solver.LoadBoard(board);
            Console.WriteLine(solver.PrintedBoard());
            solver.Run();
            Console.WriteLine("------------------- Koniec testu -------------------");

        }
    }
}
