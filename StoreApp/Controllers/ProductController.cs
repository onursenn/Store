using Microsoft.AspNetCore.Mvc;
using Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;


namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var list = _manager.ProductService.GetAllProduct(false);
            return View(list);
        }
        public IActionResult Get(int id)
        {
            var model = _manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }
    }
}