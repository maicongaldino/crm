using CRM.Application.Shared.Responses;
using CRM.Application.Usuarios.UseCases.Create;
using CRM.Application.Usuarios.UseCases.GetAll;
using CRM.Application.Usuarios.UseCases.GetById;
using CRM.Domain.Entities;

namespace CRM.Application.Usuarios.Mappings;

public static class UsuarioMappings
{
    public static CreateResponse ToCreateResponse(this Usuario usuario)
        => new(usuario.Id.Valor, usuario.Nome.Valor, usuario.Email.Valor);

    public static GetByIdResponse ToGetByIdResponse(this Usuario usuario)
        => new(usuario.Id.Valor, usuario.Nome.Valor, usuario.Email.Valor);

    public static GetAllResponse ToGetAllResponse(this Usuario usuario)
        => new(usuario.Id.Valor, usuario.Nome.Valor, usuario.Email.Valor);

    public static ListQueryResponse<GetAllResponse> ToListGetAllResponse(this IEnumerable<Usuario> usuarios)
    {
        var result = usuarios.Select(usuario => usuario.ToGetAllResponse());

        return new ListQueryResponse<GetAllResponse>(result);
    }
}