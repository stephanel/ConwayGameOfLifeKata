using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayGameOfLifeKataTests.TestCases
{
    public class CellTestCases
    {
        //public static bool[][] GetBoard3x3(params object[] )
        //{
        //    var board = new bool[][]
        //    {
        //        new bool[] { true, false, false },
        //        new bool[] { false, false, false },
        //        new bool[] { false, false, false }
        //    };
        //}


        // 1|0|0
        // 0|0|0
        // 0|0|0
        public static bool[][] TopLeft = new bool[][]
        {
            new bool[] { true, false, false },
            new bool[] { false, false, false },
            new bool[] { false, false, false }
        };

        // 0|1|0
        // 0|0|0
        // 0|0|0
        public static bool[][] TopCenter = new bool[][]
        {
            new bool[] { false, true, false },
            new bool[] { false, false, false },
            new bool[] { false, false, false }
        };

        // 0|0|1
        // 0|0|0
        // 0|0|0
        public static bool[][] TopRight = new bool[][]
        {
            new bool[] { false, false, true },
            new bool[] { false, false, false },
            new bool[] { false, false, false }
        };

        // 0|0|0
        // 1|0|0
        // 0|0|0
        public static bool[][] MiddleLeft = new bool[][]
        {
            new bool[] { false, false, false },
            new bool[] { true, false, false },
            new bool[] { false, false, false }
        };

        // 0|0|0
        // 0|1|0
        // 0|0|0
        public static bool[][] MiddleCenter = new bool[][]
        {
            new bool[] { false, false, false },
            new bool[] { false, true, false },
            new bool[] { false, false, false }
        };

        // 0|0|0
        // 0|0|1
        // 0|0|0
        public static bool[][] MiddleRight = new bool[][]
        {
            new bool[] { false, false, false },
            new bool[] { false, false, true },
            new bool[] { false, false, false }
        };

        // 0|0|0
        // 0|0|0
        // 1|0|0
        public static bool[][] BottomLeft = new bool[][]
        {
            new bool[] { false, false, false },
            new bool[] { false, false, false },
            new bool[] { true, false, false }
        };

        // 0|0|0
        // 0|0|0
        // 0|1|0
        public static bool[][] BottomCenter = new bool[][]
        {
            new bool[] { false, false, false },
            new bool[] { false, false, false },
            new bool[] { false, true, false }
        };

        // 0|0|0
        // 0|0|0
        // 0|0|1
        public static bool[][] BottomRight = new bool[][]
        {
            new bool[] { false, false, false },
            new bool[] { false, false, false },
            new bool[] { false, false, true }
        };
    }
}
