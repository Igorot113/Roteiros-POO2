using AppCarrinho;
namespace TestCarrinho;

public class UnitTest1
{
    [Fact]
    public void verificar_add_soma_itens()
    {
        var carrinho = new Carrinho();
        carrinho.Adicionar(
            new Item { Nome = "Banana", Preco = 20.00 }
        );
        Assert.Equal(1, carrinho.Quantidade());
        Assert.Equal(20.00, carrinho.Total());
    }

    [Fact]
    public void verificar_limpar_itens()
    {
        var carrinho = new Carrinho();
        carrinho.Adicionar(
            new Item { Nome = "Banana", Preco = 20.00 }
        );
        carrinho.Limpar();
        Assert.Empty(carrinho.itens);
    }

    [Fact]
    public void verificar_quantidade_itens()
    {
        var carrinho = new Carrinho();
        carrinho.Adicionar(
            new Item { Nome = "Banana", Preco = 20.00 }
        );
        Assert.Equal(1, carrinho.Quantidade());
    }
}
