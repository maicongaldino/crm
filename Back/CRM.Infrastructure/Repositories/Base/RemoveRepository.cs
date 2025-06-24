using CRM.Domain.Interfaces.Base;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories.Base;

public class RemoveRepository<TEntity>(CrmDbContext context) : IRemoveRepository<TEntity>
    where TEntity : class
{
    private readonly CrmDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public void Remove(TEntity entity, CancellationToken ct = default)
        => _dbSet.Remove(entity);
}