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
        public void GoToNextGeneration(bool[][] initialBoard, bool[][] expectedBoard)
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

        // TODO Live_When_Cell_Have_Two_Or_Three_Live_Neighbours
        // TODO Die_When_Game_Is_Overcrowding
        // TODO Live_When_Cell_Is_Dead_ANd_Have_Exactly_Three_Live_Neighbours


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
