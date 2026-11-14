using Nexora_ERP_Backend.Repositories;
using Nexora_ERP_Backend.Services.Interfaces;

namespace Nexora_ERP_Backend.Services.Implementations;

public abstract class ReadOnlyService<TEntity>(IReadOnlyRepository<TEntity> repository) : IReadOnlyService<TEntity>
    where TEntity : class
{
    public Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return repository.GetAllAsync(cancellationToken);
    }
}