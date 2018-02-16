using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using TriangleGeometricLayout.BLL;
using TriangleGeometricLayout.BLL.Abstract;
using TriangleGeometricLayout.BLL.Concrete;

namespace TriangleGeometricLayout.Controllers
{
    public class PointsController : ApiController
    {
        private readonly IInputValidator _inputValidator;
        private readonly ITriangleCalculator _triangleCalculator;

        public PointsController(IInputValidator inputValidator, ITriangleCalculator triangleCalculator)
        {
            _inputValidator = inputValidator;
            _triangleCalculator = triangleCalculator;
        }
        // GET api/values/5
        public string Get(string row, int column)
        {
            var rowIsValid = _inputValidator.RowIsValid(row);
            var columnIsValid = _inputValidator.ColumnIsValid(column);

            if (!rowIsValid || !columnIsValid)
            {
                var sb = new StringBuilder();
                if (!rowIsValid)
                    sb.AppendLine($"Row: {row} is not a valid value - restrict request to A-F");
                if (!columnIsValid)
                    sb.AppendLine($"Column: {column} is not a valid value - restrict request to 1-12");
                throw new HttpException(400, sb.ToString());

            }

            return JsonConvert.SerializeObject(_triangleCalculator.CalculateTriangle(row, column));
        }
    }
}