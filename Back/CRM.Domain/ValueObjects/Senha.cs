namespace CRM.Domain.ValueObjects;

public class Senha
{
    public string Valor { get; }

    private Senha(string valor)
        => Valor = valor;

    public static Senha Criar(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentNullException(valor, $"{nameof(Nome)} foi informado nulo ou vazio.");

        return new Senha(valor);
    }

    public override string ToString() => Valor.ToString();
    public override bool Equals(object? obj) => obj is Senha other && Valor == other.Valor;
    public override int GetHashCode() => Valor.GetHashCode();
}