using TriangleGeometricLayout.Controllers;

namespace TriangleGeometricLayout.BLL
{
    /// <summary> With more time I would have created this as a injectable dependency. </summary>
    public static class InputValidator
    {
        public static bool RowIsValid(string row) => RowMapper.ValidRow(row);
        public static bool ColumnIsValid(int colum) => colum > 0 && colum < 13;
    }
}