using Microsoft.AspNetCore.Mvc;

namespace REALESTATE_DAPPER_UI.viewcomponents.HomePage
{
    public class _DefaultFeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
