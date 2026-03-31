using System.Xml;

class Program
{
    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("estoque.xml");
        XmlNode node  = doc.SelectSingleNode("/estoque/item[2]/quantidade");
        node.InnerText = "10";
        doc.Save("estoque.xml");
        string quantidade = doc.SelectSingleNode("/estoque/item[2]/quantidade").InnerText;
        Console.WriteLine(quantidade);
    }
}