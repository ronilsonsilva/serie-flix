using System;
using System.Linq;

namespace SerieFlix.Tests.MockData
{
    /// <summary>
    /// Serviços/Ferramentas utilitários.
    /// </summary>
    public static class Utils
    {
        private static Random random = new Random();

        /// <summary>
        /// Gerador aleatório de string.
        /// </summary>
        /// <param name="length">Tamanho da string.</param>
        /// <returns>Rertorna uma string com valor especificado.</returns>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
