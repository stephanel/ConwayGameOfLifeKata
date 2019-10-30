using System;

namespace ConwayGameOfLife
{
    public class GameOfLife
    {
        int[][] Neighbours = new int[][]
        {
            new int[] { -1, 0 },
            new int[] { -1, -1 },
            new int[] { 0, -1 },
            new int[] { 1, -1 },
            new int[] { 1, 0 },
            new int[] { 1, 1 },
            new int[] { 0, 1 },
            new int[] { 1, -1 }
        };

        public bool[][] Board { get; private set; }

        public GameOfLife(bool[][] board)
        {
            this.Board = board;
        }

        public void NextGen()
        {
            for(int x = 0; x < Board.Length; x++)
            {
                for (int y = 0; y < Board[x].Length; y++)
                {
                    Cell cell = new Cell(x, y);

                    int neighboursCount = cell.CountNeighbours(Board);

                    if (Board[x][y] = true && neighboursCount >= 2 && neighboursCount <= 3)
                    {
                        Board[x][y] = true;
                    } 
                    else if (Board[x][y] = false && neighboursCount == 3)
                    {
                        Board[x][y] = true;
                    }
                    else
                    {
                        Board[x][y] = false;
                    }
                }
            }
        }

        public static bool[][] BuildBoard(int size)
        {
            var board = new bool[size][];
            for(int x = 0; x < size; x++)
            {
                board[x] = new bool[size];
            }
            return board;
        }
    }
}
