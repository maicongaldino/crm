using CRM.Application.Shared.Responses;
using CRM.Application.Shared.UseCases.Abstractions;
using CRM.Application.Usuarios.Mappings;
using CRM.Domain.Interfaces;

namespace CRM.Application.Usuarios.UseCases.GetAll;

public class GetAllHandler(IUsuarioRepository repository)
    : IQueryHandler<GetAllQuery, ListQueryResponse<GetAllResponse>>
{
    public async Task<ListQueryResponse<GetAllResponse>> HandleAsync(GetAllQuery query)
    {
        var result = await repository.GetAllAsync();

        return result.ToListGetAllResponse();
    }
}