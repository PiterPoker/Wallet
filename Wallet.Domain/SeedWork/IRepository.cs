namespace Wallet.Domain.SeedWork;

public interface IRepository<TEntity,in TId>
    where TEntity : Entity<TId> 
    where TId : struct
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetByIdAsync(TId id);
    Task UpdateAsync(TEntity entity);
    Task AddAsync(TEntity entity);
    Task DeleteAsync(TId id);
    Task SaveAsync();
}