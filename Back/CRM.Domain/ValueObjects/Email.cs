namespace CRM.Domain.ValueObjects;

public class Email(string valor)
{
    private string Valor { get; } = valor;

    public static Email Criar(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentNullException(valor, $"{nameof(Nome)} foi informado nulo ou vazio.");

        return new Email(valor);
    }

    public override string ToString() => Valor.ToString();
    public override bool Equals(object? obj) => obj is Email other && Valor == other.Valor;
    public override int GetHashCode() => Valor.GetHashCode();
}