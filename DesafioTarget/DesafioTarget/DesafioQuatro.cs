using System;

namespace DesafioQuatro
{
    public static class FaturamentoEstados
    {
        public static void CalcularPercentualFaturamento()
        {
            // Valores de faturamento por estado
            var faturamento = new (string Estado, double Valor)[]
            {
                ("SP", 67836.43),
                ("RJ", 36678.66),
                ("MG", 29229.88),
                ("ES", 27165.48),
                ("Outros", 19849.53)
            };

            // Calcula o faturamento total
            double faturamentoTotal = 0;
            foreach (var estado in faturamento)
            {
                faturamentoTotal += estado.Valor;
            }

            // Exibe os percentuais
            Console.WriteLine("Percentual de representação por estado:");
            foreach (var estado in faturamento)
            {
                double percentual = (estado.Valor / faturamentoTotal) * 100;
                Console.WriteLine($"{estado.Estado}: {percentual:F2}%");
            }
        }
    }
}
