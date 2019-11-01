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
                new object[] {
                    "000|000|000",
                    "000|000|000"
                },
                new object[] {
                    "100|000|000",
                    "000|000|000"
                },
                new object[] {
                    "110|000|000",
                    "000|000|000"
                },
                new object[] {
                    "110|100|000",
                    "110|110|000"
                },
                new object[] {
                    "110|110|000",
                    "110|110|000"
                },
                new object[] {
                    "110|100|011",
                    "110|101|011",
                },
                new object[] {
                    "111|111|111",
                    "101|001|011",
                },
            };

        [Theory]
        [MemberData(nameof(TestCases))]
        public void Play_To_Next_Generation(string initialBoard, string expected)
        {

            // Given
            bool[][] grid = StringToArrayGridConverter.TransformToGridArray(initialBoard);

            GameOfLife game = new GameOfLife(grid);

            // When
            game.NextGen();

            // Then
            var actual = StringToArrayGridConverter.TransformBoard(game.Board.Grid);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Another_Test_Playing_To_The_Next_Generation()
        {
            // Given
            var gridAsString = "110011|101010|001010|101011|100110|110100";
            bool[][] grid = StringToArrayGridConverter.TransformToGridArray(gridAsString);
                
            GameOfLife game = new GameOfLife(grid);

            // When
            game.NextGen();

            // Then
            var actual = StringToArrayGridConverter.TransformBoard(game.Board.Grid);
            var expected = "110011|101010|001010|101011|100110|110100";
            Assert.Equal(expected, actual);
        }

    }
}
