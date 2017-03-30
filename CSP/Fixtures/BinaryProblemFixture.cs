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
            Console.WriteLine("------------------ Poczatek testu ------------------");
            var board = (bool?[,])StartBoardTrue.Clone();
            Solver.LoadBoard(board);
            Console.WriteLine("------------------- Koniec testu -------------------");
            Assert.AreEqual(true, Solver.CheckBoard());
        }

        [TestMethod]
        public void CheckBoardTrue_02()
        {
            Console.WriteLine("------------------ Poczatek testu ------------------");
            var board = StartBoardTrue;
            board[0, 0] = board[2, 6] = board[7, 7] = null;
            Solver.LoadBoard(board);
            Console.WriteLine("------------------- Koniec testu -------------------");
            Assert.AreEqual(false, Solver.CheckBoard());
        }
        
        [TestMethod]
        public void CheckConstraintTure_01()
        {
            Console.WriteLine("------------------ Poczatek testu ------------------");
            var board = (bool?[,]) StartBoardTrue.Clone();
            board[0, 0] = board[2, 6] = board[7, 7] = null;
            Console.WriteLine("------------------- Koniec testu -------------------");
            Assert.AreEqual(true, BinaryProblemSolver.CheckConstraints(board, 0, 0));
            Assert.AreEqual(true, BinaryProblemSolver.CheckConstraints(board, 2, 6));
            Assert.AreEqual(true, BinaryProblemSolver.CheckConstraints(board, 7, 7));
        }

        [TestMethod]
        public void CheckBoardFalse()
        {
            Console.WriteLine("------------------ Poczatek testu ------------------");
            var board = (bool?[,])StartBoardFalse.Clone();
            Solver.LoadBoard(board);
            Console.WriteLine("------------------- Koniec testu -------------------");
            Assert.AreEqual(false, Solver.CheckBoard());
        }

        [TestMethod]
        public void ResolveBoardTrue()
        {
            Console.WriteLine("------------------ Poczatek testu ------------------");
            var newBoard = (bool?[,]) StartBoardTrue.Clone();
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
            Console.WriteLine("------------------- Koniec testu -------------------");
            Assert.AreEqual(true, Solver.CheckBoard());
        }

        /*
        [TestMethod]
        public void ResolveEmptyBoard_4x4_True()
        {
            Console.WriteLine("------------------ Poczatek testu ------------------");
            Solver.GenerateBoard(4, 10);
            Console.WriteLine(Solver.PrintedBoard());
            Solver.Run();
            Console.WriteLine("------------------- Koniec testu -------------------");
            Assert.AreEqual(true, Solver.CheckBoard());
        }
        */
        /*
        [TestMethod]
        public void ResolveEmptyBoard_6x6_True()
        {
            Solver.GenerateBoard(6, 10);
            Console.WriteLine(Solver.PrintedBoard());
            Solver.Run();
            Console.WriteLine(Solver.PrintedBoard());
            Assert.AreEqual(true, Solver.CheckBoard());
        }
        */
        /*
        [TestMethod]
        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(15)]
        [DataRow(20)]
        [DataRow(25)]
        [DataRow(35)]
        [DataRow(40)]
        [DataRow(45)]
        [DataRow(50)]
        [DataRow(55)]
        [DataRow(60)]
        [DataRow(65)]
        [DataRow(70)]
        [DataRow(75)]
        [DataRow(80)]
        [DataRow(85)]
        [DataRow(90)]
        [DataRow(95)]
        [DataRow(100)]
        public void ResolveEmptyBoard_10x10_True(int m)
        {
            Console.WriteLine("\n------------------ Poczatek testu ------------------");
            Console.WriteLine($"Liczba pol do uzupelnienia: {m}");
            var newBoard = (bool?[,])StartBoardTrue.Clone();
            var rand = new Random();
            var added = 0;
            var n = newBoard.GetLength(1);
            while (added < m)
            {
                var x = rand.Next(0, n);
                var y = rand.Next(0, n);

                if (newBoard[x, y] != null)
                {
                    newBoard[x, y] = null;
                    added++;
                }
            }
            Solver.LoadBoard(newBoard);
            Console.WriteLine(Solver.PrintedBoard());
            Solver.Run();
            Console.WriteLine("------------------- Koniec testu -------------------");
            Assert.AreEqual(true, Solver.CheckBoard());
        }*/

        [TestMethod]
        public void CheckBoard_20x20()
        {
            Console.WriteLine("--------------- Poczatek testu 20x20 ---------------");
            var board = new bool?[20,20];
            for (var i = 0; i < 20; i++)
            {
                for (var j = 0; j < 20; j++)
                {
                    board[i, j] = null;
                }
            }
            Solver.LoadBoard(board);
            Console.WriteLine(Solver.PrintedBoard());
            Console.WriteLine("------------------- Koniec testu -------------------");
            Assert.AreEqual(true, Solver.CheckBoard());
        }
    }
}
