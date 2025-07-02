using CRM.Application.Shared.UseCases.Abstractions;

namespace CRM.Application.Usuarios.UseCases.Create;

public abstract record CreateCommand(string Nome, string Email, string Cpf, string Senha) : ICommand;