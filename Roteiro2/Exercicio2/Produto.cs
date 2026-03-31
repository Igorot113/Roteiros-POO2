using System.Xml.Serialization;

[XmlRoot("Produto")]
public class Produto
{
    [XmlElement("nome")]
    public string nome {get;set;}
    [XmlElement("preco")]
    public double preco {get; set;}
}