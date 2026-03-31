using System;
using System.Xml.Serialization;
[XmlRoot("Aluno")]
public class Aluno
{
 [XmlElement("Nome")]
 public string Nome { get; set; }
 [XmlElement("Idade")]
 public int Idade { get; set; }
 [XmlElement("Curso")]
 public string Curso { get; set; }
}