using CRM.Application.Shared.Responses;
using CRM.Application.Shared.UseCases.Abstractions;
using CRM.Application.Usuarios.UseCases.Create;
using CRM.Application.Usuarios.UseCases.GetAll;
using CRM.Application.Usuarios.UseCases.GetById;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Application;

public static class ApplicationConfiguration
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateCommand, CreateResponse>, CreateCommandHandler>();
        services.AddScoped<IQueryHandler<GetByIdQuery, GetByIdResponse>, GetByIdHandler>();
        services.AddScoped<IQueryHandler<GetAllQuery, ListQueryResponse<GetAllResponse>>, GetAllHandler>();
    }
}