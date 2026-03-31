using Newtonsoft.Json;

class Produto
{
    [JsonProperty(Order = 1)]
    public int Id { get; set; }

    [JsonProperty("product_name", Order = 2,Required = Required.Always)]
    public string Nome { get; set; }

    [JsonProperty("product_price", Order = 3,Required = Required.Always)]
    public double Preco { get; set; }

    [JsonProperty(Order = 4)]
    public int Estoque { get; set; }

    [JsonProperty(Order = 5)]
    public string Fornecedor { get; set; }

    [JsonIgnore]
    public string CodigoInterno { get; set; }
}