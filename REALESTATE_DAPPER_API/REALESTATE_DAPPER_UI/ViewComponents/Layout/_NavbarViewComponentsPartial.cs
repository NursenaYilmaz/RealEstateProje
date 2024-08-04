using Microsoft.AspNetCore.Mvc;

namespace REALESTATE_DAPPER_UI.viewcomponents.Layout
{
    public class _NavbarViewComponentsPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
