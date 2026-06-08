using CouponModule.Domain.Shared;
using CouponModule.Domain.Shared.Abstraction;
using CouponModule.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CouponModule.Infrastructure.Shared.Repository
{
    public class BaseRepository<TEntity> : Domain.Shared.Abstraction.IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(i =>
            i.Id.Equals(id));
        }

        public async Task<TEntity> GetFilterAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public async Task<List<TEntity>> GetLisByFilterAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<bool> RemoveExpressionAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = await _context.Set<TEntity>().Where(expression).ToListAsync();
                _context.Set<TEntity>().RemoveRange(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
