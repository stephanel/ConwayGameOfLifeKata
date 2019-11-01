using System.Linq;

namespace ConwayGameOfLifeKataTests
{
    public class StringToArrayGridConverter
    {
        public static bool[][] TransformToGridArray(string readableGrid)
        {
            return readableGrid.Split("|")
                .Select(row => row.Select(cell => cell == '1' ? true : false).ToArray())
                .ToArray();
        }

        public static string TransformBoard(bool[][] board)
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
