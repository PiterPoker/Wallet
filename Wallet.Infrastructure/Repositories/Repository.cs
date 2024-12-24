using Microsoft.EntityFrameworkCore;
using Wallet.Domain.SeedWork;

namespace Wallet.Infrastructure.Repositories;

public class Repository<T, TId> : IRepository<T, TId>
    where T : Entity<TId>
    where TId : struct
{
    private readonly WalletDBContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(WalletDBContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(TId id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(TId id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is not null)
            _dbSet.Remove(entity);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
