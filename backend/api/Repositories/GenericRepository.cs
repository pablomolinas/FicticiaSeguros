using api.DataContext;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Repositories
{  
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected AppDbContext _dbContext { get; set; }
        protected DbSet<T> dbSet;
        public GenericRepository(AppDbContext _dbContext)
        {
            _dbContext = _dbContext;
            dbSet = _dbContext.Set<T>();
        }
        public async Task<ICollection<T>> FindAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<ICollection<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);                        
        }        
    }
}
