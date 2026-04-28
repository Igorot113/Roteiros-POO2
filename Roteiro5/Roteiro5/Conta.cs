class Conta
{
    public int Numero { get; private set; }
    public string Titular { get; private set; }
    public decimal Saldo { get; private set; }
    private static decimal Limite = 500;
    private decimal _saqueAcumulado;
    private const decimal LIMITE_DIARIO_TOTAL = 1000;

    public Conta(int numero, string titulo, decimal saldo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
        {
            throw new ArgumentException("Titular não pode ser vazio");
        }
        if (saldo < 0)
        {
            throw new ArgumentException("Saldo inicial não pode ser negativo");
        }
        Numero = numero;
        Titular = titulo;
        Saldo = saldo;
    }

    public decimal Depositar(decimal valor)//Exercicio 1 - Validação básica
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor do depósito deve ser positivo");
        }
        else if (valor > 10000)
        {
            throw new ArgumentException("Valor do depósito não pode ultrapassar os 10000.");
        }
        Saldo += valor;
        return Saldo;
    }

    public decimal Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("Valor do saque deve ser positivo");
        }
        if(_saqueAcumulado + valor > LIMITE_DIARIO_TOTAL)
        {
            throw new LimiteDiarioAcumuladoException(_saqueAcumulado,LIMITE_DIARIO_TOTAL);
        }
        try
        {
            if (Saldo < valor)
            {
                throw new Exception("Saldo insuficiente (erro interno)");
            }
            else if (valor > 500)
            {
                throw new LimiteDiarioException("Saque ultrapassou o limite.");
            }
            Saldo -= valor;
            _saqueAcumulado += valor;
            return Saldo;
        }
        catch (SaldoInsuficienteException e)
        {
            throw new SaldoInsuficienteException(valor, Saldo, e);
        }
        catch (LimiteDiarioException e)
        {
            throw new LimiteDiarioException(valor, Limite, e);
        }
    }
    public void Transferir(Conta destino, decimal valor)// Exercicio 3 - Transferência
    {
        decimal valorSacado = Sacar(valor);
        destino.Depositar(valorSacado);

    }
    public override string ToString()
    {
        return $"Conta: {Numero}-{Titular}-Saldo: {Saldo}";
    }
}