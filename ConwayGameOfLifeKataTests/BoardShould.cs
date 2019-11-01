using ConwayGameOfLife;
using ConwayGameOfLifeKataTests.TestCases;
using System.Linq;
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
                new object[] { "010|000|000", Cell.TopLeft },
                new object[] { "000|100|000", Cell.TopLeft },
                new object[] { "000|010|000", Cell.TopLeft },

                // cell on a top center 1,0
                new object[] { "100|000|000", Cell.TopCenter },
                new object[] { "001|000|000", Cell.TopCenter },
                new object[] { "000|100|000", Cell.TopCenter },
                new object[] { "000|010|000", Cell.TopCenter },
                new object[] { "000|001|000", Cell.TopCenter },
                
                // cell on top right 2,0
                new object[] { "010|000|000", Cell.TopRight },
                new object[] { "000|010|000", Cell.TopRight },
                new object[] { "000|001|000", Cell.TopRight },

                // cell on middle left 0,1
                new object[] { "100|000|000", Cell.MiddleLeft },
                new object[] { "010|000|000", Cell.MiddleLeft },
                new object[] { "000|010|000", Cell.MiddleLeft },
                new object[] { "000|000|100", Cell.MiddleLeft },
                new object[] { "000|000|010", Cell.MiddleLeft },

                // cell on middle center 1,1
                new object[] { "100|000|000", Cell.MiddleCenter },
                new object[] { "010|000|000", Cell.MiddleCenter },
                new object[] { "001|000|000", Cell.MiddleCenter },
                new object[] { "000|100|000", Cell.MiddleCenter },
                new object[] { "000|001|000", Cell.MiddleCenter },
                new object[] { "000|000|100", Cell.MiddleCenter },
                new object[] { "000|000|010", Cell.MiddleCenter },
                new object[] { "000|000|001", Cell.MiddleCenter },

                // cell on middle right 2,1
                new object[] { "001|000|000", Cell.MiddleRight },
                new object[] { "010|000|000", Cell.MiddleRight },
                new object[] { "000|010|000", Cell.MiddleRight },
                new object[] { "000|000|010", Cell.MiddleRight },
                new object[] { "000|000|001", Cell.MiddleRight },

                // cell on bottom left 0,2
                new object[] { "000|100|000", Cell.BottomLeft },
                new object[] { "000|010|000", Cell.BottomLeft },
                new object[] { "000|000|010", Cell.BottomLeft },

                // cell on bottom center 1,2
                new object[] { "000|000|100", Cell.BottomCenter },
                new object[] { "000|100|000", Cell.BottomCenter },
                new object[] { "000|010|000", Cell.BottomCenter },
                new object[] { "000|001|000", Cell.BottomCenter },
                new object[] { "000|000|001", Cell.BottomCenter },

                // cell on bottom right 2,2
                new object[] { "000|010|000", Cell.BottomRight },
                new object[] { "000|001|000", Cell.BottomRight },
                new object[] { "000|000|010", Cell.BottomRight },
            };

        [Theory]
        [MemberData(nameof(OneNeighboursTestCases))]
        public void Count_One_Neighbour(string readableGrid, Cell cell)
        {
            // Arrange
            bool[][] grid = StringToArrayGridConverter.TransformToGridArray(readableGrid);
            Board board = Board.BuildBoard(grid);

            // Act
            int neighboursCount = board.CountNeighbours(cell);

            // Assert
            Assert.Equal(1, neighboursCount);
        }

        public static object[][] TwoNeighboursTestCases =>
            new object[][]
            {
                // cell on a top left 0,0
                new object[] { "010|100|000", Cell.TopLeft },

                // cell on a top center 1,0
                new object[] { "101|000|000", Cell.TopCenter },
                new object[] { "000|101|000", Cell.TopCenter },
                
                // cell on middle center 1,1
                new object[] { "100|000|100", Cell.MiddleCenter },
                new object[] { "010|000|001", Cell.MiddleCenter },
                new object[] { "001|001|000", Cell.MiddleCenter },
            };

        [Theory]
        [MemberData(nameof(TwoNeighboursTestCases))]
        public void Count_Two_Neighbour(string readableGrid, Cell cell)
        {
            // Arrange
            bool[][] grid = StringToArrayGridConverter.TransformToGridArray(readableGrid);
            Board board = Board.BuildBoard(grid);

            // Act
            int neighboursCount = board.CountNeighbours(cell);

            // Assert
            Assert.Equal(2, neighboursCount);
        }

        public static object[][] ThreeNeighboursTestCases =>
            new object[][]
            {
                // cell on a top left 0,0
                new object[] { "010|110|000", Cell.TopLeft },

                // cell on a top center 1,0
                new object[] { "101|100|000", Cell.TopCenter },
                new object[] { "001|101|000", Cell.TopCenter },
                
                // cell on middle center 1,1
                new object[] { "100|100|100", Cell.MiddleCenter },
                new object[] { "010|001|001", Cell.MiddleCenter },
                new object[] { "001|001|100", Cell.MiddleCenter },
            };

        [Theory]
        [MemberData(nameof(ThreeNeighboursTestCases))]
        public void Count_Three_Neighbour(string readableGrid, Cell cell)
        {
            // Arrange
            bool[][] grid = StringToArrayGridConverter.TransformToGridArray(readableGrid);
            Board board = Board.BuildBoard(grid);

            // Act
            int neighboursCount = board.CountNeighbours(cell);

            // Assert
            Assert.Equal(3, neighboursCount);
        }

        public static object[][] FourNeighboursTestCases =>
            new object[][]
            {
                // cell on a top center 1,0
                new object[] { "101|101|000", Cell.TopCenter },
                new object[] { "001|111|000", Cell.TopCenter },

                // cell on a middle right 2,1
                new object[] { "010|010|011", Cell.MiddleRight },
                new object[] { "001|010|011", Cell.MiddleRight },
                
                // cell on middle center 1,1
                new object[] { "100|101|100", Cell.MiddleCenter },
                new object[] { "011|001|001", Cell.MiddleCenter },
                new object[] { "001|001|101", Cell.MiddleCenter },
            };

        [Theory]
        [MemberData(nameof(FourNeighboursTestCases))]
        public void Count_Four_Neighbour(string readableGrid, Cell cell)
        {
            // Arrange
            bool[][] grid = StringToArrayGridConverter.TransformToGridArray(readableGrid);
            Board board = Board.BuildBoard(grid);

            // Act
            int neighboursCount = board.CountNeighbours(cell);

            // Assert
            Assert.Equal(4, neighboursCount);
        }        

    }
}
