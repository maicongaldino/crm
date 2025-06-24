namespace CRM.Domain.ValueObjects;

public class Cpf(string valor)
{
    private string Valor { get; } = valor;

    public static Cpf Criar(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentNullException(valor, $"{nameof(Nome)} foi informado nulo ou vazio.");

        return new Cpf(valor);
    }

    public override string ToString() => Valor.ToString();
    public override bool Equals(object? obj) => obj is Cpf other && Valor == other.Valor;
    public override int GetHashCode() => Valor.GetHashCode();
}