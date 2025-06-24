namespace CRM.Domain.Interfaces.Base;

public interface IAddRepository<in TEntity>
    where TEntity : class
{
    Task AddAsync(TEntity entity, CancellationToken ct = default);
}