using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public CategoriesMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _manager.CategoryService.GetAllCategory(false);
            return View(categories);
        }
    }
}