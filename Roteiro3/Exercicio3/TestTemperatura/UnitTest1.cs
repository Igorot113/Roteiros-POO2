using AppTemperatura;
namespace TestTemperatura;

public class UnitTest1
{
    [Fact]
    public void verificar_celsius_fahrenheit_0_32()
    {
        var temperatura = new ConversorTemperatura();
        double valor = temperatura.CelsiusParaFahrenheit(0);
        Assert.Equal(32, valor,2);
    }
    [Fact]
    public void verificar_celsius_fahrenheit_100_212()
    {
        var temperatura = new ConversorTemperatura();
        double valor = temperatura.CelsiusParaFahrenheit(100);
        Assert.Equal(212, valor,2);
    }
    [Fact]
    public void verificar_fahrenheit_celsius_32_0()
    {
        var temperatura = new ConversorTemperatura();
        double valor = temperatura.FahrenheitParaCelsius(32);
        Assert.Equal(0, valor,2);
    }
    [Fact]
    public void verificar_fahrenheit_celsius_212_100()
    {
        var temperatura = new ConversorTemperatura();
        double valor = temperatura.FahrenheitParaCelsius(212);
        Assert.Equal(100, valor,2);
    }
}
