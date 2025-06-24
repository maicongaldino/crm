namespace CRM.Domain.ValueObjects;

public class Nome(string valor)
{
    private string Valor { get; } = valor;

    public static Nome Criar(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentNullException(valor, $"{nameof(Nome)} foi informado nulo ou vazio.");

        return new Nome(valor);
    }

    public override string ToString() => Valor.ToString();
    public override bool Equals(object? obj) => obj is Nome other && Valor == other.Valor;
    public override int GetHashCode() => Valor.GetHashCode();
}