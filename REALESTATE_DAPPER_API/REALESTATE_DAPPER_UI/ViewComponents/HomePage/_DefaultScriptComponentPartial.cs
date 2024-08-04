using Microsoft.AspNetCore.Mvc;

namespace REALESTATE_DAPPER_UI.viewcomponents.HomePage
{
    public class _DefaultScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
