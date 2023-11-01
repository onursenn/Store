using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        void DeleteOneProduct(int id);
        IEnumerable<Product> GetAllProduct(bool trackChanges);
        Product? GetOneProduct(int id, bool trackChanges);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
        void ProductCreate(ProductDtoForInsertion productDto);
        void UpdateOneProduct(ProductDtoForUpdate productDto);
    }
}