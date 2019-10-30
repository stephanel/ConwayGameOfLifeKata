using ConwayGameOfLife;
using Xunit;

namespace ConwayGameOfLifeKataTests
{
    public class GoToNextGenerationFeature
    {
        public static object[][] TestCases =>
            new object[][]
            {
                //Initial board
                // 0|0|0
                // 0|0|0
                // 0|0|0
                // should become 
                // 0|0|0
                // 0|0|0
                // 0|0|0
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
                // 1|0|0
                // 0|0|0
                // 0|0|0
                // should become 
                // 0|0|0
                // 0|0|0
                // 0|0|0
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
                // 1|1|0
                // 0|0|0
                // 0|0|0
                // should become 
                // 0|0|0
                // 0|0|0
                // 0|0|0
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
                // 1|1|0
                // 1|0|0
                // 0|0|0
                // should become 
                // 1|1|0
                // 1|0|0
                // 0|0|0
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
                        new bool[] { true, false, false },
                        new bool[] { false, false, false }
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
            Assert.Equal(expectedBoard, game.Board);
        }


        // TODO Live_When_Cell_Have_Two_Or_Three_Live_Neighbours
        // TODO Die_When_Game_Is_Overcrowding
        // TODO Live_When_Cell_Is_Dead_ANd_Have_Exactly_Three_Live_Neighbours

    }
}
