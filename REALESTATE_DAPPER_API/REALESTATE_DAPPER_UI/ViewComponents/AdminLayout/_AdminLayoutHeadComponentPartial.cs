using Microsoft.AspNetCore.Mvc;

namespace REALESTATE_DAPPER_UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
