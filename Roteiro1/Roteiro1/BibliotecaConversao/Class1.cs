namespace BibliotecaConversao;

public class Conversor
{
    public double ConversorDeFahrenheitToCelsius(double fahrenheit)
    {
        double celsius = (fahrenheit - 32) * 5 / 9;
        return celsius;
    }

    public double ConversorDeMetrosParaQuilometros(double metros)
    {
        double quilometros = metros / 1000;
        return quilometros;
    }
}
