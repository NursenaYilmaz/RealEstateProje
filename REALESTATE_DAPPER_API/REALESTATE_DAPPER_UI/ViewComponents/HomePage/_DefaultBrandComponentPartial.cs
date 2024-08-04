using Microsoft.AspNetCore.Mvc;

namespace REALESTATE_DAPPER_UI.viewcomponents.HomePage
{
    public class _DefaultBrandComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
