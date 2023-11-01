using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
       private readonly IProductService _productService;
       private readonly ICategoryService _categoryService;
        public ServiceManager(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public ICategoryService CategoryService =>_categoryService;
        public IProductService ProductService => _productService;
    }
}