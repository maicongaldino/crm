using CRM.Domain.Interfaces;
using CRM.Domain.ValueObjects;

namespace CRM.Domain.Entities;

public class Usuario
{
    private GuidId Id { get; set; }
    private Nome Nome { get; set; }
    private Email Email { get; set; }
    private Cpf Cpf { get; set; }
    private Senha Senha { get; set; }

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