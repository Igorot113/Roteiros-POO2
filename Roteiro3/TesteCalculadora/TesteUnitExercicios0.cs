using TesteUnitarios;
namespace TesteCalculadora;

public class TesteUnitExercicios0
{
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(10, 5, 15)]
    [InlineData(0, 0, 0)]
    [InlineData(-2, 5, 3)]
    [InlineData(-4, -6, -10)]
    public void Somar_DeveRetornarResultadoCorreto(int a, int b, int esperado)
    {
        // Arrange
        var calc = new Calculadora();
        // Act
        var resultado = calc.Somar(a, b);
        // Assert
        Assert.Equal(esperado, resultado);
    }
    // --- TESTE SUBTRAIR ---
    [Theory]
    [InlineData(10, 5, 5)]
    [InlineData(5, 10, -5)]
    [InlineData(0, 0, 0)]
    [InlineData(-3, -7, 4)]
    public void Subtrair_DeveRetornarResultadoCorreto(int a, int b, int esperado)
    {
        var calc = new Calculadora();
        var resultado = calc.Subtrair(a, b);
        Assert.Equal(esperado, resultado);
    }
    // --- TESTE MULTIPLICAR ---
    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(10, 0, 0)]
    [InlineData(-2, 5, -10)]
    [InlineData(-3, -3, 9)]
    public void Multiplicar_DeveRetornarResultadoCorreto(int a, int b, int
   esperado)
    {
        var calc = new Calculadora();
        var resultado = calc.Multiplicar(a, b);
        Assert.Equal(esperado, resultado);
    }
    // --- TESTE DIVIDIR (RESULTADO NORMAL) ---
    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(9, 3, 3)]
    [InlineData(5, 2, 2.5)]
    [InlineData(-10, 2, -5)]
    public void Dividir_DeveRetornarResultadoCorreto(int a, int b, double
   esperado)
    {
        var calc = new Calculadora();
        var resultado = calc.Dividir(a, b);
        Assert.Equal(esperado, resultado, 1); // tolerância de 1 casa decimal
    }
    // --- TESTE DIVIDIR (EXCEÇÃO) ---
    [Theory]
    [InlineData(10, 0)]
    [InlineData(-5, 0)]
    [InlineData(0, 0)]
    public void Dividir_DeveLancarExcecao_QuandoDivisorForZero(int a, int b)
    {
        var calc = new Calculadora();
        Assert.Throws<DivideByZeroException>(() => calc.Dividir(a, b));
    }

    [Fact]
    public void Somar_DeveRetornar5()
    {
        var calc = new Calculadora();
        var resultado = calc.Somar(2, 3);
        Assert.Equal(5, resultado);
        //Questão a) Valor esperado esta errado era para ser 5.
    }
    [Fact]
    public void Dividir_DeveLancarExcecao()
    {
        var calc = new Calculadora();
        Assert.Throws<DivideByZeroException>(() => calc.Dividir(10, 0));
        //Questão b) Com esses argumentos ele nao ira lançar a exceção pois essa conta nao esta dividindo por 0.
    }/*
    [Fact]
    public void Carrinho_DeveEstarVazio()
    {
        var carrinho = new Carrinho();
        carrinho.Adicionar(new Item { Nome = "Produto", Preco = 15 });
        Assert.Empty(new List<Item> carrinho);
        // Questão c) Ele espera uma uma lista de carrinho vazia mas esta referenciando uma lista de item com um item dentro. Nao esta fazia e nem referenciando a lista certo
    }
    [Fact]
    public void Classificar_DeveRetornarPesoNormal()
    {
        var calc = new CalculadoraIMC();
        var resultado = calc.Classificar(31);
        Assert.Equal("Peso Normal", resultado);
        // Questão d) Para efetuar o IMC com esse valor de 31 tem que dar Obsidade classe 1 para ser peso normal e 18,5 a 24,9.  
    }*/
}
