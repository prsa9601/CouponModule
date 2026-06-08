using System.Linq.Expressions;

namespace CouponModule.Domain.Shared.Abstraction
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
        Task<bool> RemoveExpressionAsync(Expression<Func<TEntity, bool>> expression);
        Task<List<TEntity>> GetLisByFilterAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetFilterAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetListAsync();
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
