using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace ConwayGameOfLife
{
    [DebuggerDisplay("{X};{Y}")]
    public class Cell
    {
        public static readonly Cell TopLeft = new Cell(0, 0);
        public static readonly Cell MiddleCenter = new Cell(1, 1);

        int[][] Neighbours = new int[][]
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

        public int X { get; private set; }
        public int Y { get; private set; }

        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int CountNeighbours(bool[][] board)
        {
            int neighboursCount = 0;

            foreach (var neighbourRelativeCoord in Neighbours)
            {
                int xDelta = neighbourRelativeCoord[0];
                int yDelta = neighbourRelativeCoord[1];
                int xCoord = X + xDelta;
                int yCoord = Y + yDelta;

                Cell adjacentCell = new Cell(xCoord, yCoord);

                if(!adjacentCell.IsInsideBoard(board))
                {
                    continue;
                }

                if (adjacentCell.IsAlive(board))
                {
                    neighboursCount++;
                }
            }

            return neighboursCount;
        }

        public bool IsAlive(bool[][] board)
        {
            return board[X][Y] == true;
        }

        public bool IsInsideBoard(bool[][] board)
        {
            if (X < 0 || X >= board.Length)
            {
                return false;
            }
            if (Y < 0 || Y >= board[X].Length)
            {
                return false;
            }

            return true;
        }


    }
}
