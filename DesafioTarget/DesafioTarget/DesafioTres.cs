using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;

namespace DesafioTres
{
    public class FaturamentoDia
    {
        public int dia { get; set; }
        public double valor { get; set; }
    }

    public static class Faturamento
    {
        public static void ProcessarFaturamento()
        {
            string pathJson = @"C:\Users\cdmun\OneDrive\Documents\Target-Sistemas\DesafioTarget\DesafioTarget\Dados\dados.json";
            string pathXml = @"C:\Users\cdmun\OneDrive\Documents\Target-Sistemas\DesafioTarget\DesafioTarget\Dados\dados.xml";

            ProcessarArquivo(pathJson, "JSON");
            Console.WriteLine(); // Separação entre JSON e XML
            ProcessarArquivo(pathXml, "XML");
        }

        private static void ProcessarArquivo(string filePath, string fileType)
        {
            try
            {
                List<FaturamentoDia> faturamentos = fileType == "JSON"
                    ? CarregarJson(filePath)
                    : CarregarXml(filePath);

                if (!faturamentos.Any(f => f.valor > 0))
                {
                    Console.WriteLine($"Nenhum dia com faturamento positivo encontrado no arquivo {fileType}.");
                    return;
                }

                ExibirResultados(faturamentos, fileType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar os dados do arquivo {fileType}: {ex.Message}");
            }
        }

        private static List<FaturamentoDia> CarregarJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<FaturamentoDia>>(json);
        }

        private static List<FaturamentoDia> CarregarXml(string filePath)
        {
            string xmlContent = File.ReadAllText(filePath);

            // Adiciona um nó raiz se ele não existir
            string wrappedXml = $"<root>{xmlContent}</root>";

            XDocument doc = XDocument.Parse(wrappedXml);

            return doc.Descendants("row")
                .Select(x => new FaturamentoDia
                {
                    dia = (int)x.Element("dia"),
                    valor = double.Parse(x.Element("valor").Value.Replace(".", ","))
                })
                .ToList();
        }

        private static void ExibirResultados(List<FaturamentoDia> faturamentos, string fileType)
        {
            var faturamentoPositivo = faturamentos.Where(f => f.valor > 0).ToList();
            double menorValor = faturamentoPositivo.Min(f => f.valor);
            double maiorValor = faturamentoPositivo.Max(f => f.valor);
            double mediaMensal = faturamentoPositivo.Average(f => f.valor);
            int diasAcimaMedia = faturamentoPositivo.Count(f => f.valor > mediaMensal);

            Console.WriteLine($"Resultados a partir do arquivo {fileType}:");
            Console.WriteLine("Menor faturamento do mês: " + menorValor.ToString("F2"));
            Console.WriteLine("Maior faturamento do mês: " + maiorValor.ToString("F2"));
            Console.WriteLine("Número de dias com faturamento acima da média: " + diasAcimaMedia);
        }
    }
}
