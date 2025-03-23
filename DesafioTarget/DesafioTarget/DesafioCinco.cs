using System;

namespace DesafioCinco
{
    public static class InversorDeString
    {
        public static string Inverter(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return texto;
            }

            char[] caracteres = new char[texto.Length];
            int indiceFinal = texto.Length - 1;

            for (int i = 0; i <= indiceFinal; i++)
            {
                caracteres[i] = texto[indiceFinal - i];
            }

            return new string(caracteres);
        }
    }
}
