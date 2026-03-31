using System.Xml;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ListaDeProdutos));
        ListaDeProdutos produtos = new ListaDeProdutos()
        {
            Produtos = new List<Produto>
            {
                new Produto {nome = "maca", preco = 10.00},
                new Produto {nome = "banana",preco = 5.00},
                new Produto {nome = "abacaxi",preco = 20.00}
            }
        };
        using (StreamWriter writer = new StreamWriter("produtos.xml"))
        {
            serializer.Serialize(writer, produtos);
        }
        XmlDocument doc = new XmlDocument();
        doc.Load("produtos.xml");
        for(int i = 1; i <= 3; i++)
        {
            string nome = doc.SelectSingleNode($"/ListaDeProdutos/Produtos/Produto[{i}]/nome").InnerText;
            double preco = double.Parse(doc.SelectSingleNode($"/ListaDeProdutos/Produtos/Produto[{i}]/preco").InnerText);
            Console.WriteLine($"Nome: {nome} | Preço: {preco}");
        }
    }
}