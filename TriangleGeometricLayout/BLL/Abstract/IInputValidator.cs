namespace TriangleGeometricLayout.BLL.Abstract
{
    /// <summary> Interface for input validator. </summary>
    public interface IInputValidator
    {
        /// <summary> Check the value of a column for validity. </summary>
        ///
        /// <param name="colum"> The colum value. </param>
        ///
        /// <returns> True if it succeeds, false if it fails. </returns>
        bool ColumnIsValid(int colum);

        /// <summary> Checks the value of a row for validity. </summary>
        ///
        /// <param name="row"> The row. </param>
        ///
        /// <returns> True if it succeeds, false if it fails. </returns>
        bool RowIsValid(string row);
    }
}