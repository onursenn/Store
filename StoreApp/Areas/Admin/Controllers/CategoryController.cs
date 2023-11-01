using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers.CategoryController
{
    
    public class CategoryController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}