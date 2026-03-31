using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        Pessoa pessoa = new Pessoa
        {
            Nome = "Igor",
            Idade = 25,
            Cidade = "Uberlandia"
        };
        string jsonstr = @"{'firstName': 'Ian','Idade': 25, 'Cidade': 'Uberlandia'}";
        //Serializar: o Objeto para JSON
        string json = JsonConvert.SerializeObject(pessoa, Formatting.Indented);
        Console.WriteLine(json);
        //Deserializar: o JSON para Objeto
        Pessoa pessoa1 = JsonConvert.DeserializeObject<Pessoa>(jsonstr);
        Console.WriteLine(pessoa1.Nome);
        Console.WriteLine(pessoa1.Idade);
        Console.WriteLine(pessoa1.Cidade);
        //Salvar JSON em arquivos - Salvando em arquivo 
        Pessoa pessoa2 = new Pessoa { Nome = "Ana", Idade = 19, Cidade = "Uberlandia" };
        string json2 = JsonConvert.SerializeObject(pessoa2, Formatting.Indented);
        File.WriteAllText("pessoa.json", json2);
        Console.WriteLine("Arquivo salvo com sucesso");
        //Lendo o arquivo
        string conteudo = File.ReadAllText("pessoa.json");
        Pessoa pessoa3 = JsonConvert.DeserializeObject<Pessoa>(conteudo);
        Console.WriteLine($"Nome: {pessoa3.Nome}, Idade: {pessoa3.Idade}, Cidade: {pessoa3.Cidade}");
        //JObject 
        string json4 = @"{'Produto': 'Notebook', 'Preco': 3500, 'Estoque': 10}";
        JObject obj = JObject.Parse(json4);
        Console.WriteLine(obj["Produto"]);
        Console.WriteLine(obj["Preco"]);
        obj["Estoque"] = 8;
        Console.WriteLine(obj.ToString());
        //Listas e JSONs
        var pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Lucas", Idade = 27, Cidade = "SP"},
            new Pessoa { Nome = "Maria", Idade = 20, Cidade = "BH"}

        };
        string json5 = JsonConvert.SerializeObject(pessoas, Formatting.Indented);
        var lista = JsonConvert.DeserializeObject<List<Pessoa>>(json5);
        foreach (var p in lista)
        {
            Console.WriteLine($"{p.Nome}, {p.Idade}, {p.Cidade}");
        }
        // Usando o JsonIgnore na classe Credenciais
        Credenciais login = new Credenciais
        {
            Email = "igor@email.com",
            Senha = "oioi1010101"
        };
        string json6 = JsonConvert.SerializeObject(login, Formatting.Indented);
        Console.WriteLine(json6);
        // Ignorando valores nulls
        Pessoa pessoa4 = new Pessoa()
        {
            Nome = "Olar",
            Idade = 1,
            Cidade = null
        };
        string json7 = JsonConvert.SerializeObject(pessoa4,Formatting.Indented);
        Console.WriteLine(json7);
        json7 = JsonConvert.SerializeObject(pessoa4,Formatting.Indented,new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        });
        Console.WriteLine(json7);
    }
}