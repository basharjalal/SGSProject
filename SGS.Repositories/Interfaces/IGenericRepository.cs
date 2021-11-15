using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SGS.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entites);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entites);
        void Update(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filterPredicate);
        Task<int> SaveChangesAsync();

    }
}
