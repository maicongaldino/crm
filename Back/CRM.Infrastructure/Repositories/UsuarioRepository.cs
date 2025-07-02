using CRM.Domain.Entities;
using CRM.Domain.Interfaces;
using CRM.Domain.ValueObjects;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories;

public class UsuarioRepository(CrmDbContext context) : IUsuarioRepository
{
    private readonly CrmDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly DbSet<Usuario> _dbSet = context.Set<Usuario>();

    public async Task AddAsync(Usuario entity, CancellationToken ct = default)
        => await _dbSet.AddAsync(entity, ct);

    public async Task<IEnumerable<Usuario>> GetAllAsync(CancellationToken ct = default)
        => await _dbSet.AsNoTracking().ToListAsync(ct);

    public async Task<Usuario?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _dbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Id == GuidId.Restaurar(id), cancellationToken: ct);

    public void Remove(Usuario entity, CancellationToken ct = default)
        => _dbSet.Remove(entity);

    public void Update(Usuario entity, CancellationToken ct = default)
        => _dbSet.Update(entity);

    public async Task SaveChangesAsync(CancellationToken ct = default)
        => await _context.SaveChangesAsync(ct);
}