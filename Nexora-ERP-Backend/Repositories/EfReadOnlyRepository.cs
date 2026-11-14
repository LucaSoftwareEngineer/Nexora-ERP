using Microsoft.EntityFrameworkCore;
using Nexora_ERP_Backend.Models;

namespace Nexora_ERP_Backend.Repositories;

public abstract class EfReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;

    protected EfReadOnlyRepository(DevAziendaDbContext dbContext)
    {
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }
}