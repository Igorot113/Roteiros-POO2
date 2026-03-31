using System.Xml;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("alunos.xml");

        string nome1 = doc.SelectSingleNode("/alunos/aluno[1]/nome").InnerText;
        string curso1 = doc.SelectSingleNode("/alunos/aluno[1]/curso").InnerText;
        string nome2 = doc.SelectSingleNode("/alunos/aluno[2]/nome").InnerText;
        string curso2 = doc.SelectSingleNode("/alunos/aluno[2]/curso").InnerText;

        Console.WriteLine($"{nome1} | {curso1}");
        Console.WriteLine($"{nome2} | {curso2}");
    }
}