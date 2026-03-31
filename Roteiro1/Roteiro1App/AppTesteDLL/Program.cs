using System;
using MinhaBiblioteca;
using BibliotecaConversao;
using ConvertorDeMoeda;
using AreaTriangulo;
using BibliotecaFinanceira;
using BibliotecaValidacoes;
using DLLdoBetinha;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        var calc = new Calculadora();
        var conversor = new Conversor();
        var conversorMoeda = new ConvertorMoeda();
        var area = new Area();
        var jurosSimples = new CalculadoraJuros();
        var verificacoes = new Validacao();
        var beta = new BetaCalculator();

        Console.WriteLine("Soma: " + calc.Somar(5, 3));
        Console.WriteLine("Multiplicar: " + calc.Multiplicar(5, 3));
        Console.WriteLine("Fahrenheit para Celsius: " + conversor.ConversorDeFahrenheitToCelsius(32.0));
        Console.WriteLine("Metro para Quilômetro: " + conversor.ConversorDeMetrosParaQuilometros(100.0));
        Console.WriteLine("Real para Dolar: " + conversorMoeda.ConverterRealParaDolar(100.0, 0.19));
        Console.WriteLine("Real para Dolar: " + conversorMoeda.ConverterRealParaDolar(100.0, 0.19));
        Console.WriteLine("Area do triangulo: " + area.CalculoDaArea(10, 5));
        beta.Beta(100);
        Console.WriteLine("Calcular o juros simples: " + jurosSimples.JurosSimples(1000.0, 0.5, 10));
        Console.WriteLine("Validar CPF: " + verificacoes.ValidadorCPF("11111111100"));
        //error CS1061: ‘Validacao’ não contém uma definição para "ValidadorCPF" e 
        // não foi possível encontrar nenhum método de extensão "ValidadorCPF" 
        // que aceite um primeiro argumento do tipo ‘Validacao’ 
        // (você está se esquecendo de usar uma diretiva ou uma referência de assembly?)
        // Mudei o metodo do BibliotecaValidacoes.dll para ValidadorCPF2
        Console.WriteLine("Validar Senha: " + verificacoes.ValidadorSenhas("senha1020"));
        Console.WriteLine("Validar Email: " + verificacoes.ValidadorEmail("emailfalso@gmail.com"));
        //Console.WriteLine("Calcular o juros simples interno: " + jurosSimples.CalculoDoJurosSimples(1000.0, 0.5, 10));
        //Assinatura do metodo nao encontrado.
        /* 
        O que é breaking change
        Uma alteração incompatível em software é uma modificação que faz com que programas 
        clientes existentes ou sistemas dependentes falhem, 
        se comportem incorretamente ou parem de compilar após uma atualização. 
        Essencialmente, ela quebra a compatibilidade com versões anteriores, 
        exigindo que os usuários façam atualizações correspondentes em seus próprios códigos ou configurações para manter a funcionalidade.
        */
    }
}