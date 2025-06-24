using CRM.Domain.Interfaces.Base;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories.Base;

public class ReadRepository<TEntity>(CrmDbContext context) : IReadRepository<TEntity>
    where TEntity : class
{
    private readonly CrmDbContext _context = context ?? throw new NullReferenceException(nameof(context));
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct = default)
        => await _dbSet.ToListAsync(ct);

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _dbSet.FindAsync([id, ct], cancellationToken: ct);
}