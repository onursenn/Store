using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers.DashboardController
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}