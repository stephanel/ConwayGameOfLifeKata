using ConwayGameOfLife;
using ConwayGameOfLifeKataTests.TestCases;
using Xunit;

namespace ConwayGameOfLifeKataTests
{
    public class BoardShould
    {
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
        public void Check_If_Cell_Is_Inside(int x, int y)
        {
            // Arrange
            Board  board = Board.BuildBoard(3);

            Cell cell = new Cell(x, y);

            // Act
            var inside = board.IsInsideBoard(cell);

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
        public void Check_If_Cell_Is_Outside(int x, int y)
        {
            // Arrange
            Board board = Board.BuildBoard(3);

            Cell cell = new Cell(x, y);

            // Act
            var outside = board.IsOutsideBoard(cell);

            // Assert
            Assert.True(outside);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(0, 1, 1, 0)]
        [InlineData(0, 2, 2, 0)]
        [InlineData(1, 0, 0, 1)]
        [InlineData(1, 1, 1, 1)]
        [InlineData(1, 2, 2, 1)]
        [InlineData(2, 0, 0, 2)]
        [InlineData(2, 1, 1, 2)]
        [InlineData(2, 2, 2, 2)]
        public void Check_If_Cell_Is_Alive(int xCell, int yCell, int xBoardAlive, int yBoardAlive)
        {
            // Arrange
            Board board = Board.BuildBoard(3);
            board.Grid[xBoardAlive][yBoardAlive] = true;

            Cell cell = new Cell(xCell, yCell);

            // Act
            var alive = board.IsAlive(cell);

            // Assert
            Assert.True(alive);
        }

        [Theory]
        [InlineData(0, 0)]
        public void Check_If_Cell_Is_Dead(int xCell, int yCell)
        {
            // Arrange
            Board board = Board.BuildBoard(3);

            Cell cell = new Cell(xCell, yCell);

            // Act
            var dead = board.IsDead(cell);

            // Assert
            Assert.True(dead);
        }

        [Fact]
        public void Count_Zero_Neighbour()
        {
            // under-population means cell have fewer than two live neighbours
            // Arrange
            Board board = Board.BuildBoard(3);

            Cell cell = new Cell(1, 1);

            // Act
            int neighboursCount = board.CountNeighbours(cell);

            // Assert
            Assert.Equal(0, neighboursCount);
        }

        public static object[][] OneNeighboursTestCases =>
            new object[][]
            {
                // cell on a top left 0,0
                new object[] { CellTestCases.TopCenter, Cell.TopLeft },
                new object[] { CellTestCases.MiddleLeft, Cell.TopLeft },
                new object[] { CellTestCases.MiddleCenter, Cell.TopLeft },

                // cell on a top center 1,0
                new object[] { CellTestCases.TopLeft, Cell.TopCenter },
                new object[] { CellTestCases.TopRight, Cell.TopCenter },
                new object[] { CellTestCases.MiddleLeft, Cell.TopCenter },
                new object[] { CellTestCases.MiddleCenter, Cell.TopCenter },
                new object[] { CellTestCases.MiddleRight, Cell.TopCenter },
                
                // cell on top right 2,0
                new object[] { CellTestCases.TopCenter, Cell.TopRight },
                new object[] { CellTestCases.MiddleCenter, Cell.TopRight },
                new object[] { CellTestCases.MiddleRight, Cell.TopRight },

                // cell on middle left 0,1
                new object[] { CellTestCases.TopLeft, Cell.MiddleLeft },
                new object[] { CellTestCases.TopCenter, Cell.MiddleLeft },
                new object[] { CellTestCases.MiddleCenter, Cell.MiddleLeft },
                new object[] { CellTestCases.BottomLeft, Cell.MiddleLeft },
                new object[] { CellTestCases.BottomCenter, Cell.MiddleLeft },

                // cell on middle center 1,1
                new object[] { CellTestCases.TopLeft, Cell.MiddleCenter },
                new object[] { CellTestCases.TopCenter, Cell.MiddleCenter },
                new object[] { CellTestCases.TopRight, Cell.MiddleCenter },
                new object[] { CellTestCases.MiddleLeft, Cell.MiddleCenter },
                new object[] { CellTestCases.MiddleRight, Cell.MiddleCenter },
                new object[] { CellTestCases.BottomLeft, Cell.MiddleCenter },
                new object[] { CellTestCases.BottomCenter, Cell.MiddleCenter },
                new object[] { CellTestCases.BottomRight, Cell.MiddleCenter },

                // cell on middle right 2,1
                new object[] { CellTestCases.TopRight, Cell.MiddleRight },
                new object[] { CellTestCases.TopCenter, Cell.MiddleRight },
                new object[] { CellTestCases.MiddleCenter, Cell.MiddleRight },
                new object[] { CellTestCases.BottomCenter, Cell.MiddleRight },
                new object[] { CellTestCases.BottomRight, Cell.MiddleRight },

                // cell on bottom left 0,2
                new object[] { CellTestCases.MiddleLeft, Cell.BottomLeft },
                new object[] { CellTestCases.MiddleCenter, Cell.BottomLeft },
                new object[] { CellTestCases.BottomCenter, Cell.BottomLeft },

                // cell on bottom center 1,2
                new object[] { CellTestCases.BottomLeft, Cell.BottomCenter },
                new object[] { CellTestCases.MiddleLeft, Cell.BottomCenter },
                new object[] { CellTestCases.MiddleCenter, Cell.BottomCenter },
                new object[] { CellTestCases.MiddleRight, Cell.BottomCenter },
                new object[] { CellTestCases.BottomRight, Cell.BottomCenter },

                // cell on bottom right 2,2
                new object[] { CellTestCases.MiddleCenter, Cell.BottomRight },
                new object[] { CellTestCases.MiddleRight, Cell.BottomRight },
                new object[] { CellTestCases.BottomCenter, Cell.BottomRight },
            };

        [Theory]
        [MemberData(nameof(OneNeighboursTestCases))]
        public void Count_One_Neighbour(bool[][] grid, Cell cell)
        {
            // under-population means cell have fewer than two live neighbours
            // Arrange
            Board board = Board.BuildBoard(grid);

            // Act
            int neighboursCount = board.CountNeighbours(cell);

            // Assert
            Assert.Equal(1, neighboursCount);
        }

    }
}
