namespace CRM.Domain.Interfaces.Base;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken ct = default);
}