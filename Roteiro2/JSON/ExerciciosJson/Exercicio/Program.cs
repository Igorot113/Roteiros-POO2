

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        // Exercicio 1
        Console.WriteLine("Exercicio 1");
        Livro livro = new Livro()
        {
            Titulo = "Senhor dos Aneis",
            Autor = "JRR Tolkien",
            Ano = 1970
        };
        string json1 = JsonConvert.SerializeObject(livro, Formatting.Indented);
        Console.WriteLine(json1);
        // Exercicio 2
        Console.WriteLine("\nExercicio 2");
        Aluno aluno = new Aluno { Nome = "Ana", Idade = 19, Cidade = "Uberlandia" };
        string json2 = JsonConvert.SerializeObject(aluno, Formatting.Indented);
        File.WriteAllText("pessoa.json", json2);
        string conteudo = File.ReadAllText("pessoa.json");
        Aluno aluno1 = JsonConvert.DeserializeObject<Aluno>(conteudo);
        Console.WriteLine($"Nome: {aluno1.Nome}\nIdade: {aluno1.Idade}\nCidade: {aluno1.Cidade}\n");
        // Exercicio 3
        Console.WriteLine("\nExercicio 3");
        List<Carro> carros = new List<Carro>
        {
            new Carro { Marca = "Ferrari", Modelo = "F50", Ano = 2000},
            new Carro { Marca = "Bugatti", Modelo = "A01", Ano = 2012},
            new Carro { Marca = "Lamborgini", Modelo = "A13", Ano = 2015},
        };
        string json3 = JsonConvert.SerializeObject(carros, Formatting.Indented);
        File.WriteAllText("carro.json", json3);
        string conteudo1 = File.ReadAllText("carro.json");
        List<Carro> carros1 = JsonConvert.DeserializeObject<List<Carro>>(conteudo1);
        foreach (Carro carro in carros1)
        {
            Console.WriteLine($"Marca: {carro.Marca}\nAno: {carro.Ano}\nModelo: {carro.Modelo}\n");
        }
        // Exercicio 4
        Console.WriteLine("\nExercicio 4");
        string jsonConfig = @"{
            'Servidor': '192.168.0.1',
            'Porta': 8080,
            'Usuario': 'admin'
        }";
        JObject config = JObject.Parse(jsonConfig);
        config["Porta"] = 5432;
        Console.WriteLine(config.ToString());
    }
}