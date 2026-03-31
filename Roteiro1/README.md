# AreaTriangulo.dll

Uma biblioteca simples em .NET para cálculo de área de triângulos.

## 🚀 Como usar

Para utilizar esta DLL no seu projeto, siga os passos abaixo:

### 1. Adicionar a Referência
Primeiro, você precisa adicionar o arquivo `AreaTriangulo.dll` às referências do seu projeto:
* No Visual Studio: Clique com o botão direito em **Dependencies** > **Add Project Reference** > **Browse** e selecione a DLL.

### 2. Espaço de Nomes (Namespace)
Adicione a diretiva `using` no topo do seu arquivo de código:

```csharp
### 💻 Exemplo de Uso (Snippet)
//Use o código abaixo para testar a funcionalidade básica:
using AreaTriangulo;// OBRIGATÓRIO
var calculadora = new Area(); // Ha também essa forma de instaciar o objeto AreaTriangulo.Area()
//Chamar a unica função que existe nessa classe CalculoDaArea(double x, double y)
double resultado = calculadora.CalculoDaArea(5.0, 10.0); 
Console.WriteLine($"O resultado é: {resultado}");