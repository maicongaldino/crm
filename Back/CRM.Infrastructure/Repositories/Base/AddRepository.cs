using CRM.Domain.Interfaces.Base;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories.Base;

public class AddRepository<TEntity>(CrmDbContext context) : IAddRepository<TEntity>
    where TEntity : class
{
    private readonly CrmDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task AddAsync(TEntity entity, CancellationToken ct = default)
        => await _dbSet.AddAsync(entity, ct);
}