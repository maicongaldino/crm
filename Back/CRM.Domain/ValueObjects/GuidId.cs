using CRM.Domain.Interfaces;

namespace CRM.Domain.ValueObjects;

public class GuidId(Guid valor)
{
    private Guid Valor { get; } = valor;

    public static GuidId Criar(IGuidGenerator generator)
    {
        ArgumentNullException.ThrowIfNull(generator);

        return new GuidId(generator.NewGuid());
    }

    public override string ToString() => Valor.ToString();
    public override bool Equals(object? obj) => obj is GuidId other && Valor == other.Valor;
    public override int GetHashCode() => Valor.GetHashCode();
}