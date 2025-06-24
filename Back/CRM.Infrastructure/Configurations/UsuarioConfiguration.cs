using CRM.Domain.Entities;
using CRM.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasConversion(
                id => id.ToString(), // VO → string/Guid para salvar no banco
                valor => GuidId.Restaurar(Guid.Parse(valor)) // string/Guid → VO
            )
            .HasColumnName(nameof(Usuario.Id))
            .IsRequired();

        // Configura VO Nome
        builder.OwnsOne(u => u.Nome, nome
            =>
        {
            nome.Property(n => n.Valor)
                .HasColumnName(nameof(Usuario.Nome))
                .IsRequired();
        });

        // Configura VO Email
        builder.OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Valor)
                .HasColumnName(nameof(Usuario.Email))
                .IsRequired();
        });

        // Configura VO Cpf
        builder.OwnsOne(u => u.Cpf, cpf
            =>
        {
            cpf.Property(n => n.Valor)
                .HasColumnName(nameof(Usuario.Cpf))
                .IsRequired();
        });

        // Configura VO Senha
        builder.OwnsOne(u => u.Senha, senha
            =>
        {
            senha.Property(n => n.Valor)
                .HasColumnName(nameof(Usuario.Senha))
                .IsRequired();
        });
    }
}