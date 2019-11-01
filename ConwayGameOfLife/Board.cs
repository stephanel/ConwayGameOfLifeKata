using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayGameOfLife
{
    public class Board
    {
        int[][] RelativeAdjacentPosition = new int[][]
        {
            new int[] { -1, 0 },    // left
            new int[] { -1, -1 },   // top left
            new int[] { 0, -1 },    // top
            new int[] { 1, -1 },    // top right
            new int[] { 1, 0 },     // right
            new int[] { 1, 1 },     // bottom right
            new int[] { 0, 1 },     // bottom
            new int[] { -1, 1 }     // bottom left
        };

        public bool[][] Grid { get; private set; }

        public int Size
        {
            get
            {
                return Grid.Length;
            }
        }

        private Board(bool[][] grid)
        {
            Grid = grid;
        }

        public static Board BuildBoard(int size)
        {
            var board = new bool[size][];
            for (int x = 0; x < size; x++)
            {
                board[x] = new bool[size];
            }
            return new Board(board);
        }

        public static Board BuildBoard(bool[][] grid)
        {
            return new Board(grid);
        }

        public bool IsInsideBoard(Cell cell)
        {
            if (cell.X < 0 || cell.X >= this.Grid.Length)
            {
                return false;
            }
            if (cell.Y < 0 || cell.Y >= Grid[cell.X].Length)
            {
                return false;
            }

            return true;
        }

        public bool IsOutsideBoard(Cell cell)
        {
            return !IsInsideBoard(cell);
        }

        public bool IsAlive(Cell cell)
        {
            return Grid[cell.Y][cell.X] == true;
        }

        public bool IsDead(Cell cell)
        {
            return !IsAlive(cell);
        }

        public int CountNeighbours(Cell cell)
        {
            int neighboursCount = 0;

            foreach (var neighbourRelativeCoord in RelativeAdjacentPosition)
            {
                int xDelta = neighbourRelativeCoord[0];
                int yDelta = neighbourRelativeCoord[1];
                int xCoord = cell.X + xDelta;
                int yCoord = cell.Y + yDelta;

                Cell adjacentCell = new Cell(xCoord, yCoord);

                if (!IsInsideBoard(adjacentCell))
                {
                    continue;
                }

                if (IsAlive(adjacentCell))
                {
                    neighboursCount++;
                }
            }

            return neighboursCount;
        }
    }
}
