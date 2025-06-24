using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace CRM.Infrastructure.Data;

public class CrmDbContextFactory : IDesignTimeDbContextFactory<CrmDbContext>
{
    public CrmDbContext CreateDbContext(string[] args)
    {
        // Configuração robusta para encontrar o appsettings.json
        var solutionRoot = Directory.GetCurrentDirectory();
        var appSettingsPath = Path.Combine(solutionRoot, "appsettings.json");

        if (!File.Exists(appSettingsPath))
        {
            solutionRoot = Path.Combine(Directory.GetCurrentDirectory(), "..", "CRM.Api");
        }

        // Configuração com fallbacks
        var configuration = new ConfigurationBuilder()
            .SetBasePath(solutionRoot)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile(
                $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json",
                optional: true)
            .Add(new EnvironmentVariablesConfigurationSource()) // Forma alternativa
            .Build();

        // Obtenção segura da connection string
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("Connection string not found");

        // Criação do DbContext com resolução de ambiguidade
        var optionsBuilder = new DbContextOptionsBuilder<CrmDbContext>();
        optionsBuilder.UseSqlServer(connectionString, sqlServerOptions =>
        {
            // Configurações adicionais opcionais
            sqlServerOptions.EnableRetryOnFailure();
        });

        return new CrmDbContext(optionsBuilder.Options);
    }
}