using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeEx.Test
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Game_Constructor_Positive_Test()
        {
            var rows = 2;
            var columns = 2;
            var expectedResult = 2;

            Game target = new Game(rows, columns);
            var actualRowCount = target.RowCount;
            var actualColumnCount = target.ColumnCount;

            Assert.AreEqual(expectedResult, actualRowCount);
            Assert.AreEqual(expectedResult, actualColumnCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Row and Column size must be greater than or equal to zero")]
        public void GameRow_Constructor_Exception_Test()
        {
            var rows = -1;
            var columns = 0;

            Game target = new Game(rows, columns);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Row and Column size must be greater than zero")]
        public void GameColumn_Constructor_Exception_Test()
        {
            var rows = 0;
            var columns = -1;

            Game target = new Game(rows, columns);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Row and Column size must be greater than zero")]
        public void GameZero_Constructor_Exception_Test()
        {
            var rows = 0;
            var columns = 0;

            Game target = new Game(rows, columns);
        }

        [TestMethod]
        public void ToggleGridCell_Positive_Test()
        {
            var rows = 2;
            var columns = 3;
            var x = 1;
            var y = 2;
            var expectedResult = true;

            Game target = new Game(rows, columns);
            target.ToggleGridCell(x, y);

            Assert.AreEqual(expectedResult, target.InputGrid[1, 2].IsAlive);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Argument out of bound")]
        public void ToggleGridCell_Row_Exception_Test()
        {
            var rows = 1;
            var columns = 0;
            var x = 0;
            var y = 0;

            Game target = new Game(rows, columns);

            target.ToggleGridCell(x, y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Argument out of bound")]
        public void ToggleGridCell_Column_Excecptino_Test()
        {
            var rows = 0;
            var columns = 1;
            var x = 1;
            var y = 1;

            Game target = new Game(rows, columns);

            target.ToggleGridCell(x, y);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Argument out of bound")]
        public void ToggleGridCell_OutOfBound_Exception_Test()
        {
            var rows = 2;
            var columns = 3;
            var x = 3;
            var y = 3;

            Game target = new Game(rows, columns);
            target.ToggleGridCell(x, y);
        }

        [TestMethod]
        public void Max_Generation_Test()
        {
            var rows = 2;
            var columns = 2;
            var expectedResult = 2;
            var maxGeneration = 2;

            Game target = new Game(rows, columns);
            target.MaxGenerations = maxGeneration;
            var actualMaxGenerations = target.MaxGenerations;

            Assert.AreEqual(expectedResult, actualMaxGenerations);
        }

        [TestMethod]
        public void Init_DefaultValue_Test()
        {
            var rows = 2;
            var columns = 2;
            var expectedResult = false;

            Game target = new Game(rows, columns);
            target.Init();

            Assert.AreEqual(expectedResult, target.InputGrid[0, 0].IsAlive);
            Assert.AreEqual(expectedResult, target.InputGrid[0, 1].IsAlive);
            Assert.AreEqual(expectedResult, target.InputGrid[1, 0].IsAlive);
            Assert.AreEqual(expectedResult, target.InputGrid[1, 1].IsAlive);
        }

        [TestMethod]
        public void Init_BlockPattern_Test()
        {
            var rows = 2;
            var columns = 2;
            var expectedResult = true;

            Game target = new Game(rows, columns);
            target.ToggleGridCell(0, 0);
            target.ToggleGridCell(0, 1);
            target.ToggleGridCell(1, 0);
            target.ToggleGridCell(1, 1);
            target.MaxGenerations = 100;
            target.Init();

            Assert.AreEqual(expectedResult, target.InputGrid[0, 0].IsAlive);
            Assert.AreEqual(expectedResult, target.InputGrid[0, 1].IsAlive);
            Assert.AreEqual(expectedResult, target.InputGrid[1, 0].IsAlive);
            Assert.AreEqual(expectedResult, target.InputGrid[1, 1].IsAlive);
        }

        [TestMethod()]
        public void Init_BoatPattern_Test()
        {
            int rows = 3;
            int columns = 3;
            Game target = new Game(rows, columns);
            target.ToggleGridCell(0, 0);
            target.ToggleGridCell(0, 1);
            target.ToggleGridCell(1, 0);
            target.ToggleGridCell(1, 2);
            target.ToggleGridCell(2, 1);
            target.Init();
            Assert.AreEqual(target.InputGrid[0, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[0, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 1].IsAlive, true);
        }

        [TestMethod()]
        public void Init_BlinkerPattern_Test()
        {
            int rows = 3;
            int columns = 3;
            Game target = new Game(rows, columns);
            target.ToggleGridCell(0, 1);
            target.ToggleGridCell(1, 1);
            target.ToggleGridCell(2, 1);

            target.Init();
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 2].IsAlive, true);
        }

        [TestMethod()]
        public void Init_ToadPattern1_Test()
        {
            int rows = 2;
            int columns = 4;
            Game target = new Game(rows, columns);
            target.ToggleGridCell(0, 1);
            target.ToggleGridCell(0, 2);
            target.ToggleGridCell(0, 3);
            target.ToggleGridCell(1, 0);
            target.ToggleGridCell(1, 1);
            target.ToggleGridCell(1, 2);
            target.Init();
            Assert.AreEqual(target.InputGrid[0, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 3].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 3].IsAlive, true);
            Assert.AreEqual(target.InputGrid[3, 1].IsAlive, true);
        }

        [TestMethod()]
        public void Init_ToadPattern2_Test()
        {
            int rows = 4;
            int columns = 2;
            Game target = new Game(rows, columns);
            target.ToggleGridCell(0, 0);
            target.ToggleGridCell(1, 0);
            target.ToggleGridCell(1, 1);
            target.ToggleGridCell(2, 0);
            target.ToggleGridCell(2, 1);
            target.ToggleGridCell(3, 1);
            target.Init();
            Assert.AreEqual(target.InputGrid[0, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[0, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 3].IsAlive, true);
            Assert.AreEqual(target.InputGrid[3, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[3, 2].IsAlive, true);
        }

        [TestMethod()]
        public void Init_DiamondPattern_Test()
        {
            int rows = 3;
            int columns = 4;

            Game target = new Game(rows, columns);
            target.ToggleGridCell(0, 1);
            target.ToggleGridCell(0, 2);
            target.ToggleGridCell(1, 0);
            target.ToggleGridCell(1, 3);
            target.ToggleGridCell(2, 1);
            target.ToggleGridCell(2, 2);
            target.MaxGenerations = 50;
            target.Init();
            Assert.AreEqual(target.InputGrid[0, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[0, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[1, 3].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 2].IsAlive, true);
        }

        [TestMethod()]
        public void Init_QueenBeeShuttle_Test()
        {
            // The Queen Bee Shuttle pattern
            int rows = 7;
            int columns = 4;
            Game target = new Game(rows, columns);
            target.ToggleGridCell(0, 0);
            target.ToggleGridCell(0, 1);
            target.ToggleGridCell(1, 2);
            target.ToggleGridCell(2, 3);
            target.ToggleGridCell(3, 3);
            target.ToggleGridCell(4, 3);
            target.ToggleGridCell(5, 2);
            target.ToggleGridCell(6, 0);
            target.ToggleGridCell(6, 1);
            target.MaxGenerations = 100;
            target.Init();
            Assert.AreEqual(target.InputGrid[4, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[4, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[5, 0].IsAlive, true);
            Assert.AreEqual(target.InputGrid[5, 3].IsAlive, true);
            Assert.AreEqual(target.InputGrid[6, 1].IsAlive, true);
            Assert.AreEqual(target.InputGrid[6, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[3, 8].IsAlive, true);
            Assert.AreEqual(target.InputGrid[4, 7].IsAlive, true);
            Assert.AreEqual(target.InputGrid[4, 9].IsAlive, true);
            Assert.AreEqual(target.InputGrid[5, 6].IsAlive, true);
            Assert.AreEqual(target.InputGrid[5, 10].IsAlive, true);
            Assert.AreEqual(target.InputGrid[6, 6].IsAlive, true);
            Assert.AreEqual(target.InputGrid[6, 10].IsAlive, true);
            Assert.AreEqual(target.InputGrid[7, 7].IsAlive, true);
            Assert.AreEqual(target.InputGrid[7, 8].IsAlive, true);
            Assert.AreEqual(target.InputGrid[7, 9].IsAlive, true);
            Assert.AreEqual(target.InputGrid[9, 7].IsAlive, true);
            Assert.AreEqual(target.InputGrid[9, 8].IsAlive, true);
            Assert.AreEqual(target.InputGrid[9, 9].IsAlive, true);
            Assert.AreEqual(target.InputGrid[10, 6].IsAlive, true);
            Assert.AreEqual(target.InputGrid[10, 10].IsAlive, true);
            Assert.AreEqual(target.InputGrid[11, 6].IsAlive, true);
            Assert.AreEqual(target.InputGrid[11, 10].IsAlive, true);
            Assert.AreEqual(target.InputGrid[12, 7].IsAlive, true);
            Assert.AreEqual(target.InputGrid[12, 9].IsAlive, true);
            Assert.AreEqual(target.InputGrid[13, 8].IsAlive, true);
        }

        [TestMethod()]
        public void Init_Period15Oscillator_Test()
        {
            // The Queen Bee Shuttle pattern
            int rows = 1;
            int columns = 10;
            Game target = new Game(rows, columns);

            target.ToggleGridCell(0, 0);
            target.ToggleGridCell(0, 1);
            target.ToggleGridCell(0, 2);
            target.ToggleGridCell(0, 3);
            target.ToggleGridCell(0, 4);
            target.ToggleGridCell(0, 5);
            target.ToggleGridCell(0, 6);
            target.ToggleGridCell(0, 7);
            target.ToggleGridCell(0, 8);
            target.ToggleGridCell(0, 9);
            target.MaxGenerations = 50;
            target.Init();
            Assert.AreEqual(target.InputGrid[4, 2].IsAlive, true);
            Assert.AreEqual(target.InputGrid[3, 3].IsAlive, true);
            Assert.AreEqual(target.InputGrid[4, 3].IsAlive, true);
            Assert.AreEqual(target.InputGrid[5, 3].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 4].IsAlive, true);
            Assert.AreEqual(target.InputGrid[3, 4].IsAlive, true);
            Assert.AreEqual(target.InputGrid[4, 4].IsAlive, true);
            Assert.AreEqual(target.InputGrid[5, 4].IsAlive, true);
            Assert.AreEqual(target.InputGrid[6, 4].IsAlive, true);

            Assert.AreEqual(target.InputGrid[4, 13].IsAlive, true);
            Assert.AreEqual(target.InputGrid[3, 12].IsAlive, true);
            Assert.AreEqual(target.InputGrid[4, 12].IsAlive, true);
            Assert.AreEqual(target.InputGrid[5, 12].IsAlive, true);
            Assert.AreEqual(target.InputGrid[2, 11].IsAlive, true);
            Assert.AreEqual(target.InputGrid[3, 11].IsAlive, true);
            Assert.AreEqual(target.InputGrid[4, 11].IsAlive, true);
            Assert.AreEqual(target.InputGrid[5, 11].IsAlive, true);
            Assert.AreEqual(target.InputGrid[6, 11].IsAlive, true);

        }

        [TestMethod]
        public void Grid_Constructor_Positive_Test()
        {
            var rows = 2;
            var columns = 2;
            var expectedResult = 2;

            Grid target = new Grid(rows, columns);

            Assert.AreEqual(expectedResult, target.RowCount);
            Assert.AreEqual(expectedResult, target.ColumnCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Row and Column size must be greater than or equal to zero")]
        public void Grid_Constructor_Exception_Test()
        {
            var rows = -1;
            var columns = 0;

            Grid target = new Grid(rows, columns);
        }
    }
}
