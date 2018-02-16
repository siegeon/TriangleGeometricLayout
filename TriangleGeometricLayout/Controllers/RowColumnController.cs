using System.Web.Http;
using TriangleGeometricLayout.BLL.Abstract;

namespace TriangleGeometricLayout.Controllers
{
    public class RowColumnController : ApiController
    {
        private readonly ITriangleCalculator _triangleCalculator;

        public RowColumnController(ITriangleCalculator triangleCalculator)
        {
            _triangleCalculator = triangleCalculator;
        }

        int AccountForGuiScale(int i) => 
            i > 0 ? i / 50 * 10 : i;

        // GET api/values/5
        public string Get(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            var p1 = new Point(AccountForGuiScale(x1), AccountForGuiScale(y1));
            var p2 = new Point(AccountForGuiScale(x2), AccountForGuiScale(y2));
            var p3 = new Point(AccountForGuiScale(x3), AccountForGuiScale(y3));

            return _triangleCalculator.GetRowColumn(p1, p2, p3);
        }
    }
}