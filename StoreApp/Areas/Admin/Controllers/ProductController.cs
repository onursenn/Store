using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entities.Dtos;

namespace StoreApp.Areas.Admin.Controllers.ProductController
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProduct(false);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = string.Concat("/images/", file.FileName);
                _manager.ProductService.ProductCreate(productDto);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }
        public SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategory(false), "CategoryId", "CategoryName", "1");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();

            var model = _manager.ProductService.GetOneProductForUpdate(id, false);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            productDto.ImageUrl = string.Concat("/images/", file.FileName);
            _manager.ProductService.UpdateOneProduct(productDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);

            return RedirectToAction("Index");
        }

    }
}