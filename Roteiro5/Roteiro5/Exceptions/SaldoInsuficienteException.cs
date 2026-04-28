[Serializable]
public class SaldoInsuficienteException : Exception
{
    public decimal ValorSaque { get; }
    public decimal ValorAtual { get; }

    public SaldoInsuficienteException() { }

    public SaldoInsuficienteException(string message) : base(message) { }

    public SaldoInsuficienteException(string message, Exception inner) : base(message, inner) { }

    public SaldoInsuficienteException(decimal saque, decimal saldo, Exception inner) : base($"Saque de {saque} não permitido. Saldo atual: {saldo}", inner)
    {
        ValorSaque = saque;
        ValorAtual = saldo;
    }
    public override string HelpLink
    {
        get => "http://meusistema.com/error/saldo-insuficiente";
    }
}