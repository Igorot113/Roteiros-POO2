class Program
{
    static void Main()
    {
        //Conta conta = new Conta(100, "Maria", 100m);
        try
        {
            Console.WriteLine("Digite o nome do Titular da conta: "); // Exercicio 6
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o saldo inicial da conta: ");
            decimal saldoInicial = decimal.Parse(Console.ReadLine());
            Conta conta = new Conta(numero, nome, saldoInicial);
            Console.WriteLine(conta);
            //conta.Depositar(50);//50 1000
            Console.WriteLine($"Saldo: {conta.Saldo}");
            //conta.Sacar(200); //200 600
            //Console.WriteLine($"Saldo: {conta.Saldo}");
            conta.Sacar(500);
            conta.Sacar(500);
            conta.Sacar(500);
            Console.WriteLine(conta.Saldo);
        }
        catch (SaldoInsuficienteException ex)
        {
            Console.WriteLine("ERRO DE NEGÓCIO:");
            Console.WriteLine(ex.Message);
            Console.WriteLine("Ajuda:" + ex.HelpLink);
            Console.WriteLine("StackTrace:" + ex.StackTrace);
            if (ex.InnerException != null)
            {
                Console.WriteLine("Cause:" + ex.InnerException.Message);
            }
        }
        catch (LimiteDiarioException ex) // Exercicio 4 - uso das prorpriedades Exception
        {
            Console.WriteLine("Erro: Limite Atingido");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(ex.HelpLink);
            if (ex.InnerException != null)
            {
                Console.WriteLine("Cause: " + ex.InnerException.Message);
            }
        }
        catch(LimiteDiarioAcumuladoException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Erro de validação:" + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro inesperado");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            //Exercicio 5 - Tratamento correto
            /*
            Ao escrever throw ex;, você está tecnicamente dizendo ao .NET para "reiniciar" a exceção. 
            Isso causa a perda do Stack Trace (Rastro da Pilha) original.
            Com throw ex;: O sistema entende que a exceção nasceu naquela linha específica do catch. 
            Se o erro real aconteceu em um método profundo dentro de uma biblioteca, você não conseguirá ver o caminho completo até a origem.
            Com throw;: O .NET preserva toda a hierarquia do erro. 
            Ele "repassa" a exceção adiante exatamente como ela chegou, mantendo a informação de onde o problema realmente começou.
            */

            //Exercicio7
            /*
            1.​ Por que usar exceção personalizada aqui?
            Clareza Semântica: O código se torna "autoexplicativo". 
            Quando você lê catch (SaldoInsuficienteException), entende imediatamente a regra de negócio que foi violada.
            Tratamento Seletivo: No Main, você pode querer tratar um erro de saldo insuficiente de um jeito (avisar o usuário para depositar)  e um erro de conexão de banco de dados de outro. 
            Se tudo for apenas Exception, você não consegue distinguir o que aconteceu sem olhar a mensagem de texto.
            Controle de Dados: Você pode adicionar propriedades extras à sua classe de exceção, como o ValorTentado ou o SaldoAtual, facilitando o log ou a mensagem de erro.
            2.​ Qual a função do InnerException?
            O InnerException serve para manter o histórico de origem de um erro quando você decide "embrulhá-lo" em outra exceção.
            Imagine que uma falha ao sacar dinheiro ocorreu por um erro de leitura no banco de dados. 
            Você pode lançar uma SaqueException (mais amigável para o usuário), mas anexar a SqlException original como InnerException.
            Utilidade: Permite que o desenvolvedor veja a "causa raiz" (InnerException) enquanto o sistema lida com uma exceção de alto nível.
            Preservação: Sem ele, ao lançar uma nova exceção, você perderia o rastro do que realmente causou o problema lá embaixo.
            3.​ Onde o erro deve ser tratado: Conta ou Main?
            A regra de ouro é: O erro deve ser tratado onde você tem informações suficientes para tomar uma decisão.
            Na classe Conta: Geralmente, você não trata a exceção aqui. A função da classe Conta é apenas dizer: "Eu não consigo realizar essa operação". 
            Se você colocar um Console.WriteLine dentro da classe Conta, você está "sujando" sua lógica de negócio com interface de usuário. A Conta apenas lança (throw) o erro.
            No Main (ou na Camada de UI): É aqui que o erro deve ser tratado (catch). 
            O Main sabe que está interagindo com um usuário e pode decidir exibir uma mensagem na tela, pedir para digitar o valor novamente ou encerrar o programa.
            */
        }
    }
}