namespace CRM.Domain.Interfaces.Base;

public interface IUpdateRepository<in TEntity>
    where TEntity : class
{
    void Update(TEntity entity, CancellationToken ct = default);
}