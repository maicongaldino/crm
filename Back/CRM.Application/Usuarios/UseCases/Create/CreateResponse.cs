using CRM.Application.Shared.UseCases.Abstractions;

namespace CRM.Application.Usuarios.UseCases.Create;

public record CreateResponse(Guid Id, string Nome, string Email) : IResponse;