using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using TriangleGeometricLayout.BLL;

namespace TriangleGeometricLayout.Controllers
{
    public class PointsController : ApiController
    {
        // GET api/values/5
        public string Get(string row, int column)
        {
            row = row.ToUpper();
            var rowIsValid = InputValidator.RowIsValid(row);
            var columnIsValid = InputValidator.ColumnIsValid(column);

            if (!rowIsValid || !columnIsValid)
            {
                StringBuilder sb = new StringBuilder();
                if (!rowIsValid)
                    sb.AppendLine($"Row: {row} is not a valid value - restrict request to A-F");
                if (!columnIsValid)
                    sb.AppendLine($"Column: {column} is not a valid value - restrict request to 1-12");
                throw new HttpException(400, sb.ToString());

            }

            var triangle = TriangleCalculator.CalculateTriangle(row, column);
            var result = JsonConvert.SerializeObject(triangle);

            return result;
        }
    }
}