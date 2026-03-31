using Newtonsoft.Json;

class Exercicio5
{
    static void Main()
    {
        List<Produto> produtos = new List<Produto>
        {
          new Produto {Id = 1, Nome = "Notebook", Preco = 2500, Estoque = 10, Fornecedor = "Dell", CodigoInterno = "a10101"},
          new Produto {Id = 2, Nome = "Mouse", Preco = 80, Estoque = 50, Fornecedor = "RedDragon", CodigoInterno = "b22222"},
          new Produto {Id = 3, Nome = "Monitor", Preco = 1500, Estoque = 5, Fornecedor = null, CodigoInterno = "c22200"}
        };
        string json = JsonConvert.SerializeObject(produtos, Formatting.Indented, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        });
        Console.WriteLine(json);
        File.WriteAllText("produtos.json", json);
        string conteudo = File.ReadAllText("produtos.json");
        List<Produto> produtos1 = JsonConvert.DeserializeObject<List<Produto>>(conteudo);
        foreach (Produto produto in produtos1)
        {
            Console.WriteLine($"Id: {produto.Id}\nNome: {produto.Nome}\nPreco: {produto.Preco}\nEstoque: {produto.Estoque}\nFornecedor: {produto.Fornecedor}\n");
        }
    }
}