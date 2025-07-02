using CRM.Application.Shared.UseCases.Abstractions;

namespace CRM.Application.Usuarios.UseCases.GetById;

public record GetByIdQuery(Guid Id) : IQuery;