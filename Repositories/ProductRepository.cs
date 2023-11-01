using System.Data;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }
        public void UpdateOneProduct(Product entity)=>Update(entity);

        public void CreateProduct(Product product)=>CreateOneProduct(product);

        public void DeleteOneProduct(Product product)=>Delete(product);
        
        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public Product? GetOneProduct(int id, bool trackChanges)
        {
           return FindByCondition(p=> p.ProductId.Equals(id),trackChanges);
        }
    }
}