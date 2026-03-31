using System.Xml;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("aluno.xml");
        //Usando o XMLDocument ----------------------------------------
        string nome = doc.SelectSingleNode("/Aluno/Nome").InnerText;
        string idade = doc.SelectSingleNode("/Aluno/Idade").InnerText;
        string curso = doc.SelectSingleNode("/Aluno/Curso").InnerText;
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Idade: {idade}");
        Console.WriteLine($"Curso: {curso}");
        // Final do XMLDocument ---------------------------------------
        // Serializando um Objeto C# para XML -------------------------
        XmlSerializer serializer = new XmlSerializer(typeof(Aluno));
        Aluno aluno = new Aluno
        {
            Nome = "João Oliveira",
            Idade = 21,
            Curso = "Engenharia de Software"
        };
        using (StreamWriter writer = new StreamWriter("aluno.xml"))
        {
            serializer.Serialize(writer, aluno);
        }
        Console.WriteLine("Arquivo XML criado com sucesso!");
        // Final do serializando objeto para xml ----------------------
        // Deserializando xml para objeto c# --------------------------
        using (StreamReader reader = new StreamReader("aluno.xml"))
        {
            Aluno aluno1 = (Aluno)serializer.Deserialize(reader);
            Console.WriteLine($"Nome: {aluno1.Nome}");
            Console.WriteLine($"Idade: {aluno1.Idade}");
            Console.WriteLine($"Curso: {aluno1.Curso}");
        }
        // Final do deserializando um objeto --------------------------
        // Serializando listas (colecoes de objetos) ------------------
        XmlSerializer serializer2 = new XmlSerializer(typeof(Turma));
        var turma = new Turma
        {
            Alunos = new List<Aluno>
            {
            new Aluno { Nome = "João", Idade = 21, Curso = "Engenharia" },
            new Aluno { Nome = "Maria", Idade = 22, Curso = "Sistemas" }
            }
        };
        using (StreamWriter writer = new StreamWriter("turma.xml"))
        {
            serializer2.Serialize(writer, turma);
        }
        // Final do serializando lista --------------------------------
        // Tentando usar o XMLDocumento  em uma lista -----------------
        doc.Load("turma.xml");
        string nomeLista = doc.SelectSingleNode("/Turma/Alunos/Aluno[1]/Nome").InnerText;
        string idadeLista = doc.SelectSingleNode("/Turma/Alunos/Aluno[1]/Idade").InnerText;
        string cursoLista = doc.SelectSingleNode("/Turma/Alunos/Aluno[1]/Curso").InnerText;
        Console.WriteLine($"Nome:{nomeLista} | Idade{idadeLista} | Curso{cursoLista}");
        // Final do XMLDocumento em uma lista -------------------------
        // escrevendo XML manualmente com XMLWriter -------------------
        using (XmlWriter writer1 = XmlWriter.Create("produto.xml"))
        {
            writer1.WriteStartDocument();
            writer1.WriteStartElement("Produto");
            writer1.WriteElementString("Nome", "Mouse Gamer");
            writer1.WriteElementString("Preco", "199.90");
            writer1.WriteElementString("Estoque", "25");
            writer1.WriteEndElement();
            writer1.WriteEndDocument();
        }
        Console.WriteLine("Arquivo XML, 'produto.xml' criado com sucesso!");
        // final do XMLWriter -----------------------------------------
        // escrevendo xml manualmente com atributos -------------------
        using (XmlWriter writer = XmlWriter.Create("pedido.xml"))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Pedido");
            writer.WriteStartElement("Item");
            writer.WriteAttributeString("codigo", "A123");
            writer.WriteAttributeString("quantidade", "10");
            writer.WriteElementString("Descricao", "Cabo HDMI");
            writer.WriteElementString("Preco", "49.90");
            writer.WriteEndElement(); // Fecha Item
            writer.WriteEndElement(); // Fecha Pedido
            writer.WriteEndDocument();
        }
        // final de escrever manualmente com atributos ----------------
    }
}