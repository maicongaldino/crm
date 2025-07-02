using CRM.Application.Shared.Exceptions;
using CRM.Application.Shared.UseCases.Abstractions;
using CRM.Application.Usuarios.Mappings;
using CRM.Domain.Interfaces;

namespace CRM.Application.Usuarios.UseCases.GetById;

public class GetByIdHandler(IUsuarioRepository repository) : IQueryHandler<GetByIdQuery, GetByIdResponse>
{
    public async Task<GetByIdResponse> HandleAsync(GetByIdQuery query)
    {
        var result = await repository.GetByIdAsync(query.Id);

        if (result is null)
            throw new NotFoundException($"Usuário com ID {query.Id} não encontrado.");

        return result.ToGetByIdResponse();
    }
}