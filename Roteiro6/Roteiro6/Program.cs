using System;
using NLog;

namespace ExerciciosNLog
{
    class Program
    {
        // Criação da instância do logger
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            // Exercício 2: Log de início do programa
            Logger.Info("Início do programa.");

            try
            {
                // Exercício 3: Implementar conversão de string para inteiro com log de erro
                string valorInvalido = "123a";
                Logger.Info($"Tentativa de conversão da string: '{valorInvalido}'");

                try
                {
                    int numeroConvertido = int.Parse(valorInvalido);
                }
                catch (FormatException ex)
                {
                    // Exercício 5 e 7: Log de Erro com a exceção formatada no layout
                    Logger.Error(ex, "Erro: Falha na conversão da string para inteiro.");
                }

                // Exercício 4 e 6: Instanciação das contas para os testes de fluxo
                Conta contaOrigem = new Conta("Conta 001", 500.00m);
                Conta contaDestino = new Conta("Conta 002", 100.00m);

                // Fluxo 1: Depósito
                contaOrigem.Depositar(200.00m);

                // Fluxo 2: Saque com sucesso
                contaOrigem.Sacar(150.00m);

                // Fluxo 3: Transferência
                contaOrigem.Transferir(100.00m, contaDestino);

                // Fluxo 4: Tentativa inválida (Saque com valor superior ao saldo)
                try
                {
                    contaOrigem.Sacar(3000.00m);
                }
                catch (Exception)
                {
                    // O erro de saldo insuficiente foi registrado internamente
                }
                
                // Outra conversão inválida para teste
                int.Parse("TextoInvalido");
            }
            catch (Exception ex)
            {
                // Captura exceções gerais não tratadas no fluxo principal
                Logger.Error(ex, "Exceção não tratada capturada no escopo global.");
            }
            finally
            {
                // Exercício 2: Log de fim do programa
                Logger.Info("Fim do programa.");
            }
        }
    }

    // Classe Conta para cobrir os Exercícios 4 e 6
    public class Conta
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public string NumeroConta { get; set; }
        public decimal Saldo { get; private set; }

        public Conta(string numeroConta, decimal saldoInicial)
        {
            NumeroConta = numeroConta;
            Saldo = saldoInicial;
            Logger.Info($"Conta '{NumeroConta}' inicializada com sucesso. Saldo: R$ {Saldo:F2}");
        }

        public void Depositar(decimal valor)
        {
            Logger.Info($"[Depósito] Início da operação na conta {NumeroConta}. Valor: R$ {valor:F2}");
            
            if (valor <= 0)
            {
                // Exercício 5: Warn para tentativa inválida
                Logger.Warn($"[Depósito] Tentativa inválida. Valor do depósito deve ser maior que zero: R$ {valor:F2}");
                throw new ArgumentException("O valor do depósito deve ser positivo.");
            }

            Saldo += valor;
            Logger.Info($"[Depósito] Sucesso: Depósito efetuado. Saldo atualizado: R$ {Saldo:F2}");
        }

        public void Sacar(decimal valor)
        {
            Logger.Info($"[Saque] Início da operação na conta {NumeroConta}. Valor: R$ {valor:F2}");

            if (valor <= 0)
            {
                Logger.Warn($"[Saque] Tentativa inválida. Valor do saque deve ser maior que zero: R$ {valor:F2}");
                throw new ArgumentException("O valor do saque deve ser positivo.");
            }

            if (Saldo < valor)
            {
                // Exercício 5: Warn para tentativa inválida de saldo insuficiente
                Logger.Warn($"[Saque] Tentativa inválida (Saldo insuficiente). Saldo atual: R$ {Saldo:F2}, Tentativa: R$ {valor:F2}");
                throw new InvalidOperationException("Saldo insuficiente para a operação.");
            }

            Saldo -= valor;
            Logger.Info($"[Saque] Sucesso: Saque efetuado. Saldo atualizado: R$ {Saldo:F2}");
        }

        public void Transferir(decimal valor, Conta destino)
        {
            Logger.Info($"[Transferência] Início da operação: R$ {valor:F2} de {NumeroConta} para {destino.NumeroConta}");

            try
            {
                // Utiliza a própria lógica de saque e depósito
                this.Sacar(valor);
                destino.Depositar(valor);

                Logger.Info($"[Transferência] Sucesso: Transferência concluída com êxito.");
            }
            catch (Exception ex)
            {
                // Exercício 5: Error para exceções
                Logger.Error(ex, $"[Transferência] Erro: Falha ao transferir R$ {valor:F2} de {NumeroConta} para {destino.NumeroConta}");
                throw;
            }
        }
    }
}