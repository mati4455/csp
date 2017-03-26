using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSP.Fixtures
{
    [TestClass]
    public class BinaryProblemFixture
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

        private bool?[,] StartBoardFalse =
        {
            {false, false, true, false, false, true, true, false, true, true},
            {false, false, true, false, true, false, true, false, true, true},
            {true, true, true, true, false, true, false, true, false, false},
            {false, false, true, false, true, false, true, true, false, true},
            {false, true, false, true, false, true, false, false, true, true},
            {true, false, true, false, true, false, false, true, true, false},
            {true, true, false, true, false, false, true, true, false, false},
            {false, false, true, true, false, true, true, false, false, true},
            {true, true, false, false, true, true, false, false, false, false},
            {true, true, false, true, true, false, false, true, false, false}
        };

        private BinaryProblemSolver Solver = new BinaryProblemSolver();
        
        [TestMethod]
        public void CheckBoardTrue_01()
        {
            var board = StartBoardTrue;
            Solver.LoadBoard(board);
            Assert.AreEqual(true, Solver.CheckBoard());
        }

        [TestMethod]
        public void CheckBoardTrue_02()
        {
            var board = StartBoardTrue;
            board[0, 0] = board[2, 6] = board[7, 7] = null;
            Solver.LoadBoard(board);
            Assert.AreEqual(false, Solver.CheckBoard());
        }
        
        [TestMethod]
        public void CheckConstraintTure_01()
        {
            var board = StartBoardTrue;
            board[0, 0] = board[2, 6] = board[7, 7] = null;
            Assert.AreEqual(true, Solver.CheckConstraints(board, 0, 0));
            Assert.AreEqual(true, Solver.CheckConstraints(board, 2, 6));
            Assert.AreEqual(true, Solver.CheckConstraints(board, 7, 7));
        }

        [TestMethod]
        public void CheckBoardFalse()
        {
            Solver.LoadBoard(StartBoardFalse);
            Assert.AreEqual(false, Solver.CheckBoard());
        }

        [TestMethod]
        public void ResolveBoardTrue()
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
            //newBoard[7, 0] = null;
            newBoard[8, 0] = null;
            newBoard[9, 0] = null;

            Solver.LoadBoard(StartBoardTrue);
            Console.WriteLine(Solver.PrintedBoard());
            Solver.Run();
            Console.WriteLine(Solver.PrintedBoard());
            Assert.AreEqual(true, Solver.CheckBoard());
        }

        
        [TestMethod]
        public void ResolveEmptyBoard_4x4_True()
        {
            Solver.GenerateBoard(4, 5);
            Console.WriteLine(Solver.PrintedBoard());
            Solver.Run();
            Console.WriteLine(Solver.PrintedBoard());
            Assert.AreEqual(true, Solver.CheckBoard());
        }
        
        /*
        [TestMethod]
        public void ResolveEmptyBoard_6x6_True()
        {
            int n = 6;
            var newBoard = new bool?[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    newBoard[i, j] = null;

            Solver.LoadBoard(newBoard);
            Console.WriteLine(Solver.PrintedBoard());
            Solver.Run();
            Console.WriteLine(Solver.PrintedBoard());
            Assert.AreEqual(true, Solver.CheckBoard());
        }
        */
        /*
        [TestMethod]
        public void ResolveEmptyBoard_10x10_True()
        {
            int n = 10;
            var newBoard = new bool?[n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    newBoard[i, j] = null;

            Solver.LoadBoard(newBoard);
            Console.WriteLine(Solver.PrintedBoard());
            Solver.Run();
            Console.WriteLine(Solver.PrintedBoard());
            Assert.AreEqual(true, Solver.CheckBoard());
        }*/
    }
}
