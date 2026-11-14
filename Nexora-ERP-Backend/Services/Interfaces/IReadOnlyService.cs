namespace Nexora_ERP_Backend.Services.Interfaces;

public interface IReadOnlyService<TEntity> where TEntity : class
{
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
}