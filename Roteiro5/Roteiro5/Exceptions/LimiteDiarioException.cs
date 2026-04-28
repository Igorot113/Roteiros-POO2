[Serializable]
public class LimiteDiarioException : Exception // Exercicio 2 - Nova Exceção
{
    public LimiteDiarioException() { }
    public LimiteDiarioException(string message) : base(message) { }
    public LimiteDiarioException(string message, Exception inner) : base(message, inner) { }
    public LimiteDiarioException(decimal valor, decimal limite, Exception inner) : base($"Saque de {valor} não pode ultrapassar limite: {limite}", inner) { }
    public override string HelpLink
    {
        get => "http://meusistema.com/error/saldo-insuficiente";
    }
}