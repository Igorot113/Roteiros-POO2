using System.Runtime.CompilerServices;

namespace ConvertorDeMoeda;

public class ConvertorMoeda
{
    public double ConverterRealParaDolar(double real, double taxaCambio)
    {
        double conversao = real * taxaCambio;
        return conversao;
    }
}
