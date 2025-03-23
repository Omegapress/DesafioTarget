using System;
using DesafioUm; // Importa o namespace onde está a classe Calculadora
using DesafioDois; // Importa o namespace onde a classe DesafioDois foi definida
using DesafioTres; // Importa o namespace onde está definida a classe DesafioTres
using DesafioQuatro; // Importa o namespace onde está a classe FaturamentoEstados
using DesafioCinco;


namespace DesafioTargetSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int desafioUm = Calculadora.CalcularSoma();

            Console.WriteLine("------ DESAFIO UM ------");
            Console.WriteLine("O valor de SOMA é: " + desafioUm);
            Console.WriteLine("------------");

            Console.WriteLine(" ");
            Console.WriteLine("------ DESAFIO DOIS ------");
            Console.Write("Informe um número para verificar se pertence à sequência de Fibonacci: ");

            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                string desafioDois = DesafioDois.DesafioDois.VerificarFibonacci(numero);
                Console.WriteLine(desafioDois);
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }

            Console.WriteLine("------------");

            Console.WriteLine(" ");
            Console.WriteLine("------ DESAFIO TRÊS ------");
            // Chama o método que processa os dados de faturamento
            Faturamento.ProcessarFaturamento();
            Console.WriteLine("------------");

            Console.WriteLine(" ");
            Console.WriteLine("------ DESAFIO QUATRO ------");
            // Chama o método para calcular os percentuais de faturamento
            FaturamentoEstados.CalcularPercentualFaturamento();
            Console.WriteLine("------------");

            Console.WriteLine(" ");
            Console.WriteLine("------ DESAFIO CINCO ------");
            Console.Write("Digite uma string para inverter: ");
            string entrada = Console.ReadLine();
            string invertida = InversorDeString.Inverter(entrada);
            Console.WriteLine($"String invertida: {invertida}");
            Console.WriteLine(" ");
        }
    }
}