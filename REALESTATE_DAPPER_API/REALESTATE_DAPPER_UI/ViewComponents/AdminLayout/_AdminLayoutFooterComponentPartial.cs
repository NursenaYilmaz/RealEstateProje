﻿using Microsoft.AspNetCore.Mvc;

namespace REALESTATE_DAPPER_UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
               return View();
        }
    }
}
