namespace Wallet.Domain.SeedWork;

public interface IRepository<T,in TId>
    where T : Entity<TId> 
    where TId : struct
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(TId id);
    Task UpdateAsync(T entity);
    Task AddAsync(T entity);
    Task DeleteAsync(TId id);
    Task SaveAsync(); 
}