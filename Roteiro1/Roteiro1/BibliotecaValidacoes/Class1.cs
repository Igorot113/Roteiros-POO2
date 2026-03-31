using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace BibliotecaValidacoes;

public class Validacao
{
    public bool ValidadorCPF(string cpf)
    {
        if (cpf.Length == 11)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool ValidadorEmail(string email)
    {
        try
        {
            var emailVerif = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public bool ValidadorSenhas(string senha)
    {
        if (senha.Length > 8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
