using CRM.Application.Shared.UseCases.Abstractions;

namespace CRM.Application.Usuarios.UseCases.GetAll;

public record GetAllResponse(Guid Id, string Nome, string Email) : IQueryResponse;