using Newtonsoft.Json;

class Pessoa
{
    [JsonProperty("firstName")]
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Cidade { get; set; }
    /*
    Exemplo:
    Quando queremos definir a ordem das propriedades no JSON
    class Produto
    {
        [JsonProperty(Order = 1)]
        public string Nome {get; set;}
        [JsonProperty(Order = 2)]
        public double Preco {get; set;}
        [JsonProperty(Order = 3)]
        public int Estoque {get; set;}
    }
    */
}