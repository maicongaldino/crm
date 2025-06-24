using CRM.Domain.Interfaces.Base;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories.Base;

public class UpdateRepository<TEntity>(CrmDbContext context) : IUpdateRepository<TEntity>
    where TEntity : class
{
    private readonly CrmDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public void Update(TEntity entity, CancellationToken ct = default)
        => _dbSet.Update(entity);
}