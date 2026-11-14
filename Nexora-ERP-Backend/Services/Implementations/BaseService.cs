using Nexora_ERP_Backend.Repositories;
using Nexora_ERP_Backend.Services.Interfaces;

namespace Nexora_ERP_Backend.Services.Implementations;

public abstract class BaseService<TEntity>(IRepository<TEntity> repository) : IBaseService<TEntity>
    where TEntity : class
{
    public Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return repository.GetAllAsync(cancellationToken);
    }

    public Task<TEntity?> GetByIdAsync(object[] keyValues, CancellationToken cancellationToken = default)
    {
        return repository.GetByIdAsync(keyValues, cancellationToken);
    }

    public Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return repository.AddAsync(entity, cancellationToken);
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return repository.UpdateAsync(entity, cancellationToken);
    }

    public Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default)
    {
        return repository.DeleteAsync(keyValues, cancellationToken);
    }
}