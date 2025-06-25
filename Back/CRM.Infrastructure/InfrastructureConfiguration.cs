using CRM.Domain.Interfaces;
using CRM.Infrastructure.Data;
using CRM.Infrastructure.Repositories;
using CRM.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Infrastructure;

public static class InfrastructureConfiguration
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CrmDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IGuidGenerator, GuidGenerator>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }
}