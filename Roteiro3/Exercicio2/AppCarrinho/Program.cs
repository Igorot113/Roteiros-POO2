using AppCarrinho;
class Program
{
    static void Main()
    {
        var carrinho = new Carrinho();
        carrinho.Adicionar(
            new Item {Nome = "Banana", Preco = 5.00}
        );
        carrinho.Adicionar(
            new Item {Nome = "Maça", Preco = 10.00}
        );
        carrinho.Adicionar(
            new Item {Nome = "Abacaxi", Preco = 15.00}
        );
        carrinho.Adicionar(
            new Item {Nome = "Pera", Preco = 2.00}
        );
        carrinho.Total();
        carrinho.Quantidade();
        carrinho.Limpar();

    }
}