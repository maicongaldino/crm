using CRM.Domain.Interfaces;
using CRM.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Infrastructure;

public static class InfrastructureConfiguration
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IGuidGenerator, GuidGenerator>();
    }
}