using System;
using System.Xml.Serialization;
[XmlRoot("Turma")]
public class Turma
{
    [XmlArray("Alunos")]
    [XmlArrayItem("Aluno")]
    public List<Aluno> Alunos { get; set; }
}
