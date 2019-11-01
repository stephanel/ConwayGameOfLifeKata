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
            int size = Board.Size;

            for(int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Cell cell = new Cell(x, y);

                    Board.Grid[x][y] = CalculateNewState(cell, Board.CountNeighbours(cell));
                }
            }
        }

        bool CalculateNewState(Cell cell, int neighboursCount)
        {
            if(Board.IsAlive(cell) && (neighboursCount == 2 || neighboursCount == 3))
            {
                return true;
            }

            if (Board.IsDead(cell) && neighboursCount == 3)
            {
                return true;
            }

            return false;
        }
    }
}
