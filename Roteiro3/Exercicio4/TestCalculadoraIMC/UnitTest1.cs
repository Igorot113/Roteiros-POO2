using CalculadoraIMCPasta;
namespace TestCalculadoraIMC;

public class UnitTest1
{
    [Fact]
    public void verificar_calcular_70_retorna_22()
    {
        var calculadora = new CalculadoraIMC();
        double total = calculadora.Calcular(70, 1.75);
        Assert.Equal(22.86, total,2);
    }
    [Fact]
    public void classificar_17_AbaixoDoPeso()
    {
        var calculadora = new CalculadoraIMC();
        string valor = calculadora.Classificar(17);
        Assert.Equal("Abaixo do peso", valor);
    }
    [Fact]
    public void classificar_26_SobrePeso()
    {
        var calculadora = new CalculadoraIMC();
        string valor = calculadora.Classificar(26);
        Assert.Equal("Sobrepeso", valor);
    }
    [Fact]
    public void verificar_se_lanca_excecao()
    {
        var calculadora = new CalculadoraIMC();
        Assert.Throws<ArgumentException>(() =>
        {
            double valor = calculadora.Calcular(26, 0.00);
        });
    }
}
