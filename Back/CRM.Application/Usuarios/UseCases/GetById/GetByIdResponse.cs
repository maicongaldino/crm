using CRM.Application.Shared.UseCases.Abstractions;

namespace CRM.Application.Usuarios.UseCases.GetById;

public record GetByIdResponse(Guid Id, string Nome, string Email) : IQueryResponse;