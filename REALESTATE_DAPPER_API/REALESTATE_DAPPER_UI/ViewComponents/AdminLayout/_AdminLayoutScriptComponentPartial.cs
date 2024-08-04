using Microsoft.AspNetCore.Mvc;

namespace REALESTATE_DAPPER_UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
