using Microsoft.EntityFrameworkCore;
using SGS.Domain.Entities;
using SGS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SGS.Repositories.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        protected readonly SGSDbContext _dbcontext;
        public GenericRepository(SGSDbContext context)
        {
            _dbcontext = context;
            _dbSet = _dbcontext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entites)
        {
            await _dbSet.AddRangeAsync(entites);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filterPredicate)
        {
            return await _dbSet.Where(filterPredicate).FirstOrDefaultAsync();

        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }


        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entites)
        {
            _dbSet.RemoveRange(entites);
        }
        public  void Update(TEntity entity)
        {
           _dbSet.Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }
    }
}
