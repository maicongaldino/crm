namespace CRM.Domain.Interfaces.Base;

public interface IRemoveRepository<in TEntity>
    where TEntity : class
{
    void Remove(TEntity entity, CancellationToken ct = default);
}