using CRM.Application.Shared.Responses;
using CRM.Application.Shared.UseCases.Abstractions;
using CRM.Application.Usuarios.UseCases.Create;
using CRM.Application.Usuarios.UseCases.GetAll;
using CRM.Application.Usuarios.UseCases.GetById;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Extensions;

public static class UsuarioEndpoints
{
    public static IEndpointRouteBuilder MapUsuarioEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/usuario/",
            async ([FromServices] IQueryHandler<GetAllQuery, ListQueryResponse<GetAllResponse>> handler)
                =>
            {
                var result = await handler.HandleAsync(new GetAllQuery());

                return result.Items.Any()
                    ? Results.Ok(result.Items)
                    : Results.NoContent();
            });

        app.MapGet("/v1/usuario/{id:guid}",
            async (Guid id, [FromServices] IQueryHandler<GetByIdQuery, GetByIdResponse> handler)
                =>
            {
                var query = new GetByIdQuery(id);
                var result = await handler.HandleAsync(query);

                return Results.Ok(result);
            });

        app.MapPost("/v1/usuario", async (CreateCommand command,
                [FromServices] ICommandHandler<CreateCommand, CreateResponse> handler)
            =>
        {
            var result = await handler.HandleAsync(command);

            return Results.Created("/v1/usuario", result);
        });

        return app;
    }
}