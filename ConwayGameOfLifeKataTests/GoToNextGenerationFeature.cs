using ConwayGameOfLife;
using System.Linq;
using Xunit;

namespace ConwayGameOfLifeKataTests
{
    public class GoToNextGenerationFeature
    {
        public static object[][] TestCases =>
            new object[][]
            {
                //Initial board
                // 000|000|000
                // should become 
                // 000|000|000
                new object[] {
                    new bool[][]
                    {
                        new bool[] { false, false, false },
                        new bool[] { false, false, false },
                        new bool[] { false, false, false }
                    },
                    new bool[][]
                    {
                        new bool[] { false, false, false },
                        new bool[] { false, false, false },
                        new bool[] { false, false, false }
                    },
                },
                //Initial board
                // 100|000|000
                // should become 
                // 000|000|000
                new object[] {
                    new bool[][]
                    {
                        new bool[] { true, false, false },
                        new bool[] { false, false, false },
                        new bool[] { false, false, false }
                    },
                    new bool[][]
                    {
                        new bool[] { false, false, false },
                        new bool[] { false, false, false },
                        new bool[] { false, false, false }
                    },
                },
                //Initial board
                // 110|000|000
                // should become 
                // 000|000|000
                new object[] {
                    new bool[][]
                    {
                        new bool[] { true, true, false },
                        new bool[] { false, false, false },
                        new bool[] { false, false, false }
                    },
                    new bool[][]
                    {
                        new bool[] { false, false, false },
                        new bool[] { false, false, false },
                        new bool[] { false, false, false }
                    },
                },
                //Initial board
                // 110|100|000
                // should become 
                // 110|110|000
                new object[] {
                    new bool[][]
                    {
                        new bool[] { true, true, false },
                        new bool[] { true, false, false },
                        new bool[] { false, false, false }
                    },
                    new bool[][]
                    {
                        new bool[] { true, true, false },
                        new bool[] { true, true, false },
                        new bool[] { false, false, false }
                    },
                },
                //Initial board
                // 110|110|000
                // should become 
                // 110|110|000
                new object[] {
                    new bool[][]
                    {
                        new bool[] { true, true, false },
                        new bool[] { true, true, false },
                        new bool[] { false, false, false }
                    },
                    new bool[][]
                    {
                        new bool[] { true, true, false },
                        new bool[] { true, true, false },
                        new bool[] { false, false, false }
                    },
                },
                //Initial board
                // 110|100|011
                // should become 
                // 110|110|000
                new object[] {
                    new bool[][]
                    {
                        new bool[] { true, true, false },
                        new bool[] { true, false, false },
                        new bool[] { false, true, true }
                    },
                    new bool[][]
                    {
                        new bool[] { true, true, false },
                        new bool[] { true, false, true },
                        new bool[] { false, true, true }
                    },
                },
                //Initial board
                // 111|111|111
                // should become 
                // 101|001|011
                new object[] {
                    new bool[][]
                    {
                        new bool[] { true, true, true },
                        new bool[] { true, true, true },
                        new bool[] { true, true, true }
                    },
                    new bool[][]
                    {
                        new bool[] { true, false, true },
                        new bool[] { false, false, true },
                        new bool[] { false, true, true }
                    },
                },
            };

        [Theory]
        [MemberData(nameof(TestCases))]
        public void Play_To_Next_Generation(bool[][] initialBoard, bool[][] expectedBoard)
        {

            // Given
            bool[][] board = new bool[][]
            {
                new bool[] { false, false, false},
                new bool[] { false, false, false},
                new bool[] { false, false, false }
            };

            GameOfLife game = new GameOfLife(initialBoard);

            // When
            game.NextGen();

            // Then
            var actual = TransformBoard(game.Board.Grid);
            var expected = TransformBoard(expectedBoard);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Another_Test_Playing_To_The_Next_Generation()
        {
            // Given
            // 110011
            // 101010
            // 001010
            // 101011
            // 100110
            // 110100
            bool[][] grid = new bool[][]
            {
                new bool[] { true, true, false, false, true, true },
                new bool[] { true, false, true, false, true, false },
                new bool[] { false, false, true, false, true, false },
                new bool[] { true, false, true, false, true, true },
                new bool[] { true, false, false, true, true, false },
                new bool[] { true, true, false, true, false, false },
            };

            GameOfLife game = new GameOfLife(grid);

            // When
            game.NextGen();

            // Then
            // 110111
            // 101001
            // 001010
            // 101001
            // 100110
            // 111110
            bool[][] expectedBoard = new bool[][]
            {
                new bool[] { true, true, false, true, true, true},
                new bool[] { true, false, true, false, false, true },
                new bool[] { false, false, true, false, true, false },
                new bool[] { true, false, true, false, false, true },
                new bool[] { true, false, false, true, true, false },
                new bool[] { true, true, true, true, true, false },
            };

            var actual = TransformBoard(game.Board.Grid);
            var expected = TransformBoard(expectedBoard);
            Assert.Equal(expected, actual);
        }

        string TransformBoard(bool[][] board)
        {
            string data = string.Empty;

            data = string.Join('|', board
                .Select(ligne => 
                    string.Concat(ligne.Select(cell => cell ? "1" : "0").ToArray())
                ).ToArray());

            return data;
        }
    }
}
