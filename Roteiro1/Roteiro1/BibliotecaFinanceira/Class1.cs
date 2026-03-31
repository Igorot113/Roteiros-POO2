using System.ComponentModel.Design;

namespace BibliotecaFinanceira;

public class CalculadoraJuros
{
    public double JurosSimples(double capital, double taxa, double tempo)
    {
        double resultado = CalculoDoJurosSimples(capital, taxa, tempo);
        return resultado;
    }

    internal double CalculoDoJurosSimples(double capital, double taxa, double tempo)
    {
        double jurosSimples = capital * taxa * tempo;
        return jurosSimples;
    }
}
