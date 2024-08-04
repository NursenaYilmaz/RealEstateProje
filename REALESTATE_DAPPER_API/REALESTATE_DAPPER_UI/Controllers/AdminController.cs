using Microsoft.AspNetCore.Mvc;

namespace REALESTATE_DAPPER_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
