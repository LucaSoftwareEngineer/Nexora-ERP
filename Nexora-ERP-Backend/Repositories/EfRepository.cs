using Microsoft.EntityFrameworkCore;
using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public abstract class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DevAziendaDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    protected EfRepository(DevAziendaDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(object[] keyValues, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(keyValues, cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FindAsync(keyValues, cancellationToken);
        if (entity is null)
        {
            return false;
        }

        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}