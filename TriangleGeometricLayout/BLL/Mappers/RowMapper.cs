using System.Collections.Generic;
using System.Linq;

namespace TriangleGeometricLayout.BLL.Mappers
{
    /// <summary> A row mapper. </summary>
    public class RowMapper
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

        private RowMapper() {}

        /// <summary> Gets the value for a row, not case sensitive. </summary>
        ///
        /// <param name="row"> The row. </param>
        ///
        /// <returns> The value for a row </returns>
        public static int GetValue(string row) => 
            RowMappings[row.ToUpperInvariant()];

        /// <summary> Checks if a row value is valid. </summary>
        ///
        /// <param name="row"> The row value. </param>
        ///
        /// <returns> True if it succeeds, false if it fails. </returns>
        public static bool ValidRow(string row) => 
            RowMappings.ContainsKey(row.ToUpperInvariant());

        /// <summary> Gets the first instance of row for a value. </summary>
        ///
        /// <param name="value"> The value. </param>
        ///
        /// <returns> The key. </returns>
        public static string GetKey(int value) => 
            RowMappings.FirstOrDefault(x => x.Value == value).Key;
    }
}