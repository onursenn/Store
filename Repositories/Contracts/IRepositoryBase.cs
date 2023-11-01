using System.Linq.Expressions;
namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void CreateOneProduct(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}