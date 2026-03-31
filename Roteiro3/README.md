# 🧪 Guia de Asserções em Testes Unitários (xUnit)

## 🧐 O que é o Assert?
O **Assert** é o mecanismo de verificação utilizado em testes unitários. Ele serve para comparar o resultado obtido de um método com o resultado esperado.

* **Sucesso:** Se a comparação for verdadeira, o teste passa.
* **Falha:** Caso contrário, o teste falha.

No C#, as asserções são fornecidas por bibliotecas como **xUnit**, **NUnit** ou **MSTest**. Este guia foca no **xUnit**, que é o padrão moderno mais utilizado.

---

## 🚀 Tipos mais usados de Assert

### 1. Igualdade e Diferença
Compara se os valores são iguais ou diferentes.

```csharp
// Compara se o valor obtido é igual ao esperado
[Fact]
public void DeveSomarCorretamente()
{
    int resultado = 2 + 3;
    Assert.Equal(5, resultado);
}
// Para valores decimais 
[Fact]
public void TesteTemperatura()
{
    double temperatura = 22.857;
    Assert.Equal(22.86, temperatura, 2); // (precisão de 2 casas)
}

// Verifica se dois valores NÃO são iguais
[Fact]
public void DeveRetornarValorDiferente()
{
    int resultado = 10 - 5;
    Assert.NotEqual(0, resultado);
}
```
### 2. Validações Booleanas e Nulidade
Verifica condições lógicas ou se um objeto existe na memória.

```csharp
// Verifica se a condição é verdadeira
Assert.True(senha.Any(char.IsLetter));

// Verifica se a condição é falsa
Assert.False(!string.IsNullOrEmpty(senha));

// Verifica se o valor é nulo
Assert.Null(obj);

// Verifica se o valor NÃO é nulo
Assert.NotNull(usuario);
```
### 3. Texto e Strings
Busca por partes de um texto dentro de uma string maior.

```csharp
// Verifica se contém a substring
Assert.Contains("sistema", "Bem-vindo ao sistema");

// Verifica se NÃO contém a substring
Assert.DoesNotContain("erro", "Operação concluída com sucesso");
```
### 4. Coleções (Listas e Arrays)
Valida o estado e o conteúdo de coleções de dados

```csharp
// Verifica se a coleção está vazia
Assert.Empty(itens);

// Verifica se a coleção NÃO está vazia
Assert.NotEmpty(listaProdutos);

// Verifica se há exatamente UM elemento
Assert.Single(listaComUmItem);

// Aplica uma verificação a TODOS os elementos
Assert.All(numeros, n => Assert.True(n > 0));
```
### 5. Exceções e Tipos
Verifica se o código se comporta corretamente diante de erros ou tipos específicos.

```csharp
// Verifica se o método lança a exceção esperada
Assert.Throws<DivideByZeroException>(() => {
    int x = 10 / 0;
});

// Captura a exceção para verificar a mensagem interna
var ex = Assert.Throws<ArgumentException>(() => throw new ArgumentException("Altura inválida"));
Assert.Equal("Altura inválida", ex.Message);

//Outras formas de usar o Assert.Throws e Assert.ThrowsAsync no Exercicio 5 eu utilizei mais formas alem desses.
[Fact]
    public async Task verificar_excecao_se_percentual_maior100()
    {
        var desconto = new Desconto();
        var mensagem = await Assert.ThrowsAsync<ArgumentException>(() => throw new ArgumentException("Percentual inválido"));
        Assert.Equal("Percentual inválido",mensagem.Message);
    }


[Fact]
    public void verificar_mensagem_excecao()
    {
        var desconto = new Desconto();
        var ex = Assert.Throws<ArgumentException>(() => desconto.AplicarDesconto(100,-10));
        Assert.Equal("Percentual inválido",ex.Message);
    }

// Verifica se o objeto é de um tipo específico (ex: string)
Assert.IsType<string>(texto);
```
### 6. Intervalos Numéricos
Verifica se um valor está dentro de uma faixa permitida.

```csharp
[Fact]
public void IMCDeveEstarDentroDoIntervaloNormal()
{
    double imc = 22.8;
    // Verifica se está entre 18.5 e 24.9
    Assert.InRange(imc, 18.5, 24.9);
}
```
### Comando do dotnet para quem usa no vcCode:
```
dotnet add [PROJETO_QUE_VAI_RECEBER] reference [PROJETO_QUE_TEM_O_CODIGO]
```