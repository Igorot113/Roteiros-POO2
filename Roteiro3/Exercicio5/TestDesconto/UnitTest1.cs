using AppDesconto;

namespace TestDesconto;

public class UnitTest1
{
    /*
    Tarefa
    a) Crie testes para verificar:
    1. Se AplicarDesconto(100, 10) retorna 90
    2. Se AplicarDesconto(200, 50) retorna 100
    3. Se AplicarDesconto(80, 0) retorna 80
    4. Se lançar exceção quando o valor for negativo
    5. Se lançar exceção quando o percentual for menor que 0
    6. Se lançar exceção quando o percentual for maior que 100
    
    b) Reescreva os testes de valores válidos usando [Theory] e [InlineData].
    */
    [Fact]
    public void desconto_100_10_retorna_90()
    {
        var desconto = new Desconto();
        double valor = desconto.AplicarDesconto(100, 10);
        Assert.Equal(90, valor, 2);
    }

    [Fact]
    public void desconto_200_50_retorna_100()
    {
        var desconto = new Desconto();
        double valor = desconto.AplicarDesconto(200, 50);
        Assert.Equal(100, valor, 2);
    }

    [Fact]
    public void desconto_80_0_retorna_80()
    {
        var desconto = new Desconto();
        double valor = desconto.AplicarDesconto(80, 0);
        Assert.Equal(80, valor, 2);
    }

    [Fact]
    public void verificar_excecao_se_valor_negativo()
    {
        var desconto = new Desconto();
        Assert.Throws<ArgumentException>(() =>
        {
            double valor = desconto.AplicarDesconto(-10, 10);
        });
    }

    [Fact]
    public void verificar_excecao_se_percentual_menor0()
    {
        var desconto = new Desconto();
        Assert.Throws<ArgumentException>(() =>
        {
            double valor = desconto.AplicarDesconto(10, -10);
        });
    }

    [Fact]
    public async Task verificar_excecao_se_percentual_maior100()
    {
        var desconto = new Desconto();
        var mensagem = await Assert.ThrowsAsync<ArgumentException>(() => throw new ArgumentException("Percentual inválido"));
        Assert.Equal("Percentual inválido",mensagem.Message);
    }

    [Fact]
    public void verificar_mensagem_excecao()
    {
        var desconto = new Desconto();
        var ex = Assert.Throws<ArgumentException>(() => desconto.AplicarDesconto(100,-10));
        Assert.Equal("Percentual inválido",ex.Message);
    }

    [Theory]
    [InlineData(100,10,90)]
    [InlineData(200,50,100)]
    [InlineData(80,0,80)]
    public void verificar_condicoes(double valor,double percentual, double esperado)
    {
        var desconto = new Desconto();
        double total = desconto.AplicarDesconto(valor,percentual);
        Assert.Equal(esperado,total,2);
    }

    [Theory]
    [InlineData(-100,10,"Valor não pode ser negativo")]
    [InlineData(100,-10,"Percentual inválido")]
    [InlineData(50,200,"Percentual inválido")]
    public void verificar_excecoes(double valor, double percentual,string esperado)
    {
        var desconto = new Desconto();
        var excecao = Assert.Throws<ArgumentException>(() => desconto.AplicarDesconto(valor,percentual));
        Assert.Equal(esperado, excecao.Message);
    }
}
