using System.Collections.Generic;
using System.Linq;

namespace TriangleGeometricLayout.Controllers
{
    public static class RowMapper
    {
        private static readonly Dictionary<string, int> RowMappings = new Dictionary<string, int>
        {
            {"A", 0},
            {"B", 1},
            {"C", 2},
            {"D", 3},
            {"E", 4},
            {"F", 5},

        };

        public static int GetValue(string row) => RowMappings[row];

        public static bool ValidRow(string row) => RowMappings.ContainsKey(row);

        public static string GetKey(int value) => RowMappings.FirstOrDefault(x => x.Value == value).Key;
    }
}