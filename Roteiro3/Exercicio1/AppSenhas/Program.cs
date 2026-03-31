using AppSenhas;

class Program
{
    static void Main()
    {
        var verif = new ValidadorSenhas();
        string[] senhas = {"Senha123","12345678","","abcdEFGH"};
        for (int i = 0; i < senhas.Length; i++)
        {
            bool validador = verif.EhValida(senhas[i]);
            if (validador)
            {
                Console.WriteLine($"Senha: {senhas[i]} = Valido");
            }
            else
            {
                Console.WriteLine($"Senha: {senhas[i]} = Invalido");
            }
        }
    }
}