using CRM.Application.Shared.UseCases.Abstractions;
using CRM.Application.Usuarios.Mappings;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces;

namespace CRM.Application.Usuarios.UseCases.Create;

public class CreateCommandHandler(IUsuarioRepository usuarioRepository, IGuidGenerator guidGenerator)
    : ICommandHandler<CreateCommand, CreateResponse>
{
    public async Task<CreateResponse> HandleAsync(CreateCommand createCommand)
    {
        var usuarioResult = Usuario.Criar(guidGenerator, createCommand.Nome, createCommand.Email, createCommand.Cpf,
            createCommand.Senha);

        await usuarioRepository.AddAsync(usuarioResult);
        await usuarioRepository.SaveChangesAsync();

        return usuarioResult.ToCreateResponse();
    }
}