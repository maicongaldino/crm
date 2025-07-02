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
                id => id.Valor, //GuidId → Guid
                guid => GuidId.Restaurar(guid) // Guid → GuidId
            )
            .HasColumnName(nameof(Usuario.Id))
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        // Configura VO Nome
        builder.OwnsOne(u => u.Nome, nome
            =>
        {
            nome.Property(n => n.Valor)
                .HasColumnName(nameof(Usuario.Nome))
                .HasColumnType("varchar(255)")
                .IsRequired();
        });

        // Configura VO Email
        builder.OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Valor)
                .HasColumnName(nameof(Usuario.Email))
                .HasColumnType("varchar(320)") // max length RFC para emails
                .IsRequired();
        });

        // Configura VO Cpf
        builder.OwnsOne(u => u.Cpf, cpf
            =>
        {
            cpf.Property(n => n.Valor)
                .HasColumnName(nameof(Usuario.Cpf))
                .HasColumnType("char(11)")
                .IsRequired();
        });

        // Configura VO Senha
        builder.OwnsOne(u => u.Senha, senha
            =>
        {
            senha.Property(n => n.Valor)
                .HasColumnName(nameof(Usuario.Senha))
                .HasColumnType("varchar(256)")
                .IsRequired();
        });
    }
}