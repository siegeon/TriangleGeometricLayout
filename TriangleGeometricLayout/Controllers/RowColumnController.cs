using System.Web.Http;
using TriangleGeometricLayout.BLL;


namespace TriangleGeometricLayout.Controllers
{
    public class RowColumnController : ApiController
    {
        private int AccountForGUIScale(int i) => i > 0 ? i/50*10 : i;

        // GET api/values/5
        public string Get(int x1, int y1, int x2, int y2,int x3, int y3)
        {


            var p1 = new Point(AccountForGUIScale(x1), AccountForGUIScale(y1));
            var p2 = new Point(AccountForGUIScale(x2), AccountForGUIScale(y2));
            var p3 = new Point(AccountForGUIScale(x3), AccountForGUIScale(y3));

            
            return TriangleCalculator.GetRowColumn(p1, p2, p3);
        }
    }
}