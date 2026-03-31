using System;
using System.Xml.Serialization;
[XmlRoot("ListaDeProdutos")]
public class ListaDeProdutos
{
    [XmlArray("Produtos")]
    [XmlArrayItem("Produto")]
    public List<Produto> Produtos { get; set; }
}
