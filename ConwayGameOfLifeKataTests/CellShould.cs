using ConwayGameOfLife;
using ConwayGameOfLifeKataTests.TestCases;
using System;
using System.Collections.Generic;
using Xunit;

namespace ConwayGameOfLifeKataTests
{
    public class CellShould
    {

        // TODO: test cell inside board
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 0)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        public void Be_Inside_Board3x3(int x, int y)
        {
            // Arrange
            bool[][] board = GameOfLife.BuildBoard(3);

            Cell cell = new Cell(x, y);

            // Act
            var inside = cell.IsInsideBoard(board);

            // Assert
            Assert.True(inside);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(-1, -1)]
        [InlineData(0, -1)]
        [InlineData(1, -1)]
        [InlineData(2, -1)]
        [InlineData(3, -1)]
        [InlineData(3, 0)]
        [InlineData(-1, 1)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(2, 3)]
        [InlineData(1, 3)]
        [InlineData(0, 3)]
        [InlineData(-1, 3)]
        public void Be_Outside_Board3x3(int x, int y)
        {
            // Arrange
            bool[][] board = GameOfLife.BuildBoard(3);

            Cell cell = new Cell(x, y);

            // Act
            var inside = cell.IsInsideBoard(board);

            // Assert
            Assert.False(inside);
        }

        [Fact]
        public void Be_Alive_Board3x3()
        {
            // Arrange
            bool[][] board = GameOfLife.BuildBoard(3);
            board[0][0] = true;

            Cell cell = new Cell(0, 0);

            // Act
            var alive = cell.IsAlive(board);

            // Assert
            Assert.True(alive);
        }

        [Fact]
        public void Be_Dead_Board3x3()
        {
            // Arrange
            bool[][] board = GameOfLife.BuildBoard(3);

            Cell cell = new Cell(0, 0);

            // Act
            var alive = cell.IsAlive(board);

            // Assert
            Assert.False(alive);
        }

        [Fact]
        public void Count_Zero_Neighbour()
        {
            // under-population means cell have fewer than two live neighbours
            // Arrange
            bool[][] board = new bool[][]
            {
                new bool[] { false, false, false },
                new bool[] { false, false, false },
                new bool[] { false, false, false }
            };

            Cell cell = new Cell(1, 1);

            // Act
            int neighboursCount = cell.CountNeighbours(board);

            // Assert
            Assert.Equal(0, neighboursCount);
        }

        public static object[][] OneNeighboursTestCases =>
            new object[][]
            {
                // cell on a side 0,1
                new object[] { CellTestCases.TopCenter, Cell.TopLeft },
                new object[] { CellTestCases.MiddleLeft, Cell.TopLeft },
                new object[] { CellTestCases.MiddleCenter, Cell.TopLeft },
                
                // cell on middle center 1,1
                new object[] { CellTestCases.TopLeft, Cell.MiddleCenter },
                new object[] { CellTestCases.TopCenter, Cell.MiddleCenter },
                new object[] { CellTestCases.TopRight, Cell.MiddleCenter },
                new object[] { CellTestCases.MiddleLeft, Cell.MiddleCenter },
                new object[] { CellTestCases.MiddleRight, Cell.MiddleCenter },
                new object[] { CellTestCases.BottomLeft, Cell.MiddleCenter },
                new object[] { CellTestCases.BottomCenter, Cell.MiddleCenter },
                new object[] { CellTestCases.BottomRight, Cell.MiddleCenter }
            };

        [Theory]
        [MemberData(nameof(OneNeighboursTestCases))]
        public void Count_One_Neighbour(bool[][] board, Cell cell)
        {
            // under-population means cell have fewer than two live neighbours
            // Arrange
            // Act
            int neighboursCount = cell.CountNeighbours(board);

            // Assert
            Assert.Equal(1, neighboursCount);
        }


    }
}
