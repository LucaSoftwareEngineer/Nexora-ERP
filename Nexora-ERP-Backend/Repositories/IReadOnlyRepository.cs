namespace Nexora_ERP_Backend.Repositories;

public interface IReadOnlyRepository<TEntity> where TEntity : class
{
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
}