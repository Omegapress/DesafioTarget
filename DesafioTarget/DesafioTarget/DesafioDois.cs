namespace DesafioDois
{
    public static class DesafioDois
    {
        public static string VerificarFibonacci(int numero)
        {
            if (numero < 0)
            {
                return "Números negativos não pertencem à sequência de Fibonacci.";
            }

            // Inicializa os dois primeiros números da sequência
            int a = 0, b = 1;
            string sequencia = $"{a}, {b}";

            // Gera a sequência até que 'a' seja maior ou igual ao número informado
            while (a < numero)
            {
                int temp = a + b;
                a = b;
                b = temp;
                sequencia += $", {a}";
            }

            if (a == numero)
            {
                return $"O número {numero} pertence à sequência de Fibonacci.\nSequência: {sequencia}";
            }
            else
            {
                return $"O número {numero} não pertence à sequência de Fibonacci.";
            }
        }
    }
}
