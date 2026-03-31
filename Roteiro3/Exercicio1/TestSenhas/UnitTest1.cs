using System.Reflection.Metadata;
using AppSenhas;

namespace TestSenhas;

public class UnitTest1
{
    [Fact]
    public void verificar_Senha_123_Valida ()
    {
        var verif = new ValidadorSenhas();
        bool valido = verif.EhValida("Senha123");
        Assert.True(valido);
    }
    [Fact]
    public void verificar_12345678_Invalida()
    {
        var verif = new ValidadorSenhas();
        bool valido = verif.EhValida("12345678");
        Assert.False(valido);
    }
    [Fact]
    public void verificar_Senha_Vazia_Invalida()
    {
        var verif = new ValidadorSenhas();
        bool valido = verif.EhValida("");
        Assert.False(valido);
    }
    [Fact]
    public void verificar_Senha_abcdEFGH_Invalida()
    {
        var verif = new ValidadorSenhas();
        bool valido = verif.EhValida("abcdEFGH");
        Assert.False(valido);
    }
}
