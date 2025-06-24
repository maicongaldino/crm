using CRM.Domain.Interfaces.Base;
using CRM.Infrastructure.Data;

namespace CRM.Infrastructure.Repositories.Base;

public class UnitOfWork<TEntity>(CrmDbContext context) : IUnitOfWork
    where TEntity : class
{
    private readonly CrmDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task SaveChangesAsync(CancellationToken ct = default)
        => await _context.SaveChangesAsync(ct);
}