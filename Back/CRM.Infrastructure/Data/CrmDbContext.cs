using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Data;

public class CrmDbContext(DbContextOptions<CrmDbContext> options) : DbContext(options)
{
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrmDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}