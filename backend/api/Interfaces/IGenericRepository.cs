using System.Linq.Expressions;

namespace api.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> FindAllAsync();
        Task<ICollection<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);        
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(ICollection<T> entities);
        void RemoveRange(ICollection<T> entities);
    }
}
