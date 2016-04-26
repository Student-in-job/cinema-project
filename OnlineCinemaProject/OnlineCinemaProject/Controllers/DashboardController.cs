using System.Web.Mvc;

namespace OnlineCinemaProject.Controllers
{
    [Authorize(Roles = "BilingManager, Admin, PRManager, ContentManager")]
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {
            return View();
        }
	}
}