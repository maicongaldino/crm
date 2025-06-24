using CRM.Domain.Interfaces;

namespace CRM.Domain.ValueObjects;

public class GuidId
{
    public Guid Valor { get; }

    private GuidId(Guid valor)
        => Valor = valor;

    public static GuidId Criar(IGuidGenerator generator)
    {
        ArgumentNullException.ThrowIfNull(generator);

        return new GuidId(generator.NewGuid());
    }

    public static GuidId Restaurar(Guid valor)
        => new GuidId(valor);

    public override string ToString() => Valor.ToString();
    public override bool Equals(object? obj) => obj is GuidId other && Valor == other.Valor;
    public override int GetHashCode() => Valor.GetHashCode();
}