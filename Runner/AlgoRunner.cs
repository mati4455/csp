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
            {false, false, true, false, false, true, true, false, true, true},
            {false, false, true, false, true, false, true, false, true, true},
            {true, true, false, true, false, true, false, true, false, false},
            {false, false, true, false, true, false, true, true, false, true},
            {false, true, false, true, false, true, false, false, true, true},
            {true, false, true, false, true, false, false, true, true, false},
            {true, true, false, true, false, false, true, true, false, false},
            {false, false, true, true, false, true, true, false, false, true},
            {true, true, false, false, true, true, false, false, true, false},
            {true, true, false, true, true, false, false, true, false, false}
        };

        public AlgoRunner()
        {
            var newBoard = StartBoardTrue;
            newBoard[2, 4] = null;
            newBoard[5, 4] = null;
            newBoard[2, 6] = null;
            newBoard[3, 3] = null;
            newBoard[1, 6] = null;
            newBoard[2, 6] = null;
            newBoard[3, 6] = null;
            newBoard[5, 5] = null;
            newBoard[1, 9] = null;
            newBoard[5, 6] = null;
            newBoard[8, 8] = null;
            newBoard[1, 9] = null;
            newBoard[9, 5] = null;
            newBoard[1, 4] = null;
            newBoard[1, 8] = null;
            newBoard[1, 9] = null;
            newBoard[4, 9] = null;
            newBoard[7, 9] = null;
            newBoard[2, 9] = null;
            newBoard[3, 1] = null;
            newBoard[5, 2] = null;
            newBoard[3, 5] = null;
            newBoard[0, 0] = null;
            newBoard[0, 4] = null;
            newBoard[4, 0] = null;
            newBoard[5, 0] = null;
            newBoard[6, 0] = null;
            newBoard[7, 0] = null;
            newBoard[8, 0] = null;
            newBoard[9, 0] = null;

            var solver = new BinaryProblemSolver();
            solver.LoadBoard(StartBoardTrue);
            Console.WriteLine(solver.PrintedBoard());
            solver.Run();
            Console.WriteLine(solver.PrintedBoard());
        }
    }
}
