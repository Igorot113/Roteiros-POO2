using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace XmlConsumingApp
{
    // 4. (Opcional) Classe para representar o item do cardápio
    public class Food
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }

        public override string ToString()
        {
            return $"Prato: {Name} | Preço: {Price}";
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://www.w3schools.com/xml/simple.xml";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // 1. Fazendo a requisição HTTP
                    Console.WriteLine("Buscando dados do cardápio...");
                    var response = await client.GetStringAsync(url);

                    // 2. Fazendo o Parse do XML
                    var doc = XDocument.Parse(response);

                    // 3. Extraindo os dados e montando a lista de objetos Food
                    // O XML tem a estrutura: <breakfast_menu> -> <food> -> <name>, <price>...
                    List<Food> menu = doc.Descendants("food")
                        .Select(f => new Food
                        {
                            Name = f.Element("name")?.Value,
                            Price = f.Element("price")?.Value,
                            Description = f.Element("description")?.Value,
                            Calories = int.Parse(f.Element("calories")?.Value ?? "0")
                        }).ToList();

                    // Exibindo os resultados no console
                    Console.WriteLine("\n--- CARDÁPIO DO DIA ---");
                    foreach (var item in menu)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao processar XML: {ex.Message}");
                }
            }
        }
    }
}