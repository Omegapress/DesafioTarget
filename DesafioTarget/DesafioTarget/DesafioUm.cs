namespace DesafioUm
{
    public static class Calculadora
    {
        public static int CalcularSoma()
        {
            int INDICE = 13, SOMA = 0, K = 0;
            while (K < INDICE)
            {
                K++;
                SOMA += K;
            }
            return SOMA;
        }
    }
}
