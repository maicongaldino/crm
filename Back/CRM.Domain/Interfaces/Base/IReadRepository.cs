namespace CRM.Domain.Interfaces.Base;

public interface IReadRepository<TEntity>
    where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct = default);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
}