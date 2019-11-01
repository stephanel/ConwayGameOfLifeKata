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

        public Board Board { get; private set; }

        public GameOfLife(bool[][] grid)
        {
            this.Board = Board.BuildBoard(grid);
        }

        public void NextGen()
        {
            for(int x = 0; x < Board.Size; x++)
            {
                for (int y = 0; y < Board.Grid[x].Length; y++)
                {
                    Cell cell = new Cell(x, y);

                    int neighboursCount = Board.CountNeighbours(cell);

                    if(neighboursCount < 2 || neighboursCount > 3)
                    {
                        Board.Grid[x][y] = false;
                    }
                    else if(Board.IsDead(cell))
                    {
                        Board.Grid[x][y] = neighboursCount == 3;
                    } 
                    else
                    {
                        Board.Grid[x][y] = neighboursCount >= 2 && neighboursCount <= 3;
                    }
                }
            }
        }
    }
}
