using Microsoft.AspNetCore.Mvc;

namespace REALESTATE_DAPPER_UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
