using TriangleGeometricLayout.BLL.Abstract;
using TriangleGeometricLayout.BLL.Mappers;

namespace TriangleGeometricLayout.BLL.Concrete
{
    /// <summary> With more time I would have created this as a injectable dependency. </summary>
    public class InputValidator : IInputValidator
    {
        public bool RowIsValid(string row) => RowMapper.ValidRow(row);
        public bool ColumnIsValid(int colum) => colum > 0 && colum < 13;
    }
}