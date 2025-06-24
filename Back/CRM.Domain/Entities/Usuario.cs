using CRM.Domain.Interfaces;
using CRM.Domain.ValueObjects;

namespace CRM.Domain.Entities;

public class Usuario
{
    public GuidId Id { get; init; }
    public Nome Nome { get; init; }
    public Email Email { get; init; }
    public Cpf Cpf { get; init; }
    public Senha Senha { get; init; }

    public Usuario(GuidId id, Nome nome, Email email, Cpf cpf, Senha senha)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(nome);
        ArgumentNullException.ThrowIfNull(email);
        ArgumentNullException.ThrowIfNull(cpf);
        ArgumentNullException.ThrowIfNull(senha);

        Id = id;
        Nome = nome;
        Email = email;
        Cpf = cpf;
        Senha = senha;
    }

    // Construtor protegido para o EF Core
    protected Usuario()
    {
    }

    public static Usuario Criar(IGuidGenerator guidGenerator, string nome, string email, string cpf, string senha)
    {
        var guidIdResult = GuidId.Criar(guidGenerator);
        var nomeResult = Nome.Criar(nome);
        var emailResult = Email.Criar(email);
        var cpfResult = Cpf.Criar(cpf);
        var senhaResult = Senha.Criar(senha);

        return new Usuario(guidIdResult, nomeResult, emailResult, cpfResult, senhaResult);
    }
}