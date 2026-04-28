[Serializable]
public class LimiteDiarioAcumuladoException : Exception
{
    public decimal Acumulado { get; }
    public decimal LimiteMaximo { get; }

    public LimiteDiarioAcumuladoException(decimal acumulado, decimal limite) : base($"Limite diario atingido! Voce ja sacou {acumulado}. O limite total é {limite}.")
    {
        Acumulado = acumulado;
        LimiteMaximo = limite;
    }
    public override string HelpLink => "http://meusistema.com/error/limite-acumulado";
}