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
        public void CheckBoardTrue()
        {
            Solver.LoadBoard(StartBoardTrue);
            Console.WriteLine(Solver.PrintedBoard());
            Assert.AreEqual(true, Solver.CheckBoard());
        }

        [TestMethod]
        public void CheckBoardFalse()
        {
            Solver.LoadBoard(StartBoardFalse);
            Console.WriteLine(Solver.PrintedBoard());
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

            Solver.LoadBoard(StartBoardTrue);
            Console.WriteLine(Solver.PrintedBoard());
            Assert.AreEqual(true, Solver.CheckBoard());
        }
    }
}
