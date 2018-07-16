using System;
using System.Security.Cryptography;
using System.Text;

namespace MiAgenda.Linq {
    public static class StringExtensions {

        /// <summary>
        /// Verifica si la cadena está vacía.
        /// </summary>
        /// <param name="s">Cadena a verificar.</param>
        /// <returns></returns>
        public static bool IsEmpty(this string s) {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// Encripta una cadena de texto. Uso para contraseñas.
        /// </summary>
        /// <param name="s">Cadena a encriptar.</param>
        /// <returns></returns>
        public static string EncryptPassword(this string s) {
            return Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(s)));
        }
    }
}